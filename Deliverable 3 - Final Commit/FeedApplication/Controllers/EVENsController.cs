using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FeedApplication.Models;

namespace FeedApplication.Controllers
{
    public class EVENsController : Controller
    {
        private FEEDAFRICAEntities db = new FEEDAFRICAEntities();

        // GET: EVENs
        public ActionResult Index()
        {
            var eVENs = db.EVENs.Include(e => e.TEVEN);
            return View(eVENs.ToList());
        }

        // GET: EVENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVEN eVEN = db.EVENs.Find(id);
            if (eVEN == null)
            {
                return HttpNotFound();
            }
            return View(eVEN);
        }

        // GET: EVENs/Create
        public ActionResult Create()
        {
            ViewBag.TEVENS = new SelectList(db.TEVENS, "ID", "NAME");
            return View();
        }

        // POST: EVENs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DATES,AMOUNTRAISED,TEVENS,VIDEO")] EVEN eVEN)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.EVENs.Add(eVEN);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch { }
            }

            ViewBag.TEVENS = new SelectList(db.TEVENS, "ID", "NAME", eVEN.TEVENS);
            return View(eVEN);
        }

        // GET: EVENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVEN eVEN = db.EVENs.Find(id);
            if (eVEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.TEVENS = new SelectList(db.TEVENS, "ID", "NAME", eVEN.TEVENS);
            return View(eVEN);
        }

        // POST: EVENs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DATES,AMOUNTRAISED,TEVENS,VIDEO")] EVEN eVEN)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(eVEN).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch { }
            }
            ViewBag.TEVENS = new SelectList(db.TEVENS, "ID", "NAME", eVEN.TEVENS);
            return View(eVEN);
        }

        // GET: EVENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EVEN eVEN = db.EVENs.Find(id);
            if (eVEN == null)
            {
                return HttpNotFound();
            }
            return View(eVEN);
        }

        // POST: EVENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EVEN eVEN = db.EVENs.Find(id);
            db.EVENs.Remove(eVEN);
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
