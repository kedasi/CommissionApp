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
    public class UserMessagesController : Controller
    {
        private CommissionDbContext db = new CommissionDbContext();

        // GET: UserMessages
        public ActionResult Index()
        {
            return View(db.UserMessages.ToList());
        }

        // GET: UserMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMessage userMessage = db.UserMessages.Find(id);
            if (userMessage == null)
            {
                return HttpNotFound();
            }
            return View(userMessage);
        }

        // GET: UserMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserMessageId,UserMessageTitle,UserMessageText")] UserMessage userMessage)
        {
            if (ModelState.IsValid)
            {
                db.UserMessages.Add(userMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userMessage);
        }

        // GET: UserMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMessage userMessage = db.UserMessages.Find(id);
            if (userMessage == null)
            {
                return HttpNotFound();
            }
            return View(userMessage);
        }

        // POST: UserMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserMessageId,UserMessageTitle,UserMessageText")] UserMessage userMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userMessage);
        }

        // GET: UserMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMessage userMessage = db.UserMessages.Find(id);
            if (userMessage == null)
            {
                return HttpNotFound();
            }
            return View(userMessage);
        }

        // POST: UserMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserMessage userMessage = db.UserMessages.Find(id);
            db.UserMessages.Remove(userMessage);
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
