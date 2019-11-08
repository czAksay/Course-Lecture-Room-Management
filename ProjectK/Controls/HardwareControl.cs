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
    public partial class HardwareControl : UserControl
    {
        Hardware hardware;
        public HardwareControl()
        {
            InitializeComponent();
        }

        public HardwareControl(Hardware hardware)
        {
            InitializeComponent();
            this.hardware = hardware;
            switch (hardware.Type)
            {
                case HardwareType.CPU:
                    pbHardwareIcon.Image = Properties.Resources.cpu;
                    lblTitle.Text = "ЦПУ";
                    lblModel.Text = hardware.Model;
                    break;
                case HardwareType.RAM:
                    pbHardwareIcon.Image = Properties.Resources.ram;
                    lblTitle.Text = "ОЗУ";
                    lblModel.Text = hardware.Model + " (" + hardware.Memory+ "Гб)";
                    break;
                case HardwareType.GPU:
                    pbHardwareIcon.Image = Properties.Resources.gpu;
                    lblTitle.Text = "ГПУ";
                    lblModel.Text = hardware.Model;
                    break;
                case HardwareType.HDD:
                    pbHardwareIcon.Image = Properties.Resources.hdd;
                    lblTitle.Text = "Жесткий диск";
                    lblModel.Text = hardware.Model + " (" + hardware.Memory + "Гб)";
                    break;
                case HardwareType.Soundboard:
                    pbHardwareIcon.Image = Properties.Resources.soundboard;
                    lblTitle.Text = "Звуковая плата";
                    lblModel.Text = hardware.Model;
                    break;
                case HardwareType.Motherboard:
                    pbHardwareIcon.Image = Properties.Resources.motherboard;
                    lblTitle.Text = "Материнская плата";
                    lblModel.Text = hardware.Model;
                    break;
            }
        }
    }
}
