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
    public class quranController : Controller
    {
        private SongskarContext db = new SongskarContext();

        // GET: /quran/
        public ActionResult Index()
        {
            return View(db.qurans.ToList());
        }

        // GET: /quran/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quran quran = db.qurans.Find(id);
            if (quran == null)
            {
                return HttpNotFound();
            }
            return View(quran);
        }

        // GET: /quran/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /quran/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="QuranId,Title,Description,Image,PubDate")] quran quran)
        {
            if (ModelState.IsValid)
            {
                db.qurans.Add(quran);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quran);
        }

        // GET: /quran/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quran quran = db.qurans.Find(id);
            if (quran == null)
            {
                return HttpNotFound();
            }
            return View(quran);
        }

        // POST: /quran/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="QuranId,Title,Description,Image,PubDate")] quran quran)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quran).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quran);
        }

        // GET: /quran/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quran quran = db.qurans.Find(id);
            if (quran == null)
            {
                return HttpNotFound();
            }
            return View(quran);
        }

        // POST: /quran/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            quran quran = db.qurans.Find(id);
            db.qurans.Remove(quran);
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
