using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Models
{
    public struct Address
    {
        string Street,
               Number,
               City,
               Zipcode,
               Country;
        public Address(string street, string number, string city, string zipcode, string country)
        {
            Street = street;
            Number = number;
            City = city;
            Zipcode = zipcode;
            Country = country;
        }
    }
}
