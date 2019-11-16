using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace ProjectK_Server1
{
    public partial class DatabaseExplorerControl : UserControl
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        NpgsqlDataAdapter da;

        String[] tables = { "appliances", "appliances_in_room", "cable", "cable_in_room", "cathedra", "component_in_computer",
            "component_parts", "computer", "course", "course_and_software", "keyboard_mouse", "keymse_in_room", "monitor",
            "monitor_and_computer", "netdevice_in_room", "network_device", "os", "os_and_software", "printer_scanner", "projector",
            "projector_in_room", "request_for_repair", "request_for_software_installation", "room", "rrsc_er_in_room", "software",
            "teacher", "users", };


        public DatabaseExplorerControl()
        {
            InitializeComponent();
            cbDbTable.Items.Clear();
            foreach (String t in tables)
            {
                cbDbTable.Items.Add(t);
            }
            cbDbTable.SelectedIndex = 0;
            dataGridView1.Font = new Font("Arial", 10);
        }

        public void RefreshGrid()
        {
            //String connectStr = "Server=localhost; Port=5432; User Id=postgres; Password=12345; Database=test;";
            string command = "SELECT * FROM " + cbDbTable.Text;
            da = Pgs.GetDataAdapter(command);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
        }

        private void CbDbTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(da);
                da.Update(ds);
                MessageBox.Show("Успешно.", "Хорошо", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
}
