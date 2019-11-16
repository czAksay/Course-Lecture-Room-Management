namespace ProjectK_Server1
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
            this.flpServerInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.lblHello = new System.Windows.Forms.Label();
            this.toolTipButtons = new System.Windows.Forms.ToolTip(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRefreshComputers = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDatabase = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.flpButtons.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpServerInfo
            // 
            this.flpServerInfo.AutoScroll = true;
            this.flpServerInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.flpServerInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpServerInfo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpServerInfo.Location = new System.Drawing.Point(12, 149);
            this.flpServerInfo.Name = "flpServerInfo";
            this.flpServerInfo.Size = new System.Drawing.Size(329, 277);
            this.flpServerInfo.TabIndex = 0;
            this.flpServerInfo.WrapContents = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Light", 15F);
            this.lblTitle.Location = new System.Drawing.Point(7, 114);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(80, 28);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Сервер:";
            // 
            // flpButtons
            // 
            this.flpButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.flpButtons.Controls.Add(this.btnDatabase);
            this.flpButtons.Controls.Add(this.btnReport);
            this.flpButtons.Controls.Add(this.btnSignOut);
            this.flpButtons.Controls.Add(this.btnExit);
            this.flpButtons.Location = new System.Drawing.Point(12, 54);
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Size = new System.Drawing.Size(329, 56);
            this.flpButtons.TabIndex = 10;
            // 
            // lblHello
            // 
            this.lblHello.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.lblHello.Font = new System.Drawing.Font("Segoe UI Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHello.Location = new System.Drawing.Point(12, 12);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(503, 36);
            this.lblHello.TabIndex = 11;
            this.lblHello.Text = "Здравствуйте, никто.";
            this.lblHello.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.btnRefreshComputers);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 435);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(329, 127);
            this.flowLayoutPanel1.TabIndex = 14;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // btnRefreshComputers
            // 
            this.btnRefreshComputers.BackColor = System.Drawing.Color.White;
            this.btnRefreshComputers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshComputers.Font = new System.Drawing.Font("Segoe UI Light", 13F);
            this.btnRefreshComputers.Location = new System.Drawing.Point(3, 3);
            this.btnRefreshComputers.Name = "btnRefreshComputers";
            this.btnRefreshComputers.Size = new System.Drawing.Size(321, 57);
            this.btnRefreshComputers.TabIndex = 6;
            this.btnRefreshComputers.Text = "Открыть список оборудования";
            this.btnRefreshComputers.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Light", 13F);
            this.button1.Location = new System.Drawing.Point(3, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(321, 56);
            this.button1.TabIndex = 7;
            this.button1.Text = "Перейти в файловое хранилище";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnDatabase
            // 
            this.btnDatabase.BackColor = System.Drawing.Color.White;
            this.btnDatabase.BackgroundImage = global::ProjectK_Server1.Properties.Resources.database;
            this.btnDatabase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatabase.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.btnDatabase.Location = new System.Drawing.Point(3, 3);
            this.btnDatabase.Name = "btnDatabase";
            this.btnDatabase.Size = new System.Drawing.Size(50, 50);
            this.btnDatabase.TabIndex = 9;
            this.btnDatabase.UseVisualStyleBackColor = false;
            this.btnDatabase.Click += new System.EventHandler(this.BtnDatabase_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.White;
            this.btnReport.BackgroundImage = global::ProjectK_Server1.Properties.Resources.report;
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.btnReport.Location = new System.Drawing.Point(56, 3);
            this.btnReport.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(50, 50);
            this.btnReport.TabIndex = 13;
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.BtnReport_Click);
            // 
            // btnSignOut
            // 
            this.btnSignOut.BackColor = System.Drawing.Color.White;
            this.btnSignOut.BackgroundImage = global::ProjectK_Server1.Properties.Resources.signout;
            this.btnSignOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignOut.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.btnSignOut.Location = new System.Drawing.Point(109, 3);
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
            this.btnExit.BackgroundImage = global::ProjectK_Server1.Properties.Resources.close;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.btnExit.Location = new System.Drawing.Point(162, 3);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 50);
            this.btnExit.TabIndex = 14;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1052, 576);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flpButtons);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.flpServerInfo);
            this.Controls.Add(this.lblHello);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Кабинет";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.flpButtons.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpServerInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDatabase;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.ToolTip toolTipButtons;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnRefreshComputers;
        private System.Windows.Forms.Button button1;
    }
}