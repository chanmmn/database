using System;
using System.Data;
using System.Data.SqlClient;

//using System.Linq;

    namespace conAppADO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            ReadTeacher();
            Console.ReadLine();
        }

        public static void ReadTeacher()
        {
            string strconn = "Server=.;Database=SchoolDB;User ID=mufg;Password=P2ssw0rd!@#;MultipleActiveResultSets=True;" ;
            string strSql = "SELECT * FROM TEACHER";
            SqlConnection conn = new SqlConnection(strconn);
            SqlCommand cmd = new SqlCommand(strSql,conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())

            {

                Console.WriteLine("{0}", dr[1].ToString());

            }

            conn.Close();
        }
    }
}