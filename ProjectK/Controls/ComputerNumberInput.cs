using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectK.Controls
{
    public partial class ComputerNumberInput : UserControl
    {
        private int number;
        private bool error;
        public delegate void NumberDelegate(int number);
        public event NumberDelegate onNumberApply;
        [Description("Номер компьютера"), Category("Data")]
        public int _Number
        {
            get { return number; }
            set { number = value; tbNumber.Text = number.ToString(); }
        }

        public ComputerNumberInput()
        {
            InitializeComponent();
            error = true;
            number = 0;
        }

        private void TbNumber_TextChanged(object sender, EventArgs e)
        {
            int num;
            bool parsed = Int32.TryParse(tbNumber.Text, out num);
            if (tbNumber.Text == "" || !parsed || num < 0)
                error = true;
            else
            {
                number = num;
                error = false;
            }
            
            lblError.Visible = error;
            btnApply.Enabled = !error;
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (!error && onNumberApply != null)
            {
                onNumberApply(number);
            }
        }
    }
}
