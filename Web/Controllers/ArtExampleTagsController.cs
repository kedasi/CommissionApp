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
    public class ArtExampleTagsController : Controller
    {
        private CommissionDbContext db = new CommissionDbContext();

        // GET: ArtExampleTags
        public ActionResult Index()
        {
            var artExampleTags = db.ArtExampleTags.Include(a => a.ArtExample).Include(a => a.Tag);
            return View(artExampleTags.ToList());
        }

        // GET: ArtExampleTags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtExampleTag artExampleTag = db.ArtExampleTags.Find(id);
            if (artExampleTag == null)
            {
                return HttpNotFound();
            }
            return View(artExampleTag);
        }

        // GET: ArtExampleTags/Create
        public ActionResult Create()
        {
            ViewBag.ArtExampleId = new SelectList(db.ArtExamples, "ArtExampleId", "ArtExampleUrl");
            ViewBag.TagId = new SelectList(db.Tags, "TagId", "TagText");
            return View();
        }

        // POST: ArtExampleTags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtExampleTagId,TagId,ArtExampleId")] ArtExampleTag artExampleTag)
        {
            if (ModelState.IsValid)
            {
                db.ArtExampleTags.Add(artExampleTag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtExampleId = new SelectList(db.ArtExamples, "ArtExampleId", "ArtExampleUrl", artExampleTag.ArtExampleId);
            ViewBag.TagId = new SelectList(db.Tags, "TagId", "TagText", artExampleTag.TagId);
            return View(artExampleTag);
        }

        // GET: ArtExampleTags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtExampleTag artExampleTag = db.ArtExampleTags.Find(id);
            if (artExampleTag == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtExampleId = new SelectList(db.ArtExamples, "ArtExampleId", "ArtExampleUrl", artExampleTag.ArtExampleId);
            ViewBag.TagId = new SelectList(db.Tags, "TagId", "TagText", artExampleTag.TagId);
            return View(artExampleTag);
        }

        // POST: ArtExampleTags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtExampleTagId,TagId,ArtExampleId")] ArtExampleTag artExampleTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artExampleTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtExampleId = new SelectList(db.ArtExamples, "ArtExampleId", "ArtExampleUrl", artExampleTag.ArtExampleId);
            ViewBag.TagId = new SelectList(db.Tags, "TagId", "TagText", artExampleTag.TagId);
            return View(artExampleTag);
        }

        // GET: ArtExampleTags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtExampleTag artExampleTag = db.ArtExampleTags.Find(id);
            if (artExampleTag == null)
            {
                return HttpNotFound();
            }
            return View(artExampleTag);
        }

        // POST: ArtExampleTags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtExampleTag artExampleTag = db.ArtExampleTags.Find(id);
            db.ArtExampleTags.Remove(artExampleTag);
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
