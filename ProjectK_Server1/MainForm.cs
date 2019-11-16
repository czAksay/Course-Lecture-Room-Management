using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading.Tasks;
using System.IO;

namespace ProjectK_Server1
{
    public partial class MainForm : Form
    {
        LoginForm lf;
        bool closeApplication;
        Computer currentComputer;
        ReportPanelControl rpc;
        DatabaseExplorerControl dec;

        public MainForm(LoginForm _lf)
        {
            InitializeComponent();
            lf = _lf;
            closeApplication = true;
            toolTipButtons.SetToolTip(btnSignOut, "Выйти из учетной записи и перейти к окну авторизации.");
            toolTipButtons.SetToolTip(btnDatabase, "Просмотр записей базы данных.");
            toolTipButtons.SetToolTip(btnReport, "Отправить заявку о неисправности.");
            lblHello.Text = $"Здравствуйте, {User.Name} ({User.Role})";
            toolTipButtons.SetToolTip(lblTitle, lblTitle.Text);
            toolTipButtons.SetToolTip(btnExit, "Закрыть приложение.");
        }

        private void FillHardware(Computer computer)
        {
            List<string> view = new List<string>();
            ComputerInformation ci = new ComputerInformation();
            ci.ScanFromCpuZ();
            computer.AddHardware(ci.GetCpu());
            computer.AddHardware(ci.GetMotherboard());
            foreach (Hardware h in ci.GetGpus())
            {
                computer.AddHardware(h);
            }
            foreach (Hardware h in ci.GetRams())
            {
                computer.AddHardware(h);
            }
            foreach (Hardware h in ci.GetHdds())
            {
                computer.AddHardware(h);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closeApplication)
                Application.Exit();
        }

        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти из учетной записи?", "Уже уходите?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                closeApplication = false;
                lf.Show();
                lf.ResetForm();
                this.Close();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Закрыть приложение?", "Ыы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ComputerInformation ci = new ComputerInformation();
            currentComputer = new Computer()
            {
                _Name = ci.GetName(),
                _Ip = ci.GetIp(),
                _MAC = ci.GetMACAddress(),
                _Os = ci.GetOs(),
                Width = flpServerInfo.Width - 8,
                Height = 90
            };
            flpServerInfo.Controls.Add(currentComputer);

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += (obj, ea) => SetServerInformation();
            bw.RunWorkerAsync();
        }

        private void SetServerInformation()
        {
            try
            {
                FillHardware(currentComputer);
                foreach (Hardware h in currentComputer.Hardwares)
                {
                    HardwareControl hc = new HardwareControl(h);
                    hc.Width = flpServerInfo.Width - 8;
                    //flpServerInfo.Controls.Add(hc);
                    AddControlAsync(flpServerInfo, hc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при попытке сканирования комплектующих ПК.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddControlAsync(FlowLayoutPanel flow, Control control)
        {
            if (InvokeRequired)
                Invoke((Action<FlowLayoutPanel, Control>)AddControlAsync, flow, control);
            else
            {
                flow.Controls.Add(control);
                flow.Update();
                this.Update();
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("settings.ini");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDatabase_Click(object sender, EventArgs e)
        {
            ClearPanels();
            dec = new DatabaseExplorerControl();
            dec.RefreshGrid();
            dec.Size = new Size(695, 510);
            dec.Location = new Point(347, 54);
            //dec.onReportFinished += FinishReport;
            this.Controls.Add(dec);
        }

        private void ClearPanels()
        {
            if (rpc != null)
                this.Controls.Remove(rpc);
            if (dec != null)
                this.Controls.Remove(dec);
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            ClearPanels();
            rpc = new ReportPanelControl();
            rpc.FillComputers();
            rpc.Size = new Size(695, 510);
            rpc.Location = new Point(347, 54);
            rpc.onReportFinished += FinishReport;
            this.Controls.Add(rpc);
        }

        private void FinishReport()
        {
            if (rpc != null)
                this.Controls.Remove(rpc);
        }

        private void BtnRefreshComputers_Click_1(object sender, EventArgs e)
        {
            EquipementObserverForm eo = new EquipementObserverForm();
            eo.ShowDialog();
            eo.Dispose();
        }

        private void btnOpenWebStor_Click(object sender, EventArgs e)
        {
            String path = DataManager.st.GetValue("webstore");
            if (Directory.Exists(path))
            {
                Process.Start("explorer.exe", path);
            }
            else
            {
                if (MessageBox.Show("Путь к сетевому диску не установлен или не верен. Желаете ввести путь?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    InputFolderPath ifp = new InputFolderPath();
                    if (ifp.ShowDialog() == DialogResult.OK && Directory.Exists(ifp.Path))
                    {
                        Process.Start("explorer.exe", path);
                    }
                }
            }
        }
    }
}
