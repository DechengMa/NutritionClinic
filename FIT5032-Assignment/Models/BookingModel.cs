using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032_Assignment.Models
{
    public class BookingModel
    {

        [Required]
        public int Id { get; set; }


        [Required]
        public string Title { get; set; }

        [Required]
        [Display( Name = "Nutritionist Name")]
        public string NutritionistId { get; set; }


        [Required]
        public string CustomerId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
        
        public string Remarks { get; set; }

        [Required]
        public string BookingStatus { get; set; }
    }
}