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
    public class ProjectStatusReportCommentsController : Controller
    {
        private CommissionDbContext db = new CommissionDbContext();

        // GET: ProjectStatusReportComments
        public ActionResult Index()
        {
            var projectStatusReportComments = db.ProjectStatusReportComments.Include(p => p.ProjectStatusReport);
            return View(projectStatusReportComments.ToList());
        }

        // GET: ProjectStatusReportComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectStatusReportComment projectStatusReportComment = db.ProjectStatusReportComments.Find(id);
            if (projectStatusReportComment == null)
            {
                return HttpNotFound();
            }
            return View(projectStatusReportComment);
        }

        // GET: ProjectStatusReportComments/Create
        public ActionResult Create()
        {
            ViewBag.ProjectStatusReportId = new SelectList(db.ProjectStatusReports, "ProjectStatusReportId", "ProjectStatus");
            return View();
        }

        // POST: ProjectStatusReportComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectStatusReportCommentId,ProjectStatusComment,ProjectStatusReportId")] ProjectStatusReportComment projectStatusReportComment)
        {
            if (ModelState.IsValid)
            {
                db.ProjectStatusReportComments.Add(projectStatusReportComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectStatusReportId = new SelectList(db.ProjectStatusReports, "ProjectStatusReportId", "ProjectStatus", projectStatusReportComment.ProjectStatusReportId);
            return View(projectStatusReportComment);
        }

        // GET: ProjectStatusReportComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectStatusReportComment projectStatusReportComment = db.ProjectStatusReportComments.Find(id);
            if (projectStatusReportComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectStatusReportId = new SelectList(db.ProjectStatusReports, "ProjectStatusReportId", "ProjectStatus", projectStatusReportComment.ProjectStatusReportId);
            return View(projectStatusReportComment);
        }

        // POST: ProjectStatusReportComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectStatusReportCommentId,ProjectStatusComment,ProjectStatusReportId")] ProjectStatusReportComment projectStatusReportComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectStatusReportComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectStatusReportId = new SelectList(db.ProjectStatusReports, "ProjectStatusReportId", "ProjectStatus", projectStatusReportComment.ProjectStatusReportId);
            return View(projectStatusReportComment);
        }

        // GET: ProjectStatusReportComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectStatusReportComment projectStatusReportComment = db.ProjectStatusReportComments.Find(id);
            if (projectStatusReportComment == null)
            {
                return HttpNotFound();
            }
            return View(projectStatusReportComment);
        }

        // POST: ProjectStatusReportComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectStatusReportComment projectStatusReportComment = db.ProjectStatusReportComments.Find(id);
            db.ProjectStatusReportComments.Remove(projectStatusReportComment);
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
