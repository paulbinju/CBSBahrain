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
    public class TrafficContraventionsController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();


        public ActionResult Vehicles()
        {

            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);


            ViewBag.Vehicles = db.Database.SqlQuery<Vehicles>(@"select VehicleID,VehicleNoName,VehicleGroup,VehicleType,RegistrationNo,Make+' '+model+' '+convert(nvarchar(5),Year) as Brand from [dbo].[Vehicle_T] v 
             join  [dbo].[VehicleGroup_T] vg on v.VehicleGroupID=vg.VehicleGroupID
             join VehicleType_T vt on v.VehicleTypeID = vt.VehicleTypeID
             join AutoBrand_T ab on v.AutoBrandID=ab.AutoBrandID 
             where v.FleetCompanyid = " + fleetcompanyid + "  order by v.vehicleid desc");

          

            return View();
        }

        public ActionResult Add(int vehicleid)
        {

            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

            var Vehicle = db.Database.SqlQuery<Vehicles>(@"select v.*,VehicleGroup,VehicleType,v.AutoBrandID,Make+' '+model+' '+convert(nvarchar(5),Year) as Brand,Status,FuelType from [dbo].[Vehicle_T] v 
             join  [dbo].[VehicleGroup_T] vg on v.VehicleGroupID=vg.VehicleGroupID
             join VehicleType_T vt on v.VehicleTypeID = vt.VehicleTypeID
             join AutoBrand_T ab on v.AutoBrandID=ab.AutoBrandID 
			 join Status_T s on v.StatusID= s.StatusID
			 join FuelType_T f on v.FuelTypeID= f.FuelTypeID
            where  v.fleetcompanyid=" + fleetcompanyid + " and vehicleid= " + vehicleid + " order by v.vehicleid desc").ToList();


            ViewBag.Vehicle = Vehicle;

            ViewBag.VehicleID = Convert.ToString(vehicleid);

            ViewBag.VehicleUsers = (from vu in db.Vehicle_User_T
                                    join u in db.User_T on vu.UserID equals u.UserID
                                    where vu.VehicleID == vehicleid && vu.FleetCompanyID == fleetcompanyid
                                    orderby vu.StartDate descending
                                    select new VehicleUser { EmailID = u.EmailID, MobileNo = u.MobileNo, NationalID = u.NationalID, StartDate = vu.StartDate, EndDate = vu.EndDate, UserType = u.UserType, VehicleUserID = vu.VehicleDriverID, Note = vu.Note, UserID = vu.UserID, Name = u.Name }
                             ).ToList();

            ViewBag.TrafficContraventions = (from tc in db.TrafficContraventions_T
                                             join u in db.User_T on tc.UserID equals u.UserID
                                             where tc.VehicleID == vehicleid
                                             where tc.FleetCompanyID == fleetcompanyid && tc.VehicleID == vehicleid
                                             orderby tc.TrafficContraventionID descending
                                             select new VehicleTraffic { Description = tc.Description, TrafficContraventionsDate = tc.TrafficContraventionDate }).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult SaveContraventions(FormCollection col)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            TrafficContraventions_T trafficCon = new TrafficContraventions_T();

            trafficCon.UserID = Convert.ToInt32(col["userid"]);
            trafficCon.VehicleID = Convert.ToInt32(col["vehicleid"]);
            trafficCon.Description = Convert.ToString(col["Description"]);
            trafficCon.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
            trafficCon.TrafficContraventionDate = Convert.ToDateTime(col["TrafficContraventionDate"]);
            db.TrafficContraventions_T.Add(trafficCon);
            db.SaveChanges();

            return RedirectToAction("TrafficContraventions/Add/" + Convert.ToInt32(col["vehicleid"]));
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
