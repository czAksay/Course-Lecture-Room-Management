using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using ProjectK;
using ProjectK.Controls;
using SettingsAP;

namespace ProjectK_Console
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;


        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);

            LogMaker lm = new LogMaker();
            Settings st = new Settings();
            st.SeparationSymbol = ':';
            st.EndOfLineType = Settings.EOLType.CRLF;
            String ip = st.GetValue("server");
            String port = st.GetValue("port");
            lm.Log("Запуск программы.");
            if (!Pgs.SetDatabaseConnectionWithRole(ip, port, "guest"))
            {
                lm.Log($"Ошибка подключения к базе с параметрами [{ip}] [{port}].");
                return;
            }
            Computer currentComputer = new Computer();

            try
            {
                ComputerInformation nw = new ComputerInformation();
                currentComputer._MAC = nw.GetMACAddress();
                currentComputer._Name = nw.GetName();
                currentComputer._Ip = nw.GetIp();
                currentComputer._Os = nw.GetOs();

                List<Software> soft = nw.GetSoftwareCollection();
                foreach (Software s in soft)
                {
                    currentComputer.AddSoftware(s);
                }
                List<string> view = new List<string>();
                ComputerInformation ci = new ComputerInformation();
                ci.ScanFromCpuZ();
                currentComputer.AddHardware(ci.GetCpu());
                currentComputer.AddHardware(ci.GetMotherboard());
                foreach (Hardware h in ci.GetGpus())
                {
                    currentComputer.AddHardware(h);
                }
                foreach (Hardware h in ci.GetRams())
                {
                    currentComputer.AddHardware(h);
                }
                foreach (Hardware h in ci.GetHdds())
                {
                    currentComputer.AddHardware(h);
                }

                String audnum = st.GetValue("auditory_number");
                currentComputer._AuditNumber = audnum;
                Pgs.AddComputerAndOs(currentComputer);
                Pgs.AddSoftwareToComputer(currentComputer);
                Pgs.AddHardwareToComputer(currentComputer);
                lm.Log("Данные успешно отправлены.");
            }
            catch(Exception ex)
            {
                lm.Log("Ошибка при работе с данными: " + ex.Message);
            }
        }
    }
}
