using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Models
{
    class User
    {
        string _firstname,
               _lastname,
               _username;

        public User(string firstname, string lastname, string username)
        {
            _firstname = firstname;
            _lastname = lastname;
            _username = username;
        }



    }
}
