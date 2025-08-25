using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CC9.Models;
namespace CC9.Controllers
{
    public class CodeController : Controller
    {
        // GET: Code
        private practiceEntities db = new practiceEntities();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CustomersInGermany()
        {
            var germany = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(germany);
        }


        public ActionResult CustomerByOrderId(int orderId = 10248)
        {
            var order = db.Orders.Find(orderId);
            var customer = order.Customer;

            return View(customer);
        }
       

    }
}