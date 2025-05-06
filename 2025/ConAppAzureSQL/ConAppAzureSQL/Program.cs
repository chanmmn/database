using Microsoft.Data.SqlClient;

namespace ConAppAzureSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Retrieving Products table...");
            RetrieveProducts();
        }

        static void RetrieveProducts()
        {
            string connectionString = "Server=servename.database.windows.net;Database=database;User Id=username;Password=password;";
            string query = "SELECT * FROM Products";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"{reader.GetName(i)}: {reader[i]} ");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
