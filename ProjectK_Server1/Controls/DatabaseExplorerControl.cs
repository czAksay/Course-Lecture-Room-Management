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
using System.Diagnostics;

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

        String[] tables_localed = { "Бытовая техника", "Бытовая техника в аудитории", "Кабель", "Кабеля в аудитории", "Кафедра", "Компоненты в компьютере",
            "Компонент ПК", "Компьютер", "Курс", "Курс и ПО", "Клавиатура/Мышь", "Клавиатуры/мыши в аудитории", "Монитор",
            "Мониторы у компьютеров", "Сетевые устройства в аудитории", "Сетевое устройство", "ОС", "Программы на компьютере", "Принтер/Сканер", "Проектор",
            "Проектор в аудитории", "Запрос на ремонт", "Запрос на установку ПО", "Аудитория", "Принтеры/Сканеры в аудитории", "ПО",
            "Преподаватели", "Пользователи", };


        public DatabaseExplorerControl()
        {
            InitializeComponent();
            cbDbTable.Items.Clear();
            foreach (String t in tables_localed)
            {
                cbDbTable.Items.Add(t);
            }
            cbDbTable.SelectedIndex = 0;
            dataGridView1.Font = new Font("Arial", 10);
            dataGridView1.DefaultValuesNeeded += DataGridView1_DefaultValuesNeeded;
        }

        private void DataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            foreach(DataGridViewCell cell in e.Row.Cells)
            {
                if (cell is DataGridViewCheckBoxCell && cell.Value == null)
                {
                    cell.Value = false;
                }
            }
        }

        private void FillComboBox(string header, string datapropertyname, string table_name, string value_member, string display_member)
        {
            DataGridViewComboBoxColumn c = new DataGridViewComboBoxColumn();
            c.HeaderText = header;
            c.DataPropertyName = datapropertyname;

            //string table_name = tables[cbDbTable.SelectedIndex];
            da = Pgs.GetDataAdapter("SELECT * FROM " + table_name);
            dt = new DataTable();
            da.Fill(dt);
            c.ValueMember = value_member;
            c.DisplayMember = display_member;
            c.DataSource = dt;
            c.FlatStyle = FlatStyle.Popup;
            dataGridView1.Columns.Add(c);
        }

        private void FillComboBox_Simple(string[] items, string header, string datapropertyname)
        {
            DataGridViewComboBoxColumn c = new DataGridViewComboBoxColumn();
            c.HeaderText = header;
            c.DataPropertyName = datapropertyname;
            dataGridView1.Columns.Add(c);

            c.DataSource = items;
        }

        private void FillTextBox(string header, string datapropertyname)
        {
            DataGridViewTextBoxColumn c = new DataGridViewTextBoxColumn();
            c.HeaderText = header;
            c.DataPropertyName = datapropertyname;
            dataGridView1.Columns.Add(c);
        }

        private void FillBoolBox(string header, string datapropertyname)
        {
            DataGridViewCheckBoxColumn c = new DataGridViewCheckBoxColumn();
            c.HeaderText = header;
            c.DataPropertyName = datapropertyname;
            
            dataGridView1.Columns.Add(c);
        }

        private void FillGridView()
        {
            string table_name = tables[cbDbTable.SelectedIndex];
            da = Pgs.GetDataAdapter("SELECT * FROM " + table_name);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        public void RefreshGrid()
        {
            dataGridView1.Columns.Clear();

            switch(cbDbTable.SelectedIndex)
            {
                //Бытовая техника
                case 0:
                    FillTextBox("Id", "id");
                    FillTextBox("Модель", "model");
                    break;
                //Бытовая техника ММ
                case 1:
                    FillComboBox("Бытовая техника", "appliances_id", "appliances", "id", "model");
                    FillComboBox("Аудитория", "audit_id", "room", "id", "number");
                    FillBoolBox("Статус", "status");
                    FillTextBox("Количество", "count");
                    FillTextBox("Цена", "price");
                    break;
                //Кабель 
                case 2:
                    FillTextBox("Id", "id");
                    FillTextBox("Тип", "type");
                    //FillComboBox_Simple(new string[] { "Schuko", "VGA", "HDMI", "DVI", "USB" }, "Тип", "type");
                    break;
                //Кабель ММ
                case 3:
                    FillComboBox("Кабель", "cable_id", "cable", "id", "type");
                    FillComboBox("Аудитория", "audit_id", "room", "id", "number");
                    FillTextBox("Длина", "length");
                    FillTextBox("Количество", "count");
                    FillTextBox("Цена", "price");
                    break;
                //Компонент ПК
                case 5:
                    FillTextBox("Id", "id");
                    FillComboBox("Компьютер", "computer_name", "computer", "computer_name", "computer_name");
                    FillComboBox("Компонент", "component_id", "component_parts", "id", "model");
                    FillBoolBox("Locked", "locked");
                    break;
                //Компонент ПК
                case 6:
                    FillTextBox("Id", "id");
                    FillTextBox("Модель", "model");
                    FillComboBox_Simple(new string[] { "CPU", "GPU", "Motherboard", "RAM", "Soundcard", "HDD" }, "Тип", "type");
                    FillTextBox("Объем", "capacity");
                    break;
                //Компьютер
                case 7:
                    FillTextBox("Имя", "computer_name");
                    FillTextBox("Серийный номер", "serial_number");
                    FillComboBox("Аудитория", "audit_id", "room", "id", "number");
                    FillTextBox("IP", "ip");
                    FillTextBox("MAC", "mac");
                    FillBoolBox("Статус", "status");
                    break;
                //Курс
                case 8:
                    FillTextBox("Id", "id");
                    FillTextBox("Название", "course_name");
                    break;
                //ОС на курсе
                case 9:
                    FillTextBox("Id", "id");
                    FillComboBox("Аудитория", "audit_id", "room", "id", "number");
                    FillComboBox("Курс", "course_id", "course", "id", "course_name");
                    FillComboBox("Программа", "program_id", "software", "id", "name");
                    FillComboBox("Преподаватель", "teacher_id", "teacher", "id", "second_name");
                    break;
                //Клавомыш
                case 10:
                    FillTextBox("Id", "id");
                    FillTextBox("Модель", "model");
                    FillComboBox_Simple(new string[] { "Keyboard", "Mouse" }, "Тип", "type");
                    break;
                //Клавомыш ММ
                case 11:
                    FillComboBox("Клавиатура/мышь", "keymse_id", "keyboard_mouse", "id", "model");
                    FillComboBox("Аудитория", "audit_id", "room", "id", "number");
                    FillTextBox("Количество", "count");
                    FillTextBox("Стоимость", "price");
                    FillBoolBox("Статус", "status");
                    break;
                //Монитор
                case 12:
                    FillTextBox("Серийный номер", "serial_number");
                    FillTextBox("Модель", "model");
                    FillComboBox_Simple(new string[] { "TFT TN", "TFT VA", "TFT IPS", "OLED"}, "Матрица", "matrix");
                    FillTextBox("Диагональ", "diagonal");
                    FillTextBox("Разрешение", "resolution");
                    FillBoolBox("Статус", "status");
                    break;
                //Монитор компьютер ММ
                case 13:
                    FillComboBox("Компьютер", "computer_name", "computer", "computer_name", "computer_name");
                    FillComboBox("Монитор", "monitor_id", "monitor", "serial_number", "model");
                    FillTextBox("Количество", "count");
                    FillTextBox("Стоимость", "price");
                    break;
                //Сетевое устройство ММ
                case 14:
                    FillComboBox("Сетевое устройство", "netdevice_id", "network_device", "id", "model");
                    FillComboBox("Аудитория", "audit_id", "room", "id", "number");
                    FillTextBox("Занятых портов", "busy_ports");
                    FillTextBox("Свободных портов", "free_ports");
                    FillTextBox("IP", "ip");
                    FillTextBox("MAC", "mac");
                    FillBoolBox("Статус", "status");
                    FillTextBox("Количество", "count");
                    FillTextBox("Стоимость", "price");
                    break;
                //Сетевое устройство
                case 15:
                    FillTextBox("Id", "id");
                    FillTextBox("Модель", "model");
                    FillTextBox("Всего портов", "total_ports");
                    FillComboBox_Simple(new string[] { "Router", "Switch", "Hub", "Repeater" }, "Тип", "type");
                    break;
                //ОС
                case 16:
                    FillTextBox("Id", "id");
                    FillTextBox("Название", "name");
                    FillTextBox("Серийный номер", "serial_os");
                    FillComboBox_Simple(new string[] { "Windows", "Linux" }, "Семейство", "type");
                    break;
                //ОС на ПК
                case 17:
                    FillComboBox("Компьютер", "computer_name", "computer", "computer_name", "computer_name");
                    FillComboBox("Программа", "program_id", "software", "id", "name");
                    FillComboBox("ОС", "os_id", "os", "id", "name");
                    FillTextBox("Путь", "path_exe");
                    FillBoolBox("Locked", "locked");
                    break;
                //Принтер/Сканер
                case 18:
                    FillTextBox("Id", "id");
                    FillTextBox("Модель", "model");
                    FillComboBox_Simple(new string[] { "Printer", "Scanner" }, "Тип", "type");
                    break;
                //Проектор
                case 19:
                    FillTextBox("Id", "id");
                    FillTextBox("Модель", "model");
                    break;
                //Проектор ММ
                case 20:
                    FillComboBox("Проектор", "projector_id", "projector", "id", "model");
                    FillComboBox("Аудитория", "audit_id", "room", "id", "number");
                    FillBoolBox("Статус", "status");
                    FillTextBox("Количество", "count");
                    FillTextBox("Стоимость", "price");
                    break;
                case 21:
                    FillTextBox("Id", "id");
                    FillTextBox("Дата", "date");
                    FillTextBox("ФИО", "fio");
                    FillTextBox("Комментарий", "commentary");
                    FillTextBox("Имя компьютера", "computer_name");
                    FillComboBox("Компонент", "component_id", "component_parts", "id", "model");
                    FillComboBox("Монитор", "monitor_id", "monitor", "serial_number", "model");
                    FillComboBox("Сетевое устройство", "netdevice_id", "network_device", "id", "model");
                    FillComboBox("Клавиатура/мышь", "keymse_id", "keyboard_mouse", "id", "model");
                    FillComboBox("Принтер/сканер", "prsc_er_id", "printer_scanner", "id", "model");
                    FillComboBox("Проектор", "projector_id", "projector", "id", "model");
                    FillComboBox("Бытовая техника", "appliances_id", "appliances", "id", "model");
                    FillComboBox("Кабель", "cable_id", "cable", "id", "type");
                    break;
                case 22:
                    FillTextBox("Id", "id");
                    FillTextBox("ФИО", "fio");
                    FillTextBox("Комментарий", "commentary");
                    FillComboBox("Компьютер", "computer_name", "computer", "computer_name", "computer_name");
                    FillComboBox("ОС", "os_id", "os", "id", "name");
                    FillComboBox("Программа", "program_id", "software", "id", "name");
                    FillTextBox("Дата", "date");
                    break;
                //Принтер сканер ММ
                case 24:
                    FillComboBox("Принтер/сканер", "prsc_er_id", "printer_scanner", "id", "model");
                    FillComboBox("Аудитория", "audit_id", "room", "id", "number");
                    FillBoolBox("Статус", "status");
                    FillTextBox("Количество", "count");
                    FillTextBox("Стоимость", "price");
                    break;
                //Преподаватель
                case 26:
                    FillTextBox("Id", "id");
                    FillTextBox("Имя", "first_name");
                    FillTextBox("Фамилия", "second_name");
                    FillTextBox("Отчество", "patronymic");
                    FillComboBox("Кафедра", "cathedra_id", "cathedra", "id", "name");
                    break;
                //Пользователи
                case 27:
                    FillTextBox("Логин", "login");
                    FillTextBox("Пароль", "password");
                    FillComboBox_Simple(new string[] { "admin", "lecturer" }, "Роль", "role");
                    break;

            }
            FillGridView();
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
                da.UpdateCommand = commandBuilder.GetUpdateCommand();
                //da.Update(ds);
                da.Update(dt);
                
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
