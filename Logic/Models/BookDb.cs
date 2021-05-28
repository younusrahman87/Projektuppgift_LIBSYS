using System;
using System.Collections.Generic;

#nullable disable

namespace GUI.Models
{
    public partial class BookDb
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Publisher { get; set; }
        public int Id { get; set; }
        public int Price { get; set; }
        public decimal? Ddc { get; set; }
        public string Author { get; set; }
        public int? UserId { get; set; }

        public virtual CategoryDb Category { get; set; }
    }
}
