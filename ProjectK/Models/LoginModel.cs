using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SettingsAP;
using System.Windows.Forms;
using ProjectK.Core;

namespace ProjectK.Models
{
    class LoginModel
    {
        internal void SetDefaultSettings()
        {
            DataManager.st = new Settings();
            Properties.Settings.Default.Reset();
            DataManager.st.EndOfLineType = Settings.EOLType.CRLF;
            DataManager.st.SetDefaults("server:localhost\r\nport:5432\r\nauditory_number:null");
        }

        internal bool CheckConnection(string Ip, string Port)
        {
            if (Ip == string.Empty || Port == string.Empty)
            {
                MessageBox.Show("Заполните все поля!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (!Pgs.SetUserCheckConnection(Ip, Port))
            {
                MessageBox.Show("Ошибка соединения с сервером БД!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                MessageBox.Show("Соединение с сервером БД настроено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataManager.st.SetValue("server", Ip);
                DataManager.st.SetValue("port", Port);
                Properties.Settings.Default.Save();
                return true;
            }
        }

        internal bool GuestSignIn(string Ip, string Port)
        {
            Pgs.SetDatabaseConnectionWithRole(Ip, Port, "guest");
            User.Autonom = false;
            if (!Pgs.CheckConnection())
            {
                var result = MessageBox.Show("Внимание! Отсутствует соединение с базой данных. Вы все еще можете пользоваться некоторыми функциями программы, однако для ее эффективного использования необходимо восстановить соединение. Продолжить работу в автономном режиме?", "Ошибка подключения", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return false;
                }
                else
                {
                    User.Autonom = true;
                }
            }
            User.Role = UserRole.Guest;
            return true;
        }

        internal bool SignIn(string Login, string Pass)
        {
            if (!Pgs.CheckConnection())
            {
                MessageBox.Show("Невозможно соединиться с сервером. Проверка авторизации невозможна.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (Login == string.Empty || Pass == string.Empty)
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            String account_role = Pgs.GetUserRole(Login, Pass);
            if (account_role == "")
            {
                MessageBox.Show("Неверный логин или пароль! Пожалуйста, проверьте введенные данные.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            User.Name = Login;
            if (account_role.ToLower() == "admin")
                User.Role = UserRole.Admin;
            else if (account_role.ToLower() == "lecturer")
                User.Role = UserRole.Lecturer;
            else
            {
                MessageBox.Show("Неизвестная роль пользователя! Обратитесь к системному администратору!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            String ip = DataManager.st.GetValue("server");
            String port = DataManager.st.GetValue("port");
            if (!Pgs.SetDatabaseConnectionWithRole(ip, port, account_role))
            {
                MessageBox.Show("Неизвестная ошибка подключения к серверу. Обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            User.Autonom = false;

            return true;
        }

        internal bool SetIpPort(out string ip, out string port)
        {
            ip = DataManager.st.GetValue("server");
            port = DataManager.st.GetValue("port");
            
            if (String.IsNullOrEmpty(ip) || String.IsNullOrEmpty(port) || !Pgs.SetUserCheckConnection(ip, port))
            {
                return false;
            }
            return true;
        }
    }
}
