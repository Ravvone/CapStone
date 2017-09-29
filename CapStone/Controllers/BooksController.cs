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
    public class BooksController : Controller
    {
        private BooksDBContext db = new BooksDBContext();

        // GET: Books
        public ActionResult Index(string bookGenre, string searchString, DateTime? searchDate)
        {
            var GenreLst = new List<string>();

            var GenreQry = from d in db.Book
                           orderby d.Genre
                           select d.Genre;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.bookGenre = new SelectList(GenreLst);

            var books = from m in db.Book
                         select m;


            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(bookGenre))
            {
                books = books.Where(x => x.Genre == bookGenre);
            }
            var dateFilter = Convert.ToString(searchDate);

            if (!string.IsNullOrEmpty(dateFilter))
            {
                //movies = movies.Where(z => z.ReleaseDate == searchDate);
                books = books.Where(z => Convert.ToString(z.ReleaseDate).Contains(dateFilter));
            }

            return View(books);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Book.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }
        //public ActionResult Confirmation()
        //{
        //    return View();
        //}

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ISBN,ReleaseDate,Genre,Price,Rating")] Books books)
        {
            if (ModelState.IsValid)
            {
                db.Book.Add(books);
                db.SaveChanges();
                return RedirectToAction("Confirmation",books);
            }

            return View(books);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Book.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ISBN,ReleaseDate,Genre,Price,Rating")] Books books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(books);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Book.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Books books = db.Book.Find(id);
            db.Book.Remove(books);
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
        public ActionResult Confirmation(Books book)
        {
            return View(book);
        }
    }
}
