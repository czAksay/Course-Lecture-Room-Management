using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjectK.Core;

namespace ProjectK
{
    public partial class ReportItemChooseForm : Form
    {
        List<string> items;
        String selectedItem = "";

        public String SelectedItem { get { return selectedItem; } }
        public int SelectedEuipementType { get { return cbEquipType.SelectedIndex; } }

        public ReportItemChooseForm(ReportType rt)
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
            items = new List<string>();
            cbEquipType.SelectedIndex = 0;
            switch (rt)
            {
                case ReportType.None:
                    throw new Exception("Тип заявки не указан!");
                case ReportType.SoftInstall:
                    items = Pgs.GetAllSoftwareList();
                    lblTitle.Text += "программу";
                    break;
                case ReportType.ComponentRepair:
                    items = Pgs.GetAllPcComponents();
                    lblTitle.Text += "компонент";
                    break;
                case ReportType.EquipRepair:
                    cbEquipType.Visible = true;
                    cbEquipType.SelectedIndexChanged += (o, ea) => { RefreshEquipements(); };
                    RefreshEquipements();
                    break;
            }
            FillPanel(items);
        }

        private void RefreshEquipements()
        {
            selectedItem = "";
            switch(cbEquipType.SelectedIndex)
            {
                case 0:
                    items = Pgs.GetCabels();
                    break;
                case 1:
                    items = Pgs.GetNetEquip();
                    break;
                case 2:
                    items = Pgs.GetProectors();
                    break;
                case 3:
                    items = Pgs.GetBitovayaTehnika();
                    break;
                case 4:
                    items = Pgs.GetPrinterScanner();
                    break;
                case 5:
                    items = Pgs.GetKeyboardMouses();
                    break;
            }
            FillPanel(items);
        }

        private void FillPanel(List<String> items)
        {
            flowLayoutPanel1.Controls.Clear();
            List<RadioButton> rbs = new List<RadioButton>();
            foreach(String s in items)
            {
                RadioButton rb = new RadioButton();
                rb.Font = btnSelect.Font;
                rb.Text = s;
                rb.AutoSize = true;
                rb.Margin = new Padding(3, 3, 3, 0);
                rbs.Add(rb);
                //flowLayoutPanel1.Controls.Add(rb);
                rb.CheckedChanged += (o, ea) =>
                {
                    selectedItem = rb.Text;
                };
            }
            flowLayoutPanel1.Controls.AddRange(rbs.ToArray());
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (selectedItem == "")
            {
                MessageBox.Show("Не выбран ни один элемент!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
