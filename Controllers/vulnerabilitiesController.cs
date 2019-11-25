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
    public class vulnerabilitiesController : Controller
    {
        private projectContext db = new projectContext();

        // GET: vulnerabilities
        public ActionResult Index()
        {
            return View(db.vulnerabilities.ToList());
        }

        // GET: vulnerabilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vulnerability vulnerability = db.vulnerabilities.Find(id);
            if (vulnerability == null)
            {
                return HttpNotFound();
            }
            return View(vulnerability);
        }

        // GET: vulnerabilities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vulnerabilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vulID,Name,Date,Topic,Details")] vulnerability vulnerability)
        {
            if (ModelState.IsValid)
            {
                db.vulnerabilities.Add(vulnerability);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vulnerability);
        }

        // GET: vulnerabilities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vulnerability vulnerability = db.vulnerabilities.Find(id);
            if (vulnerability == null)
            {
                return HttpNotFound();
            }
            return View(vulnerability);
        }

        // POST: vulnerabilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vulID,Name,Date,Topic,Details")] vulnerability vulnerability)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vulnerability).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vulnerability);
        }

        // GET: vulnerabilities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vulnerability vulnerability = db.vulnerabilities.Find(id);
            if (vulnerability == null)
            {
                return HttpNotFound();
            }
            return View(vulnerability);
        }

        //Get: vulnerabilities/Search
        public ActionResult Search()
        {
            return View();
        }

        // POST: vulnerabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vulnerability vulnerability = db.vulnerabilities.Find(id);
            db.vulnerabilities.Remove(vulnerability);
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
