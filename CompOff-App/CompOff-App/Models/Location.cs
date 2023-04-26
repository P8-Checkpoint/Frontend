using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Models;
public class Location
{
    public string Name { get; set; }
    public string ImagePath { get; set; }
    public Address Address { get; set; }

    public Location(string name, string imagePath, Address address)
    {
        Name = name;
        ImagePath = imagePath;
        Address = address;
    }
}
