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
    public class TagTypesController : Controller
    {
        //private CommissionDbContext db = new CommissionDbContext();

        private ITagTypeRepository _tagTypeRepository = new TagTypeRepository(new CommissionDbContext());

        // GET: TagTypes
        public ActionResult Index()
        {
            return View(_tagTypeRepository.All);
        }

        // GET: TagTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TagType tagType = _tagTypeRepository.GetById(id);
            if (tagType == null)
            {
                return HttpNotFound();
            }
            return View(tagType);
        }

        // GET: TagTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TagTypeId,TagTypeValue")] TagType tagType)
        {
            if (ModelState.IsValid)
            {
                _tagTypeRepository.Add(tagType);
                _tagTypeRepository.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tagType);
        }

        // GET: TagTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TagType tagType = _tagTypeRepository.GetById(id);
            if (tagType == null)
            {
                return HttpNotFound();
            }
            return View(tagType);
        }

        // POST: TagTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TagTypeId,TagTypeValue")] TagType tagType)
        {
            if (ModelState.IsValid)
            {
                _tagTypeRepository.Update(tagType);
                _tagTypeRepository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tagType);
        }

        // GET: TagTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TagType tagType = _tagTypeRepository.GetById(id);
            if (tagType == null)
            {
                return HttpNotFound();
            }
            return View(tagType);
        }

        // POST: TagTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            _tagTypeRepository.Delete(id);
            _tagTypeRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tagTypeRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
