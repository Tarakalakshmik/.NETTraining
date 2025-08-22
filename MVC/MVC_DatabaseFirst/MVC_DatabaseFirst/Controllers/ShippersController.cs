using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_DatabaseFirst.Models;
using System.Dynamic;

namespace MVC_DatabaseFirst.Controllers
{
    public class ShipperController : Controller
    {
       practiceEntities db = new practiceEntities();
      
        public ActionResult Index()
        {
            return View(db.Shippers.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //1. passing data from view to controller using forms collection
        //public ActionResult Create(FormCollection frm)
        //{
        //    Shipper s = new Shipper();
        //    s.ShipperID = Convert.ToInt32(frm["ShipperID"]);
        //    s.CompanyName = frm["CompanyName"].ToString();
        //    s.Phone = frm["Phone"].ToString();

        //    db.Shippers.Add(s);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //2. passing data from view to controller using parameter collection
        //use the same name as that of the class/entity

        //public ActionResult Create(string CompanyName, string Phone)
        //{
        //    Shipper s = new Shipper();
        //    s.CompanyName = CompanyName;
        //    s.Phone = Phone;
        //    db.Shippers.Add(s);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");               
        //}

        //3. passing data from view to controller using Request Object 
        [ActionName("Create")]
        public ActionResult CreatePost()
        {
            Shipper s = new Shipper();
            s.ShipperID = Convert.ToInt32(Request["ShipperID"]);
            s.CompanyName = Request["CompanyName"].ToString();
            s.Phone = Request["Phone"].ToString();

            db.Shippers.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //4. Stored procedure calling



        public ActionResult Sp_With_Parameter(string customerId)
        {


            var result = db.CustOrdersOrders(customerId).ToList();
            return View("Sp_Result", result);

            
        }
        public ActionResult MultipleData()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.OrderList = db.Orders.ToList();
            mymodel.CustList = db.Customers.ToList();
            return View(db.Orders.ToList()) ;
           
        }
    }
}