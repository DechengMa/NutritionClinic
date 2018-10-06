using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032_Assignment.Models
{
    public class BookingModel
    {

        public int Id { get; set; }
        public string Title { get; set; }

        [Display( Name = "Nutritionist Name")]
        public string NutritionistId { get; set; }
        public string CustomerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Remarks { get; set; }
    }
}