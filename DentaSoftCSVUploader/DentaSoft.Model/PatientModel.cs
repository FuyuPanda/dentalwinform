using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentaSoft.Model
{
    public class PatientModel
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; }  = string.Empty;
        public DateTime DOB { get; set; }
        public string Gender { get; set; }  = string.Empty ;
        public string Email { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Suburb { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;    
    }
}
