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
                foreach (var post in postingModel)
                {
                    post.CustomerId = getFirstName(post.CustomerId, _context);
                    post.NutritionistId = getFirstName(post.NutritionistId, _context);
                }

                HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
                {
                    PostingModel = postingModel
                };
                return View(homeIndexViewModel);
            }
            else if(User.IsInRole("Nutritionist"))
            {
                string userId = User.Identity.GetUserId();
                var postingModel = _context.PostingModels.Where(x => x.NutritionistId == userId);
                foreach (var post in postingModel)
                {
                    post.CustomerId = getFirstName(post.CustomerId, _context);
                    post.NutritionistId = getFirstName(post.NutritionistId, _context);
                }

                HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
                {
                    PostingModel = postingModel
                };
                return View(homeIndexViewModel);
            }
            else
            {
                HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel();
                View(homeIndexViewModel);
            }
            return View();
        }

        public string getFirstName(string id,ApplicationDbContext _context)
        {
            string firstName = "UnKnown";
            var user = _context.Users.Where(x => x.Id == id);
            foreach (var applicationUser in user)
            {
                 firstName = applicationUser.FirstName;
            }          

            return firstName;
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