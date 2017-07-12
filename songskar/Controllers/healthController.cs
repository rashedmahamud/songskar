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
    public class healthController : Controller
    {
        private SongskarContext db = new SongskarContext();

        // GET: /health/
        public ActionResult Index()
        {
            return View(db.healths.ToList());
        }

        // GET: /health/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            health health = db.healths.Find(id);
            if (health == null)
            {
                return HttpNotFound();
            }
            return View(health);
        }

        // GET: /health/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /health/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="HealthId,Title,Description,Image,PubDate")] health health)
        {
            if (ModelState.IsValid)
            {
                db.healths.Add(health);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(health);
        }

        // GET: /health/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            health health = db.healths.Find(id);
            if (health == null)
            {
                return HttpNotFound();
            }
            return View(health);
        }

        // POST: /health/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="HealthId,Title,Description,Image,PubDate")] health health)
        {
            if (ModelState.IsValid)
            {
                db.Entry(health).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(health);
        }

        // GET: /health/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            health health = db.healths.Find(id);
            if (health == null)
            {
                return HttpNotFound();
            }
            return View(health);
        }

        // POST: /health/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            health health = db.healths.Find(id);
            db.healths.Remove(health);
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
