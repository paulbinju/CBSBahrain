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
    
    public partial class Subscription_T
    {
        public int SubscriptionID { get; set; }
        public Nullable<int> FleetCompanyID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<bool> Trial { get; set; }
    }
}
