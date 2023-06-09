using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Windows.Forms;

namespace Ren_Py
{
    public class All_Variable
    {
        public string m_Path { get; set; }
        public Dictionary<string, int> m_ListSoucreText { get; set; }
        public List<string> m_ListSoucrerpy { get; set; }
        public List<string> m_ListTrunsrpy { get; set; }
        public List<ListViewItem> m_CurrentCacheItemsSource { get; set; }
        public int m_SoucreCount { get; set; }

        //初始化
        public All_Variable(string Path, string[] ListSoucreText)
        {
            m_Path = Path;
            m_ListSoucrerpy = new List<string>(ListSoucreText);
            m_ListTrunsrpy = new List<string>(ListSoucreText);
            m_SoucreCount = Read_Soucre_Count();
        }
        //初始化文本数量
        private int Read_Soucre_Count()
        {
            int T_TextInt = 0;
            var T_ListText = new Dictionary<string, int>();
            foreach (string T_Str in m_ListSoucrerpy)
            {
                //第一次过滤
                if (T_Str.Contains("\"") && !T_Str.Contains("#"))
                {
                    //二次过滤
                    string T_Str2 = Tools_Class.MidStrEx(T_Str, "\"", "\"");
                    if (!T_Str2.Contains("#") && !T_Str2.Contains("_") && T_Str2.Length >= 1 && !T_Str2.Contains("\t"))
                    {
                        //自定义过滤
                        int i = 0;
                        foreach (string TempStr in Main.Config.m_Filtration)
                        {
                            if (!T_Str2.Contains(TempStr))
                            {
                                i++;
                            }
                        }
                        //结果判断输出
                        if (i == Main.Config.m_Filtration.Count)
                        {
                            T_ListText.Add(T_TextInt.ToString() + T_Str2, T_TextInt);
                            Console.WriteLine(T_Str2);
                        }
                    }
                }
                T_TextInt++;
            }
            m_ListSoucreText = new Dictionary<string, int>(T_ListText);
            return m_ListSoucreText.Count;

        }
    }
}
