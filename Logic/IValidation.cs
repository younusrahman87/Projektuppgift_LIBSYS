using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
   public interface IValidation
    {
        bool AvailableSocialSecurityNumber(string socialSecurityNumber);
        bool AvailableEmail(string email);
        bool RemoveEmailUser(string email);
        bool RemoveEmailPersonal(string email);

    }
}
