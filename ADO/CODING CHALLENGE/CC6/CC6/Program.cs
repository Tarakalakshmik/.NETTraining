using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CC6
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=ICS-LT-BXKZC64\\SQLEXPRESS09;Initial Catalog=codechallenge;;user id=sa;password=Tarakalakshmi@123;";

            try
            {

                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Salary: ");
                float salary = Convert.ToSingle(Console.ReadLine());

                Console.Write("Enter Gender (M/F): ");
                char gender = Convert.ToChar(Console.ReadLine());
                Console.WriteLine();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("insertion", conn);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    cmd.Parameters.AddWithValue("@Gender", gender);


                    SqlParameter Param1 = new SqlParameter("@EmpId", SqlDbType.Int);

                    Param1.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(Param1);

                    SqlParameter Param2 = new SqlParameter("@NetSalary", SqlDbType.Float);

                    Param2.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(Param2);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                  
                    Console.WriteLine("\n--- Employee Inserted Successfully ---");
                    Console.WriteLine("Generated EmpId: " + Param1.Value);
                    Console.WriteLine("Calculated Net Salary: " + Param2.Value);
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





