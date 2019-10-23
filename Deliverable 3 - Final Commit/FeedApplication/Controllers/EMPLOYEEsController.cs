using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using FeedApplication.Models;

namespace FeedApplication.Controllers
{
    public class EMPLOYEEsController : Controller
    {
        private FEEDAFRICAEntities db = new FEEDAFRICAEntities();

        // GET: EMPLOYEEs
        public ActionResult Index()
        {
            var eMPLOYEEs = db.EMPLOYEEs.Include(e => e.BRANCH).Include(e => e.EMPLOYEE_TYPE).Include(e => e.TITLE);
            return View(eMPLOYEEs.ToList());
        }

        // GET: EMPLOYEEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = db.EMPLOYEEs.Find(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.BRANCHes, "ID", "NAME");
            ViewBag.EMPLOYEE_TYPE_ID = new SelectList(db.EMPLOYEE_TYPE, "EMPLOYEE_TYPE_ID", "NAME");
            ViewBag.TITLE_ID = new SelectList(db.TITLEs, "TITLE_ID", "NAME");
            return View();
        }

        // POST: EMPLOYEEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EMPLOYEE1,PASSWORDS,EMPLOYEE_TYPE_ID,TITLE_ID,ID,NAMED,SURNAME,IDENTITY_NUMBER,EMAIL,PHONE")] EMPLOYEE eMPLOYEE)
        {
            Random random = new Random();
                   
            eMPLOYEE.PASSWORDS =random.Next(1000,2000).ToString();
            if (ModelState.IsValid)
            {
                try
                {

                    
                    using (var message = new MailMessage("feedafricainf272@gmail.com", eMPLOYEE.EMAIL))
                    {
                        message.Subject = " New Password";
                        message.Body = "Your new password is, " + eMPLOYEE.PASSWORDS + Environment.NewLine + "Do not share this password.";
                        using (SmtpClient client = new SmtpClient
                        {
                            EnableSsl = true,
                            Host = "smtp.gmail.com",
                            Port = 587,
                            Credentials = new NetworkCredential("feedafricainf272@gmail.com", "Wolverine1997")
                        })
                        {

                            try
                            {

                                client.Send(message);
                                db.EMPLOYEEs.Add(eMPLOYEE);
                                db.SaveChanges();
                            }
                            catch { }
                        }
                    }

                    return RedirectToAction("Index");
                }
                catch { }
            }

            ViewBag.ID = new SelectList(db.BRANCHes, "ID", "NAME", eMPLOYEE.ID);
            ViewBag.EMPLOYEE_TYPE_ID = new SelectList(db.EMPLOYEE_TYPE, "EMPLOYEE_TYPE_ID", "NAME", eMPLOYEE.EMPLOYEE_TYPE_ID);
            ViewBag.TITLE_ID = new SelectList(db.TITLEs, "TITLE_ID", "NAME", eMPLOYEE.TITLE_ID);
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = db.EMPLOYEEs.Find(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.BRANCHes, "ID", "NAME", eMPLOYEE.ID);
            ViewBag.EMPLOYEE_TYPE_ID = new SelectList(db.EMPLOYEE_TYPE, "EMPLOYEE_TYPE_ID", "NAME", eMPLOYEE.EMPLOYEE_TYPE_ID);
            ViewBag.TITLE_ID = new SelectList(db.TITLEs, "TITLE_ID", "NAME", eMPLOYEE.TITLE_ID);
            return View(eMPLOYEE);
        }

        // POST: EMPLOYEEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EMPLOYEE1,PASSWORDS,EMPLOYEE_TYPE_ID,TITLE_ID,ID,NAMED,SURNAME,IDENTITY_NUMBER,EMAIL,PHONE")] EMPLOYEE eMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(eMPLOYEE).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch { }
            }
            ViewBag.ID = new SelectList(db.BRANCHes, "ID", "NAME", eMPLOYEE.ID);
            ViewBag.EMPLOYEE_TYPE_ID = new SelectList(db.EMPLOYEE_TYPE, "EMPLOYEE_TYPE_ID", "NAME", eMPLOYEE.EMPLOYEE_TYPE_ID);
            ViewBag.TITLE_ID = new SelectList(db.TITLEs, "TITLE_ID", "NAME", eMPLOYEE.TITLE_ID);
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = db.EMPLOYEEs.Find(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEE);
        }

        // POST: EMPLOYEEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMPLOYEE eMPLOYEE = db.EMPLOYEEs.Find(id);
            db.EMPLOYEEs.Remove(eMPLOYEE);
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
