using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Data.SqlClient;
using Banking.Models;
using Banking.Repositories;
namespace Banking.Service
{
    public class AdminService
    {

        private BankingDBEntities1 db;
        private IAccountRepository accountRepository;

        public AdminService()
        {
            db = new BankingDBEntities1();
            accountRepository = new AccountRepositoryImpl();
        }
        public (int admin_id, string message) AdminLogin(string email, string password)
        {

            int admin_id = -1;
            string message = "";

            try
            {
                var result = db.fn_AdminLogin(email, password).FirstOrDefault();

                if (result != null && result.id.HasValue && result.id.Value != -1)
                {
                    admin_id = result.id.Value;
                    message = "Admin login successful";
                }

                else
                {
                    message = "Invalid email or password";
                }
            }

            catch (SqlException e)
            {
                message = e.Message;
            }
            return (admin_id, message);
        }
        public (List<RegisterAccount> registerAccounts, string message) PendingApprovals()
        {
            List<RegisterAccount> registerAccounts = new List<RegisterAccount>();
            string message = "";
            try
            {
                registerAccounts = db.RegisterAccounts.ToList();
                message = "Accounts fetched successfully";
            }
            catch (SqlException e)
            {
                message = e.Message;
            }
            return (registerAccounts, message);
        }

        public RegisterAccount ViewDetails(int id)
        {
            RegisterAccount account = db.RegisterAccounts.Find(id);
            return account;
        }

        public string Approve(int service_reference_number, int admin_id)
        {
            string message = "";
            try
            {
                var user = db.RegisterAccounts.Find(service_reference_number);
                
                db.Sp_CreateAccount(service_reference_number, admin_id);
                var Aadhar = user.Aadhar;
                var customer = db.Customers.FirstOrDefault(c => c.Aadhar.ToString() == Aadhar);
               
                var cust_id = customer.Customer_Id;
                var account = db.Accounts.FirstOrDefault(a => a.Customer_Id == cust_id);
                var accountno = account.Account_Number;


                string remarks = "";
                if (user.Opt_Net_Banking.Value)
                {
                    remarks = $"Your Internet Banking Credentials \n Username: {user.Email_Id} \n Password: {accountno} \n Debit card generated successfully"; ;
                }
                else if (user.Opt_Debit_Card.Value)
                {
                    remarks = "Debit card generated successfully";
                }
                SendApprovalEmail(user.Email_Id, user.First_Name, remarks);
                message = service_reference_number + " Approved successfully";
            }
            catch (SqlException e)
            {
                message = e.Message;
            }
            return message;
        }
        private void SendApprovalEmail(string email, string username, string remarks)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Bank Admin", "admin@yourbank.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Account Approved";

            message.Body = new TextPart("plain")
            {
                Text = $"Dear {username},\n\nYour account has been approved.\n{remarks}\n\nPlease log in and reset your password.\n\nRegards,\nBank Admin"
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("tarakakillada@gmail.com", "baev kroz pvpf trck");
                smtp.Send(message);
                smtp.Disconnect(true);
            }
        }

        public string RejectAccount(int serviceReferenceNumber, int id, string remarks)
        {
            string message = "";
            try
            {
                var user = db.RegisterAccounts.Find(serviceReferenceNumber);
                if (user == null)
                {
                    return "User not found.";
                }

                // Direct call to the stored procedure via EF
                db.Sp_RejectAccount(serviceReferenceNumber, id, remarks);

                // Send rejection email
                SendRejectionEmail(user.Email_Id, user.First_Name, remarks);

                message = serviceReferenceNumber + " Rejected successfully";
            }
            catch (SqlException e)
            {
                message = e.Message;
            }
            return message;
        }
        private void SendRejectionEmail(string email, string username, string remarks)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Bank Admin", "admin@yourbank.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Update on your Account Registration Status - Rejected";
 
            message.Body = new TextPart("plain")
            {
                Text = $"Dear {username},\n\nWe regret to inform you that your account registration has been rejected.\nReason: {remarks}\n\nIf you believe this was a mistake, please reach out to the customer support/ nearest branch.\n\nRegards,\nBank Admin"
            };

            message.Body = new TextPart("html")
            {
                Text = $@"
            <p>Dear {username},</p>
            <p> We regret to inform you that your account registration has been <strong style='color:red;'>rejected</strong>.</p>
            <p><strong>Reason:</strong> <span style='color:red;'>{remarks}</span></p>
            <p>We sincerely appreciate your interest in banking with us and taking time for registering.</p>
            <p>If you believe this was a mistake, please reach out to customer support/local branch.</p>
            <p><span style='color:Blue;'>Regards,<br/>Bank Admin</span></p>"
            };


            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("tarakakillada@gmail.com", "baev kroz pvpf trck");
                smtp.Send(message);
                smtp.Disconnect(true);
            }
        }


        //        public (ChatSupport cs, string message) RaiseSupportRequest(ChatSupport chatSupport)
        //        {
        //            string message = "";
        //            ChatSupport cs = null;
        //            try
        //            {
        //                chatSupport.To_Email = "tarakakillada@gmail.com";
        //                var supportId = db.Database.SqlQuery<int>(
        //    "EXEC Sp_RaiseSupportRequests @From_Email, @To_Email, @Subject, @Message",
        //    new SqlParameter("@From_Email", chatSupport.From_Email),
        //    new SqlParameter("@To_Email", chatSupport.To_Email),
        //    new SqlParameter("@Subject", chatSupport.Subject),
        //    new SqlParameter("@Message", chatSupport.Message)
        //).FirstOrDefault();


        //                cs = db.ChatSupports.Find(supportId);
        //                message = "Ticket raised successfully";
        //            }
        //            catch (SqlException e)
        //            {
        //                message = e.Message;
        //            }
        //            return (cs, message);
        //        }

        public (int supportId, string message) RaiseSupportMessage(SupportMessage supportMessage)
            {
                string message = "";
                int supportId = 0;

                try
                {
                    var result = db.Database.SqlQuery<int>(
                        "EXEC Sp_RaiseSupportMessage @UserEmail, @Subject, @Message",
                        new SqlParameter("@UserEmail", supportMessage.UserEmail),
                        new SqlParameter("@Subject", supportMessage.Subject),
                        new SqlParameter("@Message", supportMessage.Message)
                    ).FirstOrDefault();

                    supportId = result;
                    message = "Support message submitted successfully.";
                }
                catch (SqlException ex)
                {
                    message = "Error: " + ex.Message;
                }

                return (supportId, message);
            }
        public List<Transaction_Details> GetFilteredTransactions(string filter, DateTime? fromDate, DateTime? toDate)
        {
            DateTime today = DateTime.Today;
            DateTime startDate = today;

            switch (filter)
            {
                case "Today":
                    startDate = today;
                    break;
                case "Week":
                    startDate = today.AddDays(-7);
                    break;
                case "Month":
                    startDate = today.AddMonths(-1);
                    break;
                case "Custom":
                    if (fromDate.HasValue && toDate.HasValue)
                    {
                        startDate = fromDate.Value;
                        today = toDate.Value;
                    }
                    break;
            }

            return db.Transaction_Details
                     .Where(t => t.Transaction_Date >= startDate && t.Transaction_Date <= today)
                     .ToList();
        }
    }
}


