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
    public class SpareServiceDetailsController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();

        // GET: SpareServiceDetails
        public ActionResult Index(int invoiceid, int vehicleid)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }

            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            ViewBag.BillSummary = (from b in db.Bill_T
                                   where b.BillID == invoiceid && b.FleetCompanyID == fleetcompanyid
                                   select b).ToList();
            ViewBag.Vehicle = (from v in db.Vehicle_T
                               join b in db.AutoBrand_T on v.AutoBrandID equals b.AutoBrandID
                               where v.VehicleID == vehicleid && v.FleetCompanyID == fleetcompanyid
                               select new Vehicles { RegistrationNo = v.RegistrationNo, VehicleNoName = v.VehicleNoName, Brand = b.Make + " " + b.Model + " " + b.Year }
                               ).ToList();

            ViewBag.Service = (from s in db.Service_T
                               where s.FleetCompanyID == fleetcompanyid
                               select s
                               ).ToList();


            ViewBag.SparePart = (from s in db.SparePart_T
                                 where s.FleetCompanyID == fleetcompanyid
                                 select s
                             ).ToList();

            ViewBag.VehicleID = vehicleid;
            ViewBag.BillID = invoiceid;

            string invdetlistingqry = @"select * from(select SpareServiceDetailsID,sparepart,RTRIM(code)+' - '+CONVERT(nvarchar,Description) as Descri, Quantity,Amount from [SpareServiceDetails_T] ss join SparePart_T sp on ss.SparePartID = sp.SparePartID where ss.billid="+ invoiceid + " and ss.FleetCompanyID=" + fleetcompanyid + " and sp.FleetCompanyID=" + fleetcompanyid + " union select SpareServiceDetailsID,sparepart,ServiceName as Descri, Quantity,Amount from [SpareServiceDetails_T] ss join Service_T s on s.ServiceID = ss.ServiceID where ss.billid=" + invoiceid + " and ss.FleetCompanyID=" + fleetcompanyid + " and s.FleetCompanyID= " + fleetcompanyid + ") x";
            ViewBag.InvoiceDetails = db.Database.SqlQuery<BillDetailed>(invdetlistingqry).ToList();


            return View();
        }

        
        
        [HttpPost]
        public ActionResult Create([Bind(Include = "SpareServiceDetailsID,FleetCompanyID,VehicleID,BillID,JobCardID,SparePart,SparePartID,ServiceID,LabourHour,Quantity,Amount")] SpareServiceDetails_T spareServiceDetails_T, FormCollection col)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }

            if (ModelState.IsValid)
            {
                int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
                if(spareServiceDetails_T.SparePart == false)
                {
                    spareServiceDetails_T.SparePartID = null;
                    if (spareServiceDetails_T.BillID == -1) // coming from jobcard
                    {
                        spareServiceDetails_T.Quantity = Convert.ToString(col["Quantity2"]);
                    }
                }
                else
                {
                    spareServiceDetails_T.ServiceID = null;
                    if (spareServiceDetails_T.BillID == -1) // coming from jobcard  updating quantity
                    {
                        int qty = Convert.ToInt32(col["Quantity"]);
                        int sparepartid = Convert.ToInt32(col["SparePartID"]);
                        db.Database.ExecuteSqlCommand("update SparePart_T set AvailableQuantity= AvailableQuantity-" + qty + " where SparePartID=" + sparepartid + " and FleetCompanyID=" + fleetcompanyid);
                    }
                }
                spareServiceDetails_T.FleetCompanyID = fleetcompanyid;
                db.SpareServiceDetails_T.Add(spareServiceDetails_T);
                db.SaveChanges();
                if (spareServiceDetails_T.BillID == -1)
                {
                    return RedirectToAction("../JobCardDetails/" + spareServiceDetails_T.JobCardID);

                }
                else
                {
                    return RedirectToAction("../InvoiceDetail/" + spareServiceDetails_T.BillID + "/" + spareServiceDetails_T.VehicleID);
                }
            }

            return View(spareServiceDetails_T);
        }

        
        
        
        public ActionResult Deleteinvdetsxx(int id,string fromwhere)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            SpareServiceDetails_T spareServiceDetails_T = db.SpareServiceDetails_T.Where(x => x.SpareServiceDetailsID == id && x.FleetCompanyID == fleetcompanyid).SingleOrDefault();
            db.SpareServiceDetails_T.Remove(spareServiceDetails_T);
            db.SaveChanges();
            if (fromwhere == "jobcard")
            {
                return RedirectToAction("../JobCardDetails/" + spareServiceDetails_T.JobCardID);
            }
            else
            {
                return RedirectToAction("../InvoiceDetail/" + spareServiceDetails_T.BillID + "/" + spareServiceDetails_T.VehicleID);
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
