using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppCallSPCursor
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "data source =.; initial catalog = test; integrated security = True";
            SqlConnection lSQLConn = null;

            //Declare a DataAdapter and a DataSet
            //SqlDataAdapter lDA = new SqlDataAdapter();
            //DataSet lDS = new DataSet();

            ////...Execution section

            //// create and open a connection object
            lSQLConn = new SqlConnection(connStr);
            lSQLConn.Open();
            SqlCommand lSQLCmd = new SqlCommand("PrintCustomers_Cursor1", lSQLConn);
            //The CommandType must be StoredProcedure if we are using an ExecuteScalar
            lSQLCmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = lSQLCmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine("{0}", dr[0].ToString());
                Console.WriteLine("{0}", dr[1].ToString());
                Console.WriteLine("{0}", dr[2].ToString());
                dr.NextResult();
            }
            //lSQLCmd.CommandText = "PrintCustomers_Cursor1";

            //using (SqlConnection Connection = new SqlConnection(connStr))
            //{
            //    SqlCommand Command = new SqlCommand("PrintCustomers_Cursor1", Connection);
            //    Command.CommandType = CommandType.StoredProcedure;
            //    //Command.CommandTimeout = CommandTimeout;
            //    Command.Parameters.Add("@CustomerId", SqlDbType.NVarChar, 10).Value = "CustomerID";
            //    Command.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = "Name";
            //    Command.Parameters.Add("@Country", SqlDbType.NVarChar, 100).Value = "Country";

            //    Command.Connection.Open();
            //    SqlDataReader dr = Command.ExecuteReader(CommandBehavior.CloseConnection);
            //    //SqlDataReader dr = Command.ExecuteReader();
            //    DataTable MyTable = new DataTable(); //Returns a Table from the Query
            //    MyTable.Load(dr);
            //    dr.Close();

            //    //return MyTable;
            //}

            //SqlParameter aParm1 = new SqlParameter();
            //aParm1.ParameterName = "@CustomerId";
            //aParm1.Direction = ParameterDirection.Output;
            //aParm1.SqlDbType = SqlDbType.Int;

            //SqlParameter aParm2 = new SqlParameter();
            //aParm1.ParameterName = "@Name";
            //aParm1.Direction = ParameterDirection.Output;
            //aParm1.SqlDbType = SqlDbType.VarChar;

            //SqlParameter aParm3 = new SqlParameter();
            //aParm1.ParameterName = "@Country";
            //aParm1.Direction = ParameterDirection.Output;
            //aParm1.SqlDbType = SqlDbType.VarChar;

            //lSQLCmd.Parameters.Add(new SqlParameter("@CustomerId", aParm1));
            //lSQLCmd.Parameters.Add(new SqlParameter("@Name", aParm2));
            //lSQLCmd.Parameters.Add(new SqlParameter("@Country", aParm3));
            ////lSQLCmd.Parameters.Add(new SqlParameter("@Parm4", aParm4));

            //lSQLCmd.Connection = lSQLConn;
            //Fill the DataAdapter with a SelectCommand
            //lDA.SelectCommand = lSQLCmd;
            //lDA.Fill(lDS);
        }
    }
}
