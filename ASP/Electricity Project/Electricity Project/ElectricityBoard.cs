using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace Electricity_Project
{
    public class ElectricityBoard
    {
        public void CalculateBill(ElectricityBill ebill)
        {
            int units = ebill.UnitsConsumed;
            double amount = 0;

            if (units <= 100)
                amount = 0;
            else if (units <= 300)
                amount = (units - 100) * 1.5;
            else if (units <= 600)
                amount = 200 * 1.5 + (units - 300) * 3.5;
            else if (units <= 1000)
                amount = 200 * 1.5 + 300 * 3.5 + (units - 600) * 5.5;
            else
                amount = 200 * 1.5 + 300 * 3.5 + 400 * 5.5 + (units - 1000) * 7.5;

            ebill.BillAmount = amount;
        }

        public void AddBill(ElectricityBill ebill)
        {
            try{
                using (SqlConnection conn = DBHandler.GetConnection())
                {
                    string query = "INSERT INTO electricitybill VALUES (@number, @name, @units, @amount)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@number", ebill.ConsumerNumber);
                    cmd.Parameters.AddWithValue("@name", ebill.ConsumerName);
                    cmd.Parameters.AddWithValue("@units", ebill.UnitsConsumed);
                    cmd.Parameters.AddWithValue("@amount", ebill.BillAmount);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                } }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<ElectricityBill> Generate_N_BillDetails(int n)
        {
            List<ElectricityBill> bills = new List<ElectricityBill>();

            using (SqlConnection conn = DBHandler.GetConnection())
            {
                string query = $"SELECT TOP {n} * FROM electricitybill ORDER BY consumer_number DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ElectricityBill ebill = new ElectricityBill
                    {
                        ConsumerNumber = reader["consumer_number"].ToString(),
                        ConsumerName = reader["consumer_name"].ToString(),
                        UnitsConsumed = Convert.ToInt32(reader["units_consumed"]),
                        BillAmount = Convert.ToDouble(reader["bill_amount"])
                    };
                    bills.Add(ebill);
                }
            }

            return bills;
        }
    }

}




