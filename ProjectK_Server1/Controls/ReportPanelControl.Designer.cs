namespace ProjectK_Server1
{
    partial class ReportPanelControl
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlReportType = new System.Windows.Forms.Panel();
            this.rbRepairComponent = new System.Windows.Forms.RadioButton();
            this.rbRepairEquip = new System.Windows.Forms.RadioButton();
            this.rbInstall = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlAuditory = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rtbComment = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.RichTextBox();
            this.pnlReportType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Light", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(18, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(138, 45);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "РЕПОРТ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 13F);
            this.label1.Location = new System.Drawing.Point(270, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выберите тип заявки:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(4, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 2);
            this.panel1.TabIndex = 5;
            // 
            // pnlReportType
            // 
            this.pnlReportType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReportType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.pnlReportType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReportType.Controls.Add(this.rbRepairComponent);
            this.pnlReportType.Controls.Add(this.rbRepairEquip);
            this.pnlReportType.Controls.Add(this.rbInstall);
            this.pnlReportType.Enabled = false;
            this.pnlReportType.Location = new System.Drawing.Point(277, 105);
            this.pnlReportType.Name = "pnlReportType";
            this.pnlReportType.Size = new System.Drawing.Size(260, 111);
            this.pnlReportType.TabIndex = 7;
            // 
            // rbRepairComponent
            // 
            this.rbRepairComponent.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.rbRepairComponent.Location = new System.Drawing.Point(13, 79);
            this.rbRepairComponent.Name = "rbRepairComponent";
            this.rbRepairComponent.Size = new System.Drawing.Size(216, 26);
            this.rbRepairComponent.TabIndex = 10;
            this.rbRepairComponent.TabStop = true;
            this.rbRepairComponent.Text = "Ремонт комплектующих";
            this.rbRepairComponent.UseVisualStyleBackColor = true;
            // 
            // rbRepairEquip
            // 
            this.rbRepairEquip.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.rbRepairEquip.Location = new System.Drawing.Point(13, 49);
            this.rbRepairEquip.Name = "rbRepairEquip";
            this.rbRepairEquip.Size = new System.Drawing.Size(185, 25);
            this.rbRepairEquip.TabIndex = 9;
            this.rbRepairEquip.TabStop = true;
            this.rbRepairEquip.Text = "Ремонт оборудования";
            this.rbRepairEquip.UseVisualStyleBackColor = true;
            // 
            // rbInstall
            // 
            this.rbInstall.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.rbInstall.Location = new System.Drawing.Point(13, 2);
            this.rbInstall.Name = "rbInstall";
            this.rbInstall.Size = new System.Drawing.Size(216, 46);
            this.rbInstall.TabIndex = 8;
            this.rbInstall.TabStop = true;
            this.rbInstall.Text = "Установка программного обеспечения";
            this.rbInstall.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 13F);
            this.label2.Location = new System.Drawing.Point(21, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Выберите компьютер:";
            // 
            // pnlAuditory
            // 
            this.pnlAuditory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAuditory.AutoScroll = true;
            this.pnlAuditory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.pnlAuditory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAuditory.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlAuditory.Location = new System.Drawing.Point(26, 105);
            this.pnlAuditory.Name = "pnlAuditory";
            this.pnlAuditory.Size = new System.Drawing.Size(239, 111);
            this.pnlAuditory.TabIndex = 10;
            this.pnlAuditory.WrapContents = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 13F);
            this.label3.Location = new System.Drawing.Point(21, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Введите ФИО заказчика:";
            // 
            // tbFio
            // 
            this.tbFio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFio.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.tbFio.Location = new System.Drawing.Point(26, 259);
            this.tbFio.Name = "tbFio";
            this.tbFio.Size = new System.Drawing.Size(643, 27);
            this.tbFio.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 13F);
            this.label4.Location = new System.Drawing.Point(21, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Комментарий:";
            // 
            // rtbComment
            // 
            this.rtbComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbComment.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.rtbComment.Location = new System.Drawing.Point(26, 377);
            this.rtbComment.Name = "rtbComment";
            this.rtbComment.Size = new System.Drawing.Size(517, 90);
            this.rtbComment.TabIndex = 15;
            this.rtbComment.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.White;
            this.btnSend.Enabled = false;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI Light", 13F);
            this.btnSend.Location = new System.Drawing.Point(549, 425);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(122, 42);
            this.btnSend.TabIndex = 16;
            this.btnSend.Text = "Отправить";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoose.BackColor = System.Drawing.Color.White;
            this.btnChoose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChoose.Enabled = false;
            this.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoose.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.btnChoose.Location = new System.Drawing.Point(548, 142);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(125, 74);
            this.btnChoose.TabIndex = 17;
            this.btnChoose.Text = "Выбрать . . .";
            this.btnChoose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnChoose.UseVisualStyleBackColor = false;
            this.btnChoose.Click += new System.EventHandler(this.BtnChoose_Click);
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.lblResult.Location = new System.Drawing.Point(24, 296);
            this.lblResult.Name = "lblResult";
            this.lblResult.ReadOnly = true;
            this.lblResult.Size = new System.Drawing.Size(648, 47);
            this.lblResult.TabIndex = 18;
            this.lblResult.Text = "";
            // 
            // ReportPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rtbComment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbFio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnlAuditory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlReportType);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Name = "ReportPanelControl";
            this.Size = new System.Drawing.Size(694, 482);
            this.pnlReportType.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlReportType;
        private System.Windows.Forms.RadioButton rbRepairEquip;
        private System.Windows.Forms.RadioButton rbInstall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel pnlAuditory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rtbComment;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.RadioButton rbRepairComponent;
        private System.Windows.Forms.RichTextBox lblResult;
    }
}
