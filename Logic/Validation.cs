using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using GUI.Models;


namespace Logic
{
    public class Validation : IValidation
    {
        GetData getData = new GetData();
        public bool AvailableEmail(string email)
        {
            bool isValid = false;

           
                MailAddress address = new MailAddress(email);
                isValid = string.IsNullOrEmpty(address.DisplayName);
                if (isValid)
                {
                    IEnumerable<UserDb> objListUser = getData.GetUser();
                    IEnumerable<PersonalDb> objListPersonal = getData.GetPesonal();

                    foreach (var itemUser in objListUser)
                    {
                        if (itemUser.Email == email)
                        {
                            return false;
                        }

                    }
                    foreach (var itemPersonal in objListPersonal)
                    {
                        if (itemPersonal.Email ==email)
                        {
                            return false;
                        }
                    }

                    return true;
                }
                
           
            return false;

        }

        public bool AvailableSocialSecurityNumber(string socialSecurityNumber)
        {
          



                if (Regex.IsMatch(socialSecurityNumber, @"^(\d{6}|\d{8})-\d{4}$"))
               {
                IEnumerable<UserDb> objListUser = getData.GetUser();
                IEnumerable<PersonalDb> objListPersonal = getData.GetPesonal();

                foreach (var itemUser in objListUser)
                {
                    if (itemUser.SocialSecurityNumber == socialSecurityNumber)
                    {
                        return false;
                    }

                }
                foreach (var itemPersonal in objListPersonal)
                {
                    if (itemPersonal.SocialSecurityNumber == socialSecurityNumber)
                    {
                        return false;
                    }
                }

                return true;
            }


            return false;
        }

        public bool RemoveEmailPersonal(string email)
        {

            IEnumerable<PersonalDb> objListPersonal = getData.GetPesonal();

            foreach (var itemPersonal in objListPersonal)
            {
                if (itemPersonal.Email == email)
                {
                    return true;
                }
            }
            return false;

        }

        public bool RemoveEmailUser(string email)
        {
            IEnumerable<UserDb> objListUser = getData.GetUser();
            foreach (var itemUser in objListUser)
            {
                if (itemUser.Email == email)
                {
                    return true;
                }

            }

            return false;
        }
    }
 }

