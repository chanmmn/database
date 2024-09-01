using Microsoft.Data.SqlClient;

namespace ConAppCompareTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString1 = "Data Source=.;Initial Catalog=northwind;Integrated Security=True;TrustServerCertificate=true";
            string connectionString2 = "Data Source=.;Initial Catalog=northwindrepl;Integrated Security=True;TrustServerCertificate=true";

            string outputFilePath = "comparison_results.txt";

            CompareProductsTable(connectionString1, connectionString2, outputFilePath);

            Console.WriteLine("Comparison completed. Results written to " + outputFilePath);
        }

        static void CompareProductsTable(string connectionString1, string connectionString2, string outputFilePath)
        {
            using (SqlConnection connection1 = new SqlConnection(connectionString1))
            using (SqlConnection connection2 = new SqlConnection(connectionString2))
            {
                connection1.Open();
                connection2.Open();
                string query = "SELECT * FROM [dbo].[Products] WHERE ProductID IN (SELECT ProductID " +
                    "FROM  [NorthwindRepl].[dbo].[Products]) ORDER BY ProductID";
                string query1 = "SELECT * FROM [dbo].[Products] WHERE ProductID IN (SELECT ProductID " +
                    "FROM  [Northwind].[dbo].[Products]) ORDER BY ProductID";

                using (SqlCommand command1 = new SqlCommand(query, connection1))
                using (SqlCommand command2 = new SqlCommand(query1, connection2))
                using (SqlDataReader reader1 = command1.ExecuteReader())
                using (SqlDataReader reader2 = command2.ExecuteReader())
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    while (reader1.Read() && reader2.Read())
                    {
                        for (int i = 0; i < reader1.FieldCount; i++)
                        {
                            object value1 = reader1[i];
                            object value2 = reader2[i];

                            if (!value1.Equals(value2))
                            {
                                string columnName = reader1.GetName(i);
                                string rowNumber = (reader1.RecordsAffected + 1).ToString();

                                string comparisonResult = $"Mismatch found in column '{columnName}' at row {rowNumber}: {value1} != {value2}";

                                writer.WriteLine(comparisonResult);
                            }
                        }
                    }
                }
            }
        }
    }
}
