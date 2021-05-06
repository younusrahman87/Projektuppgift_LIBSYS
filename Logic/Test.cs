using GUI.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;


namespace Logic
{
    public class Test
    {
        public readonly librarysystemdbContext _db;

        public Test (librarysystemdbContext db)
        {

            _db = db;
            

        }

        public void NewMethod()
        {

            IEnumerable<UserDb> objList = _db.UserDbs;
            foreach (var item in objList)
            {
                var a = item.LibraryCard;

            }
        }
        public Test()
        {

        }
    }
}
