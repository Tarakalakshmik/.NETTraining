using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Question2.Models;
using System.Web.Http.Description;
using Swashbuckle.Swagger;
namespace Question2.Controllers
{
    public class OrdersController : ApiController
    {
        // GET: Orders
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private practiceEntities1 db = new practiceEntities1();

        [ResponseType(typeof(Employee))]
        [Route("api/customers/byempid")]
        public IHttpActionResult GetOrdersByEmployeeId(int id)
        {
            var orders = db.Orders
                .Where(o => o.EmployeeID == id)
                .ToList();

            return Ok(orders);
        }
        [HttpGet]
        [Route("api/customers/bycountry")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var customers = db.GetCustomersByCountry(country).ToList();
            return Ok(customers);
        }
    }
}