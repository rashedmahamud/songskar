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
    public class islamicworldController : Controller
    {
        private SongskarContext db = new SongskarContext();

        // GET: /islamicworld/
        public ActionResult Index()
        {
            return View(db.islamicworlds.ToList());
        }

        // GET: /islamicworld/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            islamicworld islamicworld = db.islamicworlds.Find(id);
            if (islamicworld == null)
            {
                return HttpNotFound();
            }
            return View(islamicworld);
        }

        // GET: /islamicworld/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /islamicworld/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IslamicWorldId,Title,Description,Image,PubDate")] islamicworld islamicworld)
        {
            if (ModelState.IsValid)
            {
                db.islamicworlds.Add(islamicworld);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(islamicworld);
        }

        // GET: /islamicworld/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            islamicworld islamicworld = db.islamicworlds.Find(id);
            if (islamicworld == null)
            {
                return HttpNotFound();
            }
            return View(islamicworld);
        }

        // POST: /islamicworld/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IslamicWorldId,Title,Description,Image,PubDate")] islamicworld islamicworld)
        {
            if (ModelState.IsValid)
            {
                db.Entry(islamicworld).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(islamicworld);
        }

        // GET: /islamicworld/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            islamicworld islamicworld = db.islamicworlds.Find(id);
            if (islamicworld == null)
            {
                return HttpNotFound();
            }
            return View(islamicworld);
        }

        // POST: /islamicworld/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            islamicworld islamicworld = db.islamicworlds.Find(id);
            db.islamicworlds.Remove(islamicworld);
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
