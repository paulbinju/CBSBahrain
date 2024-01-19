using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fleetmanager.Models;
using System.Data.SqlClient;

namespace Fleetmanager.Controllers
{
    public class VehicleController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();

        public void domainfinder()
        {
            string Domain = Request.Url.ToString();
            ViewBag.Domain = Domain;

            if (Domain.Contains("app.Fleetmanager.com"))
            {
                ViewBag.PageTitle = "Fleetmanager";
                ViewBag.Logo = "logo.png";
            }
            else if (Domain.Contains("fleetmanager.us"))
            {
                ViewBag.PageTitle = "Fleet Manager";
                ViewBag.Logo = "logo2.png";
            }
        }
        // GET: Vehicle
        public ActionResult Index(string which)
        {


            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            domainfinder();


            if (which == "All")
            {
             ViewBag.Vehicles = db.Database.SqlQuery<Vehicles>(@"select VehicleID,VehicleNoName,VehicleGroup,VehicleType,RegistrationNo,Make+' '+model+' '+convert(nvarchar(5),Year) as Brand from [dbo].[Vehicle_T] v 
             join  [dbo].[VehicleGroup_T] vg on v.VehicleGroupID=vg.VehicleGroupID
             join VehicleType_T vt on v.VehicleTypeID = vt.VehicleTypeID
             join AutoBrand_T ab on v.AutoBrandID=ab.AutoBrandID 
             where v.FleetCompanyid = " + fleetcompanyid + "  order by v.vehicleid desc");
            }
            else if (which == "Available")
            {
             ViewBag.Vehicles = db.Database.SqlQuery<Vehicles>(@"select VehicleID,VehicleNoName,VehicleGroup,VehicleType,RegistrationNo,Make+' '+model+' '+convert(nvarchar(5),Year) as Brand from [dbo].[Vehicle_T] v 
             join  [dbo].[VehicleGroup_T] vg on v.VehicleGroupID=vg.VehicleGroupID
             join VehicleType_T vt on v.VehicleTypeID = vt.VehicleTypeID
             join AutoBrand_T ab on v.AutoBrandID=ab.AutoBrandID 
             where v.FleetCompanyid = " + fleetcompanyid + " and VehicleID not in (select VehicleID from [dbo].[Vehicle-User_T] where EndDate is null)  order by v.vehicleid desc");
            }
            else if (which == "Allocated")
            {
             ViewBag.Vehicles = db.Database.SqlQuery<Vehicles>(@"select VehicleID,VehicleNoName,VehicleGroup,VehicleType,RegistrationNo,Make+' '+model+' '+convert(nvarchar(5),Year) as Brand from [dbo].[Vehicle_T] v 
             join  [dbo].[VehicleGroup_T] vg on v.VehicleGroupID=vg.VehicleGroupID
             join VehicleType_T vt on v.VehicleTypeID = vt.VehicleTypeID
             join AutoBrand_T ab on v.AutoBrandID=ab.AutoBrandID 
             where v.FleetCompanyid = " + fleetcompanyid + " and VehicleID in (select VehicleID from [dbo].[Vehicle-User_T] where EndDate is null) order by v.vehicleid desc");
            }

            ViewBag.Fuel = db.FuelType_T.Where(x => x.FleetCompanyID == fleetcompanyid).ToList();
            return View();
        }
        public ActionResult VehicleUserAllocation(int vehicleid, string message)
        {
            if (Session["selecteddriverid"] == null) { return RedirectToAction("Customer", "User"); }
            domainfinder();

            ViewBag.UserID = Convert.ToString(Session["selecteddriverid"]);
            ViewBag.VehicleID = Convert.ToString(vehicleid);
            if (message == "Allocated")
            {
                ViewBag.Allocated = "TRUE";
            }

            ViewBag.Vehicle = db.Database.SqlQuery<Vehicles>(@"select VehicleID,VehicleNoName,VehicleGroup,VehicleType,RegistrationNo,Make+' '+model+' '+convert(nvarchar(5),Year) as Brand,Note from [dbo].[Vehicle_T] v 
             join  [dbo].[VehicleGroup_T] vg on v.VehicleGroupID=vg.VehicleGroupID
             join VehicleType_T vt on v.VehicleTypeID = vt.VehicleTypeID
             join AutoBrand_T ab on v.AutoBrandID=ab.AutoBrandID 
            where  v.fleetcompanyid=" + Session["FleetCompanyID"] + " and vehicleid= " + vehicleid + " order by v.vehicleid desc");

            ViewBag.User = db.Database.SqlQuery<User_T>("select * from user_t where fleetcompanyid=" + Session["FleetCompanyID"] + " and userid=" + Convert.ToString(Session["selecteddriverid"]));

            return View();
        }

        [HttpPost]
        public ActionResult VehicleUserAllocation(FormCollection col)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }

            Vehicle_User_T vehicleuser = new Vehicle_User_T();
            vehicleuser.DOC = DateTime.Now;
            vehicleuser.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
            vehicleuser.StartDate = Convert.ToDateTime(col["startdate"]);
            //DateTime.ParseExact(col["startdate"], "MM/dd/yyyy", null).ToString("yyyy/MM/dd"));
            vehicleuser.UserID = Convert.ToInt32(col["userid"]);
            vehicleuser.VehicleID = Convert.ToInt32(col["vehicleid"]);
            vehicleuser.Note = Convert.ToString(col["notes"]);
            db.Vehicle_User_T.Add(vehicleuser);
            db.SaveChanges();

            return RedirectToAction("../VehicleUserAllocation/" + col["vehicleid"] + "/Allocated");
        }



         


        public ActionResult VehicleDetails(int vehicleid, string message)
        {
            domainfinder();
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }

            int FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);

            ViewBag.VehicleID = Convert.ToString(vehicleid);
            if (message == "Allocated")
            {
                ViewBag.Allocated = "TRUE";
            }
            ViewBag.Fuel = db.FuelType_T.Where(x => x.FleetCompanyID == FleetCompanyID).ToList();

            var Vehicle = db.Database.SqlQuery<Vehicles>(@"select v.*,VehicleGroup,VehicleType,v.AutoBrandID,Make+' '+model+' '+convert(nvarchar(5),Year) as Brand,Status,FuelType from [dbo].[Vehicle_T] v 
             join  [dbo].[VehicleGroup_T] vg on v.VehicleGroupID=vg.VehicleGroupID
             join VehicleType_T vt on v.VehicleTypeID = vt.VehicleTypeID
             join AutoBrand_T ab on v.AutoBrandID=ab.AutoBrandID 
			 join Status_T s on v.StatusID= s.StatusID
			 join FuelType_T f on v.FuelTypeID= f.FuelTypeID
            where  v.fleetcompanyid=" + Session["FleetCompanyID"] + " and vehicleid= " + vehicleid + " order by v.vehicleid desc").ToList();


            ViewBag.Vehicle = Vehicle;

            decimal purchaseamount = Convert.ToDecimal(Vehicle[0].PurchaseAmount);
            DateTime purchasedate = Convert.ToDateTime(Vehicle[0].PurchaseDate);
            int life = Convert.ToInt32(Vehicle[0].Life);
            decimal bookvalue = Math.Round((purchaseamount - ((purchaseamount / life) * (DateTime.Now.Subtract(purchasedate).Days / 30))), 3);


            if (bookvalue <= 0)
            {
                bookvalue = 0;
            }
            ViewBag.BookValue = bookvalue;




            ViewBag.InsuranceCompanies = (from i in db.Insurance_T
                                          where i.FleetCompanyID == FleetCompanyID
                                          orderby i.Insurance
                                          select i
                                         ).ToList();

            ViewBag.VehicleInsurance = (from vi in db.Vehicle_Insurance_T
                                        join i in db.Insurance_T on vi.InsuranceID equals i.InsuranceID
                                        where vi.FleetCompanyID == FleetCompanyID && vi.VehicleID == vehicleid
                                        orderby vi.VehicleInsuranceID descending
                                        select new VehicleInsurance { VehicleInsuranceID = vi.VehicleInsuranceID, VehicleID = vi.VehicleID, InsuranceID = vi.InsuranceID, StartDate = vi.StartDate, EndDate = vi.EndDate, Insurance = i.Insurance }
                                        ).ToList();


            ViewBag.VehicleAlerts = (from va in db.Alert_T
                                     where va.FleetCompanyID == FleetCompanyID && va.VehicleID == vehicleid
                                     orderby va.AlertID descending
                                     select va).ToList();


            ViewBag.VehicleRegistrations = (from vr in db.VehicleRegistration_T
                                            where vr.FleetCompanyID == FleetCompanyID && vr.VehicleID == vehicleid
                                            orderby vr.VehicleRegistrationID descending
                                            select vr).ToList();

            ViewBag.VehicleUsers = (from vu in db.Vehicle_User_T
                                    join u in db.User_T on vu.UserID equals u.UserID
                                    where vu.VehicleID == vehicleid && vu.FleetCompanyID == FleetCompanyID
                                    orderby vu.StartDate descending
                                    select new VehicleUser { EmailID = u.EmailID, MobileNo = u.MobileNo, NationalID = u.NationalID, StartDate = vu.StartDate, EndDate = vu.EndDate, UserType = u.UserType, VehicleUserID = vu.VehicleDriverID, Note = vu.Note, UserID = vu.UserID, Name = u.Name }
                                  ).ToList();


            ViewBag.TrafficContraventions = (from tc in db.TrafficContraventions_T
                                             join u in db.User_T on tc.UserID equals u.UserID
                                             where tc.VehicleID == vehicleid
                                             where tc.FleetCompanyID == FleetCompanyID && tc.VehicleID == vehicleid
                                             orderby tc.TrafficContraventionID descending
                                             select new VehicleTraffic {   Description = tc.Description, TrafficContraventionsDate = tc.TrafficContraventionDate }).ToList();
            ViewBag.Shop = (from sh in db.Shop_T
                            orderby sh.ShopName
                            select sh
                            ).ToList();

            ViewBag.VehicleBills = (from vb in db.Bill_T
                                    where vb.FleetCompanyID == FleetCompanyID && vb.VehicleID == vehicleid
                                    select vb).ToList();

            return View();
        }

        [HttpPost]
        public ActionResult VehicleRemoveAllocation(FormCollection col) {

            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            Vehicle_User_T vehicleuser = new Vehicle_User_T();
            vehicleuser.VehicleDriverID = Convert.ToInt32(col["VehicleUserID"]);
            vehicleuser.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
            vehicleuser.VehicleID = Convert.ToInt32(col["VehicleID"]);
            vehicleuser.UserID = Convert.ToInt32(col["UserID"]);
            vehicleuser.StartDate = Convert.ToDateTime(col["startdate"]);
            vehicleuser.EndDate = Convert.ToDateTime(col["enddate"]);

            vehicleuser.Note = Convert.ToString(col["note"]);

            db.Entry(vehicleuser).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("../VehicleDetails/" + Convert.ToInt32(col["VehicleID"]));


             
        }

        [HttpPost]
        public ActionResult VehicleBill(FormCollection col)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            Bill_T bill = new Bill_T();
            bill.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
            bill.VehicleID = Convert.ToInt32(col["VehicleID"]);
            bill.BillNo = Convert.ToString(col["BillNo"]);
            bill.BillDate = Convert.ToDateTime(col["BillDate"]);
            bill.ShopID = Convert.ToInt32(col["ShopID"]);
            
            bill.TotalAmount = Convert.ToInt32(col["TotalAmount"]);
            db.Bill_T.Add(bill);
            db.SaveChanges();
            return RedirectToAction("../VehicleDetail/" + Convert.ToInt32(col["VehicleID"]));



        }

