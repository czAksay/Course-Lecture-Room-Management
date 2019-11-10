using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using System.Management;
using System.Diagnostics;
using System.Threading;

namespace ProjectK
{
    public partial class ScanForm : Form
    {
        String audnum;
        public ScanForm()
        {
            InitializeComponent();
            lblState.Text = "Ожидание.";
            CreateComputer();
            currentComputer.onComputerSelect += (computer) => Process.Start("control.exe", "System");
            computerExplorer.SetComputer(currentComputer);
            //StartScan();
        }

        private void BtnStartScan_Click(object sender, EventArgs e)
        {
            computerExplorer.Clear();
            try
            {
                FillSoftware();
                FillHardware();
            }
            catch(Exception ex)
            {
                CanselScan("Ошибка при сканировании:\n" + ex.Message +"\nСканирование прервано.");
                return;
            }

            if (User.Autonom)
            {
                CanselScan(User.AutonomWarning + "\nДанные не были отправлены на сервер.");
                return;
            }

            if (Pgs.CheckComputerExist(currentComputer._MAC, out audnum))
            {
                SendComputerToDb();
                return;
            }
            
            if (User.Role != UserRole.Admin)
            {
                CanselScan("Данный компьютер не привязан к какой-либо аудитории. Назначить компьютеру аудиторию может только администратор. Пожалуйста, сообщите ему о проблеме.");
                return;
            }

            if (!AskAudiotyNumber(out audnum))
            {
                CanselScan("Данные не могут быть отправлены на сервер без указания номера аудитории.");
                return;
            }

            SendComputerToDb();
        }

        private void CanselScan(String message)
        {
            MessageBox.Show(message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            FinishScan();
        }

        private void CreateComputer()
        {
            ComputerInformation nw = new ComputerInformation();
            currentComputer._MAC = nw.GetMACAddress();
            currentComputer._Name = nw.GetName(currentComputer._MAC);
            currentComputer._Ip = nw.GetIp();
            currentComputer._Os = nw.GetOs();
        }

        private void SendComputerToDb()
        {
            currentComputer._AuditNumber = audnum;
            try
            {
                Pgs.AddComputerAndOs(currentComputer);
                Pgs.AddSoftwareToComputer(currentComputer);
                Pgs.HardwareSoftwareToComputer(currentComputer);
            }
            catch(Exception ex)
            {
                CanselScan("Ошибка при попытке отправить данные на сервер:\n" + ex.Message);
                return;
            }
            FinishScan();
        }

        private void FinishScan()
        {
            btnSaveToTxt.Enabled = true;
            MessageBox.Show("Сканирование успешно завершено.", "Завершение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FillSoftware()
        {
            ComputerInformation ci = new ComputerInformation();
            List<Software> soft = ci.GetSoftwareCollection();
            foreach (Software s in soft)
            {
                currentComputer.AddSoftware(s);
            }
        }

        private void FillHardware()
        {
            List<string> view = new List<string>();
            ComputerInformation ci = new ComputerInformation();

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
            currentComputer.AddHardware(ci.GetSoundboard());
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
            this.Close();
        }

        private bool AskAudiotyNumber(out String number)
        {
            NumberAssign na = new NumberAssign();
            number = "";
            var result = na.ShowDialog();
            while (result == DialogResult.OK && !Pgs.CheckAuditoryNumber(na.Number))
            {
                MessageBox.Show("Аудитории с таким номером нет в базе данных. Пожалуйста, проверьте правильность введенных данных или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = na.ShowDialog();
            }
            if (result == DialogResult.OK)
            {
                number = na.Number;
                return true;
            }
            else
                return false;
        }
    }
}
