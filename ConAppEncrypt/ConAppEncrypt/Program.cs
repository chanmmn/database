using System;
using System.Data.SqlClient;

namespace ConAppEncrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TestTDS();
        }

        public static void TestTDS()
        {
            string connectionString = "Server=172.29.99.222;Database=northwind;User ID=sa;Password=password;MultipleActiveResultSets=True;Encrypt=Yes;TrustServerCertificate=Yes";
            //string connectionString = "Server=172.29.99.222;Database=northwind;User ID=sa;Password=password;MultipleActiveResultSets=True;";
            string strSql = "SELECT TOP 10 * FROM Products";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader rd = cmd.ExecuteReader();
        }
    }
}
