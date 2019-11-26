namespace ProjectK
{
    partial class Computer
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.flowText = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblOs = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.lblMac = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAuditNumber = new System.Windows.Forms.Label();
            this.tableMain.SuspendLayout();
            this.flowText.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableMain
            // 
            this.tableMain.ColumnCount = 2;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableMain.Controls.Add(this.flowText, 1, 0);
            this.tableMain.Controls.Add(this.panel1, 0, 0);
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMain.Location = new System.Drawing.Point(0, 0);
            this.tableMain.Name = "tableMain";
            this.tableMain.RowCount = 1;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableMain.Size = new System.Drawing.Size(372, 70);
            this.tableMain.TabIndex = 1;
            // 
            // flowText
            // 
            this.flowText.Controls.Add(this.lblNumber);
            this.flowText.Controls.Add(this.lblOs);
            this.flowText.Controls.Add(this.lblIp);
            this.flowText.Controls.Add(this.lblMac);
            this.flowText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowText.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowText.Location = new System.Drawing.Point(73, 3);
            this.flowText.Name = "flowText";
            this.flowText.Size = new System.Drawing.Size(298, 64);
            this.flowText.TabIndex = 1;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Segoe UI Light", 11F, System.Drawing.FontStyle.Bold);
            this.lblNumber.Location = new System.Drawing.Point(3, 0);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(125, 20);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "Компьютер №0";
            // 
            // lblOs
            // 
            this.lblOs.AutoSize = true;
            this.lblOs.Font = new System.Drawing.Font("Segoe UI Light", 9F);
            this.lblOs.Location = new System.Drawing.Point(3, 20);
            this.lblOs.Name = "lblOs";
            this.lblOs.Size = new System.Drawing.Size(28, 15);
            this.lblOs.TabIndex = 3;
            this.lblOs.Text = "OS: ";
            this.lblOs.Visible = false;
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.lblIp.Location = new System.Drawing.Point(3, 35);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(68, 20);
            this.lblIp.TabIndex = 1;
            this.lblIp.Text = "IP: 0.0.0.0";
            // 
            // lblMac
            // 
            this.lblMac.AutoSize = true;
            this.lblMac.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.lblMac.Location = new System.Drawing.Point(134, 0);
            this.lblMac.Name = "lblMac";
            this.lblMac.Size = new System.Drawing.Size(120, 20);
            this.lblMac.TabIndex = 2;
            this.lblMac.Text = "MAC: AB:CD:12:34";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::ProjectK.Properties.Resources.computer;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.lblAuditNumber);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(64, 64);
            this.panel1.TabIndex = 2;
            // 
            // lblAuditNumber
            // 
            this.lblAuditNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblAuditNumber.Font = new System.Drawing.Font("Segoe UI Light", 10F, System.Drawing.FontStyle.Bold);
            this.lblAuditNumber.Location = new System.Drawing.Point(-4, 6);
            this.lblAuditNumber.Name = "lblAuditNumber";
            this.lblAuditNumber.Size = new System.Drawing.Size(72, 51);
            this.lblAuditNumber.TabIndex = 1;
            this.lblAuditNumber.Text = "38";
            this.lblAuditNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblAuditNumber.Visible = false;
            // 
            // Computer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableMain);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "Computer";
            this.Size = new System.Drawing.Size(372, 70);
            this.Click += new System.EventHandler(this.Computer_Click);
            this.MouseEnter += new System.EventHandler(this.Computer_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Computer_MouseLeave);
            this.tableMain.ResumeLayout(false);
            this.flowText.ResumeLayout(false);
            this.flowText.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.FlowLayoutPanel flowText;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Label lblMac;
        private System.Windows.Forms.Label lblOs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAuditNumber;
    }
}
