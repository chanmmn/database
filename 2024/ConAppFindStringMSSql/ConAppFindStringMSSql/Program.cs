using Microsoft.Data.SqlClient;
using System;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=localhost;Initial Catalog=northwind;Integrated Security=True;TrustServerCertificate=true";
        string searchString = "Chai";

        SqlCommand command1 = new SqlCommand();
        SqlConnection connection1 = new SqlConnection(connectionString);
        connection1.Open();
        command1.Connection = connection1;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT c.TABLE_NAME, c.COLUMN_NAME " +
                "FROM INFORMATION_SCHEMA.COLUMNS c " +
                "INNER JOIN INFORMATION_SCHEMA.TABLES t ON c.TABLE_NAME = t.TABLE_NAME WHERE c.DATA_TYPE IN ('varchar', 'nvarchar') AND t.TABLE_TYPE = 'BASE TABLE'";

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string tableName = reader.GetString(0);
                string columnName = reader.GetString(1);

                command1.CommandText = $"SELECT * FROM [{tableName}] WHERE [{columnName}] LIKE '%{searchString}%'";

                SqlDataReader innerReader = command1.ExecuteReader();

                while (innerReader.Read())
                {
                    Console.WriteLine($"Found '{searchString}' in {tableName}.{columnName}");
                }

                innerReader.Close();
            }

            reader.Close();
        }
        connection1.Close();
    }
}
