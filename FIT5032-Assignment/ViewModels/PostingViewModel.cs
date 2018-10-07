using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FIT5032_Assignment.Models;

namespace FIT5032_Assignment.ViewModels
{
    public class PostingViewModel
    {

        public IEnumerable<ApplicationUser> ApplicationUser { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string CustomerId { get; set; }

        [Required]
        [Display(Name = "What do you want to say?")]
        [MinLength(15)]
        public string Contents { get; set; }
    }
}