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
    public class ArtMessagesController : Controller
    {
        private CommissionDbContext db = new CommissionDbContext();

        // GET: ArtMessages
        public ActionResult Index()
        {
            var artMessages = db.ArtMessages.Include(a => a.ArtExample).Include(a => a.UserMessage);
            return View(artMessages.ToList());
        }

        // GET: ArtMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtMessage artMessage = db.ArtMessages.Find(id);
            if (artMessage == null)
            {
                return HttpNotFound();
            }
            return View(artMessage);
        }

        // GET: ArtMessages/Create
        public ActionResult Create()
        {
            ViewBag.ArtExampleId = new SelectList(db.ArtExamples, "ArtExampleId", "ArtExampleUrl");
            ViewBag.UserMessageId = new SelectList(db.UserMessages, "UserMessageId", "UserMessageTitle");
            return View();
        }

        // POST: ArtMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtMessageId,Title,ArtMessageText,UserMessageId,ArtExampleId")] ArtMessage artMessage)
        {
            if (ModelState.IsValid)
            {
                db.ArtMessages.Add(artMessage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtExampleId = new SelectList(db.ArtExamples, "ArtExampleId", "ArtExampleUrl", artMessage.ArtExampleId);
            ViewBag.UserMessageId = new SelectList(db.UserMessages, "UserMessageId", "UserMessageTitle", artMessage.UserMessageId);
            return View(artMessage);
        }

        // GET: ArtMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtMessage artMessage = db.ArtMessages.Find(id);
            if (artMessage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtExampleId = new SelectList(db.ArtExamples, "ArtExampleId", "ArtExampleUrl", artMessage.ArtExampleId);
            ViewBag.UserMessageId = new SelectList(db.UserMessages, "UserMessageId", "UserMessageTitle", artMessage.UserMessageId);
            return View(artMessage);
        }

        // POST: ArtMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtMessageId,Title,ArtMessageText,UserMessageId,ArtExampleId")] ArtMessage artMessage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artMessage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtExampleId = new SelectList(db.ArtExamples, "ArtExampleId", "ArtExampleUrl", artMessage.ArtExampleId);
            ViewBag.UserMessageId = new SelectList(db.UserMessages, "UserMessageId", "UserMessageTitle", artMessage.UserMessageId);
            return View(artMessage);
        }

        // GET: ArtMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtMessage artMessage = db.ArtMessages.Find(id);
            if (artMessage == null)
            {
                return HttpNotFound();
            }
            return View(artMessage);
        }

        // POST: ArtMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtMessage artMessage = db.ArtMessages.Find(id);
            db.ArtMessages.Remove(artMessage);
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
