using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.DTOs
{
    public class UserDto
    {
        public string Firstname;
        public string Lastname;
        public string Username;

        public UserDto(string firstName, string lastName, string userName)
        {
            Firstname = firstName;
            Lastname = lastName;
            Username = userName;
        }
    }
}
