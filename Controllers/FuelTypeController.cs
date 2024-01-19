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
    public class FuelTypeController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();

        // GET: FuelType
        public ActionResult Index()
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            domainfinder();
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            return View(db.FuelType_T.Where(x => x.FleetCompanyID == fleetcompanyid).OrderBy(x => x.FuelType).ToList());
        }

       
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FuelTypeID,FuelType")] FuelType_T fuelType_T)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            if (ModelState.IsValid)
            {
                fuelType_T.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
                db.FuelType_T.Add(fuelType_T);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fuelType_T);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FuelTypeID,FuelType")] FuelType_T fuelType_T)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            if (ModelState.IsValid)
            {
                fuelType_T.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
                db.Entry(fuelType_T).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fuelType_T);
        }
 
        public void domainfinder()
        {
            string Domain = Request.Url.ToString();
            ViewBag.Domain = Domain;

            if (Domain.Contains("app.Fleetmanager.com"))
            {
                ViewBag.PageTitle = "Fleetmanager";
                ViewBag.Logo = "logo.png";
            }
            else if (Domain.Contains("www.fleetmanager.us"))
            {
                ViewBag.PageTitle = "Fleet Manager";
                ViewBag.Logo = "logo2.png";
            }
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
