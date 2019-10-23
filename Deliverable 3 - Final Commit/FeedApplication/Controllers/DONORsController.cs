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
    public class DONORsController : Controller
    {
        private FEEDAFRICAEntities db = new FEEDAFRICAEntities();

        // GET: DONORs
        public ActionResult Index()
        {
            var dONORs = db.DONORs.Include(d => d.TITLE);
            return View(dONORs.ToList());
        }

        // GET: DONORs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONOR dONOR = db.DONORs.Find(id);
            if (dONOR == null)
            {
                return HttpNotFound();
            }
            return View(dONOR);
        }

        // GET: DONORs/Create
        public ActionResult Create()
        {
            ViewBag.TITLE_ID = new SelectList(db.TITLEs, "TITLE_ID", "NAME");
            return View();
        }

        // POST: DONORs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DONOR_ID,COMPANY,COUNTRY,EMPLOYEE_TYPE_ID,TITLE_ID,NAMED,SURNAME,IDENTITY_NUMBER,EMAIL,PHONE")] DONOR dONOR)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.DONORs.Add(dONOR);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch { }
            }

            ViewBag.TITLE_ID = new SelectList(db.TITLEs, "TITLE_ID", "NAME", dONOR.TITLE_ID);
            return View(dONOR);
        }

        // GET: DONORs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONOR dONOR = db.DONORs.Find(id);
            if (dONOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.TITLE_ID = new SelectList(db.TITLEs, "TITLE_ID", "NAME", dONOR.TITLE_ID);
            return View(dONOR);
        }

        // POST: DONORs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DONOR_ID,COMPANY,COUNTRY,EMPLOYEE_TYPE_ID,TITLE_ID,NAMED,SURNAME,IDENTITY_NUMBER,EMAIL,PHONE")] DONOR dONOR)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(dONOR).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch { }
            }
            ViewBag.TITLE_ID = new SelectList(db.TITLEs, "TITLE_ID", "NAME", dONOR.TITLE_ID);
            return View(dONOR);
        }

        // GET: DONORs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DONOR dONOR = db.DONORs.Find(id);
            if (dONOR == null)
            {
                return HttpNotFound();
            }
            return View(dONOR);
        }

        // POST: DONORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DONOR dONOR = db.DONORs.Find(id);
            db.DONORs.Remove(dONOR);
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
