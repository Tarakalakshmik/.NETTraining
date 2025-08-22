using System;
using System.Collections.Generic;
//using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_DatabaseFirst.Models;

namespace MVC_DatabaseFirst.Controllers
{
    public class Product1Controller : Controller
    {
            practiceEntities db = new practiceEntities();

        // GET: Product1
        //eager adding category and supplier
        public ActionResult Index()
        {
            var products1 = db.Products1.Include(p => p.Category).Include(p => p.Supplier);
            return View(products1.ToList());
        }

        
       

        // Create
        public ActionResult Create()
        {
            
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Product1 product1)
        {
            if (ModelState.IsValid)
            {
                db.Products1.Add(product1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product1.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product1.SupplierID);
            return View(product1);
        }

        // Edit
        public ActionResult Edit(int? id)
        {
            
            Product1 product1 = db.Products1.Find(id);
            
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product1.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product1.SupplierID);
            return View(product1);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Product1 product1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product1.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product1.SupplierID);
            return View(product1);
        }

        // Delete
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product1 product1 = db.Products1.Find(id);
            if (product1 == null)
            {
                return HttpNotFound();
            }
            return View(product1);
        }

        // Delete
        //[HttpPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product1 product1 = db.Products1.Find(id);
            db.Products1.Remove(product1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      
    }
}
