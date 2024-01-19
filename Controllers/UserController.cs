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
    public class UserController : Controller
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
            else if (Domain.Contains("www.fleetmanager.us"))
            {
                ViewBag.PageTitle = "Fleet Manager";
                ViewBag.Logo = "logo2.png";
            }
        }
        // GET: User
        public ActionResult Index(string user)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }

            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            ViewBag.Department = db.Department_T.Where(x => x.FleetCompanyID == fleetcompanyid).ToList();

            domainfinder();
            ViewBag.user = user;

            ViewBag.Users = (from u in db.User_T
                             join dp in db.Department_T on u.DepartmentID equals dp.DepartmentID
                             join di in db.Division_T on u.DivisionID equals di.DivisionID
                             where u.FleetCompanyID == fleetcompanyid && u.UserType == user
                             select new userdepartmentdivision { name = u.Name, emailid = u.EmailID, mobileno = u.MobileNo, designation = u.Designation, address = u.Address, nationalid = u.NationalID, department = dp.Department, departmentid = u.DepartmentID, divisionid = u.DivisionID, division = di.Division, userid = u.UserID, usertype = u.UserType }
                             ).ToList();


            return View(db.User_T.Where(x => x.FleetCompanyID == fleetcompanyid && x.UserType == user).OrderByDescending(x => x.UserID).ToList());
        }

        public ActionResult UserVehicleAsso1(int userid) {

            Session["selecteddriverid"] = userid;
            return RedirectToAction("Available", "Vehicle");
        }


 
        [HttpPost]
        public ActionResult Createx(FormCollection col)
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            User_T user_T = new User_T();
            user_T.FleetCompanyID = Convert.ToInt32(fleetcompanyid);
            user_T.UserType = Convert.ToString(col["UserType"]);
            user_T.Name = Convert.ToString(col["Name"]);
            user_T.Designation = Convert.ToString(col["Designation"]);
            user_T.DepartmentID = Convert.ToInt32(col["DepartmentID"]);
            user_T.DivisionID = Convert.ToInt32(col["DivisionID"]);
            user_T.EmailID = Convert.ToString(col["EmailID"]);
            user_T.MobileNo = Convert.ToString(col["MobileNo"]);
            user_T.NationalID = Convert.ToString(col["NationalID"]);
            user_T.Address = Convert.ToString(col["Address"]);
            user_T.DOC = Convert.ToDateTime(DateTime.Now);
            db.User_T.Add(user_T);
            db.SaveChanges();
            return RedirectToAction("../User/" + Convert.ToString(col["UserType"]));
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
