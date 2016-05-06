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
    public class CreditCardInfosController : Controller
    {
        private CommissionDbContext db = new CommissionDbContext();

        // GET: CreditCardInfos
        public ActionResult Index()
        {
            return View(db.CreditCardInfos.ToList());
        }

        // GET: CreditCardInfos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCardInfo creditCardInfo = db.CreditCardInfos.Find(id);
            if (creditCardInfo == null)
            {
                return HttpNotFound();
            }
            return View(creditCardInfo);
        }

        // GET: CreditCardInfos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreditCardInfos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CreditCardInfoId,FirstName,LastName,CreditCardNumber,SecurityNumber,ExpirationDate")] CreditCardInfo creditCardInfo)
        {
            if (ModelState.IsValid)
            {
                db.CreditCardInfos.Add(creditCardInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(creditCardInfo);
        }

        // GET: CreditCardInfos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCardInfo creditCardInfo = db.CreditCardInfos.Find(id);
            if (creditCardInfo == null)
            {
                return HttpNotFound();
            }
            return View(creditCardInfo);
        }

        // POST: CreditCardInfos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CreditCardInfoId,FirstName,LastName,CreditCardNumber,SecurityNumber,ExpirationDate")] CreditCardInfo creditCardInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creditCardInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(creditCardInfo);
        }

        // GET: CreditCardInfos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditCardInfo creditCardInfo = db.CreditCardInfos.Find(id);
            if (creditCardInfo == null)
            {
                return HttpNotFound();
            }
            return View(creditCardInfo);
        }

        // POST: CreditCardInfos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreditCardInfo creditCardInfo = db.CreditCardInfos.Find(id);
            db.CreditCardInfos.Remove(creditCardInfo);
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
