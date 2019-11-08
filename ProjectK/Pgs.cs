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
            //change
            return SetConnection(ip, port, "user_check", "u1s2e3r4", "usersdb");
        }

        static public String GetUserRole(String login, String password)
        {
            _chkDataReader();
            String hashedpass = DataManager.getHashSha256(password);
            NpgsqlDataReader reader = Execute($"SELECT role FROM users WHERE password = '{hashedpass}' AND login = '{login}'");
            if (!reader.Read())
                return "";
            else
                return reader[0].ToString();
        }

        static public NpgsqlDataReader Execute(String command)
        {
            _chkDataReader();
            cmd = new NpgsqlCommand(command, connection);
            cmd.AllResultTypesAreUnknown = true;
            return dataReader = cmd.ExecuteReader();
        }
    }
}
