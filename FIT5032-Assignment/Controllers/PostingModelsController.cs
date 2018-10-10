using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_Assignment.Models;

namespace FIT5032_Assignment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PostingModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PostingModels
        public ActionResult Index()
        {
            return View(db.PostingModels.ToList());
        }

        // GET: PostingModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostingModel postingModel = db.PostingModels.Find(id);
            if (postingModel == null)
            {
                return HttpNotFound();
            }
            return View(postingModel);
        }

        // GET: PostingModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostingModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,NutritionistId,CustomerId,PostTime,Content")] PostingModel postingModel)
        {
            if (ModelState.IsValid)
            {
                db.PostingModels.Add(postingModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postingModel);
        }

        // GET: PostingModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostingModel postingModel = db.PostingModels.Find(id);
            if (postingModel == null)
            {
                return HttpNotFound();
            }
            return View(postingModel);
        }

        // POST: PostingModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,NutritionistId,CustomerId,PostTime,Content")] PostingModel postingModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postingModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postingModel);
        }

        // GET: PostingModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostingModel postingModel = db.PostingModels.Find(id);
            if (postingModel == null)
            {
                return HttpNotFound();
            }
            return View(postingModel);
        }

        // POST: PostingModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostingModel postingModel = db.PostingModels.Find(id);
            db.PostingModels.Remove(postingModel);
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
