using Fleetmanager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fleetmanager.Controllers
{
    public class ReportsController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();
        // GET: Reports
        public ActionResult InvoiceCompanywise(DateTime startdate, DateTime enddate)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

            ViewBag.Startdate = startdate;
            ViewBag.Enddate = enddate;

            ViewBag.Report = (from b in db.Bill_T
                              join s in db.Shop_T on b.ShopID equals s.ShopID
                              join v in db.Vehicle_T on b.VehicleID equals v.VehicleID
                              join ab in db.AutoBrand_T on v.AutoBrandID equals ab.AutoBrandID
                              where b.FleetCompanyID == fleetcompanyid && b.BillDate >= startdate && b.BillDate <= enddate
                              select new ReportInvoice { BillNo = b.BillNo, BillDate = b.BillDate, AutoBrand = ab.Make + " " + ab.Model + " " + ab.Year, VehicleNoName = v.VehicleNoName, ShopName = s.ShopName, RegistrationNo = v.RegistrationNo, TotalAmount = b.TotalAmount }
                ).ToList();

            return View();
        }

        public ActionResult InvoiceCompanyGen(FormCollection col)
        {
              return RedirectToAction("InvoiceCompanywise/" + col["startdate"] + "/" + col["enddate"]);
            
        }


        public ActionResult InvoiceService(DateTime startdate, DateTime enddate)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

            ViewBag.Startdate = startdate;
            ViewBag.Enddate = enddate;

            ViewBag.Report = (from ssd in db.SpareServiceDetails_T
                              join ser in db.Service_T on ssd.ServiceID equals ser.ServiceID
                              join b in db.Bill_T on ssd.BillID equals b.BillID
                              join s in db.Shop_T on b.ShopID equals s.ShopID
                              join v in db.Vehicle_T on b.VehicleID equals v.VehicleID
                              join ab in db.AutoBrand_T on v.AutoBrandID equals ab.AutoBrandID
                              where ssd.FleetCompanyID == fleetcompanyid && ssd.SparePart == false && ssd.BillID > 0 && b.BillDate >= startdate && b.BillDate <= enddate
                              select new ReportInvoice { BillNo = b.BillNo, BillDate = b.BillDate, AutoBrand = ab.Make + " " + ab.Model + " " + ab.Year, ShopName = s.ShopName, RegistrationNo = v.RegistrationNo, TotalAmount = ssd.Amount, ServiceName = ser.ServiceName, Quantity= ssd.Quantity }
                              ).ToList();
                
                
            return View();
        }

        public ActionResult InvoiceServiceGen(FormCollection col)
        {
            return RedirectToAction("InvoiceService/" + col["startdate"] + "/" + col["enddate"]);

        }
        public ActionResult InvoiceSparepart(DateTime startdate, DateTime enddate)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

            ViewBag.Startdate = startdate;
            ViewBag.Enddate = enddate;

            ViewBag.Report = (from ssd in db.SpareServiceDetails_T
                              join sp in db.SparePart_T on ssd.SparePartID equals sp.SparePartID
                              join b in db.Bill_T on ssd.BillID equals b.BillID
                              join s in db.Shop_T on b.ShopID equals s.ShopID
                              join v in db.Vehicle_T on b.VehicleID equals v.VehicleID
                              join ab in db.AutoBrand_T on v.AutoBrandID equals ab.AutoBrandID
                              where ssd.FleetCompanyID == fleetcompanyid && ssd.SparePart == true && ssd.BillID > 0 && b.BillDate >= startdate && b.BillDate <= enddate
                              select new ReportInvoice { BillNo = b.BillNo, BillDate = b.BillDate, AutoBrand = ab.Make + " " + ab.Model + " " + ab.Year, ShopName = s.ShopName, RegistrationNo = v.RegistrationNo, TotalAmount = ssd.Amount, SparepartName = sp.Description, Quantity = ssd.Quantity }
                              ).ToList();


            return View();
        }

        public ActionResult InvoiceSparepartGen(FormCollection col)
        {
            return RedirectToAction("InvoiceSparepart/" + col["startdate"] + "/" + col["enddate"]);

        }


        public ActionResult GarageSparePart(DateTime startdate, DateTime enddate)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

            ViewBag.Startdate = startdate;
            ViewBag.Enddate = enddate;
            // ended jobcards will be considered
            ViewBag.Report = (from ssd in db.SpareServiceDetails_T
                              join sp in db.SparePart_T on ssd.SparePartID equals sp.SparePartID
                              join j in db.JobCard_T on ssd.JobCardID equals j.JobCardID
                              join v in db.Vehicle_T on j.VehicleID equals v.VehicleID
                              join ab in db.AutoBrand_T on v.AutoBrandID equals ab.AutoBrandID
                              where ssd.FleetCompanyID == fleetcompanyid && ssd.SparePart == true && ssd.BillID ==-1 && j.JobEnded>= startdate && j.JobEnded <= enddate
                              select new ReportJobCard { JobCardNo= j.JobCardID, JobCardDate = j.JobEnded, AutoBrand = ab.Make + " " + ab.Model + " " + ab.Year, RegistrationNo = v.RegistrationNo, TotalAmount = ssd.Amount, SparepartName = sp.Description, Quantity = ssd.Quantity }
                              ).ToList();


            return View();
        }

        public ActionResult GarageSparePartGen(FormCollection col)
        {
            return RedirectToAction("GarageSparePart/" + col["startdate"] + "/" + col["enddate"]);

        }



        public ActionResult GarageService(DateTime startdate, DateTime enddate)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

            ViewBag.Startdate = startdate;
            ViewBag.Enddate = enddate;
            // ended jobcards will be considered
            ViewBag.Report = (from ssd in db.SpareServiceDetails_T
                              join ser in db.Service_T on ssd.ServiceID equals ser.ServiceID
                              join j in db.JobCard_T on ssd.JobCardID equals j.JobCardID
                              join v in db.Vehicle_T on j.VehicleID equals v.VehicleID
                              join ab in db.AutoBrand_T on v.AutoBrandID equals ab.AutoBrandID
                              where ssd.FleetCompanyID == fleetcompanyid && ssd.SparePart == false && ssd.BillID == -1 && j.JobEnded >= startdate && j.JobEnded <= enddate
                              select new ReportJobCard { JobCardNo = j.JobCardID, JobCardDate = j.JobEnded, AutoBrand = ab.Make + " " + ab.Model + " " + ab.Year, RegistrationNo = v.RegistrationNo, LabourHour = ssd.LabourHour, ServiceName = ser.ServiceName, Quantity = ssd.Quantity }
                              ).ToList();


            return View();
        }

        public ActionResult GarageServiceGen(FormCollection col)
        {
            return RedirectToAction("GarageService/" + col["startdate"] + "/" + col["enddate"]);

        }





        public ActionResult Fuel(DateTime startdate, DateTime enddate)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            ViewBag.Startdate = startdate;
            ViewBag.Enddate = enddate;

            ViewBag.Report = (from fc in db.FuelConsumption_T
                              join f in db.FuelType_T on fc.FuelTypeID equals f.FuelTypeID
                              join v in db.Vehicle_T on fc.VehicleID equals v.VehicleID
                              join ab in db.AutoBrand_T on v.AutoBrandID equals ab.AutoBrandID
                              where fc.FleetCompanyID == fleetcompanyid && fc.FillingDate >= startdate && fc.FillingDate <= enddate
                              select new ReportFuel { AutoBrand = ab.Make + " " + ab.Model + " " + ab.Year, RegistrationNo = v.RegistrationNo, Quantity = fc.Quantity, Amount = fc.Amount, FillingDate = fc.FillingDate, Fuel = f.FuelType }
                              ).ToList();
            return View();
        }

        public ActionResult FuelGen(FormCollection col)
        {
            return RedirectToAction("Fuel/" + col["startdate"] + "/" + col["enddate"]);
        }


        public ActionResult FuelPetrol(DateTime startdate, DateTime enddate)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            ViewBag.Startdate = startdate;
            ViewBag.Enddate = enddate;

            ViewBag.Report = (from fc in db.FuelConsumption_T
                              join v in db.Vehicle_T on fc.VehicleID equals v.VehicleID
                              join ab in db.AutoBrand_T on v.AutoBrandID equals ab.AutoBrandID
                              where fc.FleetCompanyID == fleetcompanyid && fc.FillingDate >= startdate && fc.FillingDate <= enddate && fc.FuelTypeID == 1
                              select new ReportFuel { AutoBrand = ab.Make + " " + ab.Model + " " + ab.Year, RegistrationNo = v.RegistrationNo, Quantity = fc.Quantity, Amount = fc.Amount, FillingDate = fc.FillingDate }
                              ).ToList();
            return View();
        }

        public ActionResult FuelPetrolGen(FormCollection col)
        {
            return RedirectToAction("FuelPetrol/" + col["startdate"] + "/" + col["enddate"]);
        }


        public ActionResult FuelDiesel(DateTime startdate, DateTime enddate)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            ViewBag.Startdate = startdate;
            ViewBag.Enddate = enddate;

            ViewBag.Report = (from fc in db.FuelConsumption_T
                              join v in db.Vehicle_T on fc.VehicleID equals v.VehicleID
                              join ab in db.AutoBrand_T on v.AutoBrandID equals ab.AutoBrandID
                              where fc.FleetCompanyID == fleetcompanyid && fc.FillingDate >= startdate && fc.FillingDate <= enddate && fc.FuelTypeID == 2
                              select new ReportFuel { AutoBrand = ab.Make + " " + ab.Model + " " + ab.Year, RegistrationNo = v.RegistrationNo, Quantity = fc.Quantity, Amount = fc.Amount, FillingDate = fc.FillingDate }
                              ).ToList();
            return View();
        }

        public ActionResult FuelDieselGen(FormCollection col)
        {
            return RedirectToAction("FuelDiesel/" + col["startdate"] + "/" + col["enddate"]);
        }
    }
}