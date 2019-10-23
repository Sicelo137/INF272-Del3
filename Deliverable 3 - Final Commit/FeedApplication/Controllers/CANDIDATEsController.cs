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
    public class CANDIDATEsController : Controller
    {
        private FEEDAFRICAEntities db = new FEEDAFRICAEntities();

        // GET: CANDIDATEs
        public ActionResult Index()
        {
            return View(db.CANDIDATEs.ToList());
        }

        // GET: CANDIDATEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANDIDATE cANDIDATE = db.CANDIDATEs.Find(id);
            if (cANDIDATE == null)
            {
                return HttpNotFound();
            }
            return View(cANDIDATE);
        }

        // GET: CANDIDATEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CANDIDATEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CANDIDATE_ID,cANDIDATE_NAME,COUNRTY,REGISTARTIONNUMBER,CONTACTPERSON,CONTACTNUM")] CANDIDATE cANDIDATE)
        {
            if (ModelState.IsValid)
            {
                db.CANDIDATEs.Add(cANDIDATE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cANDIDATE);
        }

        // GET: CANDIDATEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANDIDATE cANDIDATE = db.CANDIDATEs.Find(id);
            if (cANDIDATE == null)
            {
                return HttpNotFound();
            }
            return View(cANDIDATE);
        }

        // POST: CANDIDATEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CANDIDATE_ID,cANDIDATE_NAME,COUNRTY,REGISTARTIONNUMBER,CONTACTPERSON,CONTACTNUM")] CANDIDATE cANDIDATE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cANDIDATE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cANDIDATE);
        }

        // GET: CANDIDATEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANDIDATE cANDIDATE = db.CANDIDATEs.Find(id);
            if (cANDIDATE == null)
            {
                return HttpNotFound();
            }
            return View(cANDIDATE);
        }

        // POST: CANDIDATEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CANDIDATE cANDIDATE = db.CANDIDATEs.Find(id);
            db.CANDIDATEs.Remove(cANDIDATE);
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
