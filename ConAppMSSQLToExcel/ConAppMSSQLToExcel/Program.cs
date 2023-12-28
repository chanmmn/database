using System;
using Microsoft.Data.SqlClient;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace ConAppMSSQLToExcel
{
    class Program
    {
        static void Main()
        {
            string connectionString = @"Server=localhost;Database=northwind;Trusted_Connection=True;TrustServerCertificate=true";
            string query = "SELECT * FROM Customers"; // Adjust the query accordingly
            string excelFilePath = "Customers.xlsx";

            ExportToExcel(connectionString, query, excelFilePath);

            Console.WriteLine("Export completed successfully.");
        }

        static void ExportToExcel(string connectionString, string query, string excelFilePath)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        IWorkbook workbook = new XSSFWorkbook();
                        ISheet sheet = workbook.CreateSheet("Customers");

                        // Add header row
                        IRow headerRow = sheet.CreateRow(0);
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            headerRow.CreateCell(i).SetCellValue(reader.GetName(i));
                        }

                        // Add data rows
                        int rowNumber = 1;
                        while (reader.Read())
                        {
                            IRow dataRow = sheet.CreateRow(rowNumber++);
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                dataRow.CreateCell(i).SetCellValue(Convert.ToString(reader[i]));
                            }
                        }

                        // Save the Excel file
                        using (FileStream fileStream = new FileStream(excelFilePath, FileMode.Create, FileAccess.Write))
                        {
                            workbook.Write(fileStream);
                        }
                    }
                }
            }
        }
    }
}

