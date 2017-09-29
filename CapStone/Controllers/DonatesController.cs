using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CapStone.Models;

namespace CapStone.Controllers
{
    public class DonatesController : Controller
    {
        private BooksDBContext db = new BooksDBContext();

        // GET: Donates
        public ActionResult Index()
        {
            return View(db.Donates.ToList());
        }

        // GET: Donates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donate donate = db.Donates.Find(id);
            if (donate == null)
            {
                return HttpNotFound();
            }
            return View(donate);
        }

        // GET: Donates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ISBN,ReleaseDate,Genre,Price,Rating")] Donate donate)
        {
            if (ModelState.IsValid)
            {
                db.Donates.Add(donate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donate);
        }

        // GET: Donates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donate donate = db.Donates.Find(id);
            if (donate == null)
            {
                return HttpNotFound();
            }
            return View(donate);
        }

        // POST: Donates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ISBN,ReleaseDate,Genre,Price,Rating")] Donate donate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donate);
        }

        // GET: Donates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donate donate = db.Donates.Find(id);
            if (donate == null)
            {
                return HttpNotFound();
            }
            return View(donate);
        }

        // POST: Donates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donate donate = db.Donates.Find(id);
            db.Donates.Remove(donate);
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
