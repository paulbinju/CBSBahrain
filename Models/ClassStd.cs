using System;
using System.Collections.Generic;

namespace CBSBahrainMVC.Models
{
    public partial class ClassStd
    {
        public ClassStd()
        {
            Lesson = new HashSet<Lesson>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; }

        public virtual ICollection<Lesson> Lesson { get; set; }
    }
}
