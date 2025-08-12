using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace MiniProject
{
    public class DatabaseHelper
    {
        
        private string connectionString = "Data Source=ICS-LT-BXKZC64\\SQLEXPRESS09;Initial Catalog=miniproject;;user id=sa;password=Tarakalakshmi@123;";

        public bool RegisterCustomer(string name, string mobile, string email, string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("RegisterCustomer", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerName", name);
                cmd.Parameters.AddWithValue("@MobileNo", mobile);
                cmd.Parameters.AddWithValue("@EmailID", email);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ValidateLogin(string username, string password, out bool isAdmin)
        {
            isAdmin = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmdUser = new SqlCommand("SELECT COUNT(*) FROM Customers WHERE Username=@u AND Password=@p", conn);
                cmdUser.Parameters.AddWithValue("@u", username);
                cmdUser.Parameters.AddWithValue("@p", password);

                SqlCommand cmdAdmin = new SqlCommand("SELECT COUNT(*) FROM Admins WHERE Username=@u AND Password=@p", conn);
                cmdAdmin.Parameters.AddWithValue("@u", username);
                cmdAdmin.Parameters.AddWithValue("@p", password);

                if ((int)cmdAdmin.ExecuteScalar() > 0)
                {
                    isAdmin = true;
                    return true;
                }
                else if ((int)cmdUser.ExecuteScalar() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void BookTicket(int customerId, string passengerName, DateTime travelDate, string travelClass, int seatNo, decimal cost, decimal refundPercent, int trainNo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("BookTicket", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.Parameters.AddWithValue("@PassengerName", passengerName);
                cmd.Parameters.AddWithValue("@TravelDate", travelDate);
                cmd.Parameters.AddWithValue("@Class", travelClass);
                cmd.Parameters.AddWithValue("@SeatNo", seatNo);
                cmd.Parameters.AddWithValue("@TotalCost", cost);
                cmd.Parameters.AddWithValue("@CancellationRefundPercent", refundPercent);
                cmd.Parameters.AddWithValue("@TrainNo", trainNo);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        //public void CancelTicket(int bookingId, decimal refundAmount, string refundStatus)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("CancelTicket", conn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@BookingID", bookingId);
        //        cmd.Parameters.AddWithValue("@RefundAmount", refundAmount);
        //        cmd.Parameters.AddWithValue("@RefundStatus", refundStatus);

        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}
        //cancel ticket 1
        //public void CancelTicket(int bookingId, decimal refundAmount)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand("CancelTicket", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@BookingID", bookingId);
        //            cmd.Parameters.AddWithValue("@RefundAmount", refundAmount);

        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //    }catch(Exception)
        //    {
        //        Console.WriteLine("Enter valid booking id");
        //    }

        //}
        public void CancelTicket(int bookingId, int customerId, decimal refundAmount)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("CancelTicket", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookingID", bookingId);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.Parameters.AddWithValue("@RefundAmount", refundAmount);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public decimal CalculateRefundAmount(int bookingId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT TotalCost, CancellationRefundPercent FROM Reservations WHERE BookingID = @bid";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@bid", bookingId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        decimal price = Convert.ToDecimal(reader["TotalCost"]);
                        decimal percentage = Convert.ToDecimal(reader["CancellationRefundPercent"]);
                        return (price * percentage) / 100;
                    }

                    Console.WriteLine("Booking does not exist.");
                    return -1;

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Booking doesnot exists");
                return -1;
            }
            
        }



        //public void ViewTicketDetails(int customerId)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        string query = "SELECT * FROM Reservations WHERE CustomerID = @cid";
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@cid", customerId);

        //        conn.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        if (!reader.HasRows)
        //        {
        //            Console.WriteLine("No records found for the given CustomerID.");
        //        }

        //        while (reader.Read())
        //        {
        //            Console.WriteLine($"BookingID: {reader["BookingID"]}, TravelDate: {reader["TravelDate"]}, Class: {reader["Class"]}, IsCancelled: {reader["IsCancelled"]}");
        //        }
        //    }
        //}

        public void ViewTicketDetails(int customerId)
        {
            Console.WriteLine($"Fetching ticket details for CustomerID: {customerId}");

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Reservations WHERE CustomerID = @cid";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cid", customerId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No records found for the given CustomerID.");
                    }

                    while (reader.Read())
                    {
                        Console.WriteLine($"BookingID: {reader["BookingID"]}, TravelDate: {reader["TravelDate"]}, Class: {reader["Class"]}, IsCancelled: {reader["IsCancelled"]}");
                    }
                }
                Console.WriteLine("Press enter to go back");
               
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Press enter to go back");

            }
        }

        public int RegisterCustomerAndGetID(string name, string mobile, string email, string username, string password)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("RegisterCustomer", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerName", name);
                    cmd.Parameters.AddWithValue("@MobileNo", mobile);
                    cmd.Parameters.AddWithValue("@EmailID", email);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                  
                    SqlCommand getIdCmd = new SqlCommand("SELECT CustomerID FROM Customers WHERE Username = @Username", conn);
                    getIdCmd.Parameters.AddWithValue("@Username", username);
                    return (int)getIdCmd.ExecuteScalar();

                }
            }
            catch (Exception )
            {
                Console.WriteLine("Username already exists..");
                return -1;
            }
        }
        public int GetCustomerIDByUsername(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT CustomerID FROM Customers WHERE Username = @Username", conn);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
        public int GetBookingId()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand getBookingIdCmd = new SqlCommand(@"
    SELECT TOP 1 BookingID 
    FROM Reservations 
    
    ORDER BY BookingDate DESC", conn);

                conn.Open();
                int bookingId = (int)getBookingIdCmd.ExecuteScalar();
                return bookingId;
            }
        }

        public List<(int TrainNo, string StartPoint, string DestinationPoint, string RunningDays)> GetMatchingTrains(string source, string destination, string dayOfWeek)
        {
            var trains = new List<(int, string, string, string)>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TrainNo, StartPoint, DestinationPoint, RunningDays FROM Trains WHERE StartPoint = @src AND DestinationPoint = @dest AND RunningDays LIKE '%' + @day + '%'  AND IsDeleted = 0";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@src", source);
                cmd.Parameters.AddWithValue("@dest", destination);
                cmd.Parameters.AddWithValue("@day", dayOfWeek);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    trains.Add((
                        Convert.ToInt32(reader["TrainNo"]),
                        reader["StartPoint"].ToString(),
                        reader["DestinationPoint"].ToString(),
                        reader["RunningDays"].ToString()
                    ));
                }
            }
            return trains;
        }

        public (int seatNo, decimal price) GetNextSeatAndPrice(int trainNo, string travelClass)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($@"
            SELECT 
                CASE 
                    WHEN @Class = 'General' THEN GeneralSeats
                    WHEN @Class = '2Sitting' THEN SittingSeats
                    WHEN @Class = 'Sleeper' THEN SleeperSeats
                    WHEN @Class = '2AC' THEN AC2Seats
                    WHEN @Class = '1AC' THEN AC1Seats
                END AS AvailableSeats,
                CASE 
                    WHEN @Class = 'General' THEN GeneralPrice
                    WHEN @Class = '2Sitting' THEN SittingPrice
                    WHEN @Class = 'Sleeper' THEN SleeperPrice
                    WHEN @Class = '2AC' THEN AC2Price
                    WHEN @Class = '1AC' THEN AC1Price
                END AS Price
            FROM TrainDetails
            WHERE TrainNo = @TrainNo", conn);

                cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                cmd.Parameters.AddWithValue("@Class", travelClass);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int availableSeats = Convert.ToInt32(reader["AvailableSeats"]);
                    decimal price = Convert.ToDecimal(reader["Price"]);
                    if(availableSeats<=0)
                    {
                        return (0, 0);
                    }
                    int seatNo = availableSeats; 
                    return (seatNo, price);
                }
                return (0, 0);
            }
        }
        public DailyReport GetDailyReport(DateTime date)
        {
            DailyReport report = new DailyReport();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

               
                string bookingsQuery = "SELECT COUNT(*) FROM Reservations WHERE CAST(BookingDate AS DATE) = @Date";
                SqlCommand bookingsCmd = new SqlCommand(bookingsQuery, conn);
                bookingsCmd.Parameters.AddWithValue("@Date", date.Date);
                report.TotalBookings = (int)bookingsCmd.ExecuteScalar();

                string revenueQuery = "SELECT SUM(TotalCost) FROM Reservations WHERE CAST(BookingDate AS DATE) = @Date";
                SqlCommand revenueCmd = new SqlCommand(revenueQuery, conn);
                revenueCmd.Parameters.AddWithValue("@Date", date.Date);
                object revenueResult = revenueCmd.ExecuteScalar();
                report.TotalRevenue = revenueResult != DBNull.Value ? Convert.ToDecimal(revenueResult) : 0;

               
                string cancelQuery = "SELECT COUNT(*) FROM Cancellations WHERE CAST(CancellationDate AS DATE) = @Date";
                SqlCommand cancelCmd = new SqlCommand(cancelQuery, conn);
                cancelCmd.Parameters.AddWithValue("@Date", date.Date);
                report.TotalCancellations = (int)cancelCmd.ExecuteScalar();
            }

            return report;
        }
        //public void AddTrain(int trainNo, string startPoint, string destinationPoint, string runningDays)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            string query = "INSERT INTO Trains (TrainNo, StartPoint, DestinationPoint, RunningDays) VALUES (@TrainNo, @Start, @Destination, @Days)";
        //            SqlCommand cmd = new SqlCommand(query, conn);
        //            cmd.Parameters.AddWithValue("@TrainNo", trainNo);
        //            cmd.Parameters.AddWithValue("@Start", startPoint);
        //            cmd.Parameters.AddWithValue("@Destination", destinationPoint);
        //            cmd.Parameters.AddWithValue("@Days", runningDays);

        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            Console.WriteLine("Train Added Successfully.");


        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);

        //    }
        //}
        public void AddTrain(int trainNo, string startPoint, string destinationPoint, string runningDays)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                   
                    string trainQuery = "INSERT INTO Trains (TrainNo, StartPoint, DestinationPoint, RunningDays) VALUES (@TrainNo, @Start, @Destination, @Days)";
                    SqlCommand trainCmd = new SqlCommand(trainQuery, conn);
                    trainCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                    trainCmd.Parameters.AddWithValue("@Start", startPoint);
                    trainCmd.Parameters.AddWithValue("@Destination", destinationPoint);
                    trainCmd.Parameters.AddWithValue("@Days", runningDays);
                    trainCmd.ExecuteNonQuery();

                   
                    Console.WriteLine("Enter General Seats:");
                    int generalSeats = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Sitting Seats:");
                    int sittingSeats = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Sleeper Seats:");
                    int sleeperSeats = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter AC2 Seats:");
                    int ac2Seats = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter AC1 Seats:");
                    int ac1Seats = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter General Price:");
                    decimal generalPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter Sitting Price:");
                    decimal sittingPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter Sleeper Price:");
                    decimal sleeperPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter AC2 Price:");
                    decimal ac2Price = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter AC1 Price:");
                    decimal ac1Price = Convert.ToDecimal(Console.ReadLine());

                 
                    string detailsQuery = @"INSERT INTO TrainDetails 
                (TrainNo, GeneralSeats, SittingSeats, SleeperSeats, AC2Seats, AC1Seats, 
                 GeneralPrice, SittingPrice, SleeperPrice, AC2Price, AC1Price) 
                VALUES 
                (@TrainNo, @GeneralSeats, @SittingSeats, @SleeperSeats, @AC2Seats, @AC1Seats, 
                 @GeneralPrice, @SittingPrice, @SleeperPrice, @AC2Price, @AC1Price)";

                    SqlCommand detailsCmd = new SqlCommand(detailsQuery, conn);
                    detailsCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                    detailsCmd.Parameters.AddWithValue("@GeneralSeats", generalSeats);
                    detailsCmd.Parameters.AddWithValue("@SittingSeats", sittingSeats);
                    detailsCmd.Parameters.AddWithValue("@SleeperSeats", sleeperSeats);
                    detailsCmd.Parameters.AddWithValue("@AC2Seats", ac2Seats);
                    detailsCmd.Parameters.AddWithValue("@AC1Seats", ac1Seats);
                    detailsCmd.Parameters.AddWithValue("@GeneralPrice", generalPrice);
                    detailsCmd.Parameters.AddWithValue("@SittingPrice", sittingPrice);
                    detailsCmd.Parameters.AddWithValue("@SleeperPrice", sleeperPrice);
                    detailsCmd.Parameters.AddWithValue("@AC2Price", ac2Price);
                    detailsCmd.Parameters.AddWithValue("@AC1Price", ac1Price);

                    detailsCmd.ExecuteNonQuery();

                    Console.WriteLine("Train and Train Details Added Successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


        //public void DeleteTrain(int trainNo)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        string query = "DELETE FROM Trains WHERE TrainNo = @TrainNo";
        //        SqlCommand cmd = new SqlCommand(query, conn);
        //        cmd.Parameters.AddWithValue("@TrainNo", trainNo);

        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}

        //public void DeleteTrain(int trainNo)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

                
        //        string deleteDetailsQuery = "DELETE FROM TrainDetails WHERE TrainNo = @TrainNo";
        //        SqlCommand deleteDetailsCmd = new SqlCommand(deleteDetailsQuery, conn);
        //        deleteDetailsCmd.Parameters.AddWithValue("@TrainNo", trainNo);
        //        deleteDetailsCmd.ExecuteNonQuery();

               
        //        string deleteTrainQuery = "DELETE FROM Trains WHERE TrainNo = @TrainNo";
        //        SqlCommand deleteTrainCmd = new SqlCommand(deleteTrainQuery, conn);
        //        deleteTrainCmd.Parameters.AddWithValue("@TrainNo", trainNo);
        //        deleteTrainCmd.ExecuteNonQuery();

        //        Console.WriteLine("Train and its details deleted successfully.");
        //    }
        //}
        public void DeleteTrain(int trainNo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Permanently delete from TrainDetails
                string deleteDetailsQuery = "DELETE FROM TrainDetails WHERE TrainNo = @TrainNo";
                SqlCommand deleteDetailsCmd = new SqlCommand(deleteDetailsQuery, conn);
                deleteDetailsCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                deleteDetailsCmd.ExecuteNonQuery();

                // Soft delete in Trains
                string softDeleteTrainQuery = "UPDATE Trains SET IsDeleted = 1 WHERE TrainNo = @TrainNo";
                SqlCommand softDeleteTrainCmd = new SqlCommand(softDeleteTrainQuery, conn);
                softDeleteTrainCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                softDeleteTrainCmd.ExecuteNonQuery();

                Console.WriteLine("Train marked as deleted and details removed successfully.");
            }
        }



        public void UpdateTrainColumn(int trainNo, string columnName, string newValue)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = $"UPDATE Trains SET {columnName} = @newValue WHERE TrainNo = @trainNo";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@newValue", newValue);
                        cmd.Parameters.AddWithValue("@trainNo", trainNo);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Train Updated Successfully.");
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public  void Reports()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                R.ReportID,
                R.BookingID,
                C.CustomerName,
                C.Username,
                Res.PassengerName,
                Res.TravelDate,
                Res.Class,
                Res.TotalCost,
                R.LogTime
            FROM Reports R
            JOIN Customers C ON R.CustomerID = C.CustomerID
            JOIN Reservations Res ON R.BookingID = Res.BookingID
            ORDER BY R.LogTime DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\n--- All Booking Reports ---\n");
                Console.WriteLine("{0,-5} {1,-10} {2,-15} {3,-12} {4,-15} {5,-12} {6,-10} {7,-10} {8,-20}",
                    "ID", "BookingID", "Customer", "Username", "Passenger", "TravelDate", "Class", "Cost", "LogTime");

                Console.WriteLine(new string('-', 110));

                while (reader.Read())
                {
                    Console.WriteLine("{0,-5} {1,-10} {2,-15} {3,-12} {4,-15} {5,-12:yyyy-MM-dd} {6,-10} {7,-10:C} {8,-20}",
                        reader["ReportID"],
                        reader["BookingID"],
                        reader["CustomerName"],
                        reader["Username"],
                        reader["PassengerName"],
                        Convert.ToDateTime(reader["TravelDate"]),
                        reader["Class"],
                        reader["TotalCost"],
                        Convert.ToDateTime(reader["LogTime"]));
                }

                reader.Close();
            }

            
        }


        public void UpdateTrainDetailsColumn(int trainNo, string columnName, string newValue)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = $"UPDATE TrainDetails SET {columnName} = @newValue WHERE TrainNo = @trainNo";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@newValue", newValue);
                        cmd.Parameters.AddWithValue("@trainNo", trainNo);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Train Details Updated Successfully.");
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        
    }


}






