using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
   public interface IValidation
    {
        bool AvailableSocialSecurityNumber(string socialSecurityNumber);
        bool AvailableEmail(string email);
        bool UserExists(string email);
        bool PersonalExists(string email);
        bool checkIfAdmin(string email, string password);
        bool checkIfValidPersonal(string email, string password);
        bool checkIfValidUser(string email, string password);

    }
}
