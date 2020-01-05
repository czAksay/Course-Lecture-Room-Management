using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using ProjectK.Core;
using ProjectK.View;
using ProjectK.Presenter;

namespace ProjectK
{
    public partial class MainForm : Form, IMainView
    {
        LoginForm lf;
        bool closeApplication;
        IMainPresenter presenter;

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
            toolTipButtons.SetToolTip(btnExit, "Закрыть приложение.");
            trgCurrentPc.onTriggered += PcViewChanged;

            presenter = new MainPresenter(this);
            presenter.CheckUserName();
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
            presenter.RefreshComputers();
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
            presenter.ComputerSelected(computer, computerExplorer1, rtbPcInfo);
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

        public void SetHelloLabel(string Text)
        {
            lblHello.Text = Text;
            toolTipButtons.SetToolTip(lblTitle, lblTitle.Text);
        }

        public void RefreshComputers(List<Computer> computers)
        {
            computerExplorer1.Clear();
            flpComputers.Controls.Clear();
            rtbPcInfo.Clear();
            if (computers.Count == 0)
            {
                Label l = new Label();
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.Width = flpComputers.Width - 15;
                l.Height = 40;
                l.Font = btnRefreshComputers.Font;
                l.Text = "Нет компьютеров в базе";
                flpComputers.Controls.Add(l);
            }
            foreach (Computer c in computers)
            {
                c.onComputerSelect += ComputerSelected;
                flpComputers.Controls.Add(c);
            }
            ResizeComputers();
        }
    }
}
