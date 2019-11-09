using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            List<Computer> computers = DataManager.GetComputerList();
            foreach (Computer c in computers)
            {
                c.Width = flpComputers.Width - 25;
                c.onComputerSelect += ComputerSelected;
                flpComputers.Controls.Add(c);
            }
        }

        private void ComputerSelected(Computer computer)
        {
            Label l = new Label();
            Computer c = computer;
            l.Font = lblTitle.Font;
            l.AutoSize = true;
            l.Text = "";
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
            //var result = MessageBox.Show("Вы уверены, что хотите провести сканирование? Это может занять некоторое время.", "Сканирование", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    ScanForm sf = new ScanForm();
            //    sf.ShowDialog();
            //}
            ScanForm sf = new ScanForm();
            sf.ShowDialog();
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
                l.Width = flpComputers.Width - 5;
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
    }
}