        [HttpPost]
        public ActionResult VehicleTrafficContraventions(FormCollection col)
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

            return RedirectToAction("../VehicleDetails/" + Convert.ToInt32(col["VehicleID"]));
        }

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormCollection col)
        {

            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }

            //stored procedure
            string vehiclegroupnoname = db.Database.SqlQuery<string>("vehiclegroupname @FleetCompanyID, @VehicleGroupID", new SqlParameter("FleetCompanyID", Convert.ToInt32(Session["FleetCompanyID"])), new SqlParameter("@VehicleGroupID", Convert.ToInt32(col["VehicleGroupID"]))).Single();
            int vehiclegroupno = db.Database.SqlQuery<int>("select ISNULL(MAX(vehicleno),0)+1 as vehicleno from Vehicle_T where FleetCompanyID=" + Convert.ToInt32(Session["FleetCompanyID"]) + " and VehicleGroupID=" + Convert.ToInt32(col["VehicleGroupID"])).Single();

            Vehicle_T veh = new Vehicle_T();
            veh.VehicleNo = Convert.ToInt32(vehiclegroupno);
            veh.VehicleNoName = vehiclegroupnoname;
            veh.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
            veh.VehicleGroupID = Convert.ToInt32(col["VehicleGroupID"]);
            veh.VehicleTypeID = Convert.ToInt32(col["VehicleTypeID"]);
            veh.AutoBrandID = Convert.ToInt32(col["AutoBrandID"]);
            veh.GPSURL = Convert.ToString(col["GPSURL"]);
            veh.RegistrationNo = Convert.ToString(col["RegistrationNo"]);
            veh.PurchaseDate = Convert.ToDateTime(col["PurchaseDate"]);
            veh.PurchaseAmount = Convert.ToDecimal(col["PurchaseAmount"]);
            veh.Life = Convert.ToInt32(col["Life"]);
            veh.FuelTypeID = Convert.ToInt32(col["FuelTypeID"]);
            veh.Color= Convert.ToString(col["Color"]);
            veh.Note = Convert.ToString(col["Note"]);
            veh.ServiceFrequency= Convert.ToInt32(col["servicefrequency"]);
            veh.StatusID = 1;
            veh.DOC = Convert.ToDateTime(DateTime.Now);
            db.Vehicle_T.Add(veh);
            db.SaveChanges();

            return RedirectToAction("/");
        }

         

 
        [HttpPost]
        public ActionResult Edit(FormCollection col)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            string vehiclegroupnoname = Convert.ToString(col["VehicleNoName"]);
            int vehiclegroupno = Convert.ToInt32(col["VehicleNo"]);

            if (Convert.ToString(col["LastVehicleGroupID"])!= Convert.ToString(col["VehicleGroupID"]))
            {
                vehiclegroupnoname = db.Database.SqlQuery<string>("vehiclegroupname @FleetCompanyID, @VehicleGroupID", new SqlParameter("FleetCompanyID", Convert.ToInt32(Session["FleetCompanyID"])), new SqlParameter("@VehicleGroupID", Convert.ToInt32(col["VehicleGroupID"]))).Single();
                vehiclegroupno = db.Database.SqlQuery<int>("select ISNULL(MAX(vehicleno),0)+1 as vehicleno from Vehicle_T where FleetCompanyID=" + Convert.ToInt32(Session["FleetCompanyID"]) + " and VehicleGroupID=" + Convert.ToInt32(col["VehicleGroupID"])).Single();
            }
            Vehicle_T veh = new Vehicle_T();
            veh.VehicleID = Convert.ToInt32(col["VehicleID"]);
            veh.VehicleNo = Convert.ToInt32(vehiclegroupno);
            veh.VehicleNoName = vehiclegroupnoname;
            veh.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
            veh.VehicleGroupID = Convert.ToInt32(col["VehicleGroupID"]);
            veh.VehicleTypeID = Convert.ToInt32(col["VehicleTypeID"]);
            veh.AutoBrandID = Convert.ToInt32(col["AutoBrandID"]);
            veh.RegistrationNo = Convert.ToString(col["RegistrationNo"]);
            veh.PurchaseDate = Convert.ToDateTime(col["PurchaseDate"]);
            veh.PurchaseAmount = Convert.ToDecimal(col["PurchaseAmount"]);
            veh.Life = Convert.ToInt32(col["Life"]);
            veh.FuelTypeID = Convert.ToInt32(col["FuelTypeID"]);
            veh.Color = Convert.ToString(col["Color"]);
            veh.Note = Convert.ToString(col["Note"]);
            veh.ServiceFrequency = Convert.ToInt32(col["servicefrequency"]);
            veh.StatusID = Convert.ToInt32(col["StatusID"]);
            veh.DOC = DateTime.Now;
            db.Entry(veh).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("../VehicleDetails/" + veh.VehicleID);

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
