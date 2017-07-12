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
    public class otherController : Controller
    {
        private SongskarContext db = new SongskarContext();

        // GET: /other/
        public ActionResult Index()
        {
            return View(db.others.ToList());
        }

        // GET: /other/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            other other = db.others.Find(id);
            if (other == null)
            {
                return HttpNotFound();
            }
            return View(other);
        }

        // GET: /other/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /other/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="OtherId,Title,Description,Image,PubDate")] other other)
        {
            if (ModelState.IsValid)
            {
                db.others.Add(other);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(other);
        }

        // GET: /other/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            other other = db.others.Find(id);
            if (other == null)
            {
                return HttpNotFound();
            }
            return View(other);
        }

        // POST: /other/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="OtherId,Title,Description,Image,PubDate")] other other)
        {
            if (ModelState.IsValid)
            {
                db.Entry(other).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(other);
        }

        // GET: /other/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            other other = db.others.Find(id);
            if (other == null)
            {
                return HttpNotFound();
            }
            return View(other);
        }

        // POST: /other/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            other other = db.others.Find(id);
            db.others.Remove(other);
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
