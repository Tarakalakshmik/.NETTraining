using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
namespace Electricity_Project
{

    public class DBHandler
    {
        public static SqlConnection GetConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ElectricityDBConn"].ConnectionString;
            return new SqlConnection(connStr);
        }
    }

}






