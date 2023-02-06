using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsAppUnitTestDB
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Program program = new Program();
            //long count = program.CountCMF("11000051");
            //long count = CountCMF("11000051");
            long count = CountNWOrder(10248);
        }

        public static long CountCMF(string customerId)
        {
            long count = 0;

            string strconn = @"data source=.;initial catalog=MUFGDBXP;integrated security=True;MultipleActiveResultSets=True;";
            string strsql = "SELECT COUNT(CustomerCode) FROM MasterCustomerDaily Where CustomerCode = '" + customerId + "'";

            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(strsql, conn);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "MasterCustomerDaily");
            //count = ds.Tables[0].Rows.Count;
            count = long.Parse(ds.Tables[0].Rows[0][0].ToString());
            return count;
        }

        public static long CountNWOrder(int orderId)
        {
            long count = 0;

            string strconn = @"data source=.;initial catalog=northwind;integrated security=True;MultipleActiveResultSets=True;";
            string strsql = "SELECT Count([OrderID]) from [dbo].[Order Details] Where OrderId =" + orderId;

            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(strsql, conn);

            DataSet ds = new DataSet();
            adapter.Fill(ds, "OrderDetails");
            //count = ds.Tables[0].Rows.Count;
            count = long.Parse(ds.Tables[0].Rows[0][0].ToString());
            return count;
        }
    }
}
