using System;
using Microsoft.Data.SqlClient;
using System.Data;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Fonts;

namespace ExportToPDF
{    
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=localhost;Database=northwind;Trusted_Connection=True;TrustServerCertificate=true";
            string query = "SELECT * FROM customers";
            //DataTable dataTable = new DataTable();
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    using (SqlCommand command = new SqlCommand(query, connection))
            //    {
            //        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
            //        {
            //            dataAdapter.Fill(dataTable);
            //        }
            //    }
            //}
            GlobalFontSettings.FontResolver = new FileSystemFontResolver();
            string fileName = "customers.pdf";
            //string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
            string filePath = @"c:\temp\customers.pdf";
            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "Customers";
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Arial", 10, XFontStyleEx.Regular);
            int yPoint = 100;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //        for (int i = 0; i < dataTable.Columns.Count; i++)
                        //{
                        //    graph.DrawString(dataTable.Columns[i].ColumnName, font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        //    yPoint += 40;
                        //}
                        //for (int i = 0; i < dataTable.Rows.Count; i++)
                        //{
                        //    yPoint += 40;
                        //    for (int j = 0; j < dataTable.Columns.Count; j++)
                        //    {
                        //        graph.DrawString(dataTable.Rows[i][j].ToString(), font, XBrushes.Black, new XRect(40, yPoint, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                        //        yPoint += 40;
                        //    }
                        //}
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            graph.DrawString(reader.GetName(i), font, XBrushes.Black, new XPoint(20, yPoint));
                            yPoint += 20;
                        }
                        // Add data rows
                        while (reader.Read())
                        {
                            //---------- try to add new page ---------------
                            pdfPage = pdf.AddPage();
                            graph = XGraphics.FromPdfPage(pdfPage);
                            //----------------------------------------------
                            yPoint += 20;
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                graph.DrawString(Convert.ToString(reader[i]), font, XBrushes.Black, new XPoint(20, yPoint));
                                yPoint += 20;
                            }
                            //---------- try to add new page
                            yPoint = 20;
                            //----------------------------------------------
                        }
                        pdf.Save(filePath);
                        Console.WriteLine("Customers table exported to PDF file successfully!");
                    }
                }
            }
        }
        public class FileSystemFontResolver : IFontResolver
        {
            public byte[] GetFont(string faceName)
            {
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), faceName + ".ttf");
                return File.ReadAllBytes(fontPath);
            }
            public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
            {
                string fontName = familyName;
                if (isBold && isItalic)
                {
                    fontName += " Bold Italic";
                }
                else if (isBold)
                {
                    fontName += " Bold";
                }
                else if (isItalic)
                {
                    fontName += " Italic";
                }

                return new FontResolverInfo(fontName);
            }
        }
    }
}
