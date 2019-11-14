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
        static public String GetPassword { get
            {
                switch (Role)
                {
                    case UserRole.Guest:
                        return "g1u2e3s4t5";
                    case UserRole.Lecturer:
                        return "l1e2c3t4u5r6e7r8";
                    case UserRole.Admin:
                        return "a1d2m3i4n5";
                    default:
                        return "";
                }
            }
        }
    }
}
