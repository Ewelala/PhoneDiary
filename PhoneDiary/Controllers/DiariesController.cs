using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhoneDiary.Models;

namespace PhoneDiary.Controllers
{
    public class DiariesController : Controller
    {
        private PhoneDiaryEntities db = new PhoneDiaryEntities();

        // GET: Diaries
        public ActionResult Index()
        {
            var diaries = db.Diaries.Include(d => d.Address).Include(d => d.Person);
            return View(diaries.ToList());
        }

        // GET: Diaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diary diary = db.Diaries.Find(id);
            if (diary == null)
            {
                return HttpNotFound();
            }
            return View(diary);
        }

        // GET: Diaries/Create
        public ActionResult Create()
        {
            ViewBag.AddressID = new SelectList(db.Addresses, "ID", "Street");
            ViewBag.PersonID = new SelectList(db.People, "ID", "FullName");
            return View();
        }

        // POST: Diaries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PersonID,AddressID,Phone,Email")] Diary diary)
        {
            if (ModelState.IsValid)
            {
                db.Diaries.Add(diary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "ID", "Street", diary.AddressID);
            ViewBag.PersonID = new SelectList(db.People, "ID", "FullName", diary.PersonID);
            return View(diary);
        }

        // GET: Diaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diary diary = db.Diaries.Find(id);
            if (diary == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "ID", "Street", diary.AddressID);
            ViewBag.PersonID = new SelectList(db.People, "ID", "FullName", diary.PersonID);
            return View(diary);
        }

        // POST: Diaries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PersonID,AddressID,Phone,Email")] Diary diary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "ID", "Street", diary.AddressID);
            ViewBag.PersonID = new SelectList(db.People, "ID", "FullName", diary.PersonID);
            return View(diary);
        }


        // POST: Diaries/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Diary diary = db.Diaries.Find(id);
                db.Diaries.Remove(diary);
                db.SaveChanges();
                return Content("success");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
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
