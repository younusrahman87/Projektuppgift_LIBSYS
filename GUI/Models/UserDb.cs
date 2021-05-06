using System;
using System.Collections.Generic;

#nullable disable

namespace GUI.Models
{
    public partial class UserDb
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool LibraryCard { get; set; }
    }
}
