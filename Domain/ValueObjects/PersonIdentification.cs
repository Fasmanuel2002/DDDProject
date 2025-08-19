using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class PersonIdentification
    {
        public const int DefaultLength = 9;
        private const string IdentificationPattern = @"^[0-9]{8}[A-Z]$";
    
        public string Value { get; init; }
        private PersonIdentification(string value) => Value = value;
    
        public static PersonIdentification? Create(string value)
        {
            if (string.IsNullOrEmpty(value) || (!PersonIdentificationPersonRegex().IsMatch(value) || value.Length > 9)
            {
                return null;
            }
            return new PersonIdentification(value);
        }

        [GeneratedRegex(IdentificationPattern)]
        private static partial Regex PersonIdentificationPersonRegex();

    }
}
