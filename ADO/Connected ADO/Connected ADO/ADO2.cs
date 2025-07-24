using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Connected_ADO
{
   

    
        class ADO2
        {
            public static void Main()
            {
                Region rg = new Region();
                SqlDataReader return_dr = rg.SelectRegion();
                while (return_dr.Read())
                {
                    Console.WriteLine($"Region ID: {return_dr["regionid"]} and the region description is :{return_dr["regiondescription"]}");
                }
                Console.WriteLine("---------");
                Console.WriteLine($"Total regions are : {rg.GetRegionCount()}");
                Console.WriteLine("----Procedure with parameters----");
                rg.CallProdWithParam();

                Console.Read();
            }
        }
        //business logic layer
        class Region
        {

            public int RegionID { get; set; }
            public string RegionDescription { get; set; }
            DataAccess da = new DataAccess();

            internal SqlDataReader SelectRegion()
            {
                return da.SelectRegionData();
            }

            //public int InsertRegion()
            //{
            //    Console.WriteLine("Enter region ID:");
            //    RegionID = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine("Enter region Description");
            //    RegionDescription = Console.ReadLine();
            //    return da.InsertRegion(RegionID,RegionDescription);
            //}

            public int GetRegionCount()
            {
                return da.GetRegionCount();
            }

            public void CallProdWithParam()
            {
                //da.Procedure_with_param();
            da.Procedure_with_param_opt2();
            }
        }
    //data layer
    class DataAccess
    {
        static SqlConnection con = null;
        static SqlCommand cmd = null;
        static SqlDataReader dr;

        public SqlConnection GetConnection()
        {
            string connect = "Data Source=ICS-LT-BXKZC64\\SQLEXPRESS09;Initial Catalog=Practice;user id=sa;password=Tarakalakshmi@123";
            
            con = new SqlConnection(connect);
            con.Open();
            return con;
        }
        public SqlDataReader SelectRegionData()
        {
            try
            {
                con = GetConnection();
                cmd = new SqlCommand("select * from region", con);
                dr = cmd.ExecuteReader();
                //return dr;
            }
            catch (SqlException sl)
            {
                Console.WriteLine(sl.Message);
            }
            return dr;
        }
        //public int InsertRegion(int rid, string desc)
        //{
        //    try
        //    {
        //        con = GetConnection();
        //        cmd = new SqlCommand("insert into region values(@rid,@desc)");
        //        cmd.Connection = con;
        //        cmd.Parameters.AddWithValue("@rid", rid);
        //        cmd.Parameters.AddWithValue("@desc", desc);
        //        res = cmd.ExecuteNonQuery();
        //        return res;
        //    } 
        //}

        public int GetRegionCount()
        {
            con = GetConnection();
            cmd = new SqlCommand("select count(regionid) from region", con);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        public SqlDataReader MostExpensiveProducts()
        {
            con = GetConnection();
            cmd = new SqlCommand("Ten Most Expensive Products", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();
            return dr;
        }

        //procedure with parameters
        public void Procedure_with_param()
        {
            con = GetConnection();
            Console.WriteLine("Enter Customer ID: ");
            string custid = Console.ReadLine();
            cmd = new SqlCommand("custordersorders", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //option 1
            cmd.Parameters.AddWithValue("@CustomerID", custid);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr["orderid"] + " " + dr["orderdate"]);
            }
            dr.Close();
            
        }
        public void Procedure_with_param_opt2()
        {
            con = GetConnection();
            Console.WriteLine("Enter dept id");
            int deptid= Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("sp_getavgsal_empcount", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@did";
            param1.Value = deptid;
            param1.DbType = System.Data.DbType.Int32;
            param1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@avgsal";
            //param2.Value = deptid;
            param2.DbType = System.Data.DbType.Single;
            param2.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@Count";
            param3.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(param3);
            cmd.ExecuteNonQuery();
            
            dr.Close();

            float avgSal = (float)cmd.Parameters["@avgsal"].Value;
            int count = (int)cmd.Parameters["@Count"].Value;
            Console.WriteLine($"Average is {avgSal}");
            Console.WriteLine($"Count is {count}"  );


        }
    }
}
