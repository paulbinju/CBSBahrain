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
    public class DivisionController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();

        // GET: Division
        public ActionResult Index()
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            ViewBag.Division = (from di in db.Division_T
                                join dp in db.Department_T on di.DepartmentID equals dp.DepartmentID
                                where di.FleetCompanyID == fleetcompanyid
                                orderby dp.Department
                                select new division { DivisionID = di.DivisionID, DepartmentID = dp.DepartmentID, Division = di.Division, Department = dp.Department }
                               ).ToList();
            ViewBag.Department = db.Department_T.Where(x => x.FleetCompanyID == fleetcompanyid).OrderBy(x => x.Department).ToList();
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DivisionID,FleetCompanyID,DepartmentID,Division")] Division_T division_T)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }

            if (ModelState.IsValid)
            {
                division_T.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
                db.Division_T.Add(division_T);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(division_T);
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DivisionID,FleetCompanyID,DepartmentID,Division")] Division_T division_T)
        {
            if (ModelState.IsValid)
            {
                division_T.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
                db.Entry(division_T).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(division_T);
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
