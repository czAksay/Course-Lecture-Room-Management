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
            currentComputer.onComputerSelect += (computer) => Process.Start("control.exe", "System"); 
            //StartScan();
        }

        private void CreateComputer()
        {
            ComputerInformation nw = new ComputerInformation();
            currentComputer._MAC = nw.GetMACAddress();
            currentComputer._Name = nw.GetName(currentComputer._MAC);
            currentComputer._Ip = nw.GetIp();
            currentComputer._Os = nw.GetOs();
        }

        private void BtnStartScan_Click(object sender, EventArgs e)
        {
            computerExplorer.Clear();
            FillSoftware();
            FillHardware();

            if (User.Autonom)
            {
                MessageBox.Show(User.AutonomWarning + "\nДанные не были отправлены на сервер.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FinishScan();
                return;
            }
            String audit_num = DataManager.st.GetValue("auditory_number");
            if (audit_num == "null" || Pgs.CheckAuditoryNumber(audit_num))
            {
                if (!AskAudiotyNumber())
                {
                    MessageBox.Show("Данные не могут быть отправлены на сервер без указания номера аудитории.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FinishScan();
                    return;
                }
            }
            SendComputerToDb();
            FinishScan();
        }

        private void SendComputerToDb()
        {
            Pgs.AddComputerAndOs(currentComputer);
            //сначала удали все старые софты для текущей ос
            //Pgs.AddSoftwareToComputer(currentComputer);
            //сначала удали все старые харды 
            //Pgs.HardwareSoftwareToComputer(currentComputer);
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

        private bool AskAudiotyNumber()
        {
            if (User.Role == UserRole.Guest)
            {
                MessageBox.Show("Компьютер не привязан к какой-либо аудитории. Это не позволит отправить данные компьютера на сервер. Учетная запись \"Гость\" не может назначать компьютер к аудитории. Обратитесь к администратору.", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return false;
            }
            var result = MessageBox.Show("Компьютер не привязан к какой-либо аудитории. Это не позволит отправить данные компьютера на сервер. Вы желаете указать номер аудитории прямо сейчас?", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return false;
            }
            else
            {
                NumberAssign na = new NumberAssign();
                result = na.ShowDialog();
                String number = na.Number;
                if (result == DialogResult.OK)
                {
                    if (Pgs.CheckAuditoryNumber(number))
                    {
                        DataManager.st.SetValue("auditory_number", number);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Данной аудитории нет в базе данных. Пожалуйста, проверьте правильность данных или обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                    return false;
            }
        }
    }
}
