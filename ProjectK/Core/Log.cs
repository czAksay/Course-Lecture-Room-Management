using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectK
{
    public class LogMaker
    {
        static String fileName = "Log.txt";
        StreamWriter sw;

        public LogMaker()
        {
            sw = new StreamWriter(fileName, true);
        }

        ~LogMaker()
        {
            sw.Close();
        }

        public void Log(String message)
        {
            sw.WriteLine($"[{DateTime.Now.ToString()}] {message}");
        }
    }
}
