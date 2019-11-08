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

namespace ProjectK
{
    public partial class ScanForm : Form
    {
        public ScanForm()
        {
            InitializeComponent();
            lblState.Text = "Ожидание.";
            computerExplorer.SetComputer(currentComputer);
            CreateComputer();
            //StartScan();
        }

        //private void ScanForm_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (isWorking)
        //    {
        //        var result = MessageBox.Show("Процесс сканирования не завершен. Вы уверены, что хотите отменить его?", "Подождите", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        //        if  (result == DialogResult.No)
        //        {
        //            e.Cancel = true;
        //        }
        //    }
        //}

        private void CreateComputer()
        {
            currentComputer._Number = Properties.Settings.Default.computerNumber;
            ComputerInformation nw = new ComputerInformation();
            currentComputer._Ip = nw.GetIp();
            currentComputer._MAC = nw.GetMACAddress();
        }

        private void BtnStartScan_Click(object sender, EventArgs e)
        {
            computerExplorer.Clear();
            FillSoftware();
            FillHardware();

            if (User.Auronom)
            {
                MessageBox.Show(User.AutonomWarning + "\nДанные не были отправлены на сервер.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FinishScan();
                return;
            }
            if (Properties.Settings.Default.computerNumber == -1)
            {
                if (User.Role != UserRole.Admin)
                {
                    MessageBox.Show("Данному компьютеру не был назначен номер. Для отправки данных на сервер, необходимо чтобы компьютеру был присвоен номер. Пожалуйста, свяжитесь с администратором или подождите, пока он сам не вспомнит об этом.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    FinishScan();
                    return;
                }
                else
                {
                    var result = MessageBox.Show("Данному компьютеру не был назначен номер.Для отправки данных на сервер, необходимо чтобы компьютеру был присвоен номер. Хотите сделать это прямо сейчас?", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.No)
                    {
                        FinishScan();
                        return;
                    }
                    else
                    {
                        NumberAssign na = new NumberAssign();
                        result = na.ShowDialog();
                        if (result == DialogResult.Cancel)
                        {
                            MessageBox.Show("Номер не был присвоен. Данные не будут отправлены на сервер.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (result == DialogResult.OK)
                        {
                            currentComputer._Number = Properties.Settings.Default.computerNumber;
                            SendComputerToDb();
                        }
                    }
                }
            }

            FinishScan();
        }

        private void SendComputerToDb()
        {

        }

        private void FinishScan()
        {
            btnSaveToTxt.Enabled = true;
            MessageBox.Show("Сканирование успешно завершено.", "Завершение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FillSoftware()
        {
            ComputerInformation ci = new ComputerInformation();
            List<string> soft = ci.GetSoftwareCollection();
            foreach (String s in soft)
            {
                Software software = new Software();
                software.Name = s;
                currentComputer.AddSoftware(software);
            }
        }

        private void FillHardware()
        {
            List<string> view = new List<string>();
            ComputerInformation ci = new ComputerInformation();

            currentComputer.AddHardware(ci.GetCpu());
            currentComputer.AddHardware(ci.GetMotherboard());
            currentComputer.AddHardware(ci.GetSoundboard());
            foreach (Hardware h in ci.GetGpus())
            {
                currentComputer.AddHardware(h);
            }
            foreach (Hardware h in ci.GetHdds())
            {
                currentComputer.AddHardware(h);
            }
            foreach (Hardware h in ci.GetRams())
            {
                currentComputer.AddHardware(h);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
            this.Close();
        }
    }
}
