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
    public class ConfirmationsController : Controller
    {
        private BooksDBContext db = new BooksDBContext();

        // GET: Confirmations
        public ActionResult Index()
        {
            return View(db.Confirmations.ToList());
        }

        // GET: Confirmations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Confirmation confirmation = db.Confirmations.Find(id);
            if (confirmation == null)
            {
                return HttpNotFound();
            }
            return View(confirmation);
        }

        // GET: Confirmations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Confirmations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ISBN,ReleaseDate,Genre,Price,Rating")] Confirmation confirmation)
        {
            if (ModelState.IsValid)
            {
                db.Confirmations.Add(confirmation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(confirmation);
        }

        // GET: Confirmations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Confirmation confirmation = db.Confirmations.Find(id);
            if (confirmation == null)
            {
                return HttpNotFound();
            }
            return View(confirmation);
        }

        // POST: Confirmations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ISBN,ReleaseDate,Genre,Price,Rating")] Confirmation confirmation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(confirmation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(confirmation);
        }

        // GET: Confirmations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Confirmation confirmation = db.Confirmations.Find(id);
            if (confirmation == null)
            {
                return HttpNotFound();
            }
            return View(confirmation);
        }

        // POST: Confirmations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Confirmation confirmation = db.Confirmations.Find(id);
            db.Confirmations.Remove(confirmation);
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
