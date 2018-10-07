using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FIT5032_Assignment.Models;

namespace FIT5032_Assignment.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<PostingModel> PostingModel { get; set; }
        public IEnumerable<BookingModel> BookingModel { get; set; }
    }
}