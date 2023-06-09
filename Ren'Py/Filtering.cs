using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ren_Py
{
    public partial class Filtering : Form
    {
        public Filtering()
        {
            InitializeComponent();
        }
        private void Filtering_Load(object sender, EventArgs e)
        {
            var TempList = Main.Config.m_Filtration;
            foreach (string FilterText in TempList)
            {
                FilterShow.Items.Add(FilterText);
            }
        }
        private void DelFilterText_Click(object sender, EventArgs e)
        {
            DialogResult TS = MessageBox.Show("请确定是否删除该关键字？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (TS == DialogResult.Yes)
            {
                int Index = FilterShow.SelectedIndex;
                FilterShow.Items.RemoveAt(Index);
            }
        }
        private void AddFilterText_Click(object sender, EventArgs e)
        {
            if (WiterFilter.Text != "")
            {
                FilterShow.Items.Add(WiterFilter.Text);
                WiterFilter.Text = "";
            }
        }
        private void Filtering_FormClosing(object sender, FormClosingEventArgs e)
        {
            string OutFilterText = "";
            List<string> TempFilterList = new List<string>();
            foreach (var TempFilter in FilterShow.Items)
            {
                string TempStr = TempFilter.ToString();
                if (!TempFilterList.Contains(TempStr))
                {
                    TempFilterList.Add(TempStr);
                    OutFilterText += TempStr + ";";
                }
            }
            if (TempFilterList.Count > 1)
            {
                OutFilterText = OutFilterText.Substring(0, OutFilterText.Length - 1);
            }
            Main.Config.m_Filtration = new List<string>(TempFilterList);
            Main.Config.SaveConfig(3, OutFilterText);
        }
    }
}
