//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fleetmanager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User_T
    {
        public int UserID { get; set; }
        public Nullable<int> FleetCompanyID { get; set; }
        public string UserType { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<int> DivisionID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        public string NationalID { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> DOC { get; set; }
    }
}
