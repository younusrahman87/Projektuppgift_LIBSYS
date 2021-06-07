using System;
using System.Collections.Generic;
using System.Linq;
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
                    IEnumerable<UserDb> objListUser = getData.GetUsers();
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
                IEnumerable<UserDb> objListUser = getData.GetUsers();
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

        public bool PersonalExists(string email)
        {
            return getData.GetPesonal().Any(p => p.Email == email);
        }

        public bool UserExists(string email)
        {
            return getData
                .GetUsers()
                .Any(u => u.Email == email);
        }

        public bool checkIfValidUser(string email, string password)
        {
            return getData
                .GetUsers()
                .Any(u => u.Email == email && u.Password == password);
        }

        public bool checkIfValidPersonal(string email, string password)
        {
            return getData
               .GetPesonal()
               .Any(u => u.Email == email && u.Password == password);
        }

        public bool checkIfAdmin(string email, string password)
        {
            return getData
                .GetPesonal()
                .Where(u => u.JobTitle == "admin")
                .Where(u => u.Email == email)
                .Any(u => u.Password == password);
        }
    }
 }

