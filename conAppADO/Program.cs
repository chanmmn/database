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
            //ReadTeacher();
            AddTeacher();
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

        public static void AddTeacher()
        {
            string strconn = "Server=.;Database=SchoolDB;User ID=mufg;Password=P2ssw0rd!@#;MultipleActiveResultSets=True;" ;
            string strSql = "INSERT INTO [dbo].[Teacher] " +
           "([TeacherName] " +
           ",[StandardId] " +
           ",[TeacherType]) " +
     "VALUES " +
           "(@TeacherName " +
           ",@StandardId " +
           ",@TeacherType)";
           SqlConnection conn = new SqlConnection(strconn);
            SqlCommand command = new SqlCommand(strSql,conn);
            conn.Open();

            IDbDataParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@TeacherName";
                parameter.DbType = DbType.String;
                parameter.Value = "Chan";
                command.Parameters.Add(parameter);

            parameter = command.CreateParameter();
                parameter.ParameterName = "@StandardId ";
                parameter.DbType = DbType.Int64;
                parameter.Value = 1;
                command.Parameters.Add(parameter);

            parameter = command.CreateParameter();
                parameter.ParameterName = "@TeacherType";
                parameter.DbType = DbType.Int64;
                parameter.Value = 1;
                command.Parameters.Add(parameter);

            command.ExecuteNonQuery();
            
            conn.Close();

        }
    }
}