using System;
using System.Collections.Generic;

namespace CBSBahrainMVC.Models
{
    public partial class SongBankCategory
    {
        public int SongId { get; set; }
        public int? CategoryId { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Lyrics { get; set; }
        public string YoutubeUrl { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CatCategoryId { get; set; }
        public string FileAttachment { get; set; }
    }
}
