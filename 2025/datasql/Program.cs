using Microsoft.Data.SqlClient;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        ReadProducts();
    }

    public static void ReadProducts()
    {
        var connectionString = "Server=172.24.222.191;Database=Northwind;User Id=sa;Password=password;TrustServerCertificate=true;";
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var command = new SqlCommand("SELECT TOP 10 * FROM Products", connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ProductID: {reader["ProductID"]}, ProductName: {reader["ProductName"]}");
                }
            }
        }
    }
}