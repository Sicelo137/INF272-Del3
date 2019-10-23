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
    public class DONATIONsController : Controller
    {
        private FEEDAFRICAEntities db = new FEEDAFRICAEntities();

        // GET: DONATIONs
        public ActionResult Index()
        {
            var dONATIONs = db.DONATIONs.Include(d => d.DONATION_TYPE).Include(d => d.DONOR).Include(d => d.EVEN1);
            return View(dONATIONs.ToList());
        }

        // GET: DONATIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONATION dONATION = db.DONATIONs.Find(id);
            if (dONATION == null)
            {
                return HttpNotFound();
            }
            return View(dONATION);
        }

        // GET: DONATIONs/Create
        public ActionResult Create()
        {
            ViewBag.DONATION_TYPE_ID = new SelectList(db.DONATION_TYPE, "DONATION_TYPE_ID", "ITEM");
            ViewBag.DONOR_ID = new SelectList(db.DONORs, "DONOR_ID", "COMPANY");
            ViewBag.EVEN = new SelectList(db.EVENs, "ID", "VIDEO");
            return View();
        }

        // POST: DONATIONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DATES,DONOR_ID,EVEN,DONATION_TYPE_ID,AMOUNT")] DONATION dONATION)
        {
            if (ModelState.IsValid)
            {
                db.DONATIONs.Add(dONATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DONATION_TYPE_ID = new SelectList(db.DONATION_TYPE, "DONATION_TYPE_ID", "ITEM", dONATION.DONATION_TYPE_ID);
            ViewBag.DONOR_ID = new SelectList(db.DONORs, "DONOR_ID", "COMPANY", dONATION.DONOR_ID);
            ViewBag.EVEN = new SelectList(db.EVENs, "ID", "VIDEO", dONATION.EVEN);
            return View(dONATION);
        }

        // GET: DONATIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONATION dONATION = db.DONATIONs.Find(id);
            if (dONATION == null)
            {
                return HttpNotFound();
            }
            ViewBag.DONATION_TYPE_ID = new SelectList(db.DONATION_TYPE, "DONATION_TYPE_ID", "ITEM", dONATION.DONATION_TYPE_ID);
            ViewBag.DONOR_ID = new SelectList(db.DONORs, "DONOR_ID", "COMPANY", dONATION.DONOR_ID);
            ViewBag.EVEN = new SelectList(db.EVENs, "ID", "VIDEO", dONATION.EVEN);
            return View(dONATION);
        }

        // POST: DONATIONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DATES,DONOR_ID,EVEN,DONATION_TYPE_ID,AMOUNT")] DONATION dONATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dONATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DONATION_TYPE_ID = new SelectList(db.DONATION_TYPE, "DONATION_TYPE_ID", "ITEM", dONATION.DONATION_TYPE_ID);
            ViewBag.DONOR_ID = new SelectList(db.DONORs, "DONOR_ID", "COMPANY", dONATION.DONOR_ID);
            ViewBag.EVEN = new SelectList(db.EVENs, "ID", "VIDEO", dONATION.EVEN);
            return View(dONATION);
        }

        // GET: DONATIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONATION dONATION = db.DONATIONs.Find(id);
            if (dONATION == null)
            {
                return HttpNotFound();
            }
            return View(dONATION);
        }

        // POST: DONATIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DONATION dONATION = db.DONATIONs.Find(id);
            db.DONATIONs.Remove(dONATION);
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
        public ActionResult DonationReport()
        {
            var dONATIONs = db.DONATIONs.Include(d => d.DONATION_TYPE).Include(d => d.DONOR).Include(d => d.EVEN1);
            return View(dONATIONs.ToList());
        }
        public ActionResult Dona()
        {
            return new Rotativa.ActionAsPdf("DonationReport");
        }
    }
}
