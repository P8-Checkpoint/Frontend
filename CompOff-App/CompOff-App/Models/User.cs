using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompOff_App.Models
{
    public class User
    {
        Guid _userID { get; set; }
        string _firstname { get; set; }
        string _lastname { get; set; }
        string _username { get; set; }
        bool _isActive { get; set; }

        public User(string firstname, string lastname, string username)
        {
            _userID = Guid.NewGuid();
            _firstname = firstname;
            _lastname = lastname;
            _username = username;
            _isActive = true; // should be changed when login is implemented
        }

        public string getInitials()
        {
            return _firstname.Substring(0,1) + _lastname.Substring(0,1);
        }
        bool isUserActive()
        {
            if (_isActive) return true;
            else return false;
        }



    }
}
