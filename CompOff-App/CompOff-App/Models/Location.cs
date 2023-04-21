using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Models
{
    class Location
    {
        string _name,
               _imagepath;
        Adress adress; 

        struct Adress
        {
            string street, 
                   number, 
                   city, 
                   zipcode, 
                   country;
        }

    }
}
