namespace Ren_Py
{
    partial class Shortcut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EnableShortcut = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Up_Keyboard = new System.Windows.Forms.TextBox();
            this.Next_Keyboard = new System.Windows.Forms.TextBox();
            this.Translation_Keyboard = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // EnableShortcut
            // 
            this.EnableShortcut.AutoSize = true;
            this.EnableShortcut.Location = new System.Drawing.Point(12, 12);
            this.EnableShortcut.Name = "EnableShortcut";
            this.EnableShortcut.Size = new System.Drawing.Size(132, 16);
            this.EnableShortcut.TabIndex = 1;
            this.EnableShortcut.Text = "是否启用快捷键功能";
            this.EnableShortcut.UseVisualStyleBackColor = true;
            this.EnableShortcut.CheckedChanged += new System.EventHandler(this.EnableShortcut_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "上一句快捷键：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "下一句快捷键：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "翻译快捷键：";
            // 
            // Up_Keyboard
            // 
            this.Up_Keyboard.Location = new System.Drawing.Point(94, 41);
            this.Up_Keyboard.MaxLength = 100;
            this.Up_Keyboard.Name = "Up_Keyboard";
            this.Up_Keyboard.ReadOnly = true;
            this.Up_Keyboard.Size = new System.Drawing.Size(100, 21);
            this.Up_Keyboard.TabIndex = 7;
            this.Up_Keyboard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.Up_Keyboard.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Up_Keyboard_KeyUp);
            // 
            // Next_Keyboard
            // 
            this.Next_Keyboard.Location = new System.Drawing.Point(94, 70);
            this.Next_Keyboard.MaxLength = 100;
            this.Next_Keyboard.Name = "Next_Keyboard";
            this.Next_Keyboard.ReadOnly = true;
            this.Next_Keyboard.Size = new System.Drawing.Size(100, 21);
            this.Next_Keyboard.TabIndex = 8;
            this.Next_Keyboard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.Next_Keyboard.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Next_Keyboard_KeyUp);
            // 
            // Translation_Keyboard
            // 
            this.Translation_Keyboard.Location = new System.Drawing.Point(93, 97);
            this.Translation_Keyboard.MaxLength = 100;
            this.Translation_Keyboard.Name = "Translation_Keyboard";
            this.Translation_Keyboard.ReadOnly = true;
            this.Translation_Keyboard.Size = new System.Drawing.Size(101, 21);
            this.Translation_Keyboard.TabIndex = 9;
            this.Translation_Keyboard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.Translation_Keyboard.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Translation_Keyboard_KeyUp);
            // 
            // Shortcut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 127);
            this.Controls.Add(this.Translation_Keyboard);
            this.Controls.Add(this.Next_Keyboard);
            this.Controls.Add(this.Up_Keyboard);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnableShortcut);
            this.MaximizeBox = false;
            this.Name = "Shortcut";
            this.Text = "快捷键设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Shortcut_FormClosing);
            this.Load += new System.EventHandler(this.Shortcut_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox EnableShortcut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Up_Keyboard;
        private System.Windows.Forms.TextBox Next_Keyboard;
        private System.Windows.Forms.TextBox Translation_Keyboard;
    }
}