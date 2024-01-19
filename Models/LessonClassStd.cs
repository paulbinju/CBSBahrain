using System;
using System.Collections.Generic;

namespace CBSBahrainMVC.Models
{
    public partial class LessonClassStd
    {
        public int LessonId { get; set; }
        public int? ClassId { get; set; }
        public string Title { get; set; }
        public string FileAttachment { get; set; }
        public string ClassName { get; set; }
        public int Expr1 { get; set; }
    }
}
