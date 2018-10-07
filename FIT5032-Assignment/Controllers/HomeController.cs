using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT5032_Assignment.Models;
using FIT5032_Assignment.ViewModels;
using Microsoft.AspNet.Identity;

namespace FIT5032_Assignment.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            if (User.IsInRole("Customer"))
            {
                string userId = User.Identity.GetUserId();
                var postingModel = _context.PostingModels.Where(x => x.CustomerId == userId);
//                var postingViewModel = from p in postingModel
//                    select new PostingViewModel()
//                    {
//                        Title = p.Title,
//                        CustomerId = p.CustomerId,
//                        Contents = p.Content
//                    };

                HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
                {
                    PostingModel = postingModel
                };
                return View(homeIndexViewModel);
            }
            else if (User.IsInRole("Nutritionist"))
            {
                string userId = User.Identity.GetUserId();
                var bookingModel = _context.BookingModels.Where(x => x.NutritionistId == userId);
                HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
                {
                    BookingModel = bookingModel
                };
                return View(homeIndexViewModel);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PostDetail()
        {
            return View();
        }
    }
}