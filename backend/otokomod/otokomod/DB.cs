using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using GTANetworkAPI;
using MySql.Data.MySqlClient;

namespace otokomod
{
    class DB
    {
        private static MySqlConnection _connection;
        private String _host { get; set; }
        private String _user { get; set; }
        private String _pass { get; set; }
        private String _base { get; set; }

        private DB()
        {
            this._host = "localhost";
            this._user = "root";
            this._pass = "";
            this._base = "otoko_server_gta5";
        }

        public static void InitConnection()
        {
            DB sql = new DB();
            String SQLconnection = $"SERVER={sql._host}; DATABASE={sql._base}; UID={sql._user}; PASSWORD={sql._pass}";
            _connection = new MySqlConnection(SQLconnection);

            try
            {
                _connection.Open();
                NAPI.Util.ConsoleOutput("Successful database connection: " + sql._base);
            }
            catch (Exception ex)
            {
                NAPI.Util.ConsoleOutput("Unsuccessful database connection: " + sql._base);
                NAPI.Util.ConsoleOutput("Exception: " + ex.ToString());
                NAPI.Task.Run(() =>
                {
                    Environment.Exit(0);
                }, delayTime: 5000);

            }
        }

        public static bool IsAccountExist(string name)
        {
            MySqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT * FROM players_accounts WHERE name=@name LIMIT 1";
            command.Parameters.AddWithValue("@name", name);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    return true;
                }
                return false;
            }
        }

        public static void NewAccountRegister(Accounts account, string password) 
        {
            string saltPw = BCrypt.HashPassword(password, BCrypt.GenerateSalt());

            try
            {
                MySqlCommand command = _connection.CreateCommand();

                command.CommandText = "INSERT INTO players_accounts (pass, name, cash) VALUES (@pass, @name, @cash)";
                command.Parameters.AddWithValue("@pass", saltPw);
                command.Parameters.AddWithValue("@name", account._name);
                command.Parameters.AddWithValue("@cash", account._cash);

                command.ExecuteReader();

                account._id = (int)command.LastInsertedId;
            }
            catch (Exception ex)
            {
                NAPI.Util.ConsoleOutput("Exception: " + ex.ToString());
            }
        }

        public static void LoadAccount(Accounts account)
        {
            MySqlCommand command = _connection.CreateCommand();

            command.CommandText = "SELECT * FROM players_accounts WHERE name=@name LIMIT 1";
            command.Parameters.AddWithValue("@name", account._name);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    account._id = reader.GetInt32("id");
                    account._cash = reader.GetInt32("cash");
                }
                
            }
        }

        public static void SaveAccount(Accounts account)
        {
            MySqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE players_accounts SET cash=@cash WHERE id=@id";
            command.Parameters.AddWithValue("@cash", account._cash);
            command.Parameters.AddWithValue("@id", account._id);
        }

        public static bool IsValidPassword(string name, string inputPw) 
        {
            string tempPass = " ";

            MySqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT pass FROM players_accounts WHERE name=@name LIMIT 1";
            command.Parameters.AddWithValue("@name", name);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    tempPass = reader.GetString("pass");
                }
            }

            if(BCrypt.CheckPassword(inputPw, tempPass)) return true;
            return false;
        }
    }
}
