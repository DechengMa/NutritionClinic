using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT5032_Assignment.Models
{
    public class PostingModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string NutritionistId { get; set; }

        public string CustomerId { get; set; }

        [Required]
        public DateTime PostTime { get; set; }

        [Required]
        public string Content { get; set; }
    }
}