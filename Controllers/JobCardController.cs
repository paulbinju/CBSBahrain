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
    public class JobCardController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();

        // GET: JobCard
        public ActionResult Index()
        {

            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

            ViewBag.Calls = (from j in db.JobCard_T
                             join c in db.Call_T on j.CallID equals c.CallID
                             join u in db.FMUser_T on c.FMUserID equals u.FMUserID
                             join v in db.Vehicle_T on c.VehicleID equals v.VehicleID
                             join s in db.Status_T on c.StatusID equals s.StatusID
                             where c.FleetCompanyID == fleetcompanyid
                             orderby c.CallID descending
                             select new callcentre { VehicleNoName = v.VehicleNoName, RegistrationNo = v.RegistrationNo, Status = s.Status, Name = u.Name, StartedOn = c.StartedOn, ReportedOn = c.ReportedOn, CompletedOn = c.CompletedOn, Note = c.Note, External = c.ExternalGarage, JobCardGenerated = c.JobCardGenerated, CallID = c.CallID, StatusID = c.StatusID, VehicleID = c.VehicleID, FMUserID = c.FMUserID, JobCardID = j.JobCardID, JobStarted = j.JobStarted, JobEnded = j.JobEnded, LabourHours = j.LabourHours, TotalCost = j.TotalCost }).ToList();
            ViewBag.StatusID = (from s in db.Status_T
                                where s.FleetCompanyID == fleetcompanyid
                                select s
                                ).ToList();
            return View();
        }

      
        public ActionResult AddJobCard(int? id)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

            ViewBag.Calls = (from c in db.Call_T
                             join u in db.FMUser_T on c.FMUserID equals u.FMUserID
                             join v in db.Vehicle_T on c.VehicleID equals v.VehicleID
                             join s in db.Status_T on c.StatusID equals s.StatusID
                             where c.FleetCompanyID == fleetcompanyid && c.ExternalGarage == false
                             orderby c.CallID descending
                             select new callcentre { VehicleNoName = v.VehicleNoName, RegistrationNo = v.RegistrationNo, Status = s.Status, Name = u.Name, StartedOn = c.StartedOn, ReportedOn = c.ReportedOn, CompletedOn = c.CompletedOn, Note = c.Note, External = c.ExternalGarage, JobCardGenerated = c.JobCardGenerated, CallID = c.CallID, StatusID = c.StatusID, VehicleID = c.VehicleID, FMUserID = c.FMUserID }).ToList();


            return View();
        }

        
   
        [HttpPost]
        public ActionResult Create([Bind(Include = "JobCardID,FleetCompanyID,VehicleID,CallID,JobStarted,JobEnded,LabourHours,TotalCost")] JobCard_T jobCard_T)
        {
            if (ModelState.IsValid)
            {
                if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
                int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
                jobCard_T.FleetCompanyID = fleetcompanyid;
                db.JobCard_T.Add(jobCard_T);
                db.SaveChanges();

                //jobcard generated for the call

                db.Database.ExecuteSqlCommand("update [Call_T] set jobcardgenerated=1 where callid=" + jobCard_T.CallID);

                return RedirectToAction("Index");
            }

            return View(jobCard_T);
        }


         
        [HttpPost]
        public ActionResult Edit([Bind(Include = "JobCardID,FleetCompanyID,VehicleID,CallID,JobStarted,JobEnded,LabourHours,TotalCost")] JobCard_T jobCard_T)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            if (ModelState.IsValid)
            {
                jobCard_T.FleetCompanyID = fleetcompanyid;
                db.Entry(jobCard_T).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobCard_T);
        }

        public ActionResult JobCardDetails(int jobcardid)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);


            var Vehicle = (from v in db.Vehicle_T
                           join j in db.JobCard_T on v.VehicleID equals j.VehicleID
                           where j.FleetCompanyID == fleetcompanyid && j.JobCardID == jobcardid
                           select new callcentre { VehicleID = v.VehicleID, VehicleNoName = v.VehicleNoName, RegistrationNo = v.RegistrationNo, JobStarted = j.JobStarted, JobEnded = j.JobEnded, JobCardID = j.JobCardID, LabourHours = j.LabourHours, TotalCost = j.TotalCost, AutoBrandID = v.AutoBrandID }
                              ).ToList();
            ViewBag.Vehicle = Vehicle;

           
            ViewBag.Service = (from s in db.Service_T
                               where s.FleetCompanyID == fleetcompanyid
                               select s
                              ).ToList();

            int autobrandid = Convert.ToInt32(Vehicle[0].AutoBrandID);
            ViewBag.SparePart = (from s in db.SparePart_T
                                 join sab in db.SparePartAutoBrand_T on s.SparePartID equals sab.SparePartID
                                 where s.FleetCompanyID == fleetcompanyid && sab.AutoBrandID == autobrandid && s.AvailableQuantity > 0
                                 select s
                             ).ToList();
            string invdetlistingqry = @"select * from(select SpareServiceDetailsID,sparepart,RTRIM(code)+' - '+CONVERT(nvarchar,Description) as Descri, Quantity,Amount from [SpareServiceDetails_T] ss join SparePart_T sp on ss.SparePartID = sp.SparePartID where ss.JobCardID=" + jobcardid + " and ss.FleetCompanyID=" + fleetcompanyid + " and sp.FleetCompanyID=" + fleetcompanyid + " union select SpareServiceDetailsID,sparepart,ServiceName as Descri, Quantity,Amount from [SpareServiceDetails_T] ss join Service_T s on s.ServiceID = ss.ServiceID where ss.jobcardid=" + jobcardid + " and ss.FleetCompanyID=" + fleetcompanyid + " and s.FleetCompanyID= " + fleetcompanyid + ") x";
            ViewBag.JobCardDetails = db.Database.SqlQuery<BillDetailed>(invdetlistingqry).ToList();
            ViewBag.JobCardID = jobcardid;

            return View();
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
