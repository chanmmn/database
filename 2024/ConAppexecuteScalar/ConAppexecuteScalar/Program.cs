using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace NorthwindExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadExecuteScalar();
        }

        private static void ReadExecuteScalar()
        {
            string connectionString = "Data Source = localhost; Initial Catalog = Northwind; User ID = sa; Password = password; TrustServerCertificate = true"; // Replace with your actual connection string
            string sqlQuery = "SELECT ProductName FROM Products WHERE ProductID = 1"; // Assuming you want the product name from the first record

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        string productName = result.ToString();
                        Console.WriteLine($"Product Name: {productName}");
                    }
                    else
                    {
                        Console.WriteLine("No product found.");
                    }
                }
            }
        }
    }
}
