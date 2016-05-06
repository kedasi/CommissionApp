using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Domain;

namespace Web.Controllers
{
    public class ArtExamplesController : Controller
    {
        private CommissionDbContext db = new CommissionDbContext();

        private IArtExampleRepository _artExampleRepository = new ArtExampleRepository(new CommissionDbContext());
        // GET: ArtExamples
        public ActionResult Index()
        {
            var artExamples = db.ArtExamples.Include(a => a.Picture).Include(a => a.User);
            return View(artExamples.ToList());
        }

        // GET: ArtExamples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtExample artExample = db.ArtExamples.Find(id);
            if (artExample == null)
            {
                return HttpNotFound();
            }
            return View(artExample);
        }

        // GET: ArtExamples/Create
        public ActionResult Create()
        {
            ViewBag.PictureId = new SelectList(db.Pictures, "PictureId", "PictureUrl");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username");
            return View();
        }

        // POST: ArtExamples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtExampleId,ArtExampleUrl,ArtExampleComment,ArtExampleDate,UserId,PictureId")] ArtExample artExample)
        {
            if (ModelState.IsValid)
            {
                db.ArtExamples.Add(artExample);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PictureId = new SelectList(db.Pictures, "PictureId", "PictureUrl", artExample.PictureId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", artExample.UserId);
            return View(artExample);
        }

        // GET: ArtExamples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtExample artExample = db.ArtExamples.Find(id);
            if (artExample == null)
            {
                return HttpNotFound();
            }
            ViewBag.PictureId = new SelectList(db.Pictures, "PictureId", "PictureUrl", artExample.PictureId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", artExample.UserId);
            return View(artExample);
        }

        // POST: ArtExamples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtExampleId,ArtExampleUrl,ArtExampleComment,ArtExampleDate,UserId,PictureId")] ArtExample artExample)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artExample).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PictureId = new SelectList(db.Pictures, "PictureId", "PictureUrl", artExample.PictureId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", artExample.UserId);
            return View(artExample);
        }

        // GET: ArtExamples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ArtExample artExample = db.ArtExamples.Find(id);
            if (artExample == null)
            {
                return HttpNotFound();
            }
            return View(artExample);
        }

        // POST: ArtExamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ArtExample artExample = db.ArtExamples.Find(id);
            db.ArtExamples.Remove(artExample);
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
