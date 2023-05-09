using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.DTOs
{
    public class UserDto
    {
        public string FirstName;
        public string LastName;
        public string UserName;

        public UserDto(string firstName, string lastName, string userName)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
        }
    }
}
