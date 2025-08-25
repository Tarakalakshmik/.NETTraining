using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CC9.Models
{
    public class Movies
    {
        [Key]

        [Required]

        public int Mid { get; set; }

        [Required]

        public string MovieName { get; set; }

        [Required]

        public string DirectorName { get; set; }

        [DataType(DataType.Date)]
        [Required]


        public DateTime DateOfRelease { get; set; }
    }
}