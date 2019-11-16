using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ProjectK
{
    public partial class ComputerExplorer : UserControl
    {
        Computer computer;
        BackgroundWorker bw;

        public ComputerExplorer()
        {
            InitializeComponent();
            trgHardSowt.onTriggered += PanelChanged;
        }

        public Computer SelectedComputer { get { return computer; } }
        public bool IsDrawing { get { return bw == null ? bw.IsBusy : false; } }

        public void SetComputer(Computer c)
        {
            if (c == null)
                throw new Exception("Set computer must be not null!");
            //if (IsDrawing)
            //    throw new Exception("Cannot assign new computer while drawing another one!");
            if (bw != null && bw.IsBusy)
            {
                return;
                //bw.CancelAsync();
            }
            computer = c;
            c.onSoftwareAdded += DrawNewSoftware;
            c.onHardwareAdded += DrawNewHardware;
            flpComputerHardware.Controls.Clear();
            flpComputerSoftware.Controls.Clear();
            //DrawNewHardware(c.Cpu);
            //DrawNewHardware(c.Motherboard);
            //DrawNewHardware(c.Soundboard);
            List<Hardware> hs = new List<Hardware>();
            hs.Add(c.Cpu);
            hs.Add(c.Motherboard);
            hs.AddRange(c.Ram);
            hs.AddRange(c.Gpu);
            hs.AddRange(c.Hdd);
            hs.Add(c.Soundboard);


            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += (obj, ea) => AsyncAddingToControl(hs, c.Softwares);
            bw.RunWorkerAsync();

            //AsyncAddingToControl(hs, c.Softwares);
            //foreach (Hardware h in hs)
            //    DrawNewHardware(h);
            //foreach (Software s in c.Softwares)
            //    DrawNewSoftware(s);
        }




        private void AddControlToFlow(FlowLayoutPanel flow, Control control)
        {
            if (InvokeRequired)
                Invoke((Action<FlowLayoutPanel, Control>)AddControlToFlow, flow, control);
            else
            {
                flow.Controls.Add(control);
                flow.Update();
                this.Update();
            }
        }

        private void AsyncAddingToControl(List<Hardware> hs, List<Software> ss)
        {
            foreach(Hardware h in hs)
            {
                if (h == null)
                    break;
                HardwareControl hc = new HardwareControl(h);
                hc.Width = flpComputerHardware.Width - 25;
                AddControlToFlow(flpComputerHardware, hc);
            }
            foreach (Software s in ss)
            {
                if (s == null)
                    break;
                SoftwareControl sc = new SoftwareControl(s);
                sc.Width = flpComputerHardware.Width - 25;
                AddControlToFlow(flpComputerSoftware, sc);
            }
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

            SoftwareControl sc = new SoftwareControl(software);
            sc.Width = flpComputerHardware.Width - 25;
            //flpComputerSoftware.Controls.Add(sc);
            AddControlToFlow(flpComputerSoftware, sc);

            //flpComputerSoftware.Update();
            this.Update();
        }

        private void DrawNewHardware(Hardware hardware)
        {
            if (hardware == null)
                return;

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

        private void FlpComputerSoftware_ControlAdded(object sender, ControlEventArgs e)
        {
            lblCount.Text = "Количество: " + flpComputerSoftware.Controls.Count;
        }
    }
}
