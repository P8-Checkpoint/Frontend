using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Models
{
    public class Location
    {
        string _name { get; set; }
        string _imagepath { get; set; }
        Adress adress { get; set; }

        public struct Adress
        {
            string street, 
                   number, 
                   city, 
                   zipcode, 
                   country;
        }

    }
}
