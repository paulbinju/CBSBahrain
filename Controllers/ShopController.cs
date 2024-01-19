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
    public class ShopController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();

        // GET: Shop
        public ActionResult Index()
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            domainfinder();
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            return View(db.Shop_T.Where(x => x.FleetCompanyID == fleetcompanyid).OrderBy(x => x.ShopName).ToList());
        }

       
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShopID,FleetCompanyID,ShopName")] Shop_T shop_T)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            if (ModelState.IsValid)
            {
                shop_T.FleetCompanyID= Convert.ToInt32(Session["FleetCompanyID"]);
                db.Shop_T.Add(shop_T);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shop_T);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShopID,FleetCompanyID,ShopName")] Shop_T shop_T)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            if (ModelState.IsValid)
            {
                shop_T.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
                db.Entry(shop_T).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shop_T);
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
