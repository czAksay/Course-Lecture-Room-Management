using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProjectK
{
    public partial class MainForm : Form
    {
        LoginForm lf;
        bool closeApplication;

        public MainForm(LoginForm _lf)
        {
            InitializeComponent();
            lf = _lf;
            closeApplication = true;
            toolTipButtons.SetToolTip(btnScan, "Начать сканирование ПО и железа на компьютере.");
            toolTipButtons.SetToolTip(btnSettings, "Открыть конфигурационный файл приложения.");
            toolTipButtons.SetToolTip(btnSignOut, "Выйти из учетной записи и перейти к окну авторизации.");
            toolTipButtons.SetToolTip(btnDatabase, "Просмотр записей базы данных.");
            toolTipButtons.SetToolTip(btnReport, "Отправить заявку о неисправности.");
            if (User.Role == UserRole.Guest)
            {
                String auto_mode = User.Autonom ? " (offline)" : "";
                lblHello.Text = "Здравствуйте, Гость" + auto_mode + ".";
            }
            else
                lblHello.Text = $"Здравствуйте, {User.Name} ({User.Role})";
            toolTipButtons.SetToolTip(lblTitle, lblTitle.Text);
            toolTipButtons.SetToolTip(btnExit, "Закрыть приложение.");
            trgCurrentPc.onTriggered += PcViewChanged;
        }

        private void PcViewChanged()
        {
            rtbPcInfo.Visible = trgCurrentPc._CurrentState;
            computerExplorer1.Visible = !trgCurrentPc._CurrentState;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (closeApplication)
                Application.Exit();
        }

        private void btnRefreshComputers_Click(object sender, EventArgs e)
        {
            if (User.Autonom)
            {
                MessageBox.Show(User.AutonomWarning, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<Computer> computers = Pgs.GetNetworkComputerList();
            computerExplorer1.Clear();
            flpComputers.Controls.Clear();
            rtbPcInfo.Clear();
            foreach (Computer c in computers)
            {
                c.onComputerSelect += ComputerSelected;
                flpComputers.Controls.Add(c);
            }
            ResizeComputers();
        }

        private void ResizeComputers()
        {
            foreach(Computer c in flpComputers.Controls.OfType<Computer>())
            {
                int minus = flpComputers.VerticalScroll.Visible ? 25 : 8;
                c.Width = flpComputers.Width - minus;
            }
        }

        private void ComputerSelected(Computer computer)
        {
            if (computerExplorer1.SelectedComputer != computer)
            {
                computerExplorer1.SetComputer(computer);
                String[] titles = { "Имя:", "IP:", "MAC:", "Номер аудитории:"};
                rtbPcInfo.Text = $"{titles[0]} {computer._Name}\n{titles[1]} {computer._Ip}\n{titles[2]} {computer._MAC}\n{titles[3]} {computer._AuditNumber}";

                foreach(string title in titles)
                {
                    rtbPcInfo.SelectionStart = rtbPcInfo.Text.IndexOf(title);
                    rtbPcInfo.SelectionLength = title.Length;
                    rtbPcInfo.SelectionFont = new Font(rtbPcInfo.Font, FontStyle.Bold);
                }
                rtbPcInfo.SelectionLength = 0;
            }
        }

        private void BtnComputerFilter_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Возможность отфильтровать компьютеры (а может быть и нет!).");
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

        private void BtnScan_Click(object sender, EventArgs e)
        {
            ScanForm sf = new ScanForm();
            sf.ShowDialog();
            sf.Dispose();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Закрыть приложение?", "Ыы уверены?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (User.Autonom)
            {
                Label l = new Label();
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.Width = flpComputers.Width - 15;
                l.Height = 40;
                l.Font = btnRefreshComputers.Font;
                l.Text = "Автономный режим";
                flpComputers.Controls.Add(l);
            }
            else
                btnRefreshComputers_Click(null, null);
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
            DatabaseExplorer de = new DatabaseExplorer();
            de.ShowDialog();
            de.Dispose();
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            if (User.Autonom || User.Role == UserRole.Guest)
            {
                MessageBox.Show("Отправка заявки на ремонт может быть осуществленна лишь при входе в учетную запись!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ReportForm rf = new ReportForm();
            rf.ShowDialog();
            rf.Dispose();
        }
    }
}
