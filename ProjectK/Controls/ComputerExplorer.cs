using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectK
{
    public partial class ComputerExplorer : UserControl
    {
        Computer computer;
        public ComputerExplorer()
        {
            InitializeComponent();
            trgHardSowt.onTriggered += PanelChanged;
        }

        public void SetComputer(Computer c)
        {
            if (c == null)
                throw new Exception("Set computer must be not null!");
            computer = c;
            c.onSoftwareAdded += DrawNewSoftware;
            c.onHardwareAdded += DrawNewHardware;
        }

        private void PanelChanged()
        {
            if (trgHardSowt._CurrentState)
            {
                lblCount.Show();
                flpComputerSoftware.Show();
                flpComputerHardware.Hide();
            }
            else
            {
                lblCount.Hide();
                flpComputerSoftware.Hide();
                flpComputerHardware.Show();
            }
        }

        private void DrawNewSoftware(Software software)
        {
            Label l = new Label();
            l.Font = new Font("Segoe UI Light", 11);
            l.AutoSize = true;
            l.Text = software.Name;
            l.BorderStyle = BorderStyle.FixedSingle;
            flpComputerSoftware.Controls.Add(l);
            flpComputerSoftware.Update();
            lblCount.Text = "Количество: " + flpComputerSoftware.Controls.Count;
            this.Update();
        }

        private void DrawNewHardware(Hardware hardware)
        {
            Label l = new Label();
            l.Font = new Font("Segoe UI Light", 11);
            l.AutoSize = true;
            l.Text = hardware.Model;
            l.BorderStyle = BorderStyle.FixedSingle;
            flpComputerHardware.Controls.Add(l);
            flpComputerHardware.Update();
            this.Update();
        }

        public void Clear()
        {
            computer = null;
            flpComputerHardware.Controls.Clear();
            flpComputerSoftware.Controls.Clear();
        }
    }
}
