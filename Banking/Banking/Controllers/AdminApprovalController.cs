//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Banking.Models;
//using Banking.Repositories;
//using MailKit.Net.Smtp;
//using MailKit.Security;
//using MimeKit;
//namespace Banking.Controllers
//{
//    public class AdminApprovalController : Controller
//    {
//        private readonly BankingDBEntities1 db = new BankingDBEntities1();
//        private IAccountRepository accountRepository;

//        public AdminApprovalController()
//        {
//            accountRepository = new AccountRepositoryImpl();
//        }
//        // GET: AdminApproval
//        public ActionResult Index()
//        {
//            return View();
//        }


//        // GET: Admin Login
//        public ActionResult AdminLogin()
//        {
//            return View();
//        }

//        // POST: Admin Login
//        [HttpPost]
//        public ActionResult AdminLogin(string username, string password)
//        {
//            // Hardcoded credentials

//            var admin = db.Admin_Table
//                                 .FirstOrDefault(a => a.Email_Id == username && a.password == password);




//            if (admin != null)
//            {

//                Session["AdminId"] = admin.id;
//                int adminId = Convert.ToInt32(Session["AdminId"]);
//                return RedirectToAction("PendingApprovals");
//            }



//            else
//            {
//                ViewBag.LoginFailed = "Login failed. Invalid username or password.";
//                return View();
//            }
//        }

//        // Existing actions: PendingApprovals, ViewDetails, Approve...

//        public ActionResult PendingApprovals()
//        {
//            var pendingUsers = db.RegisterAccounts.ToList();
//            return View(pendingUsers);
//        }
//        public ActionResult ViewDetails(int id)
//        {
//            var user = db.RegisterAccounts.Find(id);
//            if (user == null)
//            {
//                return HttpNotFound();
//            }

//            return View(user);
//        }

//        // Approve user
//        public ActionResult Approve(int id)
//        {
//            var user = db.RegisterAccounts.Find(id);
//            accountRepository.CreateAccount(user.Service_Reference_Number, (int) Session["AdminId"]);

//            //if (user != null )
//            //{
//            //    db.Sp_CreateAccount(user.Service_Reference_Number, (int)Session["AdminId"]);



//            //}
//                SendApprovalEmail(user.Email_Id, user.First_Name);

//            return RedirectToAction("PendingApprovals");
//        }

//        private void SendApprovalEmail(string email, string username)
//        {
//            var message = new MimeMessage();
//            message.From.Add(new MailboxAddress("Bank Admin", "admin@yourbank.com"));
//            message.To.Add(new MailboxAddress("", email));
//            message.Subject = "Account Approved";

//            message.Body = new TextPart("plain")
//            {
//                Text = $"Dear {username},\n\nYour account has been approved.\nUsername: {username}\nPassword: User@123\n\nPlease log in and reset your password.\n\nRegards,\nBank Admin"
//            };

//            using (var smtp = new SmtpClient())
//            {
//                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
//                smtp.Authenticate("tarakakillada@gmail.com", "baev kroz pvpf trck");
//                smtp.Send(message);
//                smtp.Disconnect(true);
//            }
//        }

//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Banking.Models;
using Banking.Repositories;
using Banking.Service;

namespace Banking.Controllers
{
    public class AdminApprovalController : Controller
    {
        private AdminService adminService;
        private BankingDBEntities1 db = new BankingDBEntities1();
        public AdminApprovalController()
        {
            adminService = new AdminService();
        }
        // GET: AdminApproval
        public ActionResult Index()
        {
            return View();
        }


        // GET: Admin Login
        public ActionResult AdminLogin()
        {
            return View();
        }

        // POST: Admin Login
        [HttpPost]
        public ActionResult AdminLogin(string username, string password)
        {
            var admin = adminService.AdminLogin(username, password);

            if (admin.admin_id != -1)
            {

                Session["AdminId"] = admin.admin_id;
                return RedirectToAction("PendingApprovals");
            }
            else
            {
                ViewBag.LoginFailed = admin.message;
                return View();
            }
        }

        // Existing actions: PendingApprovals, ViewDetails, Approve...

        public ActionResult PendingApprovals()
        {
            var pendingUsers = adminService.PendingApprovals();
            return View(pendingUsers.registerAccounts);
        }
        public ActionResult ViewDetails(int id)
        {
            var user = adminService.ViewDetails(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // Approve user
        public ActionResult Approve(int id)
        {
            adminService.Approve(id, (int)Session["AdminId"]);
            return RedirectToAction("PendingApprovals");
        }

        //Reject User
        [HttpPost]
        public ActionResult Reject(int serviceReferenceNumber, int id, string remarks)
        {
            string result = adminService.RejectAccount(serviceReferenceNumber, id, remarks);

            TempData["Message"] = result;
            return RedirectToAction("PendingApprovals");
        }
        public JsonResult GetDashboardCounts()
        {
            
                int approvalCount = db.RegisterAccounts.Count();
                int messageCount = db.SupportMessages.Count(m => m.Status == "Pending");
                int customerCount = db.Customers.Count();
                return Json(new { approvalCount, messageCount,customerCount }, JsonRequestBehavior.AllowGet);
            
        }
        //public ActionResult GetAllCustomers()
        //{
        //    var allcustomers = db.Customers.Include("Accounts").ToList();
        //    return View(allcustomers);
        //}
        public ActionResult GetAllCustomers(string searchTerm)
        {
            var customers = db.Customers.Include("Accounts").ToList();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = searchTerm.ToLower();
                customers = customers.Where(c =>
                    c.First_Name.ToLower().Contains(searchTerm) ||
                    c.Email_Id.ToLower().Contains(searchTerm) ||
                    c.Customer_Id.ToString().Contains(searchTerm)
                ).ToList();
            }

            return View(customers);
        }

        public ActionResult CustomerDetails(int id)
        {
            var customer = db.Customers
                             .Include("Accounts")
                             .FirstOrDefault(c => c.Customer_Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var accountNumber = customer.Accounts.FirstOrDefault()?.Account_Number;

            var sent_transactions = db.Transaction_Details
                                 .Where(t => t.From_Account == accountNumber)
                                 .ToList();
            var received_transactions = db.Transaction_Details
                                 .Where(t => t.To_Account == accountNumber)
                                 .ToList();

            ViewBag.SentTransactions = sent_transactions;
            ViewBag.ReceivedTransactions = received_transactions;


            return View(customer);
        }



    }
}


