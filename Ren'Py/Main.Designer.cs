namespace Ren_Py
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Text_Source = new System.Windows.Forms.TextBox();
            this.All_Text = new System.Windows.Forms.TextBox();
            this.B_Up = new System.Windows.Forms.Button();
            this.B_Next = new System.Windows.Forms.Button();
            this.B_Trace = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.L_ViewText = new System.Windows.Forms.ListView();
            this.ColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Text_Truns = new System.Windows.Forms.TextBox();
            this.Topmemu = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReadText = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveText = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitRenPy = new System.Windows.Forms.ToolStripMenuItem();
            this.翻译ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindTextList = new System.Windows.Forms.ToolStripMenuItem();
            this.FindSource = new System.Windows.Forms.ToolStripMenuItem();
            this.FindTranslate = new System.Windows.Forms.ToolStripMenuItem();
            this.SetTranslateRelText = new System.Windows.Forms.ToolStripMenuItem();
            this.KeywordFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.Alltranslate = new System.Windows.Forms.ToolStripMenuItem();
            this.SetTrIndex = new System.Windows.Forms.ToolStripMenuItem();
            this.SetOpenNextTr = new System.Windows.Forms.ToolStripMenuItem();
            this.SetShortcutKey = new System.Windows.Forms.ToolStripMenuItem();
            this.NextTrace = new System.Windows.Forms.TextBox();
            this.B_TowForOneTrace = new System.Windows.Forms.Button();
            this.Redo = new System.Windows.Forms.Button();
            this.Undo = new System.Windows.Forms.Button();
            this.CheckRel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.Topmemu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Text_Source
            // 
            this.Text_Source.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Text_Source.Location = new System.Drawing.Point(3, 34);
            this.Text_Source.Name = "Text_Source";
            this.Text_Source.ReadOnly = true;
            this.Text_Source.Size = new System.Drawing.Size(812, 26);
            this.Text_Source.TabIndex = 3;
            // 
            // All_Text
            // 
            this.All_Text.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.All_Text.Location = new System.Drawing.Point(3, 131);
            this.All_Text.Multiline = true;
            this.All_Text.Name = "All_Text";
            this.All_Text.ReadOnly = true;
            this.All_Text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.All_Text.Size = new System.Drawing.Size(812, 307);
            this.All_Text.TabIndex = 6;
            // 
            // B_Up
            // 
            this.B_Up.Location = new System.Drawing.Point(3, 97);
            this.B_Up.Name = "B_Up";
            this.B_Up.Size = new System.Drawing.Size(173, 27);
            this.B_Up.TabIndex = 8;
            this.B_Up.Text = "上一句";
            this.B_Up.UseVisualStyleBackColor = true;
            this.B_Up.Click += new System.EventHandler(this.B_Up_Click);
            // 
            // B_Next
            // 
            this.B_Next.Location = new System.Drawing.Point(182, 97);
            this.B_Next.Name = "B_Next";
            this.B_Next.Size = new System.Drawing.Size(177, 27);
            this.B_Next.TabIndex = 9;
            this.B_Next.Text = "下一句";
            this.B_Next.UseVisualStyleBackColor = true;
            this.B_Next.Click += new System.EventHandler(this.B_Next_Click);
            // 
            // B_Trace
            // 
            this.B_Trace.Location = new System.Drawing.Point(561, 97);
            this.B_Trace.Name = "B_Trace";
            this.B_Trace.Size = new System.Drawing.Size(62, 27);
            this.B_Trace.TabIndex = 13;
            this.B_Trace.Text = "翻译N句";
            this.B_Trace.UseVisualStyleBackColor = true;
            this.B_Trace.Click += new System.EventHandler(this.B_Trace_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.L_ViewText);
            this.groupBox1.Location = new System.Drawing.Point(3, 444);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(812, 423);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文本校对";
            // 
            // L_ViewText
            // 
            this.L_ViewText.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader,
            this.columnHeader1,
            this.columnHeader2});
            this.L_ViewText.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.L_ViewText.FullRowSelect = true;
            this.L_ViewText.GridLines = true;
            this.L_ViewText.HideSelection = false;
            this.L_ViewText.Location = new System.Drawing.Point(6, 20);
            this.L_ViewText.MultiSelect = false;
            this.L_ViewText.Name = "L_ViewText";
            this.L_ViewText.Size = new System.Drawing.Size(800, 397);
            this.L_ViewText.TabIndex = 0;
            this.L_ViewText.UseCompatibleStateImageBehavior = false;
            this.L_ViewText.View = System.Windows.Forms.View.Details;
            this.L_ViewText.VirtualMode = true;
            this.L_ViewText.DoubleClick += new System.EventHandler(this.L_ViewText_DoubleClick);
            // 
            // ColumnHeader
            // 
            this.ColumnHeader.Text = "行号";
            this.ColumnHeader.Width = 70;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "原文本";
            this.columnHeader1.Width = 350;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "翻译后文本";
            this.columnHeader2.Width = 400;
            // 
            // Text_Truns
            // 
            this.Text_Truns.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Text_Truns.Location = new System.Drawing.Point(3, 66);
            this.Text_Truns.Name = "Text_Truns";
            this.Text_Truns.Size = new System.Drawing.Size(812, 26);
            this.Text_Truns.TabIndex = 18;
            // 
            // Topmemu
            // 
            this.Topmemu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.翻译ToolStripMenuItem,
            this.KeywordFilter,
            this.Alltranslate,
            this.SetTrIndex,
            this.SetOpenNextTr,
            this.SetShortcutKey});
            this.Topmemu.Location = new System.Drawing.Point(0, 0);
            this.Topmemu.Name = "Topmemu";
            this.Topmemu.Size = new System.Drawing.Size(820, 25);
            this.Topmemu.TabIndex = 19;
            this.Topmemu.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReadText,
            this.SaveText,
            this.ExitRenPy});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // ReadText
            // 
            this.ReadText.Name = "ReadText";
            this.ReadText.Size = new System.Drawing.Size(180, 22);
            this.ReadText.Text = "读取";
            this.ReadText.Click += new System.EventHandler(this.ReadText_Click);
            // 
            // SaveText
            // 
            this.SaveText.Name = "SaveText";
            this.SaveText.Size = new System.Drawing.Size(180, 22);
            this.SaveText.Text = "保存";
            this.SaveText.Click += new System.EventHandler(this.SaveText_Click);
            // 
            // ExitRenPy
            // 
            this.ExitRenPy.Name = "ExitRenPy";
            this.ExitRenPy.Size = new System.Drawing.Size(180, 22);
            this.ExitRenPy.Text = "退出";
            this.ExitRenPy.Click += new System.EventHandler(this.ExitRenPy_Click);
            // 
            // 翻译ToolStripMenuItem
            // 
            this.翻译ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FindTextList,
            this.SetTranslateRelText});
            this.翻译ToolStripMenuItem.Name = "翻译ToolStripMenuItem";
            this.翻译ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.翻译ToolStripMenuItem.Text = "编辑";
            // 
            // FindTextList
            // 
            this.FindTextList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FindSource,
            this.FindTranslate});
            this.FindTextList.Name = "FindTextList";
            this.FindTextList.Size = new System.Drawing.Size(124, 22);
            this.FindTextList.Text = "查找文本";
            // 
            // FindSource
            // 
            this.FindSource.Name = "FindSource";
            this.FindSource.Size = new System.Drawing.Size(160, 22);
            this.FindSource.Text = "查找原文本";
            this.FindSource.Click += new System.EventHandler(this.FindSource_Click);
            // 
            // FindTranslate
            // 
            this.FindTranslate.Name = "FindTranslate";
            this.FindTranslate.Size = new System.Drawing.Size(160, 22);
            this.FindTranslate.Text = "查找翻译后文本";
            this.FindTranslate.Click += new System.EventHandler(this.FindTranslate_Click);
            // 
            // SetTranslateRelText
            // 
            this.SetTranslateRelText.Name = "SetTranslateRelText";
            this.SetTranslateRelText.Size = new System.Drawing.Size(124, 22);
            this.SetTranslateRelText.Text = "设置文润";
            this.SetTranslateRelText.Click += new System.EventHandler(this.SetTranslateRelText_Click);
            // 
            // KeywordFilter
            // 
            this.KeywordFilter.Name = "KeywordFilter";
            this.KeywordFilter.Size = new System.Drawing.Size(80, 21);
            this.KeywordFilter.Text = "关键字过滤";
            this.KeywordFilter.Click += new System.EventHandler(this.KeywordFilter_Click);
            // 
            // Alltranslate
            // 
            this.Alltranslate.Name = "Alltranslate";
            this.Alltranslate.Size = new System.Drawing.Size(68, 21);
            this.Alltranslate.Text = "一键翻译";
            this.Alltranslate.Click += new System.EventHandler(this.Alltranslate_Click);
            // 
            // SetTrIndex
            // 
            this.SetTrIndex.Name = "SetTrIndex";
            this.SetTrIndex.Size = new System.Drawing.Size(92, 21);
            this.SetTrIndex.Text = "设置翻译语言";
            this.SetTrIndex.Click += new System.EventHandler(this.SetTrIndex_Click);
            // 
            // SetOpenNextTr
            // 
            this.SetOpenNextTr.Name = "SetOpenNextTr";
            this.SetOpenNextTr.Size = new System.Drawing.Size(128, 21);
            this.SetOpenNextTr.Text = "设置下一句直接翻译";
            this.SetOpenNextTr.Click += new System.EventHandler(this.SetOpenNextTr_Click);
            // 
            // SetShortcutKey
            // 
            this.SetShortcutKey.Name = "SetShortcutKey";
            this.SetShortcutKey.Size = new System.Drawing.Size(80, 21);
            this.SetShortcutKey.Text = "设置快捷键";
            this.SetShortcutKey.Click += new System.EventHandler(this.SetShortcutKey_Click);
            // 
            // NextTrace
            // 
            this.NextTrace.Font = new System.Drawing.Font("宋体", 12F);
            this.NextTrace.Location = new System.Drawing.Point(629, 97);
            this.NextTrace.MaxLength = 3;
            this.NextTrace.Name = "NextTrace";
            this.NextTrace.Size = new System.Drawing.Size(46, 26);
            this.NextTrace.TabIndex = 20;
            this.NextTrace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NextTrace_KeyPress);
            // 
            // B_TowForOneTrace
            // 
            this.B_TowForOneTrace.Location = new System.Drawing.Point(467, 97);
            this.B_TowForOneTrace.Name = "B_TowForOneTrace";
            this.B_TowForOneTrace.Size = new System.Drawing.Size(88, 27);
            this.B_TowForOneTrace.TabIndex = 23;
            this.B_TowForOneTrace.Text = "翻译该句";
            this.B_TowForOneTrace.UseVisualStyleBackColor = true;
            this.B_TowForOneTrace.Click += new System.EventHandler(this.B_TowForOneTrace_Click);
            // 
            // Redo
            // 
            this.Redo.Enabled = false;
            this.Redo.Location = new System.Drawing.Point(750, 97);
            this.Redo.Name = "Redo";
            this.Redo.Size = new System.Drawing.Size(65, 27);
            this.Redo.TabIndex = 22;
            this.Redo.Text = "恢复";
            this.Redo.UseVisualStyleBackColor = true;
            this.Redo.Click += new System.EventHandler(this.Redo_Click);
            // 
            // Undo
            // 
            this.Undo.Enabled = false;
            this.Undo.Location = new System.Drawing.Point(681, 97);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(63, 27);
            this.Undo.TabIndex = 21;
            this.Undo.Text = "撤销";
            this.Undo.UseVisualStyleBackColor = true;
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // CheckRel
            // 
            this.CheckRel.Location = new System.Drawing.Point(365, 97);
            this.CheckRel.Name = "CheckRel";
            this.CheckRel.Size = new System.Drawing.Size(96, 26);
            this.CheckRel.TabIndex = 25;
            this.CheckRel.Text = "一键替换译文";
            this.CheckRel.UseVisualStyleBackColor = true;
            this.CheckRel.Click += new System.EventHandler(this.CheckRel_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 870);
            this.Controls.Add(this.CheckRel);
            this.Controls.Add(this.B_TowForOneTrace);
            this.Controls.Add(this.Redo);
            this.Controls.Add(this.Undo);
            this.Controls.Add(this.NextTrace);
            this.Controls.Add(this.Text_Truns);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.B_Trace);
            this.Controls.Add(this.B_Next);
            this.Controls.Add(this.B_Up);
            this.Controls.Add(this.All_Text);
            this.Controls.Add(this.Text_Source);
            this.Controls.Add(this.Topmemu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.Topmemu;
            this.Name = "Main";
            this.Text = "Ren\'Py 翻译软件 V2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Main_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.Topmemu.ResumeLayout(false);
            this.Topmemu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Text_Source;
        private System.Windows.Forms.TextBox All_Text;
        private System.Windows.Forms.Button B_Up;
        private System.Windows.Forms.Button B_Next;
        private System.Windows.Forms.Button B_Trace;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView L_ViewText;
        private System.Windows.Forms.ColumnHeader ColumnHeader;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox Text_Truns;
        private System.Windows.Forms.MenuStrip Topmemu;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReadText;
        private System.Windows.Forms.ToolStripMenuItem SaveText;
        private System.Windows.Forms.ToolStripMenuItem ExitRenPy;
        private System.Windows.Forms.ToolStripMenuItem 翻译ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SetTranslateRelText;
        private System.Windows.Forms.ToolStripMenuItem KeywordFilter;
        private System.Windows.Forms.ToolStripMenuItem Alltranslate;
        private System.Windows.Forms.ToolStripMenuItem SetTrIndex;
        private System.Windows.Forms.TextBox NextTrace;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button B_TowForOneTrace;
        private System.Windows.Forms.ToolStripMenuItem FindTextList;
        private System.Windows.Forms.ToolStripMenuItem FindSource;
        private System.Windows.Forms.ToolStripMenuItem FindTranslate;
        private System.Windows.Forms.ToolStripMenuItem SetOpenNextTr;
        private System.Windows.Forms.Button Redo;
        private System.Windows.Forms.Button Undo;
        private System.Windows.Forms.ToolStripMenuItem SetShortcutKey;
        private System.Windows.Forms.Button CheckRel;
    }
}

