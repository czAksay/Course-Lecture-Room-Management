using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectK
{
    public enum UserRole { Guest = 0, Lecturer, Admin}
    static class User
    {
        public static bool Autonom { get; set; } = false;
        static public String Name { get; set; }
        static public UserRole Role { get; set; }
        static public String AutonomWarning { get { return "В автономном режиме приложение не имеет доступ к некоторым функциям. Вы можете настроить соединение с сервером на странице авторизации."; } }
    }
}
