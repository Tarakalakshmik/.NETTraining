using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewModels_Prj.Models
{
    public class EmployeeAddress_view_model_
    {
        public Employee employee { get; set; }
        public Address address { get; set; }
        public string PageTitle { get; set; }

    }
}