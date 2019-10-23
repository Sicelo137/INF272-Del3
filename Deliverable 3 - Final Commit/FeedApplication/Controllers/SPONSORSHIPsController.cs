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
    public class SPONSORSHIPsController : Controller
    {
        private FEEDAFRICAEntities db = new FEEDAFRICAEntities();

        // GET: SPONSORSHIPs
        public ActionResult Index()
        {
            var sPONSORSHIPs = db.SPONSORSHIPs.Include(s => s.CANDIDATE).Include(s => s.DONATION_TYPE).Include(s => s.EVEN1);
            return View(sPONSORSHIPs.ToList());
        }

        // GET: SPONSORSHIPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPONSORSHIP sPONSORSHIP = db.SPONSORSHIPs.Find(id);
            if (sPONSORSHIP == null)
            {
                return HttpNotFound();
            }
            return View(sPONSORSHIP);
        }

        // GET: SPONSORSHIPs/Create
        public ActionResult Create()
        {
            ViewBag.CANDIDATE_ID = new SelectList(db.CANDIDATEs, "CANDIDATE_ID", "cANDIDATE_NAME");
            ViewBag.DONATION_TYPE_ID = new SelectList(db.DONATION_TYPE, "DONATION_TYPE_ID", "ITEM");
            ViewBag.EVEN = new SelectList(db.EVENs, "ID", "VIDEO");
            return View();
        }

        // POST: SPONSORSHIPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AMOUNT,EVEN,NAME,SPONSORSHIP_DATE,CANDIDATE_ID,DONATION_TYPE_ID")] SPONSORSHIP sPONSORSHIP)
        {
            if (ModelState.IsValid)
            {
                db.SPONSORSHIPs.Add(sPONSORSHIP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CANDIDATE_ID = new SelectList(db.CANDIDATEs, "CANDIDATE_ID", "cANDIDATE_NAME", sPONSORSHIP.CANDIDATE_ID);
            ViewBag.DONATION_TYPE_ID = new SelectList(db.DONATION_TYPE, "DONATION_TYPE_ID", "ITEM", sPONSORSHIP.DONATION_TYPE_ID);
            ViewBag.EVEN = new SelectList(db.EVENs, "ID", "VIDEO", sPONSORSHIP.EVEN);
            return View(sPONSORSHIP);
        }

        // GET: SPONSORSHIPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPONSORSHIP sPONSORSHIP = db.SPONSORSHIPs.Find(id);
            if (sPONSORSHIP == null)
            {
                return HttpNotFound();
            }
            ViewBag.CANDIDATE_ID = new SelectList(db.CANDIDATEs, "CANDIDATE_ID", "cANDIDATE_NAME", sPONSORSHIP.CANDIDATE_ID);
            ViewBag.DONATION_TYPE_ID = new SelectList(db.DONATION_TYPE, "DONATION_TYPE_ID", "ITEM", sPONSORSHIP.DONATION_TYPE_ID);
            ViewBag.EVEN = new SelectList(db.EVENs, "ID", "VIDEO", sPONSORSHIP.EVEN);
            return View(sPONSORSHIP);
        }

        // POST: SPONSORSHIPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AMOUNT,EVEN,NAME,SPONSORSHIP_DATE,CANDIDATE_ID,DONATION_TYPE_ID")] SPONSORSHIP sPONSORSHIP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPONSORSHIP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CANDIDATE_ID = new SelectList(db.CANDIDATEs, "CANDIDATE_ID", "cANDIDATE_NAME", sPONSORSHIP.CANDIDATE_ID);
            ViewBag.DONATION_TYPE_ID = new SelectList(db.DONATION_TYPE, "DONATION_TYPE_ID", "ITEM", sPONSORSHIP.DONATION_TYPE_ID);
            ViewBag.EVEN = new SelectList(db.EVENs, "ID", "VIDEO", sPONSORSHIP.EVEN);
            return View(sPONSORSHIP);
        }

        // GET: SPONSORSHIPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPONSORSHIP sPONSORSHIP = db.SPONSORSHIPs.Find(id);
            if (sPONSORSHIP == null)
            {
                return HttpNotFound();
            }
            return View(sPONSORSHIP);
        }

        // POST: SPONSORSHIPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SPONSORSHIP sPONSORSHIP = db.SPONSORSHIPs.Find(id);
            db.SPONSORSHIPs.Remove(sPONSORSHIP);
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
