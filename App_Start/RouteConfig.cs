using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fleetmanager
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
              name: "ReportFuelPetrol",
              url: "Reports/FuelPetrol/{startdate}/{enddate}",
              defaults: new { controller = "Reports", action = "FuelPetrol", startdate = UrlParameter.Optional, enddate = UrlParameter.Optional }
             );


            routes.MapRoute(
              name: "ReportFuelDiesel",
              url: "Reports/FuelDiesel/{startdate}/{enddate}",
              defaults: new { controller = "Reports", action = "FuelDiesel", startdate = UrlParameter.Optional, enddate = UrlParameter.Optional }
             );


            routes.MapRoute(
              name: "ReportFuel",
              url: "Reports/Fuel/{startdate}/{enddate}",
              defaults: new { controller = "Reports", action = "Fuel", startdate = UrlParameter.Optional, enddate = UrlParameter.Optional }
             );

            routes.MapRoute(
              name: "ReportGarageService",
              url: "Reports/GarageService/{startdate}/{enddate}",
              defaults: new { controller = "Reports", action = "GarageService", startdate = UrlParameter.Optional, enddate = UrlParameter.Optional }
             );

            routes.MapRoute(
               name: "ReportGarageSparePart",
               url: "Reports/GarageSparePart/{startdate}/{enddate}",
               defaults: new { controller = "Reports", action = "GarageSparePart", startdate = UrlParameter.Optional, enddate = UrlParameter.Optional }
              );
            routes.MapRoute(
               name: "ReportInvoiceCompanywise",
               url: "Reports/InvoiceCompanywise/{startdate}/{enddate}",
               defaults: new { controller = "Reports", action = "InvoiceCompanywise", startdate = UrlParameter.Optional, enddate = UrlParameter.Optional }
              );


            routes.MapRoute(
               name: "ReportInvoiceService",
               url: "Reports/InvoiceService/{startdate}/{enddate}",
               defaults: new { controller = "Reports", action = "InvoiceService", startdate = UrlParameter.Optional, enddate = UrlParameter.Optional }
              );


            routes.MapRoute(
               name: "ReportInvoiceSparepart",
               url: "Reports/InvoiceSparepart/{startdate}/{enddate}",
               defaults: new { controller = "Reports", action = "InvoiceSparepart", startdate = UrlParameter.Optional, enddate = UrlParameter.Optional }
              );


            routes.MapRoute(
            name: "FMUser",
            url: "FMUser/Index/{message}",
            defaults: new { controller = "FMUser", action = "Index", message = UrlParameter.Optional }
           );




            routes.MapRoute(
            name: "Appgetdivision",
            url: "App/getdivision/{departmentid}",
            defaults: new { controller = "App", action = "getdivision", departmentid = UrlParameter.Optional }
           );
            routes.MapRoute(
            name: "Appgetservicepart",
            url: "App/getservicepart",
            defaults: new { controller = "App", action = "getservicepart" }
           );

            routes.MapRoute(
             name: "AppAddservicepart",
             url: "App/Addservicepart/{servicepartname}",
             defaults: new { controller = "App", action = "Addservicepart", servicepartname = UrlParameter.Optional }
            );

            routes.MapRoute(
             name: "AppVehicleGroup",
             url: "App/VehicleGroup",
             defaults: new { controller = "App", action = "VehicleGroup" }
            );
            routes.MapRoute(
             name: "AppVehicleType",
             url: "App/VehicleType",
             defaults: new { controller = "App", action = "VehicleType"}
            );
            routes.MapRoute(
            name: "AppAutoBrand",
            url: "App/AutoBrand",
            defaults: new { controller = "App", action = "AutoBrand"}
            );

            routes.MapRoute(
            name: "AppAddVehicleGroup",
            url: "App/AddVehicleGroup/{VehicleGroup}",
            defaults: new { controller = "App", action = "AddVehicleGroup", VehicleGroup = UrlParameter.Optional }
           );
            routes.MapRoute(
             name: "AppAddVehicleType",
             url: "App/AddVehicleType/{VehicleType}",
             defaults: new { controller = "App", action = "AddVehicleType", VehicleType = UrlParameter.Optional }
            );
            routes.MapRoute(
            name: "AppAddAutoBrand",
            url: "App/AddAutoBrand/{Make}/{Model}/{Year}",
            defaults: new { controller = "App", action = "AddAutoBrand", Make = UrlParameter.Optional, Model = UrlParameter.Optional, Year = UrlParameter.Optional }
            );

           routes.MapRoute(
             name: "JobCardDetail",
             url: "JobCardDetails/{jobcardid}",
             defaults: new { controller = "JobCard", action = "JobCardDetails", jobcardid = UrlParameter.Optional }
            );


            



            routes.MapRoute(
             name: "Deleteinvdetsxx",
             url: "SpareServiceDetails/Deleteinvdetsxx/{id}/{fromwhere}",
             defaults: new { controller = "SpareServiceDetails", action = "Deleteinvdetsxx", id = UrlParameter.Optional, fromwhere = UrlParameter.Optional }
            );


            routes.MapRoute(
             name: "InvoiceDetail",
             url: "InvoiceDetail/{invoiceid}/{vehicleid}",
             defaults: new { controller = "SpareServiceDetails", action = "Index", invoiceid = UrlParameter.Optional, vehicleid = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "UserVehicleAsso1",
              url: "UserVehicleAsso1/{userid}",
              defaults: new { controller = "User", action = "UserVehicleAsso1", userid = UrlParameter.Optional }
             );

            routes.MapRoute(
              name: "VehicleUserAllocation",
              url: "VehicleUserAllocation/{vehicleid}/{message}",
              defaults: new { controller = "Vehicle", action = "VehicleUserAllocation", vehicleid = UrlParameter.Optional, message = UrlParameter.Optional }
             );


            routes.MapRoute(
              name: "TrafficContraventions",
              url: "TrafficContraventions",
              defaults: new { controller = "TrafficContraventions", action = "Vehicles" }
             );




            routes.MapRoute(
              name: "TrafficContraventionsAdd",
              url: "TrafficContraventions/Add/{vehicleid}",
              defaults: new { controller = "TrafficContraventions", action = "Add", vehicleid = UrlParameter.Optional }
             );


            routes.MapRoute(
              name: "SaveTrafficContraventions",
              url: "SaveTrafficContraventions",
              defaults: new { controller = "TrafficContraventions", action = "SaveContraventions", vehicleid = UrlParameter.Optional }
             );
            


            routes.MapRoute(
              name: "VehicleRemoveAllocation",
              url: "VehicleRemoveAllocation",
              defaults: new { controller = "Vehicle", action = "VehicleRemoveAllocation" }
             );



            routes.MapRoute(
              name: "VehicleDetailsEdit",
              url: "VehicleDetails/VehicleDetailsEdit",
              defaults: new { controller = "Vehicle", action = "Edit" }
             );

            routes.MapRoute(
             name: "VehicleCreate",
             url: "VehicleCreate",
             defaults: new { controller = "Vehicle", action = "Create" }
            );





            routes.MapRoute(
              name: "VehicleTrafficContraventions",
              url: "VehicleTrafficContraventions",
              defaults: new { controller = "Vehicle", action = "VehicleTrafficContraventions" }
             );
            routes.MapRoute(
              name: "VehicleDetails",
              url: "VehicleDetails/{vehicleid}/{message}",
              defaults: new { controller = "Vehicle", action = "VehicleDetails", vehicleid = UrlParameter.Optional, message = UrlParameter.Optional }
             );

            routes.MapRoute(
                name: "Help",
                url: "Help",
                defaults: new { controller = "Home", action = "Help" }
               );

            routes.MapRoute(
             name: "Userx",
             url: "Userx/Createx",
             defaults: new { controller = "User", action = "Createx" }
            );

            routes.MapRoute(
             name: "User",
             url: "User/{user}",
             defaults: new { controller = "User", action = "Index", user = UrlParameter.Optional }
            );

            routes.MapRoute(
             name: "Vehicle",
             url: "Vehicle/{which}",
             defaults: new { controller = "Vehicle", action = "Index", which = UrlParameter.Optional }
            );
            routes.MapRoute(
             name: "Login",
             url: "Login",
             defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional }
            );
            
           routes.MapRoute(
             name: "MyAccount",
             url: "MyAccount",
             defaults: new { controller = "Home", action = "MyAccount" }
            );
            routes.MapRoute(
             name: "Logout",
             url: "Logout",
             defaults: new { controller = "Home", action = "Logout", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
