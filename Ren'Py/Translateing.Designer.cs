namespace Ren_Py
{
    partial class Translateing
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
            this.ReplaceDataGrid = new System.Windows.Forms.DataGridView();
            this.OldReplaceText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewReplaceText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ReplaceDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ReplaceDataGrid
            // 
            this.ReplaceDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReplaceDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OldReplaceText,
            this.NewReplaceText});
            this.ReplaceDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReplaceDataGrid.Location = new System.Drawing.Point(0, 0);
            this.ReplaceDataGrid.Name = "ReplaceDataGrid";
            this.ReplaceDataGrid.RowTemplate.Height = 23;
            this.ReplaceDataGrid.Size = new System.Drawing.Size(607, 450);
            this.ReplaceDataGrid.TabIndex = 0;
            // 
            // OldReplaceText
            // 
            this.OldReplaceText.HeaderText = "要替换文本";
            this.OldReplaceText.Name = "OldReplaceText";
            this.OldReplaceText.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OldReplaceText.Width = 250;
            // 
            // NewReplaceText
            // 
            this.NewReplaceText.HeaderText = "要替换成文本";
            this.NewReplaceText.Name = "NewReplaceText";
            this.NewReplaceText.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NewReplaceText.Width = 250;
            // 
            // Translateing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 450);
            this.Controls.Add(this.ReplaceDataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Translateing";
            this.Text = "润色设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Translateing_FormClosing);
            this.Load += new System.EventHandler(this.Translateing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReplaceDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ReplaceDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldReplaceText;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewReplaceText;
    }
}