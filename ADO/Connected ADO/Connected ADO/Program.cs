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
            //InsertData();
            //SelectData();          
            //DeleteData();
            UpdateData();
            Console.Read();
        }

        //common function to get the connection
        static SqlConnection getConnection()
        {
            con = new SqlConnection("Data Source=ICS-LT-BXKZC64\\SQLEXPRESS09;Initial Catalog=Practice;user id=sa;password=Tarakalakshmi@123");
            con.Open();
            return con;
        }
        static void UpdateData()
        {
            try
            {
                con = getConnection();
                Console.WriteLine("Enter the employee eid you want to update:");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the updated salary");
                float salary = Convert.ToSingle(Console.ReadLine());
                cmd = new SqlCommand("update emp set salary=@salary where empno= @eid", con);
                cmd.Parameters.AddWithValue("@eid", id);
                cmd.Parameters.AddWithValue("@salary", salary);

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Salary Updated successfully..");
                else
                    Console.WriteLine("Cannot find the empid ");
            }


            catch (SqlException s)
            {
                Console.WriteLine(s.Message);
            }
        }

        static void SelectData()
        {
            try
            {
                con = getConnection();
                Console.WriteLine("Enter the Department :");
                int deptid = Convert.ToInt32(Console.ReadLine());
                cmd = new SqlCommand("select * from employee where departmentid = @did", con);
                //cmd.Connection = con;
                cmd.Parameters.AddWithValue("@did", deptid);
                dr = cmd.ExecuteReader();
                bool status = dr.HasRows;
                if (status)
                {
                    Console.WriteLine("Starting to display records..");
                    while (dr.Read())
                    {
                        // Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[3] + " " + dr[4]);
                        Console.WriteLine("Employee ID : " + dr["Empid"]);
                        Console.WriteLine("Employee name: " + dr["empname"]);
                        Console.WriteLine("Employee Salary : " + dr["salary"]);
                    }
                }
                else
                    Console.WriteLine("No Data Fetched ..");
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
        }

        static void InsertData()
        {
            try
            {
                con = getConnection();
                //hard coded values during insertion will lead violation
                // cmd = new SqlCommand("Insert into employee values(500,'Nandini','Female',6400,2,'543465')");
                Console.WriteLine("Please Enter Employee Details viz Empid,Name,job,Salary,Deptid :");
                int eid = Convert.ToInt32(Console.ReadLine());
                string ename = Console.ReadLine();
                string ejob = Console.ReadLine();
             

                float esalary = Convert.ToSingle(Console.ReadLine());
                int edept = Convert.ToInt32(Console.ReadLine());


                cmd = new SqlCommand("insert into emp values(@ecode,@empname,@ejob,@esal,@edid)");
                cmd.Connection = con;

                //bind or mapping the C# variables to SQL parameters
                cmd.Parameters.AddWithValue("@ecode", eid);
                cmd.Parameters.AddWithValue("@empname", ename);
                cmd.Parameters.AddWithValue("@ejob", ejob);
                cmd.Parameters.AddWithValue("@esal", esalary);
                cmd.Parameters.AddWithValue("@edid", edept);


                int result = cmd.ExecuteNonQuery();
                if (result > 0) 
                { 
                    Console.WriteLine("Record Inserted successfully..");
                    
                    cmd = new SqlCommand("select * from emp where empno=@ecode",con);
                    cmd.Parameters.AddWithValue("@ecode", eid);
                    dr = cmd.ExecuteReader();
                    bool status = dr.HasRows;
                    if (status)
                    {
                        Console.WriteLine("Starting to display records..");
                        while (dr.Read())
                        {
                            // Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[3] + " " + dr[4]);
                            Console.WriteLine("Employee ID : " + dr[0]);
                            Console.WriteLine("Employee name: " + dr[1]);
                            Console.WriteLine("Employee Salary : " + dr[2]);
                        }
                    }
                }
                else
                    Console.WriteLine("Could not Insert...");
            }
            catch (SqlException s)
            {
                Console.WriteLine(s.Message);
            }
        }

        static void DeleteData()
        {
            try
            {
                con = getConnection();
                Console.WriteLine("Enter Empid to delete :");
                int empid = Convert.ToInt32(Console.ReadLine());

                SqlCommand cmd1 = new SqlCommand("select * from employee where " +
                    "empid = @eid", con);
                cmd1.Parameters.AddWithValue("@eid", empid);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read())
                {
                    for (int i = 0; i < dr1.FieldCount; i++)
                    {
                        Console.WriteLine(dr1[i]);
                    }
                }
                con.Close();
                Console.WriteLine();
                Console.WriteLine("Are you sure to delete this employee ? (Y/N)");
                string answer = Console.ReadLine();
                if (answer == "Y" || answer == "y")
                {
                    cmd = new SqlCommand("delete from employee where empid=@eid", con);
                    cmd.Parameters.AddWithValue("@eid", empid);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("record deleted...");
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
        }
    }
}
