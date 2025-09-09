using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Banking.Models;
using Banking.Service;
using Banking.Repositories;
namespace Banking.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        private readonly BankingDBEntities1 db = new BankingDBEntities1();
        private AdminService adminService;

        public ReportsController()
        {
            adminService = new AdminService();
        }
        public ActionResult Index(string filter, DateTime? fromDate, DateTime? toDate)
        {
            var transactions = adminService.GetFilteredTransactions(filter, fromDate, toDate);
            return View(transactions);
        }
    }
}

