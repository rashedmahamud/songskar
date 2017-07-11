using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using songskar.Models;
using songskar.DAL;

namespace songskar.Controllers
{
    public class poemController : Controller
    {
        private SongskarContext db = new SongskarContext();

        // GET: /poem/
        public ActionResult Index()
        {
            return View(db.poems.ToList());
        }

        // GET: /poem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            poem poem = db.poems.Find(id);
            if (poem == null)
            {
                return HttpNotFound();
            }
            return View(poem);
        }

        // GET: /poem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /poem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="poemId,Title,Description,Image,PubDate")] poem poem)
        {
            if (ModelState.IsValid)
            {
                db.poems.Add(poem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(poem);
        }

        // GET: /poem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            poem poem = db.poems.Find(id);
            if (poem == null)
            {
                return HttpNotFound();
            }
            return View(poem);
        }

        // POST: /poem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="poemId,Title,Description,Image,PubDate")] poem poem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(poem);
        }

        // GET: /poem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            poem poem = db.poems.Find(id);
            if (poem == null)
            {
                return HttpNotFound();
            }
            return View(poem);
        }

        // POST: /poem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            poem poem = db.poems.Find(id);
            db.poems.Remove(poem);
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
