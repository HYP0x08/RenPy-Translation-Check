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
    public partial class Shortcut : Form
    {
        public Shortcut()
        {
            InitializeComponent();
            EnableShortcut.Checked = Main.Config.m_EnableKeyboard;
            Next_Keyboard.Text = "Ctrl + " + Encoding.Default.GetString(new byte[] { (byte)Main.Config.m_saveKeyboard.Next_Keyboard }).ToUpper();
            Up_Keyboard.Text = "Ctrl + " + Encoding.Default.GetString(new byte[] { (byte)Main.Config.m_saveKeyboard.Up_Keyboard }).ToUpper();
            Translation_Keyboard.Text = "Ctrl + " + Encoding.Default.GetString(new byte[] { (byte)Main.Config.m_saveKeyboard.Translation_Keyboard }).ToUpper();
            //Undo_Keyboard.Text = "Ctrl + " + Encoding.Default.GetString(new byte[] { (byte)Main.Config.m_saveKeyboard.Undo_Keyboard }).ToUpper();
            //Redo_Keyboard.Text = "Ctrl + " + Encoding.Default.GetString(new byte[] { (byte)Main.Config.m_saveKeyboard.Redo_Keyboard }).ToUpper();
        }
        ASCIIEncoding charToASCII = new ASCIIEncoding();
        private void EnableShortcut_CheckedChanged(object sender, EventArgs e)
        {
            //选择是否开启快捷键
            bool TempBool = EnableShortcut.Checked;
            Main.Config.m_EnableKeyboard = TempBool;
            Main.Config.SaveConfig(5);
        }
        private void keyDown(object sender, KeyEventArgs e)
        {
            StringBuilder keyValue = new StringBuilder();
            keyValue.Length = 0;
            keyValue.Append("");
            keyValue.Append("Ctrl + ");
            if ((e.KeyValue >= 33 && e.KeyValue <= 40) ||
            (e.KeyValue >= 65 && e.KeyValue <= 90) ||   //a-z/A-Z
            (e.KeyValue >= 112 && e.KeyValue <= 123))   //F1-F12
            {
                keyValue.Append(e.KeyCode);
            }
            else if ((e.KeyValue >= 48 && e.KeyValue <= 57))    //0-9
            {
                keyValue.Append(e.KeyCode.ToString().Substring(1));
            }
            this.ActiveControl.Text = "";
            //设置当前活动控件的文本内容
            this.ActiveControl.Text = keyValue.ToString();
        }
        private void keyUp(object sender, KeyEventArgs e)
        {
            string str = this.ActiveControl.Text.TrimEnd();
            int len = str.Length;
            if (len >= 1 && str.Substring(str.Length - 1) == "+")
            {
                this.ActiveControl.Text = "";
            }

        }
        private void Shortcut_Load(object sender, EventArgs e)
        {
        }
        private void Up_Keyboard_KeyUp(object sender, KeyEventArgs e)
        {
            keyUp(sender, e);
            Main.Config.m_saveKeyboard.Up_Keyboard = e.KeyValue;
        }
        private void Next_Keyboard_KeyUp(object sender, KeyEventArgs e)
        {
            keyUp(sender, e);
            Main.Config.m_saveKeyboard.Next_Keyboard = e.KeyValue;
        }
        private void Translation_Keyboard_KeyUp(object sender, KeyEventArgs e)
        {
            keyUp(sender, e);
            Main.Config.m_saveKeyboard.Translation_Keyboard = e.KeyValue;
        }
        private void Undo_Keyboard_KeyUp(object sender, KeyEventArgs e)
        {
            keyUp(sender, e);
            Main.Config.m_saveKeyboard.Undo_Keyboard = e.KeyValue;
        }
        private void Redo_Keyboard_KeyUp(object sender, KeyEventArgs e)
        {
            keyUp(sender, e);
            Main.Config.m_saveKeyboard.Redo_Keyboard = e.KeyValue;
        }
        private void Shortcut_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main.Config.SaveConfig(6);
        }
    }
}
