using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;
using Microsoft.VisualBasic;

namespace Ren_Py
{
    public partial class Main : Form
    {
        int T_Count = 0;
        string T_String = "";
        All_Variable All_SaveClass;
        public SaveUndoRedo UndoRedo = new SaveUndoRedo();
        public static ConfigClass Config = new ConfigClass("Config.xml");
        private CtlZooming _ctlZooming = new CtlZooming();
        public Main()
        {
            InitializeComponent();
        }
        private void Load_View()
        {
            UndoRedo = new SaveUndoRedo();
            All_Text.Text = String.Join("\r\n", All_SaveClass.m_ListSoucrerpy);
            T_String = All_SaveClass.m_ListSoucreText.Keys.ElementAt(T_Count);
            Text_Source.Text = T_String.Replace(All_SaveClass.m_ListSoucreText.Values.ElementAt(T_Count).ToString(), "");
            int T_StratString = All_Text.Text.IndexOf(Text_Source.Text);
            All_Text.Select(0, T_StratString);
            All_Text.ScrollToCaret();
            Load_ListView(); //Viruns Load ListView
            UpdateUndoRedo();
        }
        private void Load_ListView()
        {
            L_ViewText.Items.Clear();
            if (All_SaveClass.m_CurrentCacheItemsSource != null) { L_ViewText.RetrieveVirtualItem -= Virtual_ViewList_Load; All_SaveClass.m_CurrentCacheItemsSource.Clear(); }
            List<ListViewItem> L_WireList = new List<ListViewItem>();
            L_ViewText.VirtualListSize = All_SaveClass.m_SoucreCount; //?????
            foreach (var T_Str in All_SaveClass.m_ListSoucreText)
            {
                var L_WireText = new ListViewItem(L_WireList.Count.ToString());
                L_WireText.SubItems.Add(T_Str.Key.Replace(T_Str.Value.ToString(), ""));
                L_WireText.SubItems.Add("");
                L_WireList.Add(L_WireText);
            }
            //L_ViewText.Items.AddRange(L_WireList.ToArray());
            All_SaveClass.m_CurrentCacheItemsSource = new List<ListViewItem>(L_WireList);

            //开始加载 Virtual LiewList 提高显示效率
            L_ViewText.RetrieveVirtualItem += Virtual_ViewList_Load;
            L_ViewText.Refresh();
        }
        //载入文本至ListView
        private void Virtual_ViewList_Load(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (All_SaveClass.m_CurrentCacheItemsSource == null || All_SaveClass.m_CurrentCacheItemsSource.Count == 0)
            {
                return;
            }

            e.Item = All_SaveClass.m_CurrentCacheItemsSource[e.ItemIndex];
        }
        private void AddUndoClass(List<string> SaveSouceTran, List<ListViewItem> CurrentCacheItemsSource, int Count_T)
        {
            UndoRedo.Add(SaveSouceTran, CurrentCacheItemsSource, Count_T);
            UpdateUndoRedo();
        }
        private void B_Up_Click(object sender, EventArgs e)
        {
            if (Text_Source.Text != "")
            {
                if (T_Count > 0)
                {
                    string T_TextSource = Text_Source.Text;
                    int T_Texthead = All_SaveClass.m_ListSoucreText.Values.ElementAt(T_Count);
                    if (!All_SaveClass.m_ListTrunsrpy.Contains(Text_Truns.Text) && Text_Truns.Text != "")
                    {
                        //估计过几天我就看不懂了
                        //操你妈,这个看起来真复杂
                        //Virtual LiewList 写入事件
                        //L_ViewText.RetrieveVirtualItem += Wre_ViewList_Load;
                        AddUndoClass(new List<string>(All_SaveClass.m_ListTrunsrpy), UpdateOutListView(All_SaveClass.m_CurrentCacheItemsSource), T_Count);
                        string T_ReadTrnsText = All_SaveClass.m_CurrentCacheItemsSource[T_Count].SubItems[2].Text;
                        if (T_ReadTrnsText != "")
                        {
                            //查找并更改 ListView
                            All_SaveClass.m_CurrentCacheItemsSource[T_Count].SubItems[2].Text = Text_Truns.Text;
                            //查找并替换 更改后的
                            All_SaveClass.m_ListTrunsrpy[T_Texthead] = All_SaveClass.m_ListTrunsrpy[T_Texthead].Replace(T_ReadTrnsText, Text_Truns.Text);
                        }
                        else
                        {
                            //查找并更改 ListView
                            All_SaveClass.m_CurrentCacheItemsSource[T_Count].SubItems[2].Text = Text_Truns.Text;
                            //查找并替换 更改前的
                            All_SaveClass.m_ListTrunsrpy[T_Texthead] = All_SaveClass.m_ListTrunsrpy[T_Texthead].Replace(T_TextSource, Text_Truns.Text);
                        }
                        Text_Truns.Text = "";
                        L_ViewText.Refresh();
                    }
                    T_Count--;
                    All_Text.Text = String.Join("\r\n", All_SaveClass.m_ListTrunsrpy);
                    Text_Source.Text = All_SaveClass.m_ListSoucreText.Keys.ElementAt(T_Count).Replace(All_SaveClass.m_ListSoucreText.Values.ElementAt(T_Count).ToString(), "");
                    string TempStr = All_SaveClass.m_CurrentCacheItemsSource.First(x => x.SubItems[1].Text == Text_Source.Text).SubItems[2].Text;
                    if (TempStr != "") { Text_Truns.Text = TempStr; }
                    if (Config.m_direct_translation) { Text_Truns.Text = Tools_Class.Web_Translate(Config.m_Translation_type, Text_Source.Text); }
                    int T_StratString = All_Text.Text.IndexOf(Text_Source.Text);
                    if (Text_Truns.Text != "") { T_StratString = All_Text.Text.IndexOf(Text_Truns.Text); }
                    All_Text.Select(0, T_StratString);
                    All_Text.ScrollToCaret();
                }
            }
        }
        private void B_Next_Click(object sender, EventArgs e)
        {
            if (Text_Source.Text != "")
            {
                if (T_Count != All_SaveClass.m_SoucreCount - 1)
                {
                    string T_TextSource = Text_Source.Text;
                    int T_Texthead = All_SaveClass.m_ListSoucreText.Values.ElementAt(T_Count);
                    if (!All_SaveClass.m_ListTrunsrpy.Contains(Text_Truns.Text) && Text_Truns.Text != "")
                    {
                        //估计过几天我就看不懂了
                        //操你妈,这个看起来真复杂
                        //Virtual LiewList 写入事件
                        //L_ViewText.RetrieveVirtualItem += Wre_ViewList_Load;
                        AddUndoClass(new List<string>(All_SaveClass.m_ListTrunsrpy), UpdateOutListView(All_SaveClass.m_CurrentCacheItemsSource), T_Count);
                        string T_ReadTrnsText = All_SaveClass.m_CurrentCacheItemsSource[T_Count].SubItems[2].Text;
                        if (T_ReadTrnsText != "")
                        {
                            //查找并更改 ListView
                            All_SaveClass.m_CurrentCacheItemsSource[T_Count].SubItems[2].Text = Text_Truns.Text;
                            //查找并替换 更改后的
                            All_SaveClass.m_ListTrunsrpy[T_Texthead] = All_SaveClass.m_ListTrunsrpy[T_Texthead].Replace(T_ReadTrnsText, Text_Truns.Text);
                        }
                        else
                        {
                            //查找并更改 ListView
                            All_SaveClass.m_CurrentCacheItemsSource[T_Count].SubItems[2].Text = Text_Truns.Text;
                            //查找并替换 更改前的
                            All_SaveClass.m_ListTrunsrpy[T_Texthead] = All_SaveClass.m_ListTrunsrpy[T_Texthead].Replace(T_TextSource, Text_Truns.Text);
                        }
                        Text_Truns.Text = "";
                        L_ViewText.Refresh();
                    }
                    T_Count++;
                    All_Text.Text = String.Join("\r\n", All_SaveClass.m_ListTrunsrpy);
                    Text_Source.Text = All_SaveClass.m_ListSoucreText.Keys.ElementAt(T_Count).Replace(All_SaveClass.m_ListSoucreText.Values.ElementAt(T_Count).ToString(), "");
                    string TempStr = All_SaveClass.m_CurrentCacheItemsSource[T_Count].SubItems[2].Text;
                    if (TempStr != "") { Text_Truns.Text = TempStr; }
                    if (Config.m_direct_translation) { Text_Truns.Text = Tools_Class.Web_Translate(Config.m_Translation_type, Text_Source.Text); }
                    int T_StratString = All_Text.Text.IndexOf(Text_Source.Text);
                    if (Text_Truns.Text != "") { T_StratString = All_Text.Text.IndexOf(Text_Truns.Text); }
                    All_Text.Select(0, T_StratString);
                    All_Text.ScrollToCaret();
                }
            }
        }
        private void TraceText(string T_TextSource, string Text, int m_Count)
        {
            int T_Texthead = All_SaveClass.m_ListSoucreText.Values.ElementAt(m_Count);
            if (m_Count != All_SaveClass.m_SoucreCount - 1)
            {
                //估计过几天我就看不懂了
                //操你妈,这个看起来真复杂
                //Virtual LiewList 写入事件
                //L_ViewText.RetrieveVirtualItem += Wre_ViewList_Load;
                string T_ReadTrnsText = All_SaveClass.m_CurrentCacheItemsSource[m_Count].SubItems[2].Text;
                if (T_ReadTrnsText != "")
                {
                    //查找并更改 ListView
                    All_SaveClass.m_CurrentCacheItemsSource[m_Count].SubItems[2].Text = Text;
                    //查找并替换 更改后的
                    All_SaveClass.m_ListTrunsrpy[T_Texthead] = All_SaveClass.m_ListTrunsrpy[T_Texthead].Replace(T_ReadTrnsText, Text);
                }
                else
                {
                    //查找并更改 ListView
                    All_SaveClass.m_CurrentCacheItemsSource[m_Count].SubItems[2].Text = Text;
                    //查找并替换 更改前的
                    All_SaveClass.m_ListTrunsrpy[T_Texthead] = All_SaveClass.m_ListTrunsrpy[T_Texthead].Replace(T_TextSource, Text);
                }
                L_ViewText.Refresh();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _ctlZooming.SetXY(Width, Height); //设置宽度和高度初始值
            _ctlZooming.InitTag(this); //调用初始化标签值的函数
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            _ctlZooming.Resize(Width / (_ctlZooming.X), Height / _ctlZooming.Y, this);//随窗体改变控件大小
        }
        private void ReadText_Click(object sender, EventArgs e)
        {
            //打开选择框,选择文本
            var Read_Dialog = new OpenFileDialog();
            Read_Dialog.Title = "请选择Rpy文件进行翻译";
            Read_Dialog.Filter = "Ran'Py源码|*.rpy";
            if (Read_Dialog.ShowDialog() != DialogResult.OK || !Read_Dialog.FileName.Contains(".rpy"))
            {
                MessageBox.Show("请选择正确的文件!", "错误");
                return;
            }
            //开始初始化导入
            string[] T_ReadText = File.ReadAllLines(Read_Dialog.FileName);
            All_SaveClass = new All_Variable(Read_Dialog.FileName, T_ReadText);
            if (All_SaveClass.m_SoucreCount == 0)
            {
                MessageBox.Show("没有检测到任何文本!", "错误");
                return;
            }
            T_Count = 0;
            Text = "Ren'Py 翻译软件 V2.0";
            Text += "  当前打开文件名:" + Path.GetFileName(All_SaveClass.m_Path);
            Text += "  总文本数:" + All_SaveClass.m_SoucreCount;
            //开始载入进图形中
            Load_View();
        }
        private void SaveText_Click(object sender, EventArgs e)
        {
            if (Text_Source.Text != "")
            {
                SaveFileDialog Save_File = new SaveFileDialog();

                Save_File.Title = "请输入Rpy文件名称进行保存";
                Save_File.Filter = "Ran'Py源码|*.rpy";
                if (Save_File.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show("请选择正确的文件!", "错误");
                    return;
                }

                File.WriteAllLines(Save_File.FileName, All_SaveClass.m_ListTrunsrpy);
                MessageBox.Show("保存成功!");
            }
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult TS = MessageBox.Show("确认要退出吗？要确认已经保存了哦。", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (TS == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
        private void B_TowForOneTrace_Click(object sender, EventArgs e)
        {
            if (Text_Source.Text != "")
            {
                Text_Truns.Text = Tools_Class.Web_Translate(Config.m_Translation_type, Text_Source.Text);
            }
        }
        private void B_Trace_Click(object sender, EventArgs e)
        {
            if (NextTrace.Text != "" && Text_Source.Text != "")
            {
                int TempCount = T_Count;
                int NextInt = int.Parse(NextTrace.Text);
                DialogResult TS = MessageBox.Show("你确定要一键翻译[" + NextInt.ToString() + "]行吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (TS == DialogResult.Yes)
                {
                    AddUndoClass(new List<string>(All_SaveClass.m_ListTrunsrpy), UpdateOutListView(All_SaveClass.m_CurrentCacheItemsSource), T_Count);
                    for (int i = 1; i < NextInt; i++)
                    {
                        string ReadText = All_SaveClass.m_ListSoucreText.Keys.ElementAt(TempCount).Replace(All_SaveClass.m_ListSoucreText.Values.ElementAt(TempCount).ToString(), "");
                        if (TempCount != All_SaveClass.m_SoucreCount - 1)
                        {
                            string TrText = Tools_Class.Web_Translate(Config.m_Translation_type, ReadText);
                            TraceText(ReadText, TrText, TempCount);
                            T_Count++;
                        }
                        TempCount++;
                    }
                    L_ViewText.Refresh();
                    All_Text.Text = String.Join("\r\n", All_SaveClass.m_ListTrunsrpy);
                    Text_Source.Text = All_SaveClass.m_ListSoucreText.Keys.ElementAt(T_Count).Replace(All_SaveClass.m_ListSoucreText.Values.ElementAt(T_Count).ToString(), "");
                    int T_StratString = All_Text.Text.IndexOf(Text_Source.Text);
                    if (T_StratString < 0)
                    {
                        All_Text.Select(0, T_StratString);
                        All_Text.ScrollToCaret();
                    }
                }
            }
        }
        //撤回or回复事件
        private void NextTrace_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void ExitRenPy_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void L_ViewText_DoubleClick(object sender, EventArgs e)
        {
            int TempColumn = L_ViewText.SelectedIndices[0];
            if (TempColumn != -1)
            {
                int T_StratString;
                Text_Truns.Text = "";
                Text_Source.Text = All_SaveClass.m_ListSoucreText.Keys.ElementAt(TempColumn).Replace(All_SaveClass.m_ListSoucreText.Values.ElementAt(TempColumn).ToString(), "");
                string TempStr = All_SaveClass.m_CurrentCacheItemsSource.First(x => x.SubItems[1].Text == Text_Source.Text).SubItems[2].Text;
                if (TempStr != "")
                { T_StratString = All_Text.Text.IndexOf(TempStr); Text_Truns.Text = TempStr; }
                else
                { T_StratString = All_Text.Text.IndexOf(Text_Source.Text); }
                All_Text.Select(0, T_StratString);
                All_Text.ScrollToCaret();
                T_Count = TempColumn;
            }
        }
        private void Alltranslate_Click(object sender, EventArgs e)
        {
            if (Text_Source.Text != "")
            {
                DialogResult TS = MessageBox.Show("你确定要一键翻译吗？可能会带来巨大量的翻译错误！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (TS == DialogResult.Yes)
                {
                    DialogResult TS1 = MessageBox.Show("再次确定，是否要一键翻译？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (TS1 == DialogResult.Yes)
                    {
                        int m_Count = 0;
                        var Items = All_SaveClass.m_CurrentCacheItemsSource;
                        AddUndoClass(new List<string>(All_SaveClass.m_ListTrunsrpy), UpdateOutListView(Items), T_Count);
                        foreach (var Item in Items)
                        {
                            if (Item.SubItems[2].Text == "")
                            {
                                string SouceText = Item.SubItems[1].Text;
                                int T_Texthead = All_SaveClass.m_ListSoucreText.Values.ElementAt(m_Count);
                                string TrStr = Tools_Class.Web_Translate(Config.m_Translation_type, SouceText);
                                Item.SubItems[2].Text = TrStr;
                                //替换上翻译文本
                                All_SaveClass.m_ListTrunsrpy[T_Texthead] = All_SaveClass.m_ListTrunsrpy[T_Texthead].Replace(SouceText, TrStr);
                            }
                            m_Count++;
                        }
                        All_Text.Text = String.Join("\r\n", All_SaveClass.m_ListTrunsrpy);
                        MessageBox.Show("自动翻译完成。。。。太恐怖了", "提示");
                    }
                }
            }
        }
        private void FindSource_Click(object sender, EventArgs e)
        {
            if (Text_Source.Text != "")
            {
                string Str = Interaction.InputBox("请输入要查找的原文本", "原文本查找");
                if (Str != "")
                {
                    try
                    {
                        for (int i = T_Count; i < L_ViewText.Items.Count; i++)
                        {
                            var TempList = L_ViewText.Items[i];
                            if (TempList.SubItems[1].Text.Contains(Str))
                            {
                                int T_StratString;
                                Text_Source.Text = TempList.SubItems[1].Text;
                                Text_Truns.Text = TempList.SubItems[2].Text;
                                L_ViewText.Items[i].Selected = true;//选中行
                                L_ViewText.EnsureVisible(i);//滚动到指定的行位置
                                if (Text_Truns.Text != "")
                                { T_StratString = All_Text.Text.IndexOf(Text_Truns.Text); }
                                else
                                { T_StratString = All_Text.Text.IndexOf(Text_Source.Text); }
                                All_Text.Select(0, T_StratString);
                                All_Text.ScrollToCaret();
                                T_Count = i;
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误");
                    }
                }
            }
        }
        private void FindTranslate_Click(object sender, EventArgs e)
        {
            if (Text_Source.Text != "")
            {
                string Str = Interaction.InputBox("请输入要查找的翻译文本", "翻译文本查找");
                if (Str != "")
                {
                    try
                    {
                        for (int i = T_Count; i < L_ViewText.Items.Count; i++)
                        {
                            var TempList = L_ViewText.Items[i];
                            if (TempList.SubItems[2].Text.Contains(Str))
                            {
                                int T_StratString;
                                Text_Source.Text = TempList.SubItems[1].Text;
                                Text_Truns.Text = TempList.SubItems[2].Text;
                                L_ViewText.Items[i].Selected = true;//选中行
                                L_ViewText.EnsureVisible(i);//滚动到指定的行位置
                                if (Text_Truns.Text != "")
                                { T_StratString = All_Text.Text.IndexOf(Text_Truns.Text); }
                                else
                                { T_StratString = All_Text.Text.IndexOf(Text_Source.Text); }
                                All_Text.Select(0, T_StratString);
                                All_Text.ScrollToCaret();
                                T_Count = i;
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误");
                    }
                }
            }
        }
        private void KeywordFilter_Click(object sender, EventArgs e)
        {
            Filtering filtering = new Filtering();
            filtering.ShowDialog();
            /*string Str = Interaction.InputBox("请在原有的基础修改或加入过滤的关键字", "关键字过滤添加", TempOutFilterText);
            if (Str != "")
            {
                DialogResult TS = MessageBox.Show("请确定是否修改？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (TS == DialogResult.Yes)
                {
                    Config.m_Filtration = new List<string>(Str.Split(';'));
                    Config.SaveConfig(3, Str);
                    MessageBox.Show("修改成功！", "提示");
                }
            }*/
        }
        private void SetTrIndex_Click(object sender, EventArgs e)
        {
            string Str = Interaction.InputBox("1 有道翻译免费 2 百度翻译 3 有道翻译收费 如果输错默认有道翻译免费", "设置翻译语言", Config.m_Translation_type.ToString());
            if (Str != "")
            {
                DialogResult TS = MessageBox.Show("请确定是否修改？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (TS == DialogResult.Yes)
                {
                    Config.m_Translation_type = int.Parse(Str);
                    Config.SaveConfig(2);
                    MessageBox.Show("修改成功！", "提示");
                }
            }
        }
        private void SetTranslateRelText_Click(object sender, EventArgs e)
        {
            Translateing translateing = new Translateing();
            translateing.ShowDialog();
            /*string TempStr = "";
            foreach (var SaveList in Config.m_Translation_Corrnt)
            {
                TempStr += SaveList.Key + "-" + SaveList.Value + ";";
            }
            if (TempStr != "")
            {
                TempStr = TempStr.Substring(0, TempStr.Length - 1);
            }
            string Str = Interaction.InputBox("设置文润的方法【旧文本】-【新文本】如果要继续加，就加上分号", "设置翻译文润", TempStr);
            if (Str != "")
            {
                DialogResult TS = MessageBox.Show("请确定是否修改？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (TS == DialogResult.Yes)
                {
                    Config.m_Translation_Corrnt = new Dictionary<string, string>();
                    foreach (string TempStrText in Str.Split(';'))
                    {
                        string[] TempStrArr = TempStrText.Split('-');
                        if (TempStrArr.Length > 1)
                            Config.m_Translation_Corrnt.Add(TempStrArr[0], TempStrArr[1]);
                    }
                    Config.SaveConfig(4, Str);
                    MessageBox.Show("修改成功！", "提示");
                }
            }*/
        }
        private void SetOpenNextTr_Click(object sender, EventArgs e)
        {
            if (Config.m_direct_translation)
            {
                Config.m_direct_translation = false;
                MessageBox.Show("设置成功,已经关闭下一句翻译");
            }
            else
            {
                Config.m_direct_translation = true;
                MessageBox.Show("设置成功,已经开启下一句翻译");
            }
            Config.SaveConfig(1);
        }
        private void Undo_Click(object sender, EventArgs e)
        {
            //先解绑, 不然会报错
            L_ViewText.RetrieveVirtualItem -= Virtual_ViewList_Load;
            var Temp = UndoRedo.Undo(new List<string>(All_SaveClass.m_ListTrunsrpy), UpdateOutListView(All_SaveClass.m_CurrentCacheItemsSource), T_Count);
            T_Count = Temp.m_Count_T;
            All_SaveClass.m_ListTrunsrpy = new List<string>(Temp.m_SaveSouceTran);
            All_SaveClass.m_CurrentCacheItemsSource = new List<ListViewItem>(Temp.m_CurrentCacheItemsSource);
            //再重新绑定上并刷新
            L_ViewText.RetrieveVirtualItem += Virtual_ViewList_Load;
            UpdateUndoRedo();
            UpdateGui();
        }
        private void Redo_Click(object sender, EventArgs e)
        {
            //先解绑, 不然会报错
            L_ViewText.RetrieveVirtualItem -= Virtual_ViewList_Load;
            var Temp = UndoRedo.Redo(new List<string>(All_SaveClass.m_ListTrunsrpy), UpdateOutListView(All_SaveClass.m_CurrentCacheItemsSource), T_Count);
            T_Count = Temp.m_Count_T;
            All_SaveClass.m_ListTrunsrpy = new List<string>(Temp.m_SaveSouceTran);
            All_SaveClass.m_CurrentCacheItemsSource = new List<ListViewItem>(Temp.m_CurrentCacheItemsSource);
            //再重新绑定上并刷新
            L_ViewText.RetrieveVirtualItem += Virtual_ViewList_Load;
            UpdateUndoRedo();
            UpdateGui();

        }
        private List<ListViewItem> UpdateOutListView(List<ListViewItem> Temp)
        {
            List<ListViewItem> L_WireList = new List<ListViewItem>();
            foreach (var T_Str in Temp)
            {
                var L_WireText = new ListViewItem(L_WireList.Count.ToString());
                L_WireText.SubItems.Add(T_Str.SubItems[1].Text);
                L_WireText.SubItems.Add(T_Str.SubItems[2].Text);
                L_WireList.Add(L_WireText);
            }
            return new List<ListViewItem>(L_WireList);
        }
        private void UpdateGui()
        {
            int T_StratString;
            L_ViewText.Refresh();
            All_Text.Text = String.Join("\r\n", All_SaveClass.m_ListTrunsrpy);
            Text_Source.Text = All_SaveClass.m_ListSoucreText.Keys.ElementAt(T_Count).Replace(All_SaveClass.m_ListSoucreText.Values.ElementAt(T_Count).ToString(), "");
            if (Text_Truns.Text != "")
            { T_StratString = All_Text.Text.IndexOf(Text_Truns.Text); }
            else
            { T_StratString = All_Text.Text.IndexOf(Text_Source.Text); }
            All_Text.Select(0, T_StratString);
            All_Text.ScrollToCaret();
        }
        private void UpdateUndoRedo()
        {
            Undo.Enabled = UndoRedo.UndoStaus;
            Redo.Enabled = UndoRedo.RedoStaus;
        }
        private void SetShortcutKey_Click(object sender, EventArgs e)
        {
            Shortcut shortcut = new Shortcut();
            shortcut.ShowDialog();
        }
        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (Config.m_EnableKeyboard) {
                if (e.KeyValue == Config.m_saveKeyboard.Next_Keyboard && e.Modifiers == Keys.Control)
                    B_Next.PerformClick();
                if (e.KeyValue == Config.m_saveKeyboard.Up_Keyboard && e.Modifiers == Keys.Control)
                    B_Up.PerformClick();
                if (e.KeyValue == Config.m_saveKeyboard.Translation_Keyboard && e.Modifiers == Keys.Control)
                    B_TowForOneTrace.PerformClick();
                /*if (e.KeyValue == Config.m_saveKeyboard.Undo_Keyboard && e.Modifiers == Keys.Control)
                    Console.WriteLine(Undo.Enabled);
                    if (Undo.Enabled)
                    {
                        Undo.PerformClick();
                    }
                if (e.KeyValue == Config.m_saveKeyboard.Redo_Keyboard && e.Modifiers == Keys.Con                                                                                                                                l)
                    Console.WriteLine(Redo.Enabled);
                    if (Redo.Enabled)
                    {
                        Redo.PerformClick();
                    }*/
            }
        }
        private void CheckRel_Click(object sender, EventArgs e)
        {
            if (Text_Source.Text != "" && Text_Truns.Text != "")
            {
                DialogResult TS = MessageBox.Show("请确定一键替换译文？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (TS == DialogResult.Yes)
                {
                    string RelText = Text_Source.Text;
                    string RelTran = Text_Truns.Text;
                    AddUndoClass(new List<string>(All_SaveClass.m_ListTrunsrpy), UpdateOutListView(All_SaveClass.m_CurrentCacheItemsSource), T_Count);
                    for (int i = 0;i < All_SaveClass.m_ListTrunsrpy.Count;i++)
                    {
                        if (All_SaveClass.m_ListTrunsrpy[i] == RelText)
                            TraceText(RelText, RelTran, i);
                    }
                    All_Text.Text = String.Join("\r\n", All_SaveClass.m_ListTrunsrpy);
                    MessageBox.Show("替换完成！","系统提示");
                }
            }
        }
    }
}
