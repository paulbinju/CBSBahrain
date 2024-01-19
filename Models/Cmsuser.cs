using System;
using System.Collections.Generic;

namespace CBSBahrainMVC.Models
{
    public partial class Cmsuser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
