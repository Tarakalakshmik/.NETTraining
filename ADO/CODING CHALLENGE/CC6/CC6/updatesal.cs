using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CC6
{
    class updatesal
    {
        static void Main()
        {

            string connectionString = "Data Source=ICS-LT-BXKZC64\\SQLEXPRESS09;Initial Catalog=codechallenge;;user id=sa;password=Tarakalakshmi@123;";
            try { 
            Console.Write("Enter Employee ID to update salary: ");
            int empid = Convert.ToInt32(Console.ReadLine());
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("update_salary", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@empid", empid);


                SqlParameter Param1 = new SqlParameter("@updated_salary", SqlDbType.Float);

                Param1.Direction = ParameterDirection.Output;
                
                cmd.Parameters.Add(Param1);

                conn.Open();
                cmd.ExecuteNonQuery();

                Console.WriteLine("--- Updated Salary---");
                Console.WriteLine("Updated Salary: " + Param1.Value);


                    SqlCommand cmd1= new SqlCommand("SELECT * FROM employee_details", conn);
                    SqlDataReader r = cmd1.ExecuteReader();

                    Console.WriteLine("--- All Employee Details ---");
                    Console.WriteLine("EmpId\tName\t\tGender\tSalary\t\tNetSalary");

                    while (r.Read())
                    {
                        Console.WriteLine($"{r["empid"]}\t{r["name"]}\t{r["gender"]}\t{r["salary"]}\t\t{r["net_salary"]}");
                    }

                    
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}




