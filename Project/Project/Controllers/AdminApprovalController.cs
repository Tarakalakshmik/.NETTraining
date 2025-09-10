using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.Services;
using Project.Repository;

namespace Project.Controllers
{
    public class AdminApprovalController : Controller
    {
        private readonly BankingDBEntities db = new BankingDBEntities();
        private AdminService adminService;
        private TransactionService transactionService;

        public AdminApprovalController()
        {
            adminService = new AdminService();
            transactionService = new TransactionService(new TransactionRepositoryImpl());
        }
        // GET: AdminApproval
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Message = "please enter your username and password";
                return View();
            }
            var admin = adminService.AdminLogin(email, password);

            if (admin.admin_id != -1)
            {

                Session["AdminId"] = admin.admin_id;
                return RedirectToAction("Home");
            }
           
            else
            {
                ViewBag.Message = admin.message;
                return View();
            }
        }
        public ActionResult PendingApprovals()
        {
           if (Session["AdminId"] == null)
            {
                // Redirect to login or access denied page
                return RedirectToAction("AccessDenied", "AdminApproval");
            }
            var pendingUsers = adminService.PendingApprovals();
            return View(pendingUsers.registerAccounts);
        }
        public ActionResult ViewDetails(int id)
        {
            if (Session["AdminId"] == null)
            {
                // Redirect to login or access denied page
                return RedirectToAction("AccessDenied", "AdminApproval");
            }
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
        public ActionResult Logout()
        {
            // Clear authentication cookie
            System.Web.Security.FormsAuthentication.SignOut();

            // Clear session
            Session.Clear();
            Session.Abandon();

            // Redirect to Login page (or show logout view)
            return RedirectToAction("AdminLogin", "AdminApproval");

            // OR, if you want to show a logout confirmation page:
            // return View();
        }
        public JsonResult GetDashboardCounts()
        {
            int approvalCount = db.RegisterAccounts.Count();
            int messageCount = db.SupportMessages.Count(m => m.Status == "Pending");
            int customerCount = db.Customers.Count();
            return Json(new { approvalCount, messageCount, customerCount }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllCustomers()
        {
            if (Session["AdminId"] == null)
            {
                return RedirectToAction("AccessDenied", "AdminApproval");
            }
                var allcustomers = db.Customers.Include("Accounts").ToList();
            return View(allcustomers);
        }
        public ActionResult CustomerDetails(int id)
        {
            if (Session["AdminId"] == null)
            {
                // Redirect to login or access denied page
                return RedirectToAction("AccessDenied", "AdminApproval");
            }
            var customer = db.Customers
                             .Include("Accounts")
                             .FirstOrDefault(c => c.Customer_Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var accountNumber = customer.Accounts.FirstOrDefault()?.Account_Number;

            //var sent_transactions = db.Transaction_Details
            //                     .Where(t => t.From_Account == accountNumber)
            //                     .ToList();
            //var received_transactions = db.Transaction_Details
            //                     .Where(t => t.To_Account == accountNumber)
            //                     .ToList();

            //ViewBag.SentTransactions = sent_transactions;
            //ViewBag.ReceivedTransactions = received_transactions;

            (List<Transaction_Details> transactions, string message) = transactionService.GetStatement(accountNumber.Value, Convert.ToDateTime("2000-01-01"), Convert.ToDateTime(System.DateTime.Now));
            return View((customer, transactions.OrderByDescending(t => t.Transaction_Date).ToList()));
        }
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}