using System;
using System.Collections.Generic;

namespace CBSBahrainMVC.Models
{
    public partial class LessonClass
    {
        public int LessonId { get; set; }
        public string Title { get; set; }
        public string FileAttachment { get; set; }
        public string ClassName { get; set; }
        public int ClassId { get; set; }
    }
}
