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
    public partial class Translateing : Form
    {
        public Translateing()
        {
            InitializeComponent();
        }
        private void Translateing_Load(object sender, EventArgs e)
        {
            var TempTransCorrnt = Main.Config.m_Translation_Corrnt;
            foreach (var TempList in TempTransCorrnt)
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(ReplaceDataGrid);
                newRow.Cells[0].Value = TempList.Key;
                newRow.Cells[1].Value = TempList.Value;
                ReplaceDataGrid.Rows.Add(newRow);
            }
        }
        private void Translateing_FormClosing(object sender, FormClosingEventArgs e)
        {
            string OutTransCorrnt = "";
            Dictionary<string, string> OutTempTrans = new Dictionary<string, string>();
            for (int i = 0; i < (ReplaceDataGrid.Rows.Count - 1); i++)
            {
                if (ReplaceDataGrid.Rows[i].Cells[0].Value != null)
                {
                    string OldReplace = ReplaceDataGrid.Rows[i].Cells[0].Value.ToString();
                    string NewReplace = ReplaceDataGrid.Rows[i].Cells[1].Value != null ? ReplaceDataGrid.Rows[i].Cells[1].Value.ToString() : "" ;
                    if (!OutTempTrans.ContainsKey(OldReplace))
                    {
                        OutTempTrans.Add(OldReplace, NewReplace);
                        OutTransCorrnt += OldReplace + "-" + NewReplace + ";";
                    }
                }
            }
            if (OutTempTrans.Count > 1)
            {
                OutTransCorrnt = OutTransCorrnt.Substring(0, OutTransCorrnt.Length - 1);
            }
            Main.Config.m_Translation_Corrnt = new Dictionary<string, string>(OutTempTrans);
            Main.Config.SaveConfig(4, OutTransCorrnt);
        }
    }
}
