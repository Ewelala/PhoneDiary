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
    /// <summary>
    /// kontroller obsługujacy zapis, odczyt i edycję dotyczącą ludzi wpisanych do książki.
    /// </summary>
    public class PeopleController : Controller
    {
        private PhoneDiaryEntities db = new PhoneDiaryEntities();

        /// <summary>
        /// Zwraca widok z listą aktualnie zapisanych ludzi.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.People.ToList());
        }

        /// <summary>
        /// Zwraca szczegoły dla danego człowieka na podstawie przekazanego Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

       /// <summary>
       /// Otwiera widok który umożliwia utworzenie nowego wpisu z danymi kontaktowymi.
       /// </summary>
       /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Tworzy nowy wpis w bazie danych na podstawie danych z formularza.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,LastName")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        /// <summary>
        /// Otwiera widok umożliwiający edycję kontaktu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

       /// <summary>
       /// Zapisuje do bazy kontakt po edycji, przekazujemy obiekt person z formularza.
       /// </summary>
       /// <param name="person"></param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,LastName")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }
        /// <summary>
        /// Usuwa z bazy wpis na podstawie Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                Person person = db.People.Find(id);
                db.People.Remove(person);
                db.SaveChanges();
                return Content("success");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        /// <summary>
        /// Przekazuje obiekt do usunięcia z pamięci
        /// </summary>
        /// <param name="disposing"></param>
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
