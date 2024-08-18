using Microsoft.Data.SqlClient;

namespace ConAppScriptData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=.;Database=Northwind;Integrated Security=True;TrustServerCertificate=true";
            string tableName = "Products";
            string outputFilePath = "output.sql";

            ExtractDataToInsertStatements(connectionString, tableName, outputFilePath);

            Console.WriteLine("Data extraction completed.");
        }

        static void ExtractDataToInsertStatements(string connectionString, string tableName, string outputFilePath)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = $"SELECT * FROM {tableName}";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        using (StreamWriter writer = new StreamWriter(outputFilePath))
                        {
                            while (reader.Read())
                            {
                                string insertStatement = $"INSERT INTO {tableName} VALUES (";

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    object value = reader.GetValue(i);

                                    if (value == DBNull.Value)
                                    {
                                        insertStatement += "NULL";
                                    }
                                    else if (value is string)
                                    {
                                        insertStatement += $"'{value}'";
                                    }
                                    else if (value is DateTime)
                                    {
                                        insertStatement += $"'{((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss")}'";
                                    }
                                    else
                                    {
                                        insertStatement += value;
                                    }

                                    if (i < reader.FieldCount - 1)
                                    {
                                        insertStatement += ", ";
                                    }
                                }

                                insertStatement += ");";

                                writer.WriteLine(insertStatement);
                            }
                        }
                    }
                }
            }
        }
    }
}
