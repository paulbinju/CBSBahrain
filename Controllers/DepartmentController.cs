using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fleetmanager.Models;

namespace Fleetmanager.Controllers
{
    public class DepartmentController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();

        // GET: Department
        public ActionResult Index()
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            return View(db.Department_T.Where(x => x.FleetCompanyID == fleetcompanyid).ToList());
        }

       

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentID,FleetCompanyID,Department")] Department_T department_T)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            if (ModelState.IsValid)
            {
                int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
                department_T.FleetCompanyID = fleetcompanyid;
                db.Department_T.Add(department_T);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department_T);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentID,FleetCompanyID,Department")] Department_T department_T)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            if (ModelState.IsValid)
            {
                department_T.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
                db.Entry(department_T).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department_T);
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
