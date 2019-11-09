using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ProjectK
{
    static class Pgs
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
            return SetConnection(ip, port, "admin", "a1d2m3i4n5", "universitydb");
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

        static public void Execute(String command)
        {
            _chkDataReader();
            cmd = new NpgsqlCommand(command, connection);
            cmd.AllResultTypesAreUnknown = false;
            dataReader = cmd.ExecuteReader();
        }

        //static public int GetComputerNumber(String mac)
        //{
        //    NpgsqlDataReader reader = Execute($"SELECT serial_number FROM computer WHERE mac = CAST ('{mac}' AS macaddr);");
        //    if (!reader.Read())
        //        return -1;
        //    else
        //        return Int32.Parse(reader[0].ToString());
        //}

        static public void AddComputerAndOs(Computer computer)
        {
            Execute($"SELECT AddOrUpdatePc ( CAST('{computer._MAC}' AS macaddr), CAST('{computer._Ip}' AS inet), '{computer._Name}', '{computer._Os}' )");
            dataReader.Read();
            int a = (int)dataReader[0];
            int b = 2;
        }

        static public bool CheckAuditoryNumber(String number)
        {
            Execute($"SELECT count(*)=1 FROM room WHERE lower(number) = '{number.ToLower()}';");
            dataReader.Read();
            //String aaaaa = dataReader[0].ToString();
            bool res = (bool)dataReader[0];
            return res;
        }
    }
}
