using Microsoft.Data.SqlClient;

namespace ConAppDownloadSqlXml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Call the method to download XML content to files
            DownloadXmlToFiles();
        }

        static void DownloadXmlToFiles()
        {
            string connectionString = "Server=.;Database=poc;Integrated Security=True;TrustServerCertificate=true";
            string tableName = "tblMyXml";
            string columnName = "MyXml";
            string directoryPath = "path_to_save_xml_files";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Retrieve the XML content from the database
                string query = $"SELECT {columnName} FROM {tableName}";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                int fileCount = 0;

                while (reader.Read())
                {
                    // Get the XML content from the column
                    string xmlContent = reader.GetString(0);

                    // Generate a unique file name
                    string fileName = $"xml_file_{fileCount}.xml";
                    string filePath = Path.Combine(directoryPath, fileName);

                    // Save the XML content to a file
                    File.WriteAllText(filePath, xmlContent);

                    Console.WriteLine($"XML content downloaded to file: {fileName}");

                    fileCount++;
                }

                if (fileCount == 0)
                {
                    Console.WriteLine("No XML content found in the database.");
                }
                else
                {
                    Console.WriteLine($"Total {fileCount} XML files downloaded successfully.");
                }

                reader.Close();
            }
        }
    }
}
