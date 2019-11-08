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
    public partial class Computer : UserControl
    {
        String ip;
        int number;
        String mac;
        Color mouseEnterColor;
        List<Software> programs;

        CPU cpu;
        List<GPU> gpu;
        List<RAM> ram;
        List<HDD> hdd;
        Motherboard motherboard;
        Soundboard soundboard;
        PowerSupply powerSupply;

        CPU Cpu { get { return cpu; } }
        List<GPU> Gpu { get { return gpu; } }
        List<RAM> Ram { get { return ram; } }
        List<HDD> Hdd { get { return hdd; } }
        Motherboard Motherboard { get { return motherboard; } }
        Soundboard Soundboard { get { return soundboard; } }
        PowerSupply PowerSupply { get { return powerSupply; } }


        public delegate void SelectHandler(Computer computer);
        public event SelectHandler onComputerSelect;
        public delegate void SoftwareHandler(Software software);
        public event SoftwareHandler onSoftwareAdded;
        public delegate void HardwareHandler(Hardware hardware);
        public event HardwareHandler onHardwareAdded;

        [Description("Номер компьютера"), Category("Data")]
        public int _Number
        {
            get { return number; }
            set { number = value;
                String a_n = "";
                if (number < 0)
                    a_n = " N/I";
                else
                    a_n = number.ToString();
                    lblNumber.Text = "Компьютер №" + a_n; }
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


        public Computer() : this(0, "0.0.0.0") { }

        public Computer(int _number, String _ip)
        {
            InitializeComponent();
            programs = new List<Software>();
            _Number = _number;
            _Ip = _ip;
            foreach (Control c in this.Controls)
            {
                ControlsEvents(c);
            }
            mouseEnterColor = Color.FromArgb(240, 240, 240);
            _MAC = "A1:B2:C3:D4";
            hdd = new List<HDD>();
            ram = new List<RAM>();
            gpu = new List<GPU>();
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

            if (hardware is CPU)
            {
                cpu = (CPU)hardware;
            }
            else if (hardware is GPU)
            {
                gpu.Add((GPU)hardware);
            }
            else if (hardware is RAM)
            {
                ram.Add((RAM)hardware);
            }
            else if (hardware is HDD)
            {
                hdd.Add((HDD)hardware);
            }
            else if (hardware is Motherboard)
            {
                motherboard = (Motherboard)hardware;
            }
            else if (hardware is Soundboard)
            {
                soundboard = (Soundboard)hardware;
            }
            else if (hardware is PowerSupply)
            {
                powerSupply = (PowerSupply)hardware;
            }

            if (onHardwareAdded != null)
                onHardwareAdded(hardware);
        }
    }
}
