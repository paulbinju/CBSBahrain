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
    public class FMUserController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();

        // GET: FMUser
        public ActionResult Index(string message)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }

            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            ViewBag.Department = db.Department_T.Where(x => x.FleetCompanyID == fleetcompanyid).ToList();
            ViewBag.Role = db.Role_T.OrderBy(x => x.Role).ToList();
            ViewBag.Message = message;


            ViewBag.FMusers = (
                from fmu in db.FMUser_T
                join r in db.Role_T on fmu.RoleID equals r.RoleID
                join dp in db.Department_T on fmu.DepartmentID equals dp.DepartmentID
                join di in db.Division_T on fmu.DivisionID equals di.DivisionID
                where fmu.FleetCompanyID == fleetcompanyid && dp.FleetCompanyID == fleetcompanyid && di.FleetCompanyID == fleetcompanyid
                select new fmuser { FMUserID = fmu.FMUserID, RoleID = r.RoleID, Role = r.Role, DepartmentID = dp.DepartmentID, Department = dp.Department, DivisionID = di.DivisionID, Division = di.Division, Email = fmu.Email, FMPassword = fmu.FMPassword, Name = fmu.Name, Mobile = fmu.Mobile }
                ).ToList();


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FMUserID,FleetCompanyID,RoleID,FMUser,FMPassword,Name,Email,Mobile,DepartmentID,DivisionID")] FMUser_T fMUser_T)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            try
            {
                fMUser_T.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
                db.FMUser_T.Add(fMUser_T);
                db.SaveChanges();
                return RedirectToAction("Index/"+ "User added successfully");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index/"+ "Email ID (userid) already exists");
            }


        }
 

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FMUserID,FleetCompanyID,RoleID,FMUser,FMPassword,Name,Email,Mobile,DepartmentID,DivisionID")] FMUser_T fMUser_T)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            if (ModelState.IsValid)
            {
                try
                {
                    fMUser_T.FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
                    db.Entry(fMUser_T).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index/" + "User added successfully");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index/" + "Email ID (userid) already exists");
                }
            }
            return View(fMUser_T);
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
