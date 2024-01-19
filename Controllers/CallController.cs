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
    public class CallController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();

        // GET: Call
        public ActionResult Index()
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

            ViewBag.Calls = (from c in db.Call_T
                             join u in db.FMUser_T on c.FMUserID equals u.FMUserID
                             join v in db.Vehicle_T on c.VehicleID equals v.VehicleID
                             join s in db.Status_T on c.StatusID equals s.StatusID
                             where c.FleetCompanyID == fleetcompanyid
                             orderby c.CallID descending
                             select new callcentre { VehicleNoName = v.VehicleNoName, RegistrationNo = v.RegistrationNo, Status = s.Status, Name = u.Name, StartedOn = c.StartedOn, ReportedOn = c.ReportedOn, CompletedOn = c.CompletedOn, Note = c.Note, External = c.ExternalGarage, JobCardGenerated = c.JobCardGenerated, CallID = c.CallID, StatusID = c.StatusID, VehicleID = c.VehicleID, FMUserID = c.FMUserID }).ToList();
            ViewBag.StatusID = (from s in db.Status_T
                                where s.FleetCompanyID == fleetcompanyid && s.StatusTypeID == 2
                                select s
                                ).ToList();
            return View();
        }

        // GET: Call/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Call_T call_T = db.Call_T.Find(id);
            if (call_T == null)
            {
                return HttpNotFound();
            }
            return View(call_T);
        }

        // GET: Call/Create
        public ActionResult AddCall()
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

            ViewBag.StatusID = (from s in db.Status_T
                                where s.FleetCompanyID == fleetcompanyid && s.StatusTypeID == 2
                                select s
                               ).ToList();

            ViewBag.Vehicles = db.Database.SqlQuery<Vehicles>(@"select VehicleID,VehicleNoName,VehicleGroup,VehicleType,RegistrationNo,Make+' '+model+' '+convert(nvarchar(5),Year) as Brand from [dbo].[Vehicle_T] v 
             join  [dbo].[VehicleGroup_T] vg on v.VehicleGroupID=vg.VehicleGroupID
             join VehicleType_T vt on v.VehicleTypeID = vt.VehicleTypeID
             join AutoBrand_T ab on v.AutoBrandID=ab.AutoBrandID 
             where v.FleetCompanyid = " + fleetcompanyid + "  order by v.vehicleid desc");
            return View();
        }

 
        [HttpPost]
        public ActionResult Create([Bind(Include = "CallID,FleetCompanyID,VehicleID,FMUserID,JobCardGenerated,ReportedOn,StartedOn,CompletedOn,ExternalGarage,StatusID,Note")] Call_T call_T)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

            if (ModelState.IsValid)
            {
                call_T.FMUserID= Convert.ToInt32(Session["FMUserID"]);
                call_T.FleetCompanyID = fleetcompanyid;
                db.Call_T.Add(call_T);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(call_T);
        }


        [HttpPost]
        public ActionResult Edit([Bind(Include = "CallID,FleetCompanyID,VehicleID,FMUserID,JobCardGenerated,ReportedOn,StartedOn,CompletedOn,ExternalGarage,StatusID,Note")] Call_T call_T)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            call_T.FleetCompanyID = fleetcompanyid;
            db.Entry(call_T).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Call/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Call_T call_T = db.Call_T.Find(id);
            if (call_T == null)
            {
                return HttpNotFound();
            }
            return View(call_T);
        }

        // POST: Call/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Call_T call_T = db.Call_T.Find(id);
            db.Call_T.Remove(call_T);
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
