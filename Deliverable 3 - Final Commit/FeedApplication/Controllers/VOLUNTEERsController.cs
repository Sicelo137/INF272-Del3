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
    public class VOLUNTEERsController : Controller
    {
        private FEEDAFRICAEntities db = new FEEDAFRICAEntities();

        // GET: VOLUNTEERs
        public ActionResult Index()
        {
            var vOLUNTEERs = db.VOLUNTEERs.Include(v => v.TITLE);
            return View(vOLUNTEERs.ToList());
        }

        // GET: VOLUNTEERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VOLUNTEER vOLUNTEER = db.VOLUNTEERs.Find(id);
            if (vOLUNTEER == null)
            {
                return HttpNotFound();
            }
            return View(vOLUNTEER);
        }

        // GET: VOLUNTEERs/Create
        public ActionResult Create()
        {
            ViewBag.TITLE_ID = new SelectList(db.TITLEs, "TITLE_ID", "NAME");
            return View();
        }

        // POST: VOLUNTEERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EMPLOYEE,EMPLOYEE_TYPE_ID,TITLE_ID,NAMED,SURNAME,IDENTITY_NUMBER,EMAIL,PHONE,STARTING,ENDING")] VOLUNTEER vOLUNTEER)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.VOLUNTEERs.Add(vOLUNTEER);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch{ }
            }

            ViewBag.TITLE_ID = new SelectList(db.TITLEs, "TITLE_ID", "NAME", vOLUNTEER.TITLE_ID);
            return View(vOLUNTEER);
        }

        // GET: VOLUNTEERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VOLUNTEER vOLUNTEER = db.VOLUNTEERs.Find(id);
            if (vOLUNTEER == null)
            {
                return HttpNotFound();
            }
            ViewBag.TITLE_ID = new SelectList(db.TITLEs, "TITLE_ID", "NAME", vOLUNTEER.TITLE_ID);
            return View(vOLUNTEER);
        }

        // POST: VOLUNTEERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EMPLOYEE,EMPLOYEE_TYPE_ID,TITLE_ID,NAMED,SURNAME,IDENTITY_NUMBER,EMAIL,PHONE,STARTING,ENDING")] VOLUNTEER vOLUNTEER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vOLUNTEER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TITLE_ID = new SelectList(db.TITLEs, "TITLE_ID", "NAME", vOLUNTEER.TITLE_ID);
            return View(vOLUNTEER);
        }

        // GET: VOLUNTEERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VOLUNTEER vOLUNTEER = db.VOLUNTEERs.Find(id);
            if (vOLUNTEER == null)
            {
                return HttpNotFound();
            }
            return View(vOLUNTEER);
        }

        // POST: VOLUNTEERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VOLUNTEER vOLUNTEER = db.VOLUNTEERs.Find(id);
            db.VOLUNTEERs.Remove(vOLUNTEER);
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
