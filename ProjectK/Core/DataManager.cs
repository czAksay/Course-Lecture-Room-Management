using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ProjectK
{
    static class DataManager
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
            for (int i = 0; i < hardwares.Count; i++)
            {
                Hardware h = hardwares[i];
                h.Model = RemoveSpaces(h.Model);
                String type = "", capacity = "";
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
                type = h.Type.ToString();
                str += $"['{h.Model}', '{type}', {capacity}]";
                if (i != hardwares.Count - 1)
                    str += ", ";
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
    }
}
