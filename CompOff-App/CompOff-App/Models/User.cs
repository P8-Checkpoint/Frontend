using CompOff_App.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Models;

public class User
{
    public Guid UserID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Initials { get; set; }

    public User()
    { 
    }

    public User(string firstName, string lastName, string userName)
    {
        UserID = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Initials = GetInitials();
    }

    public User(Guid userID, string firstName, string lastName, string userName)
    {
        UserID = userID;
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Initials = GetInitials();
    }

    public User(UserDto userDto)
    {
        FirstName = userDto.FirstName;
        LastName = userDto.LastName;
        UserName = userDto.UserName;
        Initials = GetInitials();
    }

    private string GetInitials()
    {
        return string.Concat(FirstName.AsSpan(0,1), LastName.AsSpan(0,1));
    }
}
