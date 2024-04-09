using Microsoft.SqlServer.Dac;
using System;

namespace CreateBacpac
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set the connection string for the source database
            //string connectionString = "Data Source=localhost;Initial Catalog=b2c-staging;Integrated Security=True;TrustServerCertificate=true";
            string connectionString = "Data Source=localhost;Initial Catalog=b2c-staging;User ID=sa;Password=Pa$$w0rd;TrustServerCertificate=true";
            // Set the path for the bacpac file
            string bacpacFilePath = "C:/vscode/CreateBacpac/b2c-staging.dacpac";
            DacServices dacServices = new DacServices(connectionString);
            try
            {
                  // Create a DacServices instance
              
                    // Generate the bacpac file
                    dacServices.ExportBacpac(bacpacFilePath, "b2c-staging");
            

                Console.WriteLine("Bacpac file generated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error generating bacpac file: " + ex.Message);
            }
        }
    }
}
