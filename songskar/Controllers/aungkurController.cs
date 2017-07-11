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
    public class aungkurController : Controller
    {
        private SongskarContext db = new SongskarContext();

        // GET: /aungkur/
        public ActionResult Index()
        {
            return View(db.aungkur.ToList());
        }

        // GET: /aungkur/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aungkur aungkur = db.aungkur.Find(id);
            if (aungkur == null)
            {
                return HttpNotFound();
            }
            return View(aungkur);
        }

        // GET: /aungkur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /aungkur/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AungkurId,Title,Description,Image,PubDate")] aungkur aungkur)
        {
            if (ModelState.IsValid)
            {
                db.aungkur.Add(aungkur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aungkur);
        }

        // GET: /aungkur/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aungkur aungkur = db.aungkur.Find(id);
            if (aungkur == null)
            {
                return HttpNotFound();
            }
            return View(aungkur);
        }

        // POST: /aungkur/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AungkurId,Title,Description,Image,PubDate")] aungkur aungkur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aungkur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aungkur);
        }

        // GET: /aungkur/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aungkur aungkur = db.aungkur.Find(id);
            if (aungkur == null)
            {
                return HttpNotFound();
            }
            return View(aungkur);
        }

        // POST: /aungkur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            aungkur aungkur = db.aungkur.Find(id);
            db.aungkur.Remove(aungkur);
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
