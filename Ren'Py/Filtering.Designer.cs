namespace Ren_Py
{
    partial class Filtering
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
            this.FilterShow = new System.Windows.Forms.ListBox();
            this.DelFilterText = new System.Windows.Forms.Button();
            this.AddFilterText = new System.Windows.Forms.Button();
            this.WiterFilter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FilterShow
            // 
            this.FilterShow.FormattingEnabled = true;
            this.FilterShow.ItemHeight = 12;
            this.FilterShow.Location = new System.Drawing.Point(3, 3);
            this.FilterShow.Name = "FilterShow";
            this.FilterShow.ScrollAlwaysVisible = true;
            this.FilterShow.Size = new System.Drawing.Size(339, 268);
            this.FilterShow.TabIndex = 0;
            // 
            // DelFilterText
            // 
            this.DelFilterText.Location = new System.Drawing.Point(253, 277);
            this.DelFilterText.Name = "DelFilterText";
            this.DelFilterText.Size = new System.Drawing.Size(89, 29);
            this.DelFilterText.TabIndex = 1;
            this.DelFilterText.Text = "删除关键字";
            this.DelFilterText.UseVisualStyleBackColor = true;
            this.DelFilterText.Click += new System.EventHandler(this.DelFilterText_Click);
            // 
            // AddFilterText
            // 
            this.AddFilterText.Location = new System.Drawing.Point(158, 277);
            this.AddFilterText.Name = "AddFilterText";
            this.AddFilterText.Size = new System.Drawing.Size(89, 29);
            this.AddFilterText.TabIndex = 2;
            this.AddFilterText.Text = "添加关键字";
            this.AddFilterText.UseVisualStyleBackColor = true;
            this.AddFilterText.Click += new System.EventHandler(this.AddFilterText_Click);
            // 
            // WiterFilter
            // 
            this.WiterFilter.Font = new System.Drawing.Font("宋体", 13F);
            this.WiterFilter.Location = new System.Drawing.Point(3, 278);
            this.WiterFilter.Name = "WiterFilter";
            this.WiterFilter.Size = new System.Drawing.Size(149, 27);
            this.WiterFilter.TabIndex = 3;
            // 
            // Filtering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 311);
            this.Controls.Add(this.WiterFilter);
            this.Controls.Add(this.AddFilterText);
            this.Controls.Add(this.DelFilterText);
            this.Controls.Add(this.FilterShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Filtering";
            this.Text = "关键字过滤";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Filtering_FormClosing);
            this.Load += new System.EventHandler(this.Filtering_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox FilterShow;
        private System.Windows.Forms.Button DelFilterText;
        private System.Windows.Forms.Button AddFilterText;
        private System.Windows.Forms.TextBox WiterFilter;
    }
}