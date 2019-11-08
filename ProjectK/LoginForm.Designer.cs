namespace ProjectK
{
    partial class LoginForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.pbVisiblePass = new System.Windows.Forms.PictureBox();
            this.btnGuest = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSignMode = new System.Windows.Forms.Button();
            this.pnlConnect = new System.Windows.Forms.Panel();
            this.btnCheckConnection = new System.Windows.Forms.Button();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbServerIp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.messageDisplay2 = new ProjectK.MessageDisplay();
            this.messageDisplay1 = new ProjectK.MessageDisplay();
            this.trgLoginConnect = new ProjectK.ControlTrigger();
            this.pnlLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVisiblePass)).BeginInit();
            this.pnlConnect.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(351, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 471);
            this.panel1.TabIndex = 0;
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLogin.Controls.Add(this.pbVisiblePass);
            this.pnlLogin.Controls.Add(this.btnGuest);
            this.pnlLogin.Controls.Add(this.panel3);
            this.pnlLogin.Controls.Add(this.btnSignIn);
            this.pnlLogin.Controls.Add(this.tbPassword);
            this.pnlLogin.Controls.Add(this.label3);
            this.pnlLogin.Controls.Add(this.tbLogin);
            this.pnlLogin.Controls.Add(this.label2);
            this.pnlLogin.Location = new System.Drawing.Point(21, 143);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(309, 319);
            this.pnlLogin.TabIndex = 2;
            // 
            // pbVisiblePass
            // 
            this.pbVisiblePass.BackColor = System.Drawing.Color.White;
            this.pbVisiblePass.Image = global::ProjectK.Properties.Resources.eye;
            this.pbVisiblePass.Location = new System.Drawing.Point(261, 132);
            this.pbVisiblePass.Name = "pbVisiblePass";
            this.pbVisiblePass.Size = new System.Drawing.Size(20, 21);
            this.pbVisiblePass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVisiblePass.TabIndex = 7;
            this.pbVisiblePass.TabStop = false;
            this.pbVisiblePass.Click += new System.EventHandler(this.PbVisiblePass_Click);
            // 
            // btnGuest
            // 
            this.btnGuest.BackColor = System.Drawing.Color.White;
            this.btnGuest.Font = new System.Drawing.Font("Segoe UI Light", 13F);
            this.btnGuest.Location = new System.Drawing.Point(20, 247);
            this.btnGuest.Name = "btnGuest";
            this.btnGuest.Size = new System.Drawing.Size(261, 53);
            this.btnGuest.TabIndex = 6;
            this.btnGuest.Text = "Войти как гость";
            this.btnGuest.UseVisualStyleBackColor = false;
            this.btnGuest.Click += new System.EventHandler(this.BtnGuest_Click);
            this.btnGuest.MouseEnter += new System.EventHandler(this.BtnGuest_MouseEnter);
            this.btnGuest.MouseLeave += new System.EventHandler(this.BtnGuest_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(11, 229);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(283, 1);
            this.panel3.TabIndex = 5;
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.White;
            this.btnSignIn.Font = new System.Drawing.Font("Segoe UI Light", 13F);
            this.btnSignIn.Location = new System.Drawing.Point(20, 174);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(261, 37);
            this.btnSignIn.TabIndex = 4;
            this.btnSignIn.Text = "Войти";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.BtnSignIn_Click);
            this.btnSignIn.MouseEnter += new System.EventHandler(this.btnSignIn_MouseEnter);
            this.btnSignIn.MouseLeave += new System.EventHandler(this.btnSignIn_MouseLeave);
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.tbPassword.Location = new System.Drawing.Point(17, 129);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(268, 27);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPassword.MouseEnter += new System.EventHandler(this.TbPassword_MouseEnter);
            this.tbPassword.MouseLeave += new System.EventHandler(this.TbPassword_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Light", 13F);
            this.label3.Location = new System.Drawing.Point(14, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Пароль";
            // 
            // tbLogin
            // 
            this.tbLogin.Font = new System.Drawing.Font("Segoe UI Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLogin.Location = new System.Drawing.Point(17, 51);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(268, 27);
            this.tbLogin.TabIndex = 1;
            this.tbLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbLogin.MouseEnter += new System.EventHandler(this.TbLogin_MouseEnter);
            this.tbLogin.MouseLeave += new System.EventHandler(this.TbLogin_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 13F);
            this.label2.Location = new System.Drawing.Point(14, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Логин";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe Print", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 89);
            this.label1.TabIndex = 3;
            this.label1.Text = "Turbo Edvard";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(367, 242);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(239, 1);
            this.panel4.TabIndex = 6;
            // 
            // btnSignMode
            // 
            this.btnSignMode.BackColor = System.Drawing.Color.White;
            this.btnSignMode.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.btnSignMode.Location = new System.Drawing.Point(389, 397);
            this.btnSignMode.Name = "btnSignMode";
            this.btnSignMode.Size = new System.Drawing.Size(196, 49);
            this.btnSignMode.TabIndex = 8;
            this.btnSignMode.Text = "Режим входа: Пользователь";
            this.btnSignMode.UseVisualStyleBackColor = false;
            this.btnSignMode.Click += new System.EventHandler(this.btnSignMode_Click);
            this.btnSignMode.MouseEnter += new System.EventHandler(this.BtnSignMode_MouseEnter);
            this.btnSignMode.MouseLeave += new System.EventHandler(this.BtnSignMode_MouseLeave);
            // 
            // pnlConnect
            // 
            this.pnlConnect.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlConnect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConnect.Controls.Add(this.btnCheckConnection);
            this.pnlConnect.Controls.Add(this.tbServerPort);
            this.pnlConnect.Controls.Add(this.label4);
            this.pnlConnect.Controls.Add(this.tbServerIp);
            this.pnlConnect.Controls.Add(this.label5);
            this.pnlConnect.Location = new System.Drawing.Point(21, 143);
            this.pnlConnect.Name = "pnlConnect";
            this.pnlConnect.Size = new System.Drawing.Size(309, 319);
            this.pnlConnect.TabIndex = 9;
            this.pnlConnect.Visible = false;
            // 
            // btnCheckConnection
            // 
            this.btnCheckConnection.BackColor = System.Drawing.Color.White;
            this.btnCheckConnection.Font = new System.Drawing.Font("Segoe UI Light", 12F);
            this.btnCheckConnection.Location = new System.Drawing.Point(59, 176);
            this.btnCheckConnection.Name = "btnCheckConnection";
            this.btnCheckConnection.Size = new System.Drawing.Size(196, 55);
            this.btnCheckConnection.TabIndex = 4;
            this.btnCheckConnection.Text = "Проверить соединение";
            this.btnCheckConnection.UseVisualStyleBackColor = false;
            this.btnCheckConnection.Click += new System.EventHandler(this.BtnCheckConnection_Click);
            this.btnCheckConnection.MouseEnter += new System.EventHandler(this.BtnCheckConnection_MouseEnter);
            this.btnCheckConnection.MouseLeave += new System.EventHandler(this.BtnCheckConnection_MouseLeave);
            // 
            // tbServerPort
            // 
            this.tbServerPort.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.tbServerPort.Location = new System.Drawing.Point(17, 130);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(270, 27);
            this.tbServerPort.TabIndex = 3;
            this.tbServerPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbServerPort.MouseEnter += new System.EventHandler(this.TbServerPort_MouseEnter);
            this.tbServerPort.MouseLeave += new System.EventHandler(this.TbServerPort_MouseLeave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Light", 13F);
            this.label4.Location = new System.Drawing.Point(14, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Порт";
            // 
            // tbServerIp
            // 
            this.tbServerIp.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.tbServerIp.Location = new System.Drawing.Point(17, 52);
            this.tbServerIp.Name = "tbServerIp";
            this.tbServerIp.Size = new System.Drawing.Size(270, 27);
            this.tbServerIp.TabIndex = 1;
            this.tbServerIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbServerIp.MouseEnter += new System.EventHandler(this.TbServerIp_MouseEnter);
            this.tbServerIp.MouseLeave += new System.EventHandler(this.TbServerIp_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Light", 13F);
            this.label5.Location = new System.Drawing.Point(14, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "IP сервера";
            // 
            // messageDisplay2
            // 
            this.messageDisplay2._BackColor = System.Drawing.Color.White;
            this.messageDisplay2._Color = System.Drawing.SystemColors.ControlText;
            this.messageDisplay2._Font = new System.Drawing.Font("Segoe UI Light", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageDisplay2._Text = "Информация о софте тут";
            this.messageDisplay2._TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.messageDisplay2.BackColor = System.Drawing.Color.White;
            this.messageDisplay2.Location = new System.Drawing.Point(367, 267);
            this.messageDisplay2.Name = "messageDisplay2";
            this.messageDisplay2.Size = new System.Drawing.Size(239, 212);
            this.messageDisplay2.TabIndex = 7;
            // 
            // messageDisplay1
            // 
            this.messageDisplay1._BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.messageDisplay1._Color = System.Drawing.SystemColors.ControlText;
            this.messageDisplay1._Font = new System.Drawing.Font("Segoe UI Light", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageDisplay1._Text = "";
            this.messageDisplay1._TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.messageDisplay1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.messageDisplay1.Location = new System.Drawing.Point(367, 12);
            this.messageDisplay1.Name = "messageDisplay1";
            this.messageDisplay1.Size = new System.Drawing.Size(239, 200);
            this.messageDisplay1.TabIndex = 1;
            // 
            // trgLoginConnect
            // 
            this.trgLoginConnect._BackColor1 = System.Drawing.Color.White;
            this.trgLoginConnect._BackColor2 = System.Drawing.Color.White;
            this.trgLoginConnect._Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.trgLoginConnect._Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(240)))), ((int)(((byte)(30)))));
            this.trgLoginConnect._CurrentState = true;
            this.trgLoginConnect._Text1 = "Авторизация";
            this.trgLoginConnect._Text2 = "Соединение";
            this.trgLoginConnect.Location = new System.Drawing.Point(172, 112);
            this.trgLoginConnect.Name = "trgLoginConnect";
            this.trgLoginConnect.Size = new System.Drawing.Size(158, 32);
            this.trgLoginConnect.TabIndex = 10;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 491);
            this.Controls.Add(this.btnSignMode);
            this.Controls.Add(this.messageDisplay2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.messageDisplay1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trgLoginConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlConnect);
            this.Controls.Add(this.pnlLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVisiblePass)).EndInit();
            this.pnlConnect.ResumeLayout(false);
            this.pnlConnect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MessageDisplay messageDisplay1;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Button btnGuest;
        private System.Windows.Forms.Panel panel4;
        private MessageDisplay messageDisplay2;
        private System.Windows.Forms.Button btnSignMode;
        private System.Windows.Forms.Panel pnlConnect;
        private System.Windows.Forms.Button btnCheckConnection;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbServerIp;
        private System.Windows.Forms.Label label5;
        private ControlTrigger trgLoginConnect;
        private System.Windows.Forms.PictureBox pbVisiblePass;
    }
}

