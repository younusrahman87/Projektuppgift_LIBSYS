using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.Models
{
    public class CategoryDb
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public List<BookDb> Books { get; set; }
    }
}
