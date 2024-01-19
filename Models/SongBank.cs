using System;
using System.Collections.Generic;

namespace CBSBahrainMVC.Models
{
    public partial class SongBank
    {
        public int SongId { get; set; }
        public int? CategoryId { get; set; }
        public string Title { get; set; }
        public string Lyrics { get; set; }
        public string YoutubeUrl { get; set; }
        public string FileAttachment { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Category Category { get; set; }
    }
}
