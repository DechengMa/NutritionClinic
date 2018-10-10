using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_Assignment.Models;
using FIT5032_Assignment.Utils;
using Microsoft.AspNet.Identity;

namespace FIT5032_Assignment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BookingModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookingModels
        public ActionResult Index()
        {
            return View(db.BookingModels.ToList());
        }

        // GET: BookingModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingModel bookingModel = db.BookingModels.Find(id);
            if (bookingModel == null)
            {
                return HttpNotFound();
            }
            return View(bookingModel);
        }

        // GET: BookingModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,NutritionistId,CustomerId,StartTime,EndTime,Remarks,BookingStatus")] BookingModel bookingModel)
        {
            if (ModelState.IsValid)
            {
                db.BookingModels.Add(bookingModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookingModel);
        }

        // GET: BookingModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingModel bookingModel = db.BookingModels.Find(id);
            if (bookingModel == null)
            {
                return HttpNotFound();
            }
            return View(bookingModel);
        }

        // POST: BookingModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,NutritionistId,CustomerId,StartTime,EndTime,Remarks,BookingStatus")] BookingModel bookingModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingModel).State = EntityState.Modified;
                db.SaveChanges();
                EmailSender es = new EmailSender();
                //                var manager = new UserManager<ApplicationUser>(new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(new ApplicationDbContext()));
                //                var currentUser = manager.FindById(User.Identity.GetUserId());
                var userEmailAddress = db.Users
                    .Where(m => m.Id == bookingModel.CustomerId)
                    .Select(m => m.Email)
                    .SingleOrDefault();
                if (bookingModel.BookingStatus != "Pending")
                {
                    es.Send(userEmailAddress, "Reservation "+ bookingModel.BookingStatus, "Hi Customer:"+
                                                                                          "<br><br>Just to inform:" +
                                                                                "Your reservation is " + bookingModel.BookingStatus + ", please don't reply to this email" +
                                                                                "<br><br>Cheers <br>Caulfield Nutrition Clinic ");
                }


                return RedirectToAction("Index");
            }
            return View(bookingModel);
        }

        // GET: BookingModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingModel bookingModel = db.BookingModels.Find(id);
            if (bookingModel == null)
            {
                return HttpNotFound();
            }
            return View(bookingModel);
        }

        // POST: BookingModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingModel bookingModel = db.BookingModels.Find(id);
            db.BookingModels.Remove(bookingModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
