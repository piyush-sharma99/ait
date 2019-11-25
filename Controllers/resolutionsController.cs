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
    public class resolutionsController : Controller
    {
        private projectContext db = new projectContext();

        // GET: resolutions
        public ActionResult Index()
        {
            return View(db.resolutions.ToList());
        }

        // GET: resolutions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resolution resolution = db.resolutions.Find(id);
            if (resolution == null)
            {
                return HttpNotFound();
            }
            return View(resolution);
        }

        // GET: resolutions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: resolutions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "resID,Name,Date,Topic,Details")] resolution resolution)
        {
            if (ModelState.IsValid)
            {
                db.resolutions.Add(resolution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resolution);
        }

        // GET: resolutions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resolution resolution = db.resolutions.Find(id);
            if (resolution == null)
            {
                return HttpNotFound();
            }
            return View(resolution);
        }

        // POST: resolutions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "resID,Name,Date,Topic,Details")] resolution resolution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resolution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resolution);
        }

        // GET: resolutions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resolution resolution = db.resolutions.Find(id);
            if (resolution == null)
            {
                return HttpNotFound();
            }
            return View(resolution);
        }

        // POST: resolutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            resolution resolution = db.resolutions.Find(id);
            db.resolutions.Remove(resolution);
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
