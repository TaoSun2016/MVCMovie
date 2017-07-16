using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Movie.Models;

namespace Movie.Controllers
{
    public class MovieesController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: Moviees
        public ActionResult Index(string searchString)
        {
            //return View(db.Movies.ToList());
            var moviees = from m in db.Movies
                          select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                moviees = moviees.Where(s=>s.Title.Contains(searchString));
            }
            return View(moviees);
   
        }
        [HttpPost]
        public string Index(FormCollection  fc, string searchString)
        {
            return "<h3>Form[HttpPost]Index:" + searchString + "</h3>";
        }

        // GET: Moviees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moviee moviee = db.Movies.Find(id);
            if (moviee == null)
            {
                return HttpNotFound();
            }
            return View(moviee);
        }

        // GET: Moviees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moviees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] Moviee moviee)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(moviee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moviee);
        }

        // GET: Moviees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moviee moviee = db.Movies.Find(id);
            if (moviee == null)
            {
                return HttpNotFound();
            }
            return View(moviee);
        }

        // POST: Moviees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] Moviee moviee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moviee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moviee);
        }

        // GET: Moviees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moviee moviee = db.Movies.Find(id);
            if (moviee == null)
            {
                return HttpNotFound();
            }
            return View(moviee);
        }

        // POST: Moviees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moviee moviee = db.Movies.Find(id);
            db.Movies.Remove(moviee);
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
