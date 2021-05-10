using GUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface FuncService
    {
        void AddUser(UserDb users);

        void UpdateUser(UserDb users);

        void RemoveUser(string email);

        void AddPersonal(PersonalDb personal);

        void UpdatePersonal(PersonalDb personal);

        void RemovePersonal(string email);
        IEnumerable<UserDb> GetUserInfo(string email);
        IEnumerable<PersonalDb> GetPersonalInfo(string email);



    }
}
