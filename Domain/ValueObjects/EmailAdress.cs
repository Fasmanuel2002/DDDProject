using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public partial record EmailAdress
    {
        private const string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.com$";
        public string Value { get; init; }
        private EmailAdress(string value)
        {
            Value = value;
        }

        public static EmailAdress? Create(string value)
        {
            if(string.IsNullOrEmpty(value) || !EmailAdressRegex().IsMatch(value) || value.Length == 0)
            {
                return null;
            }

            return new EmailAdress(value);

        }

        [GeneratedRegex(EmailPattern)]
        private static partial Regex EmailAdressRegex();

        
    }
}
