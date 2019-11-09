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

        public Computer SelectedComputer { get { return computer; } }

        public void SetComputer(Computer c)
        {
            if (c == null)
                throw new Exception("Set computer must be not null!");
            computer = c;
            c.onSoftwareAdded += DrawNewSoftware;
            c.onHardwareAdded += DrawNewHardware;
            flpComputerHardware.Controls.Clear();
            flpComputerSoftware.Controls.Clear();
            DrawNewHardware(c.Cpu);
            DrawNewHardware(c.Motherboard);
            List<Hardware> hs = new List<Hardware>();
            hs.AddRange(c.Ram);
            hs.AddRange(c.Gpu);
            hs.AddRange(c.Hdd);
            DrawNewHardware(c.Soundboard);
            foreach (Hardware h in hs)
                DrawNewHardware(h);
            foreach (Software s in c.Softwares)
                DrawNewSoftware(s);
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
            if (software == null)
                return;
            //Label l = new Label();
            //l.Font = new Font("Segoe UI Light", 11);
            //l.AutoSize = true;
            //l.Text = software.Name;
            //l.BorderStyle = BorderStyle.FixedSingle;
            //flpComputerSoftware.Controls.Add(l);
            SoftwareControl sc = new SoftwareControl(software);
            sc.Width = flpComputerHardware.Width - 25;
            flpComputerSoftware.Controls.Add(sc);

            lblCount.Text = "Количество: " + flpComputerSoftware.Controls.Count;
            flpComputerSoftware.Update();
            this.Update();
        }

        private void DrawNewHardware(Hardware hardware)
        {
            if (hardware == null)
                return;
            //Label l = new Label();
            //l.Font = new Font("Segoe UI Light", 11);
            //l.AutoSize = true;
            //l.Text = hardware.Model;
            //l.BorderStyle = BorderStyle.FixedSingle;
            //flpComputerHardware.Controls.Add(l);

            HardwareControl hc = new HardwareControl(hardware);
            hc.Width = flpComputerHardware.Width - 25;
            flpComputerHardware.Controls.Add(hc);

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
