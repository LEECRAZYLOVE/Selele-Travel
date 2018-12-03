using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel.Classes
{
    class Employee : IStaffMember
    {
        public string username { get; set; }
        public string password { get; set; }

        public void updatePassword(string newPassword)
        {
            password = newPassword;
        }

        public void updateUsername(string newUsername)
        {
            username = newUsername;
        }
        public Employee(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}

