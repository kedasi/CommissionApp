using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Domain;

namespace Web.Controllers
{
    public class UserFeedbacksController : Controller
    {
        private CommissionDbContext db = new CommissionDbContext();

        // GET: UserFeedbacks
        public ActionResult Index()
        {
            var userFeedbacks = db.UserFeedbacks.Include(u => u.User);
            return View(userFeedbacks.ToList());
        }

        // GET: UserFeedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFeedback userFeedback = db.UserFeedbacks.Find(id);
            if (userFeedback == null)
            {
                return HttpNotFound();
            }
            return View(userFeedback);
        }

        // GET: UserFeedbacks/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username");
            return View();
        }

        // POST: UserFeedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserFeedbackId,Stars,Comment,UserId")] UserFeedback userFeedback)
        {
            if (ModelState.IsValid)
            {
                db.UserFeedbacks.Add(userFeedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", userFeedback.UserId);
            return View(userFeedback);
        }

        // GET: UserFeedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFeedback userFeedback = db.UserFeedbacks.Find(id);
            if (userFeedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", userFeedback.UserId);
            return View(userFeedback);
        }

        // POST: UserFeedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserFeedbackId,Stars,Comment,UserId")] UserFeedback userFeedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userFeedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", userFeedback.UserId);
            return View(userFeedback);
        }

        // GET: UserFeedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFeedback userFeedback = db.UserFeedbacks.Find(id);
            if (userFeedback == null)
            {
                return HttpNotFound();
            }
            return View(userFeedback);
        }

        // POST: UserFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserFeedback userFeedback = db.UserFeedbacks.Find(id);
            db.UserFeedbacks.Remove(userFeedback);
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
