using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels_Prj.Models;
namespace ViewModels_Prj.Controllers
{
    public class ViewModelController : Controller
    {
        // GET: ViewModel
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmpAddDetails()
        {
            Employee e = new Employee()
            {
                EID = 101,
                EName ="Harshitha",

                AddressId = 1
            };
            Address addr = new Address()
            {

                AddressID = 1,
                 DoorNo="4,ABC Villa",
                 Street="GulliNo 420",
                 city="MyCity"
            };
            //view model object
            EmployeeAddress_view_model_ empadd = new EmployeeAddress_view_model_();

        }
    }
}