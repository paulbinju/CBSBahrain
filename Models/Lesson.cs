using System;
using System.Collections.Generic;

namespace CBSBahrainMVC.Models
{
    public partial class Lesson
    {
        public int LessonId { get; set; }
        public int? ClassId { get; set; }
        public string Title { get; set; }
        public string FileAttachment { get; set; }

        public virtual ClassStd Class { get; set; }
    }
}
