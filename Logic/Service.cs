using GUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
   public class Service : FuncService
    {

        GetData getData = new GetData();

        public void AddUser(UserDb users)
        {

            getData.AddUserAsync(users);

        }
        public void UpdateUser(UserDb users)
        {

            getData.UpdateUserAsync(users);

        }
        public void RemoveUser(string email)
        {

            getData.RemoveUserAsyc(email);

        }

        public void AddPersonal(PersonalDb personal)
        {
            getData.AddPersonalAsync(personal);
        }

        public void UpdatePersonal(PersonalDb personal)
        {
            getData.UpdatePersonalAsync(personal);
        }

        public void RemovePersonal(string email)
        {
            getData.RemovePersonalAsyc( email);
        }

        public IEnumerable<UserDb> GetUserInfo(string email)
        {
           return getData.GetUserinfo( email);

 
        }
      
        IEnumerable<PersonalDb> FuncService.GetPersonalInfo(string email)
        {
            return getData.GetPersonalinfo(email);
         
        }
    }
}
