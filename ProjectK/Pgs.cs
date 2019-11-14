using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace ProjectK
{
    public static class Pgs
    {
        static NpgsqlConnection connection;
        static NpgsqlCommand cmd;
        static NpgsqlDataReader dataReader;
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

        static public bool SetUsersDbConnection(String ip, String port)
        {
            return SetConnection(ip, port, "user_check", "u1s2e3r4", "usersdb");
        }

        static public bool SetUniversityDbConnection(String ip, String port, String role)
        {
            return SetConnection(ip, port, role.ToLower(), User.GetPassword, "universitydb2");
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
    }
}
