using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Fleetmanager.Models;
using System;

namespace Fleetmanager.Controllers
{
    public class VehicleTypeController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();

        // GET: VehicleType
        public ActionResult Index()
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            domainfinder();
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            return View(db.VehicleType_T.Where(x => x.FleetCompanyID == fleetcompanyid).OrderBy(x => x.VehicleType).ToList());
        }

        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleTypeID,FleetCompanyID,VehicleType")] VehicleType_T vehicleType_T)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }

            if (ModelState.IsValid)
            {
                vehicleType_T.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
                db.VehicleType_T.Add(vehicleType_T);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleType_T);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleTypeID,FleetCompanyID,VehicleType")] VehicleType_T vehicleType_T)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            if (ModelState.IsValid)
            {
                vehicleType_T.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
                db.Entry(vehicleType_T).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleType_T);
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
