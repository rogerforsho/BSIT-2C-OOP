using System;
using MySql.Data.MySqlClient;

namespace ProgramDB
{

    public class insertusertoDB
    {
        public static class insertnewuser
        {
            private string server = "localhost";
            private string port = "3306";
            private string database = "useracc";
            private string uid = "root";
            private string password = "";
            private string connectionString;


            public insertnewuser()
            {
                connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";";
            }

            public void Insertuser(string username, string password)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("Connected to Database!");
                        string query = "INSERT INTO useracc (username, password) VALUES (@username, @password)";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@username", username);
                            command.Parameters.AddWithValue("@password", password);
                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine(rowsAffected > 0 ? "User added successfully!" : "Failed to add user.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }

            }
        }










    }
}

