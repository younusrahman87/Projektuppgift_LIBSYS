using System;
using System.Collections.Generic;

#nullable disable

namespace GUI.Models
{
    public partial class PersonalDb
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Password { get; set; }
    }
}
