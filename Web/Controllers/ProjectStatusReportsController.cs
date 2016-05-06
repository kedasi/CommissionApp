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
    public class ProjectStatusReportsController : Controller
    {
        private CommissionDbContext db = new CommissionDbContext();

        // GET: ProjectStatusReports
        public ActionResult Index()
        {
            var projectStatusReports = db.ProjectStatusReports.Include(p => p.Project);
            return View(projectStatusReports.ToList());
        }

        // GET: ProjectStatusReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectStatusReport projectStatusReport = db.ProjectStatusReports.Find(id);
            if (projectStatusReport == null)
            {
                return HttpNotFound();
            }
            return View(projectStatusReport);
        }

        // GET: ProjectStatusReports/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectId");
            return View();
        }

        // POST: ProjectStatusReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectStatusReportId,ProjectStatus,ProjectStatusDate,ProjectId")] ProjectStatusReport projectStatusReport)
        {
            if (ModelState.IsValid)
            {
                db.ProjectStatusReports.Add(projectStatusReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectId", projectStatusReport.ProjectId);
            return View(projectStatusReport);
        }

        // GET: ProjectStatusReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectStatusReport projectStatusReport = db.ProjectStatusReports.Find(id);
            if (projectStatusReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectId", projectStatusReport.ProjectId);
            return View(projectStatusReport);
        }

        // POST: ProjectStatusReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectStatusReportId,ProjectStatus,ProjectStatusDate,ProjectId")] ProjectStatusReport projectStatusReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectStatusReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectId", projectStatusReport.ProjectId);
            return View(projectStatusReport);
        }

        // GET: ProjectStatusReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectStatusReport projectStatusReport = db.ProjectStatusReports.Find(id);
            if (projectStatusReport == null)
            {
                return HttpNotFound();
            }
            return View(projectStatusReport);
        }

        // POST: ProjectStatusReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectStatusReport projectStatusReport = db.ProjectStatusReports.Find(id);
            db.ProjectStatusReports.Remove(projectStatusReport);
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
