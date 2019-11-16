using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProjectK
{
    public enum ReportType { None, SoftInstall, ComponentRepair, EquipRepair};
    public partial class ReportPanelControl : UserControl
    {
        ReportType reporttype = ReportType.None;
        public delegate void ReportFinishHandler();
        public event ReportFinishHandler onReportFinished;
        String chosenComputerName = "";
        String selectedItem = "";
        int selectedEquipementType = -1;

        public ReportPanelControl()
        {
            InitializeComponent();
            rbInstall.CheckedChanged += ReportTypeChosen;
            rbRepairEquip.CheckedChanged += ReportTypeChosen;
            rbRepairComponent.CheckedChanged += ReportTypeChosen;
            rtbComment.TextChanged += (o, ea) => { CheckSendButton(); };
            tbFio.TextChanged += (o, ea) => { CheckSendButton(); };
            tbFio.TextChanged += (o, ea) => { CheckSendButton(); };
        }

        private void ReportTypeChosen(object o, EventArgs ea)
        {
            btnChoose.Enabled = true;
            if (o == rbRepairEquip)
            {
                btnChoose.Text = "Выбрать оборудование";
                reporttype = ReportType.EquipRepair;
            }
            else if (o == rbInstall)
            {
                btnChoose.Text = "Выбрать программное обеспечение";
                reporttype = ReportType.SoftInstall;
            }
            else if (o == rbRepairComponent)
            {
                btnChoose.Text = "Выбрать компонент";
                reporttype = ReportType.ComponentRepair;
            }
            CheckSendButton();
        }

        public void FillComputers()
        {
            List<String> computers = Pgs.GetComputerNames();
            int i = 0;
            foreach (String a in computers)
            {
                RadioButton rb = new RadioButton();
                rb.Font = rbInstall.Font;
                rb.Text = a;
                rb.Margin = new Padding(5, 3, 3, 0);
                rb.AutoSize = true;
                pnlAuditory.Controls.Add(rb);
                rb.CheckedChanged += (o, ea) =>
                {
                    if (!rbInstall.Checked)
                        selectedItem = "";
                    pnlReportType.Enabled = true;
                    chosenComputerName = rb.Text;
                    CheckSendButton();
                };
                if (i == 0)
                    rb.Checked = true;
                i++;
            }
            if (i == 0)
            {
                MessageBox.Show("Нет компьютеров в базе. Невозможно отослать заявку.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (onReportFinished != null)
                    onReportFinished();
            }
        }

        private void CheckSendButton()
        {
            btnSend.Enabled = rtbComment.Text != string.Empty && tbFio.Text != String.Empty && chosenComputerName != string.Empty && reporttype != ReportType.None && selectedItem != string.Empty;
            lblResult.Text = $"Компьютер: {chosenComputerName}, тип заявки: {reporttype}. Выбрано: {selectedItem}. ФИО: {tbFio.Text}, комментарий: {rtbComment.Text}.";
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            ReportItemChooseForm rcf = new ReportItemChooseForm(reporttype);
                var result = rcf.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    selectedItem = rcf.SelectedItem;
                    if (reporttype == ReportType.EquipRepair)
                    {
                        selectedEquipementType = rcf.SelectedEuipementType;
                    }
                    CheckSendButton();
                }
            rcf.Dispose();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            try
            {
                ComputerInformation ci = new ComputerInformation();
                Pgs.SendReport(ci.GetOs(), chosenComputerName, reporttype, selectedItem, selectedEquipementType, tbFio.Text, rtbComment.Text);
                MessageBox.Show("Заявка успешно отправлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (onReportFinished != null)
                    onReportFinished();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка отправки заявки: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
