using Microsoft.Data.SqlClient;

namespace ConAppWriteXMLSql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string xmlFilePath = "XMLFileRemoveUTF8.xml";
            string connectionString = "Server=.;Database=poc;Integrated Security=True;TrustServerCertificate=true";
            int id = 2;

            // Read the XML file
            string xmlContent = File.ReadAllText(xmlFilePath);

            // Insert the XML into the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO tblMyXml (id, MyXml) VALUES (@id, @xml)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@xml", xmlContent);
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("XML inserted into the database successfully.");
        }
    }
}
