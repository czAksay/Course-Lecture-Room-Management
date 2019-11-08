using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SettingsAP;

namespace ProjectK
{
    public partial class LoginForm : Form
    {
        Settings st;
        public LoginForm()
        {
            InitializeComponent();
            st = new Settings();
            st.EndOfLineType = Settings.EOLType.CRLF;
            st.SetDefaults("server:localhost\r\nport:5432");
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
            messageDisplay1.SetText("Вход в приложение с правами гостя. Вы можете только смотреть. Вы - куколд.");
        }

        private void BtnGuest_MouseLeave(object sender, EventArgs e)
        {
            messageDisplay1.Clear();
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
            String ip = st.GetValue("server");
            String port = st.GetValue("port");
            if (!Pgs.SetUniversityDbConnection(ip, port, account_role))
            {
                MessageBox.Show("Неизвестная ошибка подключения к серверу. Обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            User.Auronom = false;
            this.Hide();
            MainForm mf = new MainForm(this);
            mf.Show();
        }

        private void BtnGuest_Click(object sender, EventArgs e)
        {
            User.Auronom = false;
            if (!Pgs.CheckConnection())
            {
                var result = MessageBox.Show("Внимание! Отсутствует соединение с базой данных. Вы все еще можете пользоваться некоторыми функциями программы, однако для ее эффективного использования необходимо восстановить соединение. Продолжить работу в автономном режиме?", "Ошибка подключения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }
                else
                {
                    User.Auronom = true;
                }
            }
            User.Role = UserRole.Guest;
            this.Hide();
            MainForm mf = new MainForm(this);
            mf.Show();
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

        private void btnSignMode_Click(object sender, EventArgs e)
        {
            if (Program.StartMode == EStartMode.Autostart)
            {
                Program.StartMode = EStartMode.UserStart;
                btnSignMode.Text = "Режим входа: Пользователь";
            }
            else
            {
                Program.StartMode = EStartMode.Autostart;
                btnSignMode.Text = "Режим входа: Автозапуск";
            }
            BtnSignMode_MouseEnter(null, null);
        }

        private void BtnSignMode_MouseEnter(object sender, EventArgs e)
        {
            if (Program.StartMode == EStartMode.Autostart)
                messageDisplay1.SetText("[DEBUG] Режим входа - эмуляция автозапуска.");
            else
                messageDisplay1.SetText("[DEBUG] Режим входа - пользовательский.");
        }

        private void BtnSignMode_MouseLeave(object sender, EventArgs e)
        {
            messageDisplay1.Clear();
        }

        public void ResetForm()
        {
            tbLogin.Clear();
            tbPassword.Clear();
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
            ip = st.GetValue("server");
            port = st.GetValue("port");
            tbServerIp.Text = ip;
            tbServerPort.Text = port;
            if (String.IsNullOrEmpty(ip) || String.IsNullOrEmpty(port) || !Pgs.SetUsersDbConnection(ip, port))
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
            if (!Pgs.SetUsersDbConnection(tbServerIp.Text, tbServerPort.Text))
            {
                MessageBox.Show("Ошибка соединения с сервером БД!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                trgLoginConnect._Color2 = Color.Red;
            }
            else
            {
                MessageBox.Show("Соединение с сервером БД настроено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                st.SetValue("server", tbServerIp.Text);
                st.SetValue("port", tbServerPort.Text);
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
    }
}
