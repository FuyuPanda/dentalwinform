using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentaSoft.Model
{
    public class TreatmentModel
    {
        public int PatientID { get; set; }
        public int DentistID { get; set; }
        public int Quantity { get; set; }
        public string TreatmentItem { get; set; }
        public string TreatmentIdentifier { get;set; } = string.Empty;
        public string Description { get; set; } =string.Empty;
        public decimal Fee { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Paid { get; set; } = string.Empty;
        public string ToothNumber { get; set; } = string.Empty ;
        public string Surface { get; set;} = string.Empty ;
    }
}
