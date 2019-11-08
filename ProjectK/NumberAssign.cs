using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectK
{
    public partial class NumberAssign : Form
    {
        public NumberAssign()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            computerNumberInput1.onNumberApply += NumberApplied;
        }

        private void NumberApplied (int number)
        {
            Properties.Settings.Default.computerNumber = number;
            Properties.Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
        }
    }
}
