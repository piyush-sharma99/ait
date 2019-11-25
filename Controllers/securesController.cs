using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class securesController : Controller
    {
        private projectContext db = new projectContext();

        // GET: secures
        public ActionResult Index()
        {
            return View(db.secures.ToList());
        }

        // GET: secures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            secure secure = db.secures.Find(id);
            if (secure == null)
            {
                return HttpNotFound();
            }
            return View(secure);
        }

        // GET: secures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: secures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "secID,Name,Date,Topic,Details")] secure secure)
        {
            if (ModelState.IsValid)
            {
                db.secures.Add(secure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(secure);
        }

        // GET: secures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            secure secure = db.secures.Find(id);
            if (secure == null)
            {
                return HttpNotFound();
            }
            return View(secure);
        }

        // POST: secures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "secID,Name,Date,Topic,Details")] secure secure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(secure);
        }

        // GET: secures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            secure secure = db.secures.Find(id);
            if (secure == null)
            {
                return HttpNotFound();
            }
            return View(secure);
        }

        // POST: secures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            secure secure = db.secures.Find(id);
            db.secures.Remove(secure);
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
