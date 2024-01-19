using Fleetmanager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fleetmanager.Controllers
{
    public class AppController : Controller
    {
        private FleetManagerV2Entities db = new FleetManagerV2Entities();


        public ActionResult getservicepart()
        {
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            return new JsonpResult
            {
                Data = (db.SparePart_T.Where(x => x.FleetCompanyID == fleetcompanyid).OrderBy(x => x.Description).ToList()).ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        public ActionResult getdivision(int departmentid)
        {
            int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);
            return new JsonpResult
            {
                Data = (db.Division_T.Where(x => x.FleetCompanyID == fleetcompanyid && x.DepartmentID == departmentid).OrderBy(x => x.Division).ToList()).ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        //public ActionResult Addservicepart(string ServicePartName)
        //{
        //    int fleetcompanyid = Convert.ToInt32(Session["FleetCompanyID"]);

        //    ServiceParts_T servicepart = new ServiceParts_T();
        //    servicepart.ServicePartName = ServicePartName;
        //    servicepart.FleetCompanyID = fleetcompanyid;
        //    db.ServiceParts_T.Add(servicepart);
        //    db.SaveChanges();

        //    return new JsonpResult
        //    {
        //        Data = (db.ServiceParts_T.Where(x => x.FleetCompanyID == fleetcompanyid).OrderBy(x => x.ServicePartName).ToList()).ToList(),
        //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //    };
        //}

        public ActionResult VehicleGroup()
        {
            int FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
            return new JsonpResult
            {
                Data = (db.VehicleGroup_T.Where(x => x.FleetCompanyID == FleetCompanyID).OrderBy(x => x.VehicleGroup).ToList()).ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }



        public ActionResult AddVehicleGroup(string VehicleGroup)
        {
            int FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
            VehicleGroup_T vg = new VehicleGroup_T();
            vg.FleetCompanyID = FleetCompanyID;
            vg.VehicleGroup = VehicleGroup;
            db.VehicleGroup_T.Add(vg);
            db.SaveChanges();


            return new JsonpResult
            {
                Data = (db.VehicleGroup_T.Where(x => x.FleetCompanyID == FleetCompanyID && x.VehicleGroupID == vg.VehicleGroupID).OrderBy(x => x.VehicleGroup).ToList()).ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public ActionResult AddVehicleType(string VehicleType)
        {
            int FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
            VehicleType_T vt = new VehicleType_T();
            vt.FleetCompanyID = FleetCompanyID;
            vt.VehicleType = VehicleType;
            db.VehicleType_T.Add(vt);
            db.SaveChanges();
            return new JsonpResult
            {
                Data = (db.VehicleType_T.Where(x => x.FleetCompanyID == FleetCompanyID && x.VehicleTypeID == vt.VehicleTypeID).OrderBy(x => x.VehicleType).ToList()).ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public ActionResult VehicleType()
        {
            int FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
            return new JsonpResult
            {
                Data = (db.VehicleType_T.Where(x => x.FleetCompanyID == FleetCompanyID).OrderBy(x => x.VehicleType).ToList()).ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult AddAutoBrand(string Make, string Model, int Year)
        {
            int FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
            AutoBrand_T ab = new AutoBrand_T();
            ab.FleetCompanyID = FleetCompanyID;
            ab.Make = Make;
            ab.Model = Model;
            ab.Year = Year;
            db.AutoBrand_T.Add(ab);
            db.SaveChanges();
            return new JsonpResult
            {
                Data = (db.AutoBrand_T.Where(x => x.FleetCompanyID == FleetCompanyID && x.AutoBrandID == ab.AutoBrandID).OrderBy(x => x.Make).ToList()).ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public ActionResult AutoBrand()
        {
            int FleetCompanyID = Convert.ToInt32(Session["FleetCompanyID"]);
            return new JsonpResult
            {
                Data = (db.AutoBrand_T.Where(x => x.FleetCompanyID == FleetCompanyID).OrderBy(x => x.Make).ThenBy(x => x.Model).ToList()).ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


    }
    public class JsonpResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;
            string jsoncallback = (context.RouteData.Values["jsoncallback"] as string) ?? request["jsoncallback"];
            if (!string.IsNullOrEmpty(jsoncallback))
            {
                if (string.IsNullOrEmpty(base.ContentType))
                {
                    base.ContentType = "application/x-javascript";
                }
                response.Write(string.Format("{0}((", jsoncallback));
            }
            base.ExecuteResult(context);
            if (!string.IsNullOrEmpty(jsoncallback))
            {
                response.Write("))");
            }
        }
    }
}
