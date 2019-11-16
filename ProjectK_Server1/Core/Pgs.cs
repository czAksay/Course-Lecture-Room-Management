using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace ProjectK_Server1
{
    public static class Pgs
    {
        static NpgsqlConnection connection;
        static NpgsqlCommand cmd;
        static NpgsqlDataReader dataReader;
        static readonly String databaseName = "universitydb3";

        public static NpgsqlConnection Connection {get {return connection; } }

        static private void _chkConnection()
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        static private void _chkDataReader()
        {
            if (dataReader != null && !dataReader.IsClosed)
            {
                dataReader.Close();
            }
        }


        static public bool CheckConnection()
        {
            return connection != null && connection.State == System.Data.ConnectionState.Open;
        }

        static public bool SetConnection(String ip, String port, String user, String password, String database)
        {
            try
            {
                _chkConnection();
                string connstring = String.Format("Server={0}; Port={1}; User Id={2}; Password={3}; Database={4};", ip, port, user, password, database);
                connection = new NpgsqlConnection(connstring);
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static List<string> GetAllComponentsInAuditory()
        {
            List<String> items = new List<string>();
            //Execute($"select cp.model from computer c join component_in_computer cc on cc.computer_name=c.computer_name join room r on r.id=c.audit_id " +
            //    $"join component_parts cp on cp.id=cc.component_id where r.number ILIKE '{auditoryNumber}';");
            Execute($"select model from component_parts;");
            while (dataReader.Read())
            {
                items.Add(dataReader[0].ToString());
            }
            return items;
        }

        internal static List<string> GetNetEquipInAuditory()
        {
            List<String> items = new List<string>();
            //Execute($"select nd.model from netdevice_in_room ndr join room r on ndr.audit_id=r.id " +
            //    $"join network_device nd on nd.id=ndr.netdevice_id where r.number ILIKE '{auditoryNumber}';");
            Execute($"select model from network_device;");
            while (dataReader.Read())
            {
                items.Add(dataReader[0].ToString());
            }
            return items;
        }

        internal static List<string> GetKeyboardMousesInAuditory()
        {
            List<String> items = new List<string>();
            //Execute($"select km.model from keymse_in_room kmr join room r on kmr.audit_id=r.id " +
            //    $"join keyboard_mouse km on km.id=kmr.keymse_id where r.number ILIKE '{auditoryNumber}';");
            Execute($"select model from keyboard_mouse;");
            while (dataReader.Read())
            {
                items.Add(dataReader[0].ToString());
            }
            return items;
        }

        internal static List<string> GetPrinterScannerInAuditory()
        {
            List<String> items = new List<string>();
            //Execute($"select ps.model from rrsc_er_in_room psr join room r on psr.audit_id=r.id " +
            //    $"join printer_scanner ps on ps.id=psr.prsc_er_id where r.number ILIKE '{auditoryNumber}';");
            Execute($"select model from printer_scanner;");
            while (dataReader.Read())
            {
                items.Add(dataReader[0].ToString());
            }
            return items;
        }

        internal static List<string> GetBitovayaTehnikaInAuditory()
        {
            List<String> items = new List<string>();
            //Execute($"select a.model from appliances_in_room ar join room r on ar.audit_id=r.id join " +
            //    $"appliances a on a.id=ar.appliances_id where r.number ILIKE '{auditoryNumber}';");
            Execute($"select model from appliances;");
            while (dataReader.Read())
            {
                items.Add(dataReader[0].ToString());
            }
            return items;
        }

        internal static void SendReport(string osName, string chosenComputerName, ReportType reporttype, string selectedItem, int selectedEquipementType, string fio, string comment)
        {
            Execute($"SELECT id FROM os WHERE name ILIKE '{osName}'");
            if (!dataReader.Read())
                throw new Exception("Отсутствует данная ОС в базе!");
            short os_id = (short)dataReader[0];
            switch (reporttype)
            {
                case ReportType.None:
                    throw new Exception("Невозможно добавить заявку с типом \"None\"!");
                case ReportType.SoftInstall:
                    Execute($"INSERT INTO request_for_software_installation (computer_name, os_id, program_id, date, fio, commentary) VALUES ('{chosenComputerName}', {os_id}, (SELECT id FROM software WHERE name ILIKE '{selectedItem}'), CAST('{DateTime.Now.ToString("dd.MM.yyyy")}' AS date), '{fio}', '{comment}');");
                    break;
                case ReportType.ComponentRepair:
                    Execute($"INSERT INTO request_for_repair (date, fio, commentary, computer_name, component_id) VALUES ( CAST('{DateTime.Now.ToString("dd.MM.yyyy")}' AS date), '{fio}', '{comment}', '{chosenComputerName}', (SELECT id FROM component_parts WHERE model ILIKE '{selectedItem}'));");
                    break;
                case ReportType.EquipRepair:
                    String equipTable = "";
                    String equipField = "";
                    switch(selectedEquipementType)
                    {
                        case 0:
                            equipTable = "cable";
                            equipField = "cable_id";
                            break;
                        case 1:
                            equipTable = "network_device";
                            equipField = "netdevice_id";
                            break;
                        case 2:
                            equipTable = "projector";
                            equipField = "projector_id";
                            break;
                        case 3:
                            equipTable = "appliances";
                            equipField = "appliances_id";
                            break;
                        case 4:
                            equipTable = "printer_scanner";
                            equipField = "prsc_er_id";
                            break;
                        case 5:
                            equipTable = "keyboard_mouse";
                            equipField = "keymse_id";
                            break;
                    }
                    Execute($"INSERT INTO request_for_repair (date, fio, commentary, computer_name, {equipField}) VALUES ( CAST('{DateTime.Now.ToString("dd.MM.yyyy")}' AS date), '{fio}', '{comment}', '{chosenComputerName}', (SELECT id FROM {equipTable} WHERE model ILIKE '{selectedItem}'));");
                    break;
            }
        }

        internal static List<string> GetProectorsInAuditory()
        {
            List<String> items = new List<string>();
            //Execute($"select p.model from projector_in_room pr join room r on pr.audit_id=r.id join " +
            //    $"projector p on p.id=pr.projector_id where r.number ILIKE '{auditoryNumber}';");
            Execute($"select model from projector;");
            while (dataReader.Read())
            {
                items.Add(dataReader[0].ToString());
            }
            return items;
        }

        internal static List<string> GetCabelsInAuditory()
        {
            List<String> items = new List<string>();
            //Execute($"select c.type from cable_in_room cr join room r on cr.audit_id=r.id " +
            //    $"join cable c on c.id=cr.cable_id where r.number ILIKE '{auditoryNumber}';");
            Execute($"select type from cable;");
            while (dataReader.Read())
            {
                items.Add(dataReader[0].ToString());
            }
            return items;
        }

        public static List<string> GetAllSoftwareList()
        {
            List<String> items = new List<string>();
            Execute("SELECT name FROM software ORDER BY name");
            while(dataReader.Read())
            {
                items.Add(dataReader[0].ToString());
            }
            return items;
        }

        static public bool SetUserCheckConnection(String ip, String port)
        {
            return SetConnection(ip, port, "user_check", "u1s2e3r4", databaseName);
        }

        static public bool SetDatabaseConnectionWithRole(String ip, String port, String role)
        {
            return SetConnection(ip, port, role.ToLower(), User.GetPassword, databaseName);
        }

        static public String GetUserRole(String login, String password)
        {
            String hashedpass = DataManager.getHashSha256(password);
            Execute($"SELECT role FROM users WHERE password = '{hashedpass}' AND login = '{login}'");
            if (!dataReader.Read())
                return "";
            else
                return dataReader[0].ToString();
        }

        static private void Execute(String command)
        {
            _chkDataReader();
            cmd = new NpgsqlCommand(command, connection);
            cmd.AllResultTypesAreUnknown = false;
            dataReader = cmd.ExecuteReader();
        }

        static private NpgsqlDataAdapter ExecuteDataAdapter(String command)
        {
            _chkDataReader();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command, connection);
            return da;
        }

        static public void AddComputerAndOs(Computer c)
        {
            Execute($"SELECT AddOrUpdatePc ('{c._Name}', CAST('{c._Ip}' AS inet), CAST('{c._MAC}' AS macaddr), '{c._AuditNumber}', '{c._Os}', 'Windows');");
        }

        //Проверяет, имеется ли номер аудитории в базе.
        static public bool CheckAuditoryNumber(String number)
        {
            Execute($"SELECT count(*)=1 FROM room WHERE lower(number) = lower('{number}');");
            dataReader.Read();
            return (bool)dataReader[0];
        }

        //Проверяет, имеется ли компьютер с таким MAC адресом в БД.
        static public bool CheckComputerExist(String mac, out String audit_number)
        {
            Execute($"SELECT audit_id FROM computer WHERE mac = CAST('{mac}' AS macaddr);");
            audit_number = "";
            if (!dataReader.Read())
                return false;
            Execute($"SELECT number FROM room WHERE id = {(short)dataReader[0]};");
            dataReader.Read();
            audit_number = dataReader[0].ToString();
            return true;
        }

        static public void AddSoftwareToComputer(Computer c)
        {
            String soft_string = DataManager.GetSoftwareString(c.Softwares);
            Execute($"SELECT AddSoftwareToPc('{c._Name}', ARRAY[{soft_string}], '{c._Os}' );");
        }

        static public void AddHardwareToComputer(Computer c)
        {
            String hard_string = DataManager.GetHardwareString(c.Hardwares);
            Execute($"SELECT AddHardwareToPc('{c._Name}', ARRAY[{hard_string}]);");
        }

        public static List<Computer> GetNetworkComputerList()
        {
            List<Computer> computers = new List<Computer>();
            Execute($"SELECT * FROM computer;");
            while (dataReader.Read())
            {
                Computer c = new Computer()
                {
                    _Name = dataReader[0].ToString(),
                    _AuditNumber = dataReader[2].ToString(),
                    _Ip = dataReader[3].ToString(),
                    _MAC = dataReader[4].ToString()
                };
                c._MAC = DataManager.AddMacPoints(c._MAC);
                computers.Add(c);
            }
            foreach(Computer c in computers)
            {
                Execute($"SELECT s.name FROM os_and_software oos JOIN computer c ON c.computer_name = oos.computer_name JOIN software s ON s.id=oos.program_id WHERE c.computer_name='{c._Name}';");
                while(dataReader.Read())
                {
                    Software s = new Software() { Name = dataReader[0].ToString() };
                    c.AddSoftware(s);
                }
                Execute($"SELECT cp.* FROM component_in_computer cc JOIN component_parts cp ON cp.id=cc.component_id WHERE computer_name = '{c._Name}';");
                HardwareType ht;
                while (dataReader.Read())
                {
                    Enum.TryParse(dataReader[2].ToString(), out ht);
                    Hardware h = new Hardware()
                    {
                        Model = dataReader[1].ToString(),
                        Type = ht,
                        Memory = dataReader[3].ToString() == "" ? 0 : (short)dataReader[3]
                    };
                    c.AddHardware(h);
                }
            }
            return computers;
        }

        public static NpgsqlDataAdapter GetDataAdapter(String command)
        {
            _chkDataReader();
            return new NpgsqlDataAdapter(command, Pgs.Connection);
        }

        public static NpgsqlDataAdapter GetDataAdapter(int tableIndex)
        {
            String cmd = "";
            switch(tableIndex)
            {
                case 0:
                    cmd = "SELECT course_name \"Название курса\" FROM course";
                    break;
                case 1:
                    cmd = "SELECT second_name \"Фамилия\", first_name \"Имя\", patronymic \"Отчество\", c.name \"Кафедра\" FROM teacher t JOIN cathedra c ON c.id=t.cathedra_id";
                    break;
                case 2:
                    cmd = "SELECT * FROM course_and_software";
                    break;
                case 3:
                    cmd = "SELECT computer_name \"Имя компьютера\", serial_number \"Серийный номер\", r.number \"Номер аудитории\", ip \"IP\", mac \"MAC\", status \"Статус\" FROM computer c JOIN room r ON r.id=c.audit_id";
                    break;
                case 4:
                    cmd = "SELECT name \"Название\" FROM software";
                    break;
                case 5:
                    cmd = "SELECT name \"Название\", type \"Семейство\", serial_os \"Серийный номер\" FROM os";
                    break;
                case 6:
                    cmd = "SELECT model \"Модель\", type \"Тип\", capacity \"Объем\" FROM component_parts";
                    break;
                case 7:
                    cmd = "SELECT number \"Номер\" FROM room";
                    break;
            }
            return ExecuteDataAdapter(cmd);
        }

        public static List<String> GetComputerNames()
        {
            Execute("SELECT computer_name FROM computer;");
            List<String> comps = new List<string>();
            while (dataReader.Read())
            {
                comps.Add(dataReader[0].ToString());
            }
            return comps;
        }
    }
}
