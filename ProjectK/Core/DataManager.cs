using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using ProjectK.SoftwareHardware;

namespace ProjectK
{
    static public class DataManager
    {
        public static SettingsAP.Settings st;
        public static LogMaker log = new LogMaker();

        public static string getHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        public static void GetSoftwareString(List<Software> softwares, out string soft_string, out string soft_path_string)
        {
            if (softwares.Count == 0)
                throw new Exception("Не найдено ни одной программы на компьютере!");
            soft_string = "";
            soft_path_string = "";
            for (int i = 0; i < softwares.Count; i++)
            {
                Software s = softwares[i];
                s.Name = s.Name.Replace('\'', ' ');
                s.Name = RemoveSpaces(s.Name);
                s.ExePath = s.ExePath.Replace('\'', ' ');
                s.ExePath = RemoveSpaces(s.ExePath);
                soft_string += $"'{s.Name}'";
                soft_path_string += $"'{s.ExePath}'";
                if (i != softwares.Count - 1)
                {
                    soft_string += ", ";
                    soft_path_string += ", ";
                }
            }
        }

        public static void GetHardwareString(List<Hardware> hardwares, out string models, out string types, out string capacity)
        {
            if (hardwares.Count == 0)
                throw new Exception("Не найдено ни одного оборудования на компьютере!");
            models = "";
            types = "";
            capacity = "";
            int reallyAdded = 0;
            for (int i = 0; i < hardwares.Count; i++)
            {
                Hardware h = hardwares[i];
                if (h == null)
                    continue;
                if (reallyAdded > 0)
                {
                    models += ", ";
                    types += ", ";
                    capacity += ", ";
                }
                h.Model = RemoveSpaces(h.Model);
                //String capacity = "";
                switch (h.Type)
                {
                    case HardwareType.RAM:
                        capacity += "'" + h.Memory.ToString() + "'";
                        break;
                    case HardwareType.HDD:
                        capacity += "'" + h.Memory.ToString() + "'";
                        break;
                    default:
                        capacity += "NULL";
                        break;
                }
                models += $"'{h.Model}'";
                types += $"'{h.Type.ToString()}'";
                reallyAdded++;   
            }
        }

        public static string RemoveSpaces(String str)
        {
            while (str.Length != 0 && str[0] == ' ')
                str = str.Remove(0, 1);
            while (str.Length != 0 && str[str.Length - 1] == ' ')
                str = str.Remove(str.Length - 1, 1);
            return str;
        }

        public static string AddMacPoints(String mac)
        {
            string new_mac = "";
            for (int i = 0; i < mac.Length; i++)
            {
                if (i != 0 && i % 2 == 0)
                    new_mac += ":";
                new_mac += mac[i];
            }
            return new_mac;
        }
    }
}
