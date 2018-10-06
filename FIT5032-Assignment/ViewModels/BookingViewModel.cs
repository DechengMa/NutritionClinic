using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FIT5032_Assignment.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FIT5032_Assignment.ViewModels
{
    public class BookingViewModel
    {
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public IEnumerable<ApplicationUser> ApplicationUser { get; set; }

        [Required]
        [Display(Name = "Nutritionist Name")]
        public string NutritionistId { get; set; }

//        [DataType(DataType.Date)]
        [Required]
        public DateTime DateAndTime { get; set; }

        [Display(Name = "Duration(Hours)")]
        [Required]
        public int Duration { get; set; }

        public string Remarks { get; set;  }
    }
}