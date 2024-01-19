using Fleetmanager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fleetmanager.Controllers
{
    public class HomeController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();

        public ActionResult Index()
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

            domainfinder();

            // last one year
            try { 

            ViewBag.TotalBill = db.Database.SqlQuery<decimal>("select  sum(Amount) as amount from  [dbo].[SpareServiceDetails_T] spd join Bill_T b on spd.BillID= b.BillID where spd.FleetCompanyID=" + fleetcompanyid + "   and spd.BillID is not null and b.BillDate>=DATEADD(year,-1,GETDATE())").ToList().SingleOrDefault();
            ViewBag.TotalService = db.Database.SqlQuery<decimal>("select  sum(Amount) as amount from  [dbo].[SpareServiceDetails_T] spd join Bill_T b on spd.BillID= b.BillID where spd.FleetCompanyID=" + fleetcompanyid + "  and spd.BillID is not null and spd.SparePart=0  and b.BillDate>=DATEADD(year,-1,GETDATE())").ToList().SingleOrDefault();
            ViewBag.TotalSpareParts = db.Database.SqlQuery<decimal>("select  sum(Amount) as amount from  [dbo].[SpareServiceDetails_T] spd join Bill_T b on spd.BillID= b.BillID where spd.FleetCompanyID=" + fleetcompanyid + "  and spd.BillID is not null and spd.SparePart=1  and b.BillDate>=DATEADD(year,-1,GETDATE())").ToList().SingleOrDefault();

            ViewBag.TotalGarageLabourHours = db.Database.SqlQuery<int>("select sum(LabourHours) as LabourHours from  [dbo].[JobCard_T] where JobEnded>=DATEADD(year,-1,GETDATE()) and FleetCompanyID=" + fleetcompanyid + " ").ToList().SingleOrDefault();
            ViewBag.TotalGarageSpareParts = db.Database.SqlQuery<decimal>("select sum(TotalCost) as TotalCost from  [dbo].[JobCard_T] where JobEnded>=DATEADD(year,-1,GETDATE()) and FleetCompanyID=" + fleetcompanyid + " ").ToList().SingleOrDefault();

            ViewBag.Petrol = db.Database.SqlQuery<decimal>("select sum(Amount) as amount from  [dbo].[FuelConsumption_T] where FleetCompanyID=" + fleetcompanyid + "  and fueltypeid=1 and FillingDate>=DATEADD(year,-1,GETDATE())").ToList().SingleOrDefault();
            ViewBag.Diesel = db.Database.SqlQuery<decimal>("select sum(Amount) as amount from  [dbo].[FuelConsumption_T] where FleetCompanyID=" + fleetcompanyid + "  and fueltypeid=2 and FillingDate>=DATEADD(year,-1,GETDATE())").ToList().SingleOrDefault();

            ViewBag.TotalFuel = db.Database.SqlQuery<decimal>("select sum(Amount) as amount from  [dbo].[FuelConsumption_T] where FleetCompanyID=" + fleetcompanyid + "  and FillingDate>=DATEADD(year,-1,GETDATE())").ToList().SingleOrDefault();
            }
            catch
            {

            }


            return View();
        }

        public ActionResult Login()
        {
            domainfinder();
            return View();
        }

        

        public ActionResult Help()
        {
            return View();
        }

        public ActionResult MyAccount()
        {
            if (Session["FleetCompanyID"] == null) { return RedirectToAction("Login", "Home"); }
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            ViewBag.fleetcompany = (from u in db.FleetCompany_T
                                where u.FleetCompanyID == fleetcompanyid
                                select u).ToList();


            ViewBag.Subscriptions = (from s in db.Subscription_T
                                     where s.FleetCompanyID == fleetcompanyid
                                     orderby s.SubscriptionID descending
                                     select s
                                   ).ToList();
            return View();
        }
        public ActionResult Logout()
        {
            Session["FleetCompanyID"] = null;
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(FormCollection col)
        {
            string userid = Convert.ToString(col["email"]);
            string pass = Convert.ToString(col["password"]);


            var fleetcompany = (from u in db.FMUser_T
                                where u.Email == userid && u.FMPassword == pass
                                select u).ToList();

            if (fleetcompany.Count > 0)// valid user
            {

                //check subscription
                int fleetcompanyid = Convert.ToInt32(fleetcompany[0].FleetCompanyID);
                DateTime today = DateTime.Now;

                var subscription = (from s in db.Subscription_T
                                    where s.FleetCompanyID == fleetcompanyid && s.StartDate <= today && s.EndDate >= today
                                    select s
                                    ).ToList();

                if (subscription.Count > 0) // valid subscription
                {
                     
                    Session["FleetCompanyID"] = fleetcompanyid;
                    Session["ContactPerson"] = Convert.ToString(fleetcompany[0].Name);
                    Session["Role"] = Convert.ToString(fleetcompany[0].RoleID);
                    Session["FMUserID"] = Convert.ToString(fleetcompany[0].FMUserID);


                    // get company currency
                    FleetCompany_T currency = db.FleetCompany_T.Where(x => x.FleetCompanyID == fleetcompanyid).SingleOrDefault();
                    Session["Currency"] = Convert.ToString(currency.Currency);
                    return RedirectToAction("../");
                }
                else // subscription expired
                {
                    ViewBag.Results = "Oh! sorry, your subscription has expired, please renew today";

                }


                
            }
            else
            {
                ViewBag.Results = "Invalid User ID / Password";
            }

            return View();
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
    }
}