using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel.Classes
{
    class Employee
    {
        public string username { get; protected set; }
        public string password { get; protected set; }

        public string names;
        public string surname;

        public string employeeID { get; protected set; }
        static int numberOfEmployees = 0;
        public DateTime timeHired;
        private string makeEmployeeID()
        {
            string idEnding = numberOfEmployees.ToString();
            while(idEnding.Length < 4)
            {
                idEnding = idEnding.PadLeft(1, '0');
            }
            return timeHired.Year + surname[0] + idEnding;
        }
        /// <summary>
        /// A refernce to all the employees of the company.
        /// </summary>
        public static List<Employee> AllEmployees;
        public string location;    //This is where the employee works

        public void updatePassword(string newPassword)
        {
            password = newPassword;
        }

        public void updateUsername(string newUsername)
        {
            username = newUsername;
        }
        public Employee(string names, string surname, string location = "East London")
        {
            this.names = names;
            this.surname = surname;
            this.location = location;
            AllEmployees.Add(this);
            numberOfEmployees++;
        }
    }
}

