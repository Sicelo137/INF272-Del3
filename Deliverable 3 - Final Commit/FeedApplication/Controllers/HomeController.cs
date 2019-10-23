using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FeedApplication.Models;

namespace FeedApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                string k = TempData["f"].ToString();
                ViewBag.error = "Invalid Log in details";
            }
            catch { }
            return View();
        }
        public ActionResult LogIn(string defaultFormpass,string defaultFormemail)
        {
            FEEDAFRICAEntities Fa = new FEEDAFRICAEntities();
            List<EMPLOYEE> employee = Fa.EMPLOYEEs.Where(e=>e.EMAIL==defaultFormemail && e.PASSWORDS==defaultFormpass).ToList();
            if (employee.Count>0)
            {
                return RedirectToAction("index", "employees");
            }
            TempData["f"] = "faile";
            return RedirectToAction("Index", "Home");
        }
    }
}