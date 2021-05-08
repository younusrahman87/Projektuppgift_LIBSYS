using GUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    class Service : FuncService
    {
         GetData getData = new GetData();
        public void GetUser(IEnumerable<UserDb> users)
        {
            getData.UpdateUser(users);
            
        }
    }
}
