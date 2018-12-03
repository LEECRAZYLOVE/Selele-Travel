using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel
{
    interface IStaffMember
    {
        string username { get; set; }
        string password { get; set; }

        void updatePassword(string newPassword);
        void updateUsername(string newUsername);
    }
}
