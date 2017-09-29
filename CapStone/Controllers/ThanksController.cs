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
    public class ThanksController : Controller
    {
        private BooksDBContext db = new BooksDBContext();

        // GET: Thanks
        public ActionResult Index()
        {
            return View(db.Thanks.ToList());
        }

        // GET: Thanks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thanks thanks = db.Thanks.Find(id);
            if (thanks == null)
            {
                return HttpNotFound();
            }
            return View(thanks);
        }

        // GET: Thanks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Thanks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ISBN,ReleaseDate,Genre,Price,Rating")] Thanks thanks)
        {
            if (ModelState.IsValid)
            {
                db.Thanks.Add(thanks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thanks);
        }

        // GET: Thanks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thanks thanks = db.Thanks.Find(id);
            if (thanks == null)
            {
                return HttpNotFound();
            }
            return View(thanks);
        }

        // POST: Thanks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ISBN,ReleaseDate,Genre,Price,Rating")] Thanks thanks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thanks);
        }

        // GET: Thanks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thanks thanks = db.Thanks.Find(id);
            if (thanks == null)
            {
                return HttpNotFound();
            }
            return View(thanks);
        }

        // POST: Thanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Thanks thanks = db.Thanks.Find(id);
            db.Thanks.Remove(thanks);
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
