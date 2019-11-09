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

        public static List<Computer> GetComputerList()
        {
            List<Computer> computers = new List<Computer>()
            {
                new Computer("PC-1", "192.168.0.1"),
                new Computer("PC-2", "192.168.0.2"),
                new Computer("PC-3", "192.168.0.3"),
                new Computer("PC-4", "192.168.0.4"),
                new Computer("PC-5", "192.168.0.5"),
                new Computer("PC-6", "192.168.0.6"),
                new Computer("PC-7", "192.168.0.7")
            };
            return computers;
        }

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
    }
}
