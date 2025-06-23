using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentaSoft.Common.Common
{
    public class IdentifierGenerator
    {
        private static readonly Random random = new Random();

        public string Generate(string name) 
        {

            string chars = "0123456789";
            string character = new string(Enumerable.Repeat(chars, 20)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return name+ character;

        }
    }
}
