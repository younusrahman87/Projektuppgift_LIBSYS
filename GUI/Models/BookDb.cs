using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.Models
{
    public class BookDb
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public int Id { get; set; }
        public int Price { get; set; }
        public decimal DDC { get; set; }
        public string Author { get; set; }
        public int CategoryID { get; set; }
        //Navigation
        public CategoryDb Category { get; set; }
    }
}
