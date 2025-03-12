using System;
using MySql.Data.MySqlClient;

/* MEMBERS:
CHAVOSO
CALDERON
CAGUIOA
FERMIN
MORALES
SOLIGUEN
VICENTE */

namespace ProgramDB
{

    public class ManageUseracc
    {

        public static class DatabaseConfig
        {
            public static string ConnectionString = "server=localhost;database=programdb;user=root;password=;";
        }

        public class insertnewuser
        {
            private string server = "localhost";
            private string database = "programdb";
            private string uid = "root";
            private string dbpassword = "";
            private string connectionString;


            public insertnewuser()
            {
                connectionString = $"Server={server};Database={database};User Id={uid};Password={dbpassword};";
            }

            public void Insertuser(string username, string password)
            {
                using (MySqlConnection connection = new MySqlConnection(DatabaseConfig.ConnectionString))
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
                            Console.WriteLine(rowsAffected > 0 ? "Database Is Working" : "Database Is Working");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine($"MySQL Error: {ex.Message}");
                        Console.WriteLine("Error Code: " + ex.Number);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("General Error: " + ex.ToString());
                    }
                }

            }
        }
    }


    public class LogUseracc
    {
        public static bool UserLogin(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(ManageUseracc.DatabaseConfig.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT password FROM useracc WHERE username = @username";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPassword = reader.GetString("password");

                                if (password == storedPassword)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex}");
                }
            }
            return false;
        }
    }



    public class Addproduct
    {

        public static class DatabaseConfig
        {
            public static string ConnectionString = "server=localhost;database=programdb;user=root;password=;";
        }

        public void Insertproduct(string product_name, int product_price, int product_quantity, string product_description)
        {

            using (MySqlConnection connection = new MySqlConnection(DatabaseConfig.ConnectionString))
            {
                try
                {
                    connection.Open();
                    {
                        Console.WriteLine("Connected to Database!");
                        string query = "INSERT INTO products (product_name, product_price, product_quantity, product_description) VALUES (@product_name, @product_price, @product_quantity, @product_description)";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@product_name", product_name);
                            command.Parameters.AddWithValue("@product_price", product_price);
                            command.Parameters.AddWithValue("@product_quantity", product_quantity);
                            command.Parameters.AddWithValue("@product_description", product_description);
                            int rowsAffected = command.ExecuteNonQuery();
                            Console.WriteLine(rowsAffected > 0 ? "Database Is Working" : "Database Is Working");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySQL Error: {ex.Message}");
                    Console.WriteLine("Error Code: " + ex.Number);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("General Error: " + ex.ToString());
                }
            }
        }
    }

    public class ProductUpdate
    {
        public static string ConnectionString = "server=localhost;database=programdb;user=root;password=;";

        public void UpdateProduct(int productId, string newName, double newPrice, int newQuantity, string newDescription)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Database Connected!");

                    string query = "UPDATE products SET product_name = @name, product_price = @price, product_quantity = @quantity, product_description = @description WHERE product_id = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name", newName);
                        command.Parameters.AddWithValue("@price", newPrice);
                        command.Parameters.AddWithValue("@quantity", newQuantity);
                        command.Parameters.AddWithValue("@description", newDescription);
                        command.Parameters.AddWithValue("@id", productId);

                        Console.WriteLine($"Executing Query: {query}");
                        Console.WriteLine($"With Parameters: ID={productId}, Name={newName}, Price={newPrice}, Quantity={newQuantity}, Description={newDescription}");

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Product updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("No product found with that ID. Update failed.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                }
            }
        }
    }



    public class ProductDelete
    {
        public static string ConnectionString = "server=localhost;database=programdb;user=root;password=;";

        public void DeleteProduct(int productId)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM products WHERE product_id = @id";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", productId);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Product deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("No product found with that ID.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                }
            }
        }
    }


    public class EcommerceProduct
    {
        private static string connectionString = "server=localhost;database=programdb;user=root;password=;";

        public static List<string[]> GetProducts()
        {
            List<string[]> products = new List<string[]>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT product_id, product_name, product_price, product_quantity, product_description FROM products";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new string[]
                            {
                        reader["product_id"].ToString(),     // Include Product ID
                        reader["product_name"].ToString(),
                        reader["product_price"].ToString(),
                        reader["product_quantity"].ToString(),
                        reader["product_description"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Database Error: {ex.Message}");
                }
            }
            return products;
        }


    }
}