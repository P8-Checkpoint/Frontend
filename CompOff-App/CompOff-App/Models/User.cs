using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Models
{
    public class User
    {
        public Guid UserID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }

        public User(string firstname, string lastname, string username)
        {
            UserID = Guid.NewGuid();
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
        }

        public string getInitials()
        {
            return Firstname.Substring(0,1) + Lastname.Substring(0,1);
        }
    }
}
