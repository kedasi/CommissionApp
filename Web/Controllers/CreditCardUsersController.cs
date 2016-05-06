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
    public class CreditCardUsersController : Controller
    {
        private CommissionDbContext db = new CommissionDbContext();

        // GET: CreditCardUsers
        public ActionResult Index()
        {
            var creditCardUsers = db.CreditCardUsers.Include(c => c.CreditCardInfo).Include(c => c.User);
            return View(creditCardUsers.ToList());
        }

        // GET: CreditCardUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCardUser creditCardUser = db.CreditCardUsers.Find(id);
            if (creditCardUser == null)
            {
                return HttpNotFound();
            }
            return View(creditCardUser);
        }

        // GET: CreditCardUsers/Create
        public ActionResult Create()
        {
            ViewBag.CreditCardInfoId = new SelectList(db.CreditCardInfos, "CreditCardInfoId", "FirstName");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username");
            return View();
        }

        // POST: CreditCardUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CreditCardUserId,CreditCardInfoId,UserId")] CreditCardUser creditCardUser)
        {
            if (ModelState.IsValid)
            {
                db.CreditCardUsers.Add(creditCardUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreditCardInfoId = new SelectList(db.CreditCardInfos, "CreditCardInfoId", "FirstName", creditCardUser.CreditCardInfoId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", creditCardUser.UserId);
            return View(creditCardUser);
        }

        // GET: CreditCardUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCardUser creditCardUser = db.CreditCardUsers.Find(id);
            if (creditCardUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreditCardInfoId = new SelectList(db.CreditCardInfos, "CreditCardInfoId", "FirstName", creditCardUser.CreditCardInfoId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", creditCardUser.UserId);
            return View(creditCardUser);
        }

        // POST: CreditCardUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CreditCardUserId,CreditCardInfoId,UserId")] CreditCardUser creditCardUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creditCardUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreditCardInfoId = new SelectList(db.CreditCardInfos, "CreditCardInfoId", "FirstName", creditCardUser.CreditCardInfoId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Username", creditCardUser.UserId);
            return View(creditCardUser);
        }

        // GET: CreditCardUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCardUser creditCardUser = db.CreditCardUsers.Find(id);
            if (creditCardUser == null)
            {
                return HttpNotFound();
            }
            return View(creditCardUser);
        }

        // POST: CreditCardUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreditCardUser creditCardUser = db.CreditCardUsers.Find(id);
            db.CreditCardUsers.Remove(creditCardUser);
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
