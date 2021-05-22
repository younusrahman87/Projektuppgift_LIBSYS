using System;
using System.Collections.Generic;

#nullable disable

namespace GUI.Models
{
    public partial class CategoryDb
    {
        public CategoryDb()
        {
            BookDbs = new HashSet<BookDb>();
        }

        public string CategoryName { get; set; }
        public int Id { get; set; }

        public virtual ICollection<BookDb> BookDbs { get; set; }
    }
}
