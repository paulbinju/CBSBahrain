using System;
using System.Collections.Generic;

namespace CBSBahrainMVC.Models
{
    public partial class Category
    {
        public Category()
        {
            SongBank = new HashSet<SongBank>();
        }

        public int CategoryId { get; set; }
        public string Category1 { get; set; }

        public virtual ICollection<SongBank> SongBank { get; set; }
    }
}
