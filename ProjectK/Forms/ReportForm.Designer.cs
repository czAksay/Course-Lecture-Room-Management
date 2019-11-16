namespace ProjectK
{
    partial class ReportForm
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
            this.reportPanelControl1 = new ProjectK.ReportPanelControl();
            this.SuspendLayout();
            // 
            // reportPanelControl1
            // 
            this.reportPanelControl1.BackColor = System.Drawing.Color.White;
            this.reportPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.reportPanelControl1.Name = "reportPanelControl1";
            this.reportPanelControl1.Size = new System.Drawing.Size(698, 484);
            this.reportPanelControl1.TabIndex = 0;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(698, 484);
            this.Controls.Add(this.reportPanelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Репорт";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ReportPanelControl reportPanelControl1;
    }
}