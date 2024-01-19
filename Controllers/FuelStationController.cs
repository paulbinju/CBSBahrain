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
    public class FuelStationController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();

        // GET: FuelStation
        public ActionResult Index()
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

            ViewBag.FuelConsumptiton = (from fc in db.FuelConsumption_T
                                        join v in db.Vehicle_T on fc.VehicleID equals v.VehicleID
                                        join ft in db.FuelType_T on fc.FuelTypeID equals ft.FuelTypeID
                                        join b in db.AutoBrand_T on v.AutoBrandID equals b.AutoBrandID
                                        where fc.FleetCompanyID == fleetcompanyid
                                        select new FuelConsumption { FuelConsumptionID = fc.FuelConsumptionID, VehicleNoName = v.VehicleNoName, Odometer = fc.Odometer, Quantity = fc.Quantity, Amount = fc.Amount, FuelType = ft.FuelType, FuelTypeID = ft.FuelTypeID, FillingDate = fc.FillingDate, Brand = b.Make + " " + b.Model + " " + b.Year }
                                        ).ToList();

            return View();
        }

        public ActionResult AddFuel()
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

            ViewBag.FuelType = (from f in db.FuelType_T
                                where f.FleetCompanyID == fleetcompanyid
                                select f
                               ).ToList();

            ViewBag.Vehicles = db.Database.SqlQuery<Vehicles>(@"select VehicleID,VehicleNoName,VehicleGroup,VehicleType,RegistrationNo,Make+' '+model+' '+convert(nvarchar(5),Year) as Brand from [dbo].[Vehicle_T] v 
             join  [dbo].[VehicleGroup_T] vg on v.VehicleGroupID=vg.VehicleGroupID
             join VehicleType_T vt on v.VehicleTypeID = vt.VehicleTypeID
             join AutoBrand_T ab on v.AutoBrandID=ab.AutoBrandID 
             where v.FleetCompanyid = " + fleetcompanyid + "  order by v.vehicleid desc");
            return View();
        }



        // GET: FuelStation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelConsumption_T fuelConsumption_T = db.FuelConsumption_T.Find(id);
            if (fuelConsumption_T == null)
            {
                return HttpNotFound();
            }
            return View(fuelConsumption_T);
        }

        
        [HttpPost]
        public ActionResult Create([Bind(Include = "FuelConsumptionID,FleetCompanyID,VehicleID,Odometer,FuelTypeID,Quantity,Amount,FillingDate")] FuelConsumption_T fuelConsumption_T)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            if (ModelState.IsValid)
            {
                fuelConsumption_T.FleetCompanyID = fleetcompanyid;
                db.FuelConsumption_T.Add(fuelConsumption_T);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fuelConsumption_T);
        }

        // GET: FuelStation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelConsumption_T fuelConsumption_T = db.FuelConsumption_T.Find(id);
            if (fuelConsumption_T == null)
            {
                return HttpNotFound();
            }
            return View(fuelConsumption_T);
        }

        // POST: FuelStation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FuelConsumptionID,FleetCompanyID,VehicleID,Odometer,FuelTypeID,Quantity,Amount,FillingDate")] FuelConsumption_T fuelConsumption_T)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fuelConsumption_T).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fuelConsumption_T);
        }

        // GET: FuelStation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelConsumption_T fuelConsumption_T = db.FuelConsumption_T.Find(id);
            if (fuelConsumption_T == null)
            {
                return HttpNotFound();
            }
            return View(fuelConsumption_T);
        }

        // POST: FuelStation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FuelConsumption_T fuelConsumption_T = db.FuelConsumption_T.Find(id);
            db.FuelConsumption_T.Remove(fuelConsumption_T);
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
