using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Connected_ADO
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        static void Main(string[] args)
        {
            SelectData();
            Console.Read();
        }

        //common function to get the connection
        static SqlConnection getConnection()
        {
            con = new SqlConnection("Data Source=ICS-LT-BXKZC64\\SQLEXPRESS09;Initial Catalog=Practice;Integrated Security=true;");
            con.Open();
            return con;
        }
        static void  Selectdata()
        {
            con=getConnection();
            cmd = new SqlCommand("Select * from employee",con);
            //cmd.Connection = con;
            dr=cmd.ExecuteReader();
            while(dr.Read())
            {
                Console.WriteLine(dr[0]+" "+dr[1]+" ");
            }
        }
    }
}
