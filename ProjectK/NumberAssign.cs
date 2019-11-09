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
        String number;
        public String Number { get => number; }
        public NumberAssign()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            computerNumberInput1.onNumberApply += NumberApplied;
        }

        private void NumberApplied (String number)
        {
            this.number = number;
            this.DialogResult = DialogResult.OK;
        }
    }
}
