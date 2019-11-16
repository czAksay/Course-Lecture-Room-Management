using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ProjectK
{
    static public class DataManager
    {
        public static SettingsAP.Settings st;

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

        public static string GetSoftwareString(List<Software> softwares)
        {
            if (softwares.Count == 0)
                throw new Exception("Не найдено ни одной программы на компьютере!");
            String str = "";
            for(int i = 0; i < softwares.Count; i++)
            {
                Software s = softwares[i];
                s.Name = s.Name.Replace('\'', ' ');
                s.Name = RemoveSpaces(s.Name);
                s.ExePath = s.ExePath.Replace('\'', ' ');
                s.ExePath = RemoveSpaces(s.ExePath);
                str += $"['{s.Name}', '{s.ExePath}']";
                if (i != softwares.Count - 1)
                    str += ", ";
            }
            return str;
        }

        public static string GetHardwareString(List<Hardware> hardwares)
        {
            if (hardwares.Count == 0)
                throw new Exception("Не найдено ни одного оборудования на компьютере!");
            String str = "";
            int reallyAdded = 0;
            for (int i = 0; i < hardwares.Count; i++)
            {
                Hardware h = hardwares[i];
                if (h == null)
                    continue;
                if (reallyAdded > 0)
                    str += ", ";
                h.Model = RemoveSpaces(h.Model);
                String capacity = "";
                switch (h.Type)
                {
                    case HardwareType.RAM:
                        capacity = "'" + h.Memory.ToString() + "'";
                        break;
                    case HardwareType.HDD:
                        capacity = "'" + h.Memory.ToString() + "'";
                        break;
                    default:
                        capacity = "NULL";
                        break;
                }
                String type = h.Type.ToString();
                str += $"['{h.Model}', '{type}', {capacity}]";
                reallyAdded++;
                
            }
            return str;
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
