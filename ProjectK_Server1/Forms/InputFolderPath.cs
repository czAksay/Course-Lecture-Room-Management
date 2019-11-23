using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ProjectK_Server1
{
    public partial class InputFolderPath : Form
    {
        public String Path { get { return tbPath.Text; } }
        public InputFolderPath()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(tbPath.Text))
            {
                DataManager.st.SetValue("webstore", tbPath.Text);
                DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            MessageBox.Show("Данная директория не существует или она не доступна!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
