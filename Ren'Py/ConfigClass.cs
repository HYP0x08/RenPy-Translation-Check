using ConfigFileTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ren_Py
{
    public class ConfigClass
    {
        //是否下一局直接翻译
        public bool m_direct_translation { get; set; }
        //是否开启快捷键功能
        public bool m_EnableKeyboard { get; set; }
        //翻译类型 1 有道 2 百度
        public int m_Translation_type { get; set; }
        //快捷键储存
        public SaveKeyboard m_saveKeyboard { get; set; }
        //过滤文本列表
        public List<string> m_Filtration { get; set; }
        //文润系统
        ConfigFile config;
        public Dictionary<string, string> m_Translation_Corrnt { get; set; }
        public ConfigClass(string ConfigName)
        {
            //初次读取
            config = ConfigFile.LoadFile(ConfigName);
            if (config == null)
            {
                //不存在配置文件, 那就单独创建写入
                config = ConfigFile.LoadOrCreateFile(ConfigName);
                config.AddOrSetConfigValue("EnableKeyboard", false);
                config.AddOrSetConfigValue("direct_translation", false);
                config.AddOrSetConfigValue("Translation_type", 1);
                config.AddOrSetConfigValue("Filtration", "jpg;png;gif;jpeg;bmp;webp");
                config.AddOrSetConfigValue("Translation_Corrnt", "");
                config.AddOrSetConfigValue("Next_Keyboard", 0);
                config.AddOrSetConfigValue("Up_Keyboard", 0);
                config.AddOrSetConfigValue("Translation_Keyboard", 0);
                //config.AddOrSetConfigValue("Undo_Keyboard", 0);
                //config.AddOrSetConfigValue("Redo_Keyboard", 0);
                //初始化相对应的值
                m_EnableKeyboard = false;
                m_direct_translation = false;
                m_Translation_type = 1;
                m_saveKeyboard = new SaveKeyboard();
                m_Filtration = new List<string>() { "jpg", "png", "gif", "jpeg", "bmp", "webp"};
                m_Translation_Corrnt = new Dictionary<string, string>();
                return;
            }
            m_Filtration = new List<string>();
            m_saveKeyboard = new SaveKeyboard() {
                Next_Keyboard = config.GetConfigValueInt("Next_Keyboard"),
                Up_Keyboard = config.GetConfigValueInt("Up_Keyboard"),
                Translation_Keyboard = config.GetConfigValueInt("Translation_Keyboard"),
                //Undo_Keyboard = config.GetConfigValueInt("Undo_Keyboard"),
                //Redo_Keyboard = config.GetConfigValueInt("Redo_Keyboard")
            };
            m_Translation_Corrnt = new Dictionary<string, string>();
            m_EnableKeyboard = config.GetConfigValueBool("EnableKeyboard");
            m_direct_translation = config.GetConfigValueBool("direct_translation");
            m_Translation_type = config.GetConfigValueInt("Translation_type");
            string[] FilterStr = config.GetConfigValue("Filtration").Split(';');
            string[] TrStr = config.GetConfigValue("Translation_Corrnt").Split(';');
            //导入参数
            if (FilterStr.Length > 1)
            {
                //直接加入到集合当中
                m_Filtration.AddRange(FilterStr);
            }
            if (TrStr.Length > 1)
            {
                foreach (string TempStr in TrStr)
                {
                    string[] TempStrArr = TempStr.Split('-');
                    if (TempStrArr.Length > 1)
                        m_Translation_Corrnt.Add(TempStrArr[0], TempStrArr[1]);
                }
            }
        }
        //添加字润
        public bool AddTranslationArr(string ReplaceReq,string ReplaceResult)
        {
            if (m_Translation_Corrnt.ContainsKey(ReplaceReq))
            {
                return false;
            }
            m_Translation_Corrnt.Add(ReplaceReq, ReplaceResult);
            return true;
        }
        //字润
        public string ResultTranslation(string SouceText)
        {
            string TempStr = SouceText;
            foreach (var ReplaceText in m_Translation_Corrnt)
            {
                TempStr = TempStr.Replace(ReplaceText.Key, ReplaceText.Value);
            }
            return TempStr;
        }
        public void SaveConfig(int SaveInt, string StrSaveText = "")
        {
            switch (SaveInt)
            {
                //储存是否下一句直接翻译
                case 1:
                    config.AddOrSetConfigValue("direct_translation", m_direct_translation);
                    break;
                    //储存翻译类型 1 有道 2 百度 3 有道收费
                case 2:
                    config.AddOrSetConfigValue("Translation_type", m_Translation_type);
                    break;
                    //储存过滤文本
                case 3:
                    config.AddOrSetConfigValue("Filtration", StrSaveText);
                    break;
                    //储存翻译文本
                case 4:
                    config.AddOrSetConfigValue("Translation_Corrnt", StrSaveText);
                    break;
                    //储存快捷键
                case 5:
                    config.AddOrSetConfigValue("EnableKeyboard", m_EnableKeyboard);
                    break;
                case 6:
                    config.AddOrSetConfigValue("Next_Keyboard", m_saveKeyboard.Next_Keyboard);
                    config.AddOrSetConfigValue("Up_Keyboard", m_saveKeyboard.Up_Keyboard);
                    config.AddOrSetConfigValue("Translation_Keyboard", m_saveKeyboard.Translation_Keyboard);
                    //config.AddOrSetConfigValue("Undo_Keyboard", m_saveKeyboard.Undo_Keyboard);
                    //config.AddOrSetConfigValue("Redo_Keyboard", m_saveKeyboard.Redo_Keyboard);
                    break;
            }
        }
    }
    public class SaveKeyboard
    {
        public int Next_Keyboard { get; set; }
        public int Up_Keyboard { get; set; }
        public int Translation_Keyboard { get; set; }
        public int Undo_Keyboard { get; set; }
        public int Redo_Keyboard { get; set; }
        public SaveKeyboard()
        {
            Next_Keyboard = 0;
            Up_Keyboard = 0;
            Translation_Keyboard = 0;
            Undo_Keyboard = 0;
            Redo_Keyboard = 0;
        }
    }
}
