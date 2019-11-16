namespace ProjectK
{
    partial class ScanForm
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
            this.lblState = new System.Windows.Forms.Label();
            this.btnStartScan = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSaveToTxt = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnChangeAuditoryNumber = new System.Windows.Forms.Button();
            this.currentComputer = new ProjectK.Computer();
            this.computerExplorer = new ProjectK.ComputerExplorer();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblState
            // 
            this.lblState.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblState.Font = new System.Drawing.Font("Segoe UI Light", 13F);
            this.lblState.Location = new System.Drawing.Point(12, 88);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(760, 33);
            this.lblState.TabIndex = 3;
            this.lblState.Text = "Текущее действие";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStartScan
            // 
            this.btnStartScan.BackColor = System.Drawing.Color.White;
            this.btnStartScan.BackgroundImage = global::ProjectK.Properties.Resources.scan;
            this.btnStartScan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStartScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartScan.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnStartScan.Location = new System.Drawing.Point(12, 129);
            this.btnStartScan.Name = "btnStartScan";
            this.btnStartScan.Size = new System.Drawing.Size(171, 53);
            this.btnStartScan.TabIndex = 6;
            this.btnStartScan.Text = "> Начать сканирование";
            this.btnStartScan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStartScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStartScan.UseVisualStyleBackColor = false;
            this.btnStartScan.Click += new System.EventHandler(this.BtnStartScan_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            this.lblTitle.Location = new System.Drawing.Point(204, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(190, 28);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Текущий компьютер:";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.BackgroundImage = global::ProjectK.Properties.Resources.arrow_left;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(70, 70);
            this.btnBack.TabIndex = 10;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnSaveToTxt
            // 
            this.btnSaveToTxt.BackColor = System.Drawing.Color.White;
            this.btnSaveToTxt.BackgroundImage = global::ProjectK.Properties.Resources.report;
            this.btnSaveToTxt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSaveToTxt.Enabled = false;
            this.btnSaveToTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveToTxt.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnSaveToTxt.Location = new System.Drawing.Point(12, 188);
            this.btnSaveToTxt.Name = "btnSaveToTxt";
            this.btnSaveToTxt.Size = new System.Drawing.Size(171, 53);
            this.btnSaveToTxt.TabIndex = 11;
            this.btnSaveToTxt.Text = "> Сохранить\r\nотчет txt";
            this.btnSaveToTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveToTxt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveToTxt.UseVisualStyleBackColor = false;
            this.btnSaveToTxt.Click += new System.EventHandler(this.BtnSaveToTxt_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.FileName = "scan_result";
            this.saveFileDialog1.Filter = "Текстовые файлы|*.txt";
            this.saveFileDialog1.InitialDirectory = "C:\\";
            // 
            // btnChangeAuditoryNumber
            // 
            this.btnChangeAuditoryNumber.BackColor = System.Drawing.Color.White;
            this.btnChangeAuditoryNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnChangeAuditoryNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeAuditoryNumber.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnChangeAuditoryNumber.Location = new System.Drawing.Point(12, 247);
            this.btnChangeAuditoryNumber.Name = "btnChangeAuditoryNumber";
            this.btnChangeAuditoryNumber.Size = new System.Drawing.Size(171, 53);
            this.btnChangeAuditoryNumber.TabIndex = 12;
            this.btnChangeAuditoryNumber.Text = "> Изменить \r\nномер аудитории";
            this.btnChangeAuditoryNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangeAuditoryNumber.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnChangeAuditoryNumber.UseVisualStyleBackColor = false;
            this.btnChangeAuditoryNumber.Click += new System.EventHandler(this.BtnChangeAuditoryNumber_Click);
            // 
            // currentComputer
            // 
            this.currentComputer._AuditNumber = null;
            this.currentComputer._Ip = "0.0.0.0";
            this.currentComputer._MAC = "A1:B2:C3:D4";
            this.currentComputer._MouseEnterColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.currentComputer._Name = "HOMEPC";
            this.currentComputer._Os = null;
            this.currentComputer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentComputer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.currentComputer.Location = new System.Drawing.Point(400, 10);
            this.currentComputer.Name = "currentComputer";
            this.currentComputer.Size = new System.Drawing.Size(372, 73);
            this.currentComputer.TabIndex = 9;
            // 
            // computerExplorer
            // 
            this.computerExplorer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.computerExplorer.Location = new System.Drawing.Point(193, 127);
            this.computerExplorer.Name = "computerExplorer";
            this.computerExplorer.Size = new System.Drawing.Size(579, 361);
            this.computerExplorer.TabIndex = 7;
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(12, 119);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(760, 3);
            this.pbProgress.TabIndex = 13;
            // 
            // ScanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 500);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btnChangeAuditoryNumber);
            this.Controls.Add(this.btnSaveToTxt);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.currentComputer);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.computerExplorer);
            this.Controls.Add(this.btnStartScan);
            this.Controls.Add(this.lblState);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ScanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сканирование системы";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScanForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Button btnStartScan;
        private ComputerExplorer computerExplorer;
        private System.Windows.Forms.Label lblTitle;
        private Computer currentComputer;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSaveToTxt;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnChangeAuditoryNumber;
        private System.Windows.Forms.ProgressBar pbProgress;
    }
}