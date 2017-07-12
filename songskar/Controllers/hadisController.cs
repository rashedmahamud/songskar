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
    public class hadisController : Controller
    {
        private SongskarContext db = new SongskarContext();

        // GET: /hadis/
        public ActionResult Index()
        {
            return View(db.hadises.ToList());
        }

        // GET: /hadis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hadis hadis = db.hadises.Find(id);
            if (hadis == null)
            {
                return HttpNotFound();
            }
            return View(hadis);
        }

        // GET: /hadis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /hadis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="HadisId,Title,Description,Image,PubDate")] hadis hadis)
        {
            if (ModelState.IsValid)
            {
                db.hadises.Add(hadis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hadis);
        }

        // GET: /hadis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hadis hadis = db.hadises.Find(id);
            if (hadis == null)
            {
                return HttpNotFound();
            }
            return View(hadis);
        }

        // POST: /hadis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="HadisId,Title,Description,Image,PubDate")] hadis hadis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hadis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hadis);
        }

        // GET: /hadis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hadis hadis = db.hadises.Find(id);
            if (hadis == null)
            {
                return HttpNotFound();
            }
            return View(hadis);
        }

        // POST: /hadis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hadis hadis = db.hadises.Find(id);
            db.hadises.Remove(hadis);
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
