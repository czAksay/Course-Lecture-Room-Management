using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using ProjectK.Core;

namespace ProjectK
{
    public partial class DatabaseExplorer : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        public DatabaseExplorer()
        {
            InitializeComponent();
        }

        private void DatabaseExplorer_Load(object sender, EventArgs e)
        {
            cbSelect.SelectedIndex = 0;
            RefreshDb();
        }

        private void RefreshDb()
        {
            try
            {
                NpgsqlDataAdapter da = Pgs.GetDataAdapter(cbSelect.SelectedIndex);
                ds.Reset();
                da.Fill(ds);
                dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                SetFont();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetFont()
        {
            dataGridView1.Font = new Font("Segoe UI Light", 10);
        }

        private void CbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDb();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDb();
        }
    }
}
