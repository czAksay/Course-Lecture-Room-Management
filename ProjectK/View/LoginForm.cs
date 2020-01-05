using System;
using System.Drawing;
using System.Windows.Forms;
using SettingsAP;
using ProjectK.Core;
using ProjectK.Presenter;

namespace ProjectK
{
    public partial class LoginForm : Form, ILoginView
    {
        ILoginPresenter presenter;

        public LoginForm()
        {
            InitializeComponent();
            presenter = new LoginPresenter(this);
            presenter.SetDefaultSettings();
        }

        private void btnSignIn_MouseEnter(object sender, EventArgs e)
        {
            messageDisplay1.SetText("Вход в приложение под созданной учетной записью. Вам будут выданы соответствующие права доступа.");
        }

        private void btnSignIn_MouseLeave(object sender, EventArgs e)
        {
            messageDisplay1.Clear();
        }

        private void BtnGuest_MouseEnter(object sender, EventArgs e)
        {
            messageDisplay1.SetText("Вход в приложение с правами гостя. Можно просматривать компьютеры и оборудование в аудиториях.");
        }

        private void BtnGuest_MouseLeave(object sender, EventArgs e)
        {
            messageDisplay1.Clear();
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            presenter.SignIn(tbLogin.Text, tbPassword.Text);
        }

        private void BtnGuest_Click(object sender, EventArgs e)
        {
            presenter.GuestSignIn(tbServerIp.Text, tbServerPort.Text);
        }

        private void TbLogin_MouseEnter(object sender, EventArgs e)
        {
            messageDisplay1.SetText("Введите здесь Ваш логин.");
        }

        private void TbLogin_MouseLeave(object sender, EventArgs e)
        {
            messageDisplay1.Clear();
        }

        private void TbPassword_MouseEnter(object sender, EventArgs e)
        {
            messageDisplay1.SetText("Введите здесь Ваш пароль.");
        }

        private void TbPassword_MouseLeave(object sender, EventArgs e)
        {
            messageDisplay1.Clear();
        }

        public void ResetForm()
        {
            tbLogin.Clear();
            tbPassword.Clear();
            Pgs.SetUserCheckConnection(tbServerIp.Text, tbServerPort.Text);
        }

        private void ChangePanel()
        {
            if (trgLoginConnect._CurrentState)
            {
                pnlLogin.Show();
                pnlConnect.Hide();
            }
            else
            {
                pnlLogin.Hide();
                pnlConnect.Show();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            trgLoginConnect.onTriggered += ChangePanel;
            presenter.SetIpPort();
        }

        public void SetTextBoxesIpPort(string Ip, string Port)
        {
            tbServerIp.Text = Ip;
            tbServerPort.Text = Port;
        }

        private void BtnCheckConnection_Click(object sender, EventArgs e)
        {
            presenter.CheckConnection(tbServerIp.Text, tbServerPort.Text);
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
#if DEBUG 
            if (e.KeyCode == Keys.F5)
            {
                tbLogin.Text = "cinezad";
                tbPassword.Text = "1234";
            }
            else if (e.KeyCode == Keys.F6)
            {
                tbLogin.Text = "uchilka";
                tbPassword.Text = "1234";
            }
#endif
        }

        private void PbVisiblePass_Click(object sender, EventArgs e)
        {
            if (tbPassword.PasswordChar == '*')
                tbPassword.PasswordChar = tbLogin.PasswordChar;
            else
                tbPassword.PasswordChar = '*';
        }

        private void TbServerIp_MouseEnter(object sender, EventArgs e)
        {
            messageDisplay1.SetText("Введите локальный IP-адрес сервера или localhost.");
        }

        private void TbServerIp_MouseLeave(object sender, EventArgs e)
        {
            messageDisplay1.Clear();
        }

        private void TbServerPort_MouseEnter(object sender, EventArgs e)
        {
            messageDisplay1.SetText("Введите порт сервера.");
        }

        private void TbServerPort_MouseLeave(object sender, EventArgs e)
        {
            messageDisplay1.Clear();
        }

        private void BtnCheckConnection_MouseEnter(object sender, EventArgs e)
        {
            messageDisplay1.SetText("Проверить соединие с сервером на основании введенных Вами данных.");
        }

        private void BtnCheckConnection_MouseLeave(object sender, EventArgs e)
        {
            messageDisplay1.Clear();
        }

        public void SignedIn()
        {
            this.Hide();
            MainForm mf = new MainForm(this);
            mf.Show();
        }

        public void SetTriggerBoxRed()
        {
            trgLoginConnect._CurrentState = false;
            trgLoginConnect._Color2 = Color.Red;
        }

        public void SetTriggerColor(Color color)
        {
            trgLoginConnect._Color2 = color;
        }
    }
}
