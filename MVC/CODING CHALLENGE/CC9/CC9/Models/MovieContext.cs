using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
namespace CC9.Models
{
    public class MovieContext:DbContext
    {
       
            public MovieContext() : base("name=connectstr") { }

            public DbSet<Movies> Movies { get; set; }
          

        
    }
}