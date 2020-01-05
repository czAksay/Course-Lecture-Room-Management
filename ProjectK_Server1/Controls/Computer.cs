using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ProjectK.SoftwareHardware;

namespace ProjectK_Server1
{
    public partial class Computer : UserControl
    {
        String ip;
        String name;
        String mac;
        Color mouseEnterColor;
        List<Software> programs;
        public String os;

        Hardware cpu, motherboard, soundboard;
        List<Hardware> gpu, ram, hdd;

        public Hardware Cpu { get => cpu;  }
        public Hardware Motherboard { get => motherboard;  }
        public Hardware Soundboard { get => soundboard; }
        public List<Hardware> Gpu { get => gpu;  }
        public List<Hardware> Ram { get => ram; }
        public List<Hardware> Hdd { get => hdd; }
        public List<Software> Softwares { get => programs; }
        public String _AuditNumber { get; set; }
        public List<Hardware> Hardwares { get
            {
                List<Hardware> hs = new List<Hardware>();
                hs.Add(cpu);
                hs.Add(motherboard);
                hs.AddRange(ram);
                hs.AddRange(gpu);
                hs.AddRange(hdd);
                hs.Add(soundboard);
                for (int i = hs.Count - 1; i >= 0; i --)
                {
                    if (hs[i] == null)
                    {
                        hs.RemoveAt(i);
                    }
                }
                return hs;
                    } }

        public delegate void SelectHandler(Computer computer);
        public event SelectHandler onComputerSelect;
        public delegate void SoftwareHandler(Software software);
        public event SoftwareHandler onSoftwareAdded;
        public delegate void HardwareHandler(Hardware hardware);
        public event HardwareHandler onHardwareAdded;

        [Description("Имя компьютера"), Category("Data")]
        public String _Name
        {
            get { return name; }
            set { name = value;
                lblNumber.Text = "Компьютер " + name; }
        }

        [Description("MAC компьютера"), Category("Data")]
        public String _MAC
        {
            get { return mac; }
            set { mac = value; lblMac.Text = "MAC: " + mac; }
        }

        [Description("Цвет при наведении мыши"), Category("Data")]
        public Color _MouseEnterColor
        {
            get { return mouseEnterColor; }
            set { mouseEnterColor = value; }
        }

        [Description("IP компьютера"), Category("Data")]
        public String _Ip
        {
            get { return ip; }
            set { ip = value; lblIp.Text = "IP: " + ip; }
        }

        [Description("ОС компьютера"), Category("Data")]
        public String _Os
        {
            get { return os; }
            set { os = value; lblOs.Text = "ОС: " + os; lblOs.Visible = true; }
        }


        public Computer() : this("PC-NoName", "0.0.0.0") { }

        public Computer(String _name, String _ip)
        {
            InitializeComponent();
            programs = new List<Software>();
            _Name = _name;
            _Ip = _ip;
            foreach (Control c in this.Controls)
            {
                ControlsEvents(c);
            }
            mouseEnterColor = Color.FromArgb(240, 240, 240);
            _MAC = "A1:B2:C3:D4";
            hdd = new List<Hardware>();
            ram = new List<Hardware>();
            gpu = new List<Hardware>();
        }

        private void ControlsEvents(Control control)
        {
            foreach (Control c in control.Controls)
            {
                c.Click += new EventHandler(Computer_Click);
                c.MouseEnter += new EventHandler(Computer_MouseEnter);
                c.MouseLeave += new EventHandler(Computer_MouseLeave);
                ControlsEvents(c);
            }
        }

        private void Computer_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = mouseEnterColor;
        }

        private void Computer_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void Computer_Click(object sender, EventArgs e)
        {
            if (onComputerSelect != null)
                onComputerSelect(this);
        }

        public void AddSoftware(Software software)
        {
            if (software == null)
                throw new Exception("Software is null!");
            programs.Add(software);
            if (onSoftwareAdded != null)
                onSoftwareAdded(software);
        }

        public void AddHardware(Hardware hardware)
        {
            if (hardware == null)
                throw new Exception("Hardware is null!");

            switch (hardware.Type)
            {
                case HardwareType.CPU: cpu = hardware; break;
                case HardwareType.GPU: gpu.Add(hardware); break;
                case HardwareType.RAM: ram.Add(hardware); break;
                case HardwareType.HDD: hdd.Add(hardware); break;
                case HardwareType.Motherboard: motherboard = hardware; break;
                case HardwareType.Soundcard: soundboard = hardware; break;
            }


            if (onHardwareAdded != null)
                onHardwareAdded(hardware);
        }
    }
}
