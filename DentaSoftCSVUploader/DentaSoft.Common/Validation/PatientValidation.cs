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

        public string MobilePhoneValidation(string phone)
        {
            if(phone == null || phone.Length == 0)
            {
                return "Mobile Number must be filled";
            }

            if (!Regex.IsMatch(phone, @"^\d{10,15}$"))
            {
                return "Mobile number must be filled with numeric character";
            }
            return "Success";
        }




    }
}
