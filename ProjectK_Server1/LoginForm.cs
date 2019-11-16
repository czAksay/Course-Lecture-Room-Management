using System;
using System.Drawing;
using System.Windows.Forms;
using SettingsAP;
using System.Diagnostics;

namespace ProjectK_Server1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            DataManager.st = new Settings();
            Properties.Settings.Default.Reset();
            DataManager.st.EndOfLineType = Settings.EOLType.CRLF;
            DataManager.st.SetDefaults("server:localhost\r\nport:5432\r\nauditory_number:null\r\nwebstore:null");
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            if (!Pgs.CheckConnection())
            {
                MessageBox.Show("Невозможно соединиться с сервером. Проверка авторизации невозможна.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tbLogin.Text == string.Empty || tbPassword.Text == string.Empty)
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            String account_role = Pgs.GetUserRole(tbLogin.Text, tbPassword.Text);
            if (account_role == "")
            {
                MessageBox.Show("Неверный логин или пароль! Пожалуйста, проверьте введенные данные.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            User.Name = tbLogin.Text;
            if (account_role.ToLower() == "admin")
                User.Role = UserRole.Admin;
            else if (account_role.ToLower() == "lecturer")
                User.Role = UserRole.Lecturer;
            else
            {
                MessageBox.Show("Неизвестная роль пользователя! Обратитесь к системному администратору!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String ip = DataManager.st.GetValue("server");
            String port = DataManager.st.GetValue("port");
            if (!Pgs.SetDatabaseConnectionWithRole(ip, port, account_role))
            {
                MessageBox.Show("Неизвестная ошибка подключения к серверу. Обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            User.Autonom = false;
            this.Hide();
            MainForm mf = new MainForm(this);
            mf.Show();
        }

        private void BtnGoClient_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("ProjectK.exe");
            }
            catch
            {
                MessageBox.Show("Ошибка при попытке запуска клиентского приложения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            String ip, port;
            ip = DataManager.st.GetValue("server");
            port = DataManager.st.GetValue("port");
            tbServerIp.Text = ip;
            tbServerPort.Text = port;
            if (String.IsNullOrEmpty(ip) || String.IsNullOrEmpty(port) || !Pgs.SetUserCheckConnection(ip, port))
            {
                trgLoginConnect._CurrentState = false;
                trgLoginConnect._Color2 = Color.Red;
            }
        }

        private void BtnCheckConnection_Click(object sender, EventArgs e)
        {
            if (tbServerIp.Text == string.Empty || tbServerPort.Text == string.Empty)
            {
                MessageBox.Show("Заполните все поля!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Pgs.SetUserCheckConnection(tbServerIp.Text, tbServerPort.Text))
            {
                MessageBox.Show("Ошибка соединения с сервером БД!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                trgLoginConnect._Color2 = Color.Red;
            }
            else
            {
                MessageBox.Show("Соединение с сервером БД настроено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataManager.st.SetValue("server", tbServerIp.Text);
                DataManager.st.SetValue("port", tbServerPort.Text);
                Properties.Settings.Default.Save();
                trgLoginConnect._Color2 = Color.FromArgb(15, 240, 30);
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                tbLogin.Text = "cinezad";
                tbPassword.Text = "1234";
            }
        }

        private void PbVisiblePass_Click(object sender, EventArgs e)
        {
            if (tbPassword.PasswordChar == '*')
                tbPassword.PasswordChar = tbLogin.PasswordChar;
            else
                tbPassword.PasswordChar = '*';
        }
    }
}
