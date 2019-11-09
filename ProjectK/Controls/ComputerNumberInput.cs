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
        private String number;
        private bool error;
        public delegate void NumberDelegate(String number);
        public event NumberDelegate onNumberApply;
        [Description("Номер компьютера"), Category("Data")]
        public String _Number
        {
            get { return number; }
            set { number = value; tbNumber.Text = number; }
        }

        public ComputerNumberInput()
        {
            InitializeComponent();
            error = true;
            number = "";
        }

        private void TbNumber_TextChanged(object sender, EventArgs e)
        {
            if (tbNumber.Text == "" || tbNumber.Text.Count(x => x == ' ') == tbNumber.Text.Length)
                error = true;
            else
            {
                error = false;
            }
            number = tbNumber.Text;
            
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
