using System.Windows.Forms;

namespace ProjectK
{
    public partial class SoftwareControl : UserControl
    {
        Software software;
        public SoftwareControl()
        {
            InitializeComponent();
        }

        public SoftwareControl(Software software) : this()
        {
            this.software = software;
            lblName.Text = software.Name;
            toolTip1.SetToolTip(lblName, lblName.Text);
        }
    }
}
