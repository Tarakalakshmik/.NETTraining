using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace MiniProject
{
    public class Program
    {
        static DatabaseHelper db = new DatabaseHelper();

        static void Main()
        {
            Console.WriteLine("Welcome to Railway Reservation System");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Register();
            }
            else if (choice == 2)
            {
                Login();
            }
        }

        static void Register()
        {
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();
            

            string mobile;
            while (true)
            {
                Console.WriteLine("Enter Mobile:");
                mobile = Console.ReadLine();
                if (mobile.Length == 10 && mobile.All(char.IsDigit) && mobile[0] != '0')
                    break;
                Console.WriteLine("Invalid mobile number. It must be 10 digits and not start with 0.");
            }


            string email;
            while (true)
            {
                Console.WriteLine("Enter Email:");
                email = Console.ReadLine();
                int at = email.IndexOf('@');
               
                if (at>0)
                    break;
                Console.WriteLine("Invalid email format. Please enter a valid email.");
            }

            Console.WriteLine("Enter Username:");
            string username = Console.ReadLine();
            string password;
            while (true)
            {
                Console.WriteLine("Enter Password:");
                password = Console.ReadLine();
                Console.WriteLine("Confirm Password:");
                string ConfirmPassword = Console.ReadLine();
                if (password == ConfirmPassword)
                    break;
                Console.WriteLine("Password not matched.Re Enter");
            }
            int customerId = db.RegisterCustomerAndGetID(name, mobile, email, username, password);
            if (customerId != -1)
            {
                Console.WriteLine("Registration Successful! Logging you in...");
                int custId = db.GetCustomerIDByUsername(username);
                Console.WriteLine($"You Customer Id is {custId}.Remember for future use...");
                UserMenu();
            }

            Main();
        }

        static void Login()
        {
            Console.WriteLine("Enter Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();

            if (db.ValidateLogin(username, password, out bool isAdmin))
            {
                if (isAdmin)
                {
                    AdminMenu();
                }
                else
                {
                    
                    int customerId = db.GetCustomerIDByUsername(username);
                    Customer.CustomerID = customerId;
                    UserMenu();
                }
            }
            else
            {
                Console.WriteLine("Invalid credentials.");
            }
        }


        static void AdminMenu()
        {
            Console.WriteLine("Admin Menu");
            Console.WriteLine("1. Update Train Details");
            Console.WriteLine("2. View Daily Report");
            Console.WriteLine("3. View All Report");
            Console.WriteLine("4.View All Trains");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    UpdateTrainDetails();
                    break;
                case 2:
                    ViewDailyReport();
                    break;
                case 3:
                    ViewAllReports();
                    break;
                case 4:
                    ViewTrains();
                    break;
            }
        }
        static void ViewTrains()
        {
            db.ViewTrains();
            Console.ReadLine();
            AdminMenu();
        }

        static void UpdateTrainDetails()
        {
            Console.WriteLine("Train Management");
            Console.WriteLine("1. Add Train");
            Console.WriteLine("2. Update Train or Train Details");
            Console.WriteLine("3. Delete Train");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Train No:");
                    int trainNo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Start Point:");
                    string start = Console.ReadLine();
                    Console.WriteLine("Enter Destination Point:");
                    string destination = Console.ReadLine();
                    Console.WriteLine("Enter Running Days (e.g., Mon,Tue,Wed):");
                    string days = Console.ReadLine();
                    db.AddTrain(trainNo, start, destination, days);
                    
                    AdminMenu();
                    break;


                case 2:
                    Console.WriteLine("Enter Train No to Update:");
                    int updateTrainNo = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Do you want to update:");
                    Console.WriteLine("1. Train Table");
                    Console.WriteLine("2. Train Details Table");
                    int updateChoice = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Column Name to Update:");
                    string columnName = Console.ReadLine();

                    Console.WriteLine($"Enter New Value for {columnName}:");
                    string newValue = Console.ReadLine();

                    if (updateChoice == 1)
                    {
                        db.UpdateTrainColumn(updateTrainNo, columnName, newValue);
                       
                    }
                    else if (updateChoice == 2)
                    {
                        db.UpdateTrainDetailsColumn(updateTrainNo, columnName, newValue);
                        
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice.");
                    }

                    AdminMenu();
                    break;
                case 3:
                    Console.WriteLine("Enter Train No to Delete:");
                    int deleteTrainNo = Convert.ToInt32(Console.ReadLine());
                    db.DeleteTrain(deleteTrainNo);
                    Console.WriteLine("Train Deleted Successfully.");
                    AdminMenu();
                    break;
            }
        }

        static void ViewDailyReport()
        {
            Console.WriteLine("Enter Date for Report (yyyy-mm-dd):");
            DateTime reportDate = DateTime.Parse(Console.ReadLine());

            var report = db.GetDailyReport(reportDate);

            Console.WriteLine($"\nReport for {reportDate.ToShortDateString()}:");
            Console.WriteLine($"Total Bookings: {report.TotalBookings}");
            Console.WriteLine($"Total Revenue: ₹{report.TotalRevenue}");
            Console.WriteLine($"Total Cancellations: {report.TotalCancellations}");
            Console.WriteLine("Press enter to go back");
            Console.ReadLine();
            
            AdminMenu();
        }
        static void ViewAllReports()
        {
            db.Reports();

            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.WriteLine("**************************************");
            Console.ReadLine();
            AdminMenu();
        }



        static void UserMenu()
        {
            try
            {
                Console.WriteLine("User Menu");
                Console.WriteLine("1. Book Ticket");
                Console.WriteLine("2. Cancel Ticket");
                Console.WriteLine("3. View Ticket Details");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        BookTicket(Customer.CustomerID);
                        break;

                    case 2:
                        CancelTicket();
                        break;
                    case 3:

                        db.ViewTicketDetails(Customer.CustomerID);
                        UserMenu();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            }

        static void BookTicket(int customerId)
        {
            Console.WriteLine("Enter Journey Date (yyyy-mm-dd):");
            DateTime journeyDate = DateTime.Parse(Console.ReadLine());
            DateTime todayDate = DateTime.Now;
            DateTime exceed_Date = DateTime.Now.AddDays(7);

            if (journeyDate <todayDate)
            {
                Console.WriteLine("Bookings are closed for the day....");
            }
            else if(journeyDate>exceed_Date)
            {
                Console.WriteLine("Bookings are not open yet!!!!!");
            }
            else 
            {
                Console.WriteLine("Enter Source Station:");
                string source = Console.ReadLine();

                Console.WriteLine("Enter Destination Station:");
                string destination = Console.ReadLine();


                string dayAbbreviation = journeyDate.ToString("ddd");

               
                var matchingTrains = db.GetMatchingTrainsWithDetails(source, destination, dayAbbreviation);


                if (matchingTrains.Count == 0)
                {
                    Console.WriteLine("No trains available for the selected route and date.");
                    UserMenu();
                    return;
                }

                Console.WriteLine("\nAvailable Trains:");
                
                foreach (var train in matchingTrains)
                {
                    Console.WriteLine("============================================================");
                    Console.WriteLine($"Train No: {train.TrainNo}, From: {train.StartPoint}, To: {train.DestinationPoint}, Runs on: {train.RunningDays}");
                    Console.WriteLine($"Seats - General: {train.GeneralSeats}, Sitting: {train.SittingSeats}, Sleeper: {train.SleeperSeats}, AC2: {train.AC2Seats}, AC1: {train.AC1Seats}");
                    Console.WriteLine($"Prices - General: {train.GeneralPrice}, Sitting: {train.SittingPrice}, Sleeper: {train.SleeperPrice}, AC2: {train.AC2Price}, AC1: {train.AC1Price}");
                }


                Console.WriteLine("\nEnter Train No to book:");
                int trainNo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Class (General, 2Sitting, Sleeper, 2AC, 1AC):");
                string travelClass = Console.ReadLine();
                List<string> passengerNames = new List<string>();
                decimal totalCost = 0;
                List<int> seatNumbers = new List<int>();
                int s = 0;
                while (true)
                {

                    Console.WriteLine("Enter Passenger Name:");
                    string pname = Console.ReadLine();
                    passengerNames.Add(pname);

                    var (seatNo, price) = db.GetNextSeatAndPrice(trainNo, travelClass);
                    if (seatNo == 0)
                    {
                        Console.WriteLine("No seats available in selected class.");
                        UserMenu();
                        return;
                    }

                    seatNumbers.Add(seatNo - s);
                    totalCost += price;
                    s = s + 1;
                    Console.WriteLine("Add another passenger? (yes/no):");
                    string more = Console.ReadLine().ToLower();
                    if (more != "yes") break;
                }


                Console.WriteLine("\nBooking Summary:");
                for (int i = 0; i < passengerNames.Count; i++)
                {
                    Console.WriteLine($"Passenger: {passengerNames[i]}, Seat No: {seatNumbers[i]}");
                }
                Console.WriteLine($"Total Price to be Paid: ₹{totalCost}");

                Random rnd = new Random();
                int captcha = rnd.Next(1000, 9999);
                Console.WriteLine($"\nEnter Captcha: {captcha}");
                int userCaptcha = Convert.ToInt32(Console.ReadLine());

                if (userCaptcha == captcha)
                {
                    for (int i = 0; i < passengerNames.Count; i++)
                    {
                        db.BookTicket(customerId, passengerNames[i], journeyDate, travelClass, seatNumbers[i], totalCost / passengerNames.Count, 50, trainNo);
                        int BookingId = db.GetBookingId();



                        if (i == 0)
                        {
                            Console.WriteLine("\nBooking Successful!");
                        }
                        Console.WriteLine($"Your Booking ID for Passenger {i+1} is {BookingId}");
                        
                       
                    }
                    //int BookingId = db.GetBookingId();




                    //Console.WriteLine("\nBooking Successful!");
                    //Console.WriteLine($"Your Booking ID is {BookingId}");
                    Console.WriteLine("**************************************");
                }
                else
                {
                    Console.WriteLine("\nCaptcha Incorrect. Booking Failed.");
                    Console.WriteLine("**************************************");
                }
            }
            

            UserMenu();
        }
       
        static void CancelTicket()
        {
            Console.WriteLine("Enter Booking ID:");
            int bookingId = Convert.ToInt32(Console.ReadLine());
           
          

            Console.WriteLine("Are you sure you want to cancel this ticket? (yes/no)");
            string confirmation = Console.ReadLine()?.Trim().ToLower();

            if (confirmation == "yes")
            {
                decimal refundAmount = db.CalculateRefundAmount(bookingId);
                try
                {
                    db.CancelTicket(bookingId, Customer.CustomerID, refundAmount);
                    Console.WriteLine("Refund successful...");
                    Console.WriteLine($"{refundAmount} will be refunded within 2 days.");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Cancellation failed: " + ex.Message);
                }
                Console.ReadLine();
                Console.WriteLine("Press enter to logout!!!");
                Console.ReadLine();
                Main();
            }
            else
            {
                Console.WriteLine("Cancellation aborted.");
                
                Console.ReadLine();
                Console.WriteLine("Press enter to logout!!!");
                Console.ReadLine();
                Main();
            }
        }


    }

}



