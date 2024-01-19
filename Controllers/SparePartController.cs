using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fleetmanager.Models;
using System.Text;

namespace Fleetmanager.Controllers
{
    public class SparePartController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();

        // GET: SparePart
        public ActionResult Index()
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            domainfinder();
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

            ViewBag.AutoBrand = (from ab in db.AutoBrand_T
                                 where ab.FleetCompanyID == fleetcompanyid
                                 select new autobrand { AutoBrandID = ab.AutoBrandID, AutoBrand = ab.Make + " " + ab.Model + " " + ab.Year }
                                 ).ToList();

            var SpareParts = (from sp in db.SparePart_T
                              join spau in db.SparePartAutoBrand_T on sp.SparePartID equals spau.SparePartID
                              join ab in db.AutoBrand_T on spau.AutoBrandID equals ab.AutoBrandID
                              where sp.FleetCompanyID == fleetcompanyid
                              orderby sp.Code
                              select new sparepart { Code = sp.Code, Description = sp.Description, Price = sp.Price, AvailableQuantity = sp.AvailableQuantity, SparePartID = sp.SparePartID, AutoBrand = ab.Make + " " + ab.Model + " " + ab.Year }
                               ).ToList();

            List<sparepart> sprt = new List<sparepart>();
            sparepart eachsprt;
            string autobrandx = "";// autobrdids = "";
            int sparepartid = 0;

            foreach (var sp in SpareParts)
            {
                eachsprt = new sparepart();
               
                if (sparepartid != sp.SparePartID)
                {
                    autobrandx = "";
                    //autobrdids = "";
                    foreach (var spx in SpareParts)
                    {
                        if (spx.SparePartID == sp.SparePartID)
                        {
                            autobrandx += ", " + spx.AutoBrand;
                        //    autobrdids += "," + spx.AutoBrandID;
                        }
                    }
                    eachsprt.SparePartID = sp.SparePartID;
                    eachsprt.AutoBrand = autobrandx.TrimStart(',');
                    //eachsprt.AutoBrandIDs = autobrdids.TrimStart(',');
                    eachsprt.Code = sp.Code;
                    eachsprt.Description = sp.Description;
                    eachsprt.AvailableQuantity = sp.AvailableQuantity;
                    eachsprt.Price = sp.Price;
                    sprt.Add(eachsprt);
                }
               

              
         

                sparepartid = sp.SparePartID;
            }

            ViewBag.SparePart = sprt.ToList();
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SparePartID,FleetCompanyID,AutoBrandID,Code,Description,AvailableQuantity,Price")] SparePart_T sparePart_T,FormCollection col)
        {
            if (ModelState.IsValid)
            {
                if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
                int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

                sparePart_T.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
                db.SparePart_T.Add(sparePart_T);

                db.SaveChanges();

                string[] vehicleids = Convert.ToString(col["AutoBrandID"]).Split(',');

                StringBuilder sb;




                foreach (var vid in vehicleids)
                {
                    sb = new StringBuilder();
                    sb.AppendFormat("Insert into [SparePartAutoBrand_T] (fleetcompanyid,sparepartid,autobrandid) values({0},{1},{2})", fleetcompanyid, sparePart_T.SparePartID, vid);
                    db.Database.ExecuteSqlCommand(sb.ToString());
                }


                return RedirectToAction("Index");
            }

            return View(sparePart_T);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "SparePartID,FleetCompanyID,AutoBrandID,Code,Description,AvailableQuantity,Price")] SparePart_T sparePart_T, FormCollection col)
        {

            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

            sparePart_T.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
            db.Entry(sparePart_T).State = EntityState.Modified;
            db.SaveChanges();

            //clean all existing
            db.Database.ExecuteSqlCommand("Delete from [SparePartAutoBrand_T] where fleetcompanyid=" + fleetcompanyid + " and SparePartID=" + sparePart_T.SparePartID);
            //recreated all new
            string[] vehicleids = Convert.ToString(col["AutoBrandID"]).Split(',');
            StringBuilder sb;
            foreach (var vid in vehicleids)
            {
                sb = new StringBuilder();
                sb.AppendFormat("Insert into [SparePartAutoBrand_T] (fleetcompanyid,sparepartid,autobrandid) values({0},{1},{2})", fleetcompanyid, sparePart_T.SparePartID, vid);

                db.Database.ExecuteSqlCommand(sb.ToString());
            }


            return RedirectToAction("Index");

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
