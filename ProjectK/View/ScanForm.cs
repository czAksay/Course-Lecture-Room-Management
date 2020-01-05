using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using ProjectK.Core;
using ProjectK.SoftwareHardware;
using ProjectK.View;
using ProjectK.Presenter;

namespace ProjectK
{
    public partial class ScanForm : Form, IScanView
    {
        String audnum;
        IScanPresenter presenter;

        public ScanForm()
        {
            InitializeComponent();
            lblState.Text = "Ожидание.";
            CreateComputer();
            presenter = new ScanPresenter(this);
            currentComputer.onComputerSelect += (computer) => Process.Start("control.exe", "System");
        }

        private void BtnStartScan_Click(object sender, EventArgs e)
        {
            SetProgress(0);
            DataManager.log.Log("Клиент: начало сканирования.");
            computerExplorer.Clear();
            try
            {
                Notify("Извлечение ПО");
                SetProgress(15);
                DataManager.log.Log("Клиент: начало извлечения ПО.");
                FillSoftware();
                computerExplorer.SetComputer(currentComputer);
                SetProgress(40);
                Notify("Извлечение комплектующих");
                SetProgress(45);
                DataManager.log.Log("Клиент: начало извлечения железа.");
                FillHardware();
                SetProgress(65);
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

            audnum = DataManager.st.GetValue("auditory_number");
            if (audnum == "null" || !Pgs.CheckAuditoryNumber(audnum))
            {
                Notify("Назначение аудитории");
                MessageBox.Show("Данному компьютеру необходимо назначить аудиторию, в которой он находится. Укажите это в следующем окне.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (!AskAudiotyNumber(out audnum))
                {
                    CanselScan("Данные не могут быть отправлены на сервер без указания номера аудитории.");
                    return;
                }
            }

            SetProgress(70);
            SendComputerToDb();
        }

        private void CanselScan(String message)
        {
            DataManager.log.Log("Клиент: завершение сканирования с ошибками.");
            MessageBox.Show(message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Notify("Завершение сканирования");
            FinishScan(false);
        }

        private void CreateComputer()
        {
            ComputerInformation nw = new ComputerInformation();
            currentComputer._MAC = nw.GetMACAddress();
            currentComputer._Name = nw.GetName();
            currentComputer._Ip = nw.GetIp();
            currentComputer._Os = nw.GetOs();
        }

        private void SendComputerToDb()
        {
            currentComputer._AuditNumber = audnum;

            DataManager.log.Log("Клиент: начало отправки данных на сервер.");
            try
            {
                SetProgress(72);
                Notify("Отправка данных о компьютере");
                DataManager.log.Log("Клиент: отправка данных о компьютере на сервер.");
                Pgs.AddComputerAndOs(currentComputer);
                SetProgress(75);
                Notify("Отправка ПО компьютера");
                DataManager.log.Log("Клиент: отправка данных о ПО компьютера на сервер.");
                Pgs.AddSoftwareToComputer(currentComputer);
                SetProgress(85);
                Notify("Отправка комплектующих компьютера");
                DataManager.log.Log("Клиент: отправка данных о комплектующих компьютера на сервер.");
                Pgs.AddHardwareToComputer(currentComputer);
                SetProgress(95);
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
            DataManager.log.Log("Клиент: успешное завершение сканирования.");
            FinishScan(true);
        }

        private void FinishScan(bool success)
        {
            btnSaveToTxt.Enabled = true;
            SetProgress(100);
            Notify("Готово");
            if (success)
                MessageBox.Show("Сканирование успешно завершено.", "Завершение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Сканирование завершено с ошибкой.", "Завершение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            //currentComputer.AddHardware(new Hardware()
            //{
            //    Model = currentComputer.Hardwares[2].Model,
            //    Memory = currentComputer.Hardwares[2].Memory,
            //    Type = currentComputer.Hardwares[2].Type
            //});
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
            this.Close();
        }

        private bool AskAudiotyNumber(out String number)
        {
            using (NumberAssign na = new NumberAssign())
            {
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
                    DataManager.st.SetValue("auditory_number", number);
                    return true;
                }
                else
                    return false;
            }
        }

        private void BtnSaveToTxt_Click(object sender, EventArgs e)
        {
            try
            {
                var result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false);
                    sw.WriteLine(currentComputer._Name);
                    sw.WriteLine("IP: " + currentComputer._Ip);
                    sw.WriteLine("MAC: " + currentComputer._MAC);
                    sw.WriteLine("##############################");
                    sw.WriteLine("Список программ: ");
                    foreach (Software s in currentComputer.Softwares)
                    {
                        sw.WriteLine(s.Name);
                    }
                    sw.WriteLine("##############################");
                    sw.WriteLine("Список комплектующих: ");
                    foreach (Hardware h in currentComputer.Hardwares)
                    {
                        String wrt = "";
                        wrt += $"{h.Model} [{h.Type.ToString()}]";
                        if (h.Type == HardwareType.RAM || h.Type == HardwareType.HDD)
                            wrt += $" ({h.Memory}Гб)";
                        sw.WriteLine(wrt);
                    }
                    sw.Close();
                    MessageBox.Show("Успешно сохранено по пути:\n" + saveFileDialog1.FileName + ".", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка сохранения отчета:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnChangeAuditoryNumber_Click(object sender, EventArgs e)
        {
            if (User.Role != UserRole.Admin)
            {
                MessageBox.Show("Невозможно изменить номер аудитории компьютера, не будучи администратором. Обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String num;
            if (!AskAudiotyNumber(out num))
            {
                MessageBox.Show("Номер аудитории не был назначен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Успешно.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Notify(String message)
        {
            lblState.Text = message;
            lblState.Update();
        }

        private void ScanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Notify("Закрытие...");
            for(int i = this.Controls.Count - 1; i>=0; i--)
            {
                if (this.Controls[i].Name != "lblState")
                {
                    this.Controls.Remove(this.Controls[i]);
                }
            }
        }

        private void SetProgress(int percent)
        {
            pbProgress.Value = percent;
            pbProgress.Update();
        }
    }
}
