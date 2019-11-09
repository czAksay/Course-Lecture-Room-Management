namespace ProjectK
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.flpComputers = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRefreshComputers = new System.Windows.Forms.Button();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDatabase = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblHello = new System.Windows.Forms.Label();
            this.toolTipButtons = new System.Windows.Forms.ToolTip(this.components);
            this.btnComputerFilter = new System.Windows.Forms.Button();
            this.computerExplorer1 = new ProjectK.ComputerExplorer();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpComputers
            // 
            this.flpComputers.AutoScroll = true;
            this.flpComputers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.flpComputers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpComputers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpComputers.Location = new System.Drawing.Point(12, 152);
            this.flpComputers.Name = "flpComputers";
            this.flpComputers.Size = new System.Drawing.Size(329, 412);
            this.flpComputers.TabIndex = 0;
            this.flpComputers.WrapContents = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            this.lblTitle.Location = new System.Drawing.Point(7, 116);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(126, 28);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Компьютеры:";
            // 
            // btnRefreshComputers
            // 
            this.btnRefreshComputers.BackColor = System.Drawing.Color.White;
            this.btnRefreshComputers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshComputers.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.btnRefreshComputers.Location = new System.Drawing.Point(219, 115);
            this.btnRefreshComputers.Name = "btnRefreshComputers";
            this.btnRefreshComputers.Size = new System.Drawing.Size(122, 30);
            this.btnRefreshComputers.TabIndex = 5;
            this.btnRefreshComputers.Text = "Обновить";
            this.btnRefreshComputers.UseVisualStyleBackColor = false;
            this.btnRefreshComputers.Click += new System.EventHandler(this.btnRefreshComputers_Click);
            // 
            // flpButtons
            // 
            this.flpButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flpButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.flpButtons.Controls.Add(this.btnDatabase);
            this.flpButtons.Controls.Add(this.btnReport);
            this.flpButtons.Controls.Add(this.btnScan);
            this.flpButtons.Controls.Add(this.btnSettings);
            this.flpButtons.Controls.Add(this.btnSignOut);
            this.flpButtons.Controls.Add(this.btnExit);
            this.flpButtons.Location = new System.Drawing.Point(16, 54);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(321, 56);
            this.flpButtons.TabIndex = 10;
            // 
            // btnDatabase
            // 
            this.btnDatabase.BackColor = System.Drawing.Color.White;
            this.btnDatabase.BackgroundImage = global::ProjectK.Properties.Resources.database;
            this.btnDatabase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatabase.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.btnDatabase.Location = new System.Drawing.Point(3, 3);
            this.btnDatabase.Name = "btnDatabase";
            this.btnDatabase.Size = new System.Drawing.Size(50, 50);
            this.btnDatabase.TabIndex = 9;
            this.btnDatabase.UseVisualStyleBackColor = false;
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.White;
            this.btnReport.BackgroundImage = global::ProjectK.Properties.Resources.report;
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.btnReport.Location = new System.Drawing.Point(56, 3);
            this.btnReport.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(50, 50);
            this.btnReport.TabIndex = 13;
            this.btnReport.UseVisualStyleBackColor = false;
            // 
            // btnScan
            // 
            this.btnScan.BackColor = System.Drawing.Color.White;
            this.btnScan.BackgroundImage = global::ProjectK.Properties.Resources.scan;
            this.btnScan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScan.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.btnScan.Location = new System.Drawing.Point(109, 3);
            this.btnScan.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(50, 50);
            this.btnScan.TabIndex = 10;
            this.btnScan.UseVisualStyleBackColor = false;
            this.btnScan.Click += new System.EventHandler(this.BtnScan_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.White;
            this.btnSettings.BackgroundImage = global::ProjectK.Properties.Resources.settings;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.btnSettings.Location = new System.Drawing.Point(162, 3);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(50, 50);
            this.btnSettings.TabIndex = 11;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // btnSignOut
            // 
            this.btnSignOut.BackColor = System.Drawing.Color.White;
            this.btnSignOut.BackgroundImage = global::ProjectK.Properties.Resources.signout;
            this.btnSignOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignOut.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.btnSignOut.Location = new System.Drawing.Point(215, 3);
            this.btnSignOut.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(50, 50);
            this.btnSignOut.TabIndex = 12;
            this.btnSignOut.UseVisualStyleBackColor = false;
            this.btnSignOut.Click += new System.EventHandler(this.BtnSignOut_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.BackgroundImage = global::ProjectK.Properties.Resources.close;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.btnExit.Location = new System.Drawing.Point(268, 3);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 50);
            this.btnExit.TabIndex = 14;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // lblHello
            // 
            this.lblHello.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblHello.Font = new System.Drawing.Font("Segoe UI Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHello.Location = new System.Drawing.Point(12, 9);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(503, 40);
            this.lblHello.TabIndex = 11;
            this.lblHello.Text = "Здравствуйте, никто.";
            this.lblHello.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnComputerFilter
            // 
            this.btnComputerFilter.BackColor = System.Drawing.Color.White;
            this.btnComputerFilter.BackgroundImage = global::ProjectK.Properties.Resources.filter;
            this.btnComputerFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComputerFilter.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.btnComputerFilter.Location = new System.Drawing.Point(185, 115);
            this.btnComputerFilter.Name = "btnComputerFilter";
            this.btnComputerFilter.Size = new System.Drawing.Size(30, 30);
            this.btnComputerFilter.TabIndex = 7;
            this.btnComputerFilter.UseVisualStyleBackColor = false;
            this.btnComputerFilter.Click += new System.EventHandler(this.BtnComputerFilter_Click);
            // 
            // computerExplorer1
            // 
            this.computerExplorer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.computerExplorer1.Location = new System.Drawing.Point(351, 65);
            this.computerExplorer1.Name = "computerExplorer1";
            this.computerExplorer1.Size = new System.Drawing.Size(594, 499);
            this.computerExplorer1.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(959, 576);
            this.Controls.Add(this.flpButtons);
            this.Controls.Add(this.btnComputerFilter);
            this.Controls.Add(this.btnRefreshComputers);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.flpComputers);
            this.Controls.Add(this.lblHello);
            this.Controls.Add(this.computerExplorer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кабинет";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpComputers;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRefreshComputers;
        private System.Windows.Forms.Button btnComputerFilter;
        private System.Windows.Forms.Button btnDatabase;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.ToolTip toolTipButtons;
        private System.Windows.Forms.Button btnReport;
        private ComputerExplorer computerExplorer1;
        private System.Windows.Forms.Button btnExit;
    }
}