using GUI.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;


namespace Logic
{
    public class GetData
    {
        private readonly librarysystemdbContext _db = new librarysystemdbContext();
        public IEnumerable<UserDb> GetUser() => _db.UserDbs;
        public IEnumerable<PersonalDb> GetPersonalAdmin() => _db.PersonalDbs;
        public void UpdateUser(IEnumerable<UserDb> users)
        {
           
                _db.UserDbs.Add((UserDb)users);
                _db.SaveChanges();
              
            


        }


    }
}
