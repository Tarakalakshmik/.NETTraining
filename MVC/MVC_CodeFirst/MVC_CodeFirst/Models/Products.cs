﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CodeFirst.Models
{
    public class Products
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }
    }
}
///enable-migrations
///add-migration "Initial Create"
///update-database