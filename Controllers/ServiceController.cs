﻿using System;
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
    public class ServiceController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();

        // GET: Service
        public ActionResult Index()
        {

            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            domainfinder();
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            return View(db.Service_T.Where(x => x.FleetCompanyID == fleetcompanyid).OrderBy(x => x.ServiceName).ToList());
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceID,FleetCompanyID,ServiceName")] Service_T service_T)
        {
            if (ModelState.IsValid)
            {
                if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
                service_T.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
                db.Service_T.Add(service_T);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service_T);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceID,FleetCompanyID,ServiceName")] Service_T service_T)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }

            if (ModelState.IsValid)
            {
                service_T.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
                db.Entry(service_T).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service_T);
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