using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Models;
public class Location
{
    public string Name { get; set; }
    public string Imagepath { get; set; }
    public Address Address { get; set; }



    public Location(string name, string imagepath, Address address)
    {
        Name = name;
        Imagepath = imagepath;
        Address = address;
    }
}
