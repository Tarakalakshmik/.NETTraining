using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Custom_Remote_Validations.Models
{
    public class CustomerModel
    {
        public string Name { get; set; }
        [Remote("IsEmailExists","Customer",ErrorMessage="Email already exists")]
        public string Email { get; set; }
    }
}