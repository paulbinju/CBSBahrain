using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fleetmanager.Models
{
    public class fleetbox
    {
    }
    public class Vehicles
    {
        public int VehicleID { get; set; }
        public string VehicleNoName { get; set; }
        public int VehicleNo { get; set; }
        public int VehicleGroupID { get; set; }
        public string VehicleGroup { get; set; }
        public int VehicleTypeID { get; set; }
        public string VehicleType { get; set; }
        public string RegistrationNo { get; set; }
        public int AutoBrandID { get; set; }
        public string Brand { get; set; }
        public string GPSURL { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal PurchaseAmount { get; set; }
        public DateTime YearofManufacture { get; set; }
        public string Note { get; set; }
        public int Life { get; set; }
        public string Color { get; set; }
        public int ServiceFrequency { get; set; }
        public int FuelTypeID { get; set; }
        public string FuelType { get; set; }
        public int StatusID { get; set; }
        public string Status { get; set; }
        public DateTime? DOC { get; set; }


    }

    public class FuelConsumption
    {
        public int FuelConsumptionID { get; set; }
        public string VehicleNoName { get; set; }
        public int? Odometer { get; set; }
        public int FuelTypeID { get; set; }
        public string FuelType { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? FillingDate { get; set; }
        public string Brand { get; set; }
        
    }



    public class VehicleInsurance {

        public int VehicleInsuranceID { get; set; }
        public int? VehicleID { get; set; }
        public int? InsuranceID { get; set; }
        public string Insurance { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class VehicleUser
    {
        public int VehicleUserID { get; set; }
        public string UserType { get; set; }
        public string Name { get; set; }
        public int? UserID { get; set; }
        public string EmailID { get; set; }
        public string NationalID { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Note { get; set; }
    }

    public class VehicleTraffic
    {
        public DateTime? TrafficContraventionsDate { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
    }

    public class BillDetailed {

        public int SpareServiceDetailsID { get; set; }
        public bool SparePart { get; set; }
        public int? BillID { get; set; }
        public string Descri { get; set; }
        public string Quantity { get; set; }
        public decimal? Amount { get; set; }

    }

    public class fmuser
    {
        public int FMUserID { get; set; }
        public int RoleID { get; set; }
        public string Role { get; set; }
        public int DepartmentID { get; set; }
        public string Department { get; set; }
        public int DivisionID { get; set; }
        public string Division { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FMPassword { get; set; }
        public string Mobile { get; set; }
    }

    public class division
    {

        public int DivisionID { get; set; }
        public int DepartmentID { get; set; }
        public string Division { get; set; }
        public string Department { get; set; }

    }
    public class autobrand
    {
        public int AutoBrandID { get; set; }
        public string AutoBrand { get; set; }

    }

    public class sparepart
    {
        public int SparePartID { get; set; }
        public int AutoBrandID { get; set; }
        public string AutoBrandIDs { get; set; }
        public string AutoBrand { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? AvailableQuantity { get; set; }
        public decimal? Price { get; set; }

    }
    public class userdepartmentdivision {

        public int userid { get; set; }
        public int? departmentid { get; set; }
        public string department { get; set; }
        public int? divisionid { get; set; }
        public string division { get; set; }
        public string name { get; set; }
        public string designation { get; set; }
        public string mobileno { get; set; }
        public string emailid { get; set; }
        public string address { get; set; }
        public string nationalid { get; set; }
        public string usertype { get; set; }
    }

    public class callcentre
    {
        public int CallID { get; set; }
        public string VehicleNoName { get; set; }
        public string RegistrationNo { get; set; }
        public string Name { get; set; }
        public DateTime? ReportedOn { get; set; }
        public DateTime? StartedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public bool? External { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public bool? JobCardGenerated { get; set; }
        public int? StatusID { get; set; }
        public int? VehicleID { get; set; }
        public int? FMUserID { get; set; }
        public int JobCardID { get; set; }
        public DateTime? JobStarted { get; set; }
        public DateTime? JobEnded { get; set; }
        public int? LabourHours { get; set; }
        public decimal? TotalCost { get; set; }
        public int? AutoBrandID { get; set; }
    }

    public class status
    {
        public int StatusID { get; set; }
        public int StatusTypeID { get; set; }
        public string StatusType { get; set; }
        public string Status { get; set; }

    }


    public class ReportInvoice
    {
        public string BillNo { get; set; }
        public DateTime? BillDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public string VehicleNoName { get; set; }
        public string RegistrationNo { get; set; }
        public string AutoBrand { get; set; }
        public string ShopName { get; set; }
        public string ServiceName { get; set; }
        public string SparepartName { get; set; }
        public string Quantity { get; set; }  
    }


    public class ReportJobCard
    {
        public int JobCardNo { get; set; }
        public DateTime? JobCardDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? LabourHour { get; set; }
        public string VehicleNoName { get; set; }
        public string RegistrationNo { get; set; }
        public string AutoBrand { get; set; }
        public string ShopName { get; set; }
        public string ServiceName { get; set; }
        public string SparepartName { get; set; }
        public string Quantity { get; set; }
    }


    public class ReportFuel
    {
        public DateTime? FillingDate { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Quantity { get; set; }
        public string RegistrationNo { get; set; }
        public string AutoBrand { get; set; }
        public string Fuel { get; set; }
    }



}