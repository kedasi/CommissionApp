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
    public class UserTagsController : Controller
    {
        private CommissionDbContext db = new CommissionDbContext();

        // GET: UserTags
        public ActionResult Index()
        {
            var userTags = db.UserTags.Include(u => u.Tag).Include(u => u.User);
            return View(userTags.ToList());
        }

        // GET: UserTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTag userTag = db.UserTags.Find(id);
            if (userTag == null)
            {
                return HttpNotFound();
            }
            return View(userTag);
        }

        // GET: UserTags/Create
        public ActionResult Create()
        {
            ViewBag.TagId = new SelectList(db.Tags, "TagId", "TagText");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username");
            return View();
        }

        // POST: UserTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserTagId,UserId,TagId")] UserTag userTag)
        {
            if (ModelState.IsValid)
            {
                db.UserTags.Add(userTag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TagId = new SelectList(db.Tags, "TagId", "TagText", userTag.TagId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", userTag.UserId);
            return View(userTag);
        }

        // GET: UserTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTag userTag = db.UserTags.Find(id);
            if (userTag == null)
            {
                return HttpNotFound();
            }
            ViewBag.TagId = new SelectList(db.Tags, "TagId", "TagText", userTag.TagId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", userTag.UserId);
            return View(userTag);
        }

        // POST: UserTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserTagId,UserId,TagId")] UserTag userTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TagId = new SelectList(db.Tags, "TagId", "TagText", userTag.TagId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", userTag.UserId);
            return View(userTag);
        }

        // GET: UserTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTag userTag = db.UserTags.Find(id);
            if (userTag == null)
            {
                return HttpNotFound();
            }
            return View(userTag);
        }

        // POST: UserTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserTag userTag = db.UserTags.Find(id);
            db.UserTags.Remove(userTag);
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
