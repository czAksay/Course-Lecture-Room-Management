using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ProjectK.SoftwareHardware;

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

            if (bw != null && bw.IsBusy)
            {
                return;
            }

            Clear();
            computer = c;
            c.onSoftwareAdded += DrawNewSoftware;
            c.onHardwareAdded += DrawNewHardware;
            
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

            DataManager.log.Log(@"Клиент: компьютер успешно установлен в качестве обозреваемого.");
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

        private void UpdateLabelText()
        {
            if (InvokeRequired)
                Invoke((Action)UpdateLabelText);
            else
            {
                lblCount.Text = "Количество: " + computer.Softwares.Count;
                lblCount.Update();
            }
        }

        private void UpdateRtbText(string text)
        {
            if (InvokeRequired)
                Invoke((Action<string>)UpdateRtbText, text);
            else
            {
                rtbSoftware.Text = text;
                rtbSoftware.Update();
            }
        }

        private void AsyncAddingToControl(List<Hardware> hs, List<Software> ss)
        {
            foreach(Hardware h in hs)
            {
                if (h == null)
                    continue;
                HardwareControl hc = new HardwareControl(h);
                hc.Width = flpComputerHardware.Width - 25;
                AddControlToFlow(flpComputerHardware, hc);
            }
            String soft = "";
            foreach (Software s in ss)
            {
                if (s == null)
                    continue;
                soft += s.Name + "\n";
            }
            //flpComputerSoftware.Controls.Count;
            UpdateRtbText(soft);
            UpdateLabelText();
        }


        private void PanelChanged()
        {
            if (trgHardSowt._CurrentState)
            {
                lblCount.Show();
                flpComputerHardware.Hide();
                rtbSoftware.Show();
            }
            else
            {
                lblCount.Hide();
                rtbSoftware.Hide();
                flpComputerHardware.Show();
            }
        }

        private void DrawNewSoftware(Software software)
        {
            if (software == null)
                return;
            rtbSoftware.Text += software.Name + "\n";
            this.Update();
            UpdateLabelText();
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
            //flpComputerSoftware.Controls.Clear();
            //lblSoftware.Text = "";
            rtbSoftware.Clear();
        }
    }
}
