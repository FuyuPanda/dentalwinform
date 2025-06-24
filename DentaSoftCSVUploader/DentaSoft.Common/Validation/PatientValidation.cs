using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DentaSoft.Common.Validation
{
    public class PatientValidation
    {

        public string MobilePhoneValidation(string name,string number)
        {
            if (!Regex.IsMatch(number, @"^\d{10,15}$"))
            {
                return name+" number must be filled with numeric character";
            }
            return "Success";
        }

        public string EmailValidation(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (Regex.IsMatch(email.Trim(), pattern, RegexOptions.IgnoreCase))
            {
                return "Invalid Email Format";
            }
            return "Success";

        }

       




    }
}
