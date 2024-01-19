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
    public class StatusController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();

        // GET: Status
        public ActionResult Index()
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);


            ViewBag.Status = (from s in db.Status_T
                              join st in db.StatusType_T on s.StatusTypeID equals st.StatusTypeID
                              where s.FleetCompanyID == fleetcompanyid
                              select new status { StatusID = s.StatusID, StatusTypeID = st.StatusTypeID, StatusType = st.StatusType, Status = s.Status }
                              ).ToList();

            ViewBag.StatusType = db.StatusType_T.ToList();

            
            return View();
        }

        
  
        [HttpPost]
        public ActionResult Create([Bind(Include = "StatusID,FleetCompanyID,StatusTypeID,Status")] Status_T status_T)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }

            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

            if (ModelState.IsValid)
            {
                status_T.FleetCompanyID = fleetcompanyid;
                db.Status_T.Add(status_T);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(status_T);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusID,FleetCompanyID,StatusTypeID,Status")] Status_T status_T)
        {
            if (ModelState.IsValid)
            {
                if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }

                int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
                status_T.FleetCompanyID = fleetcompanyid;
                db.Entry(status_T).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(status_T);
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
