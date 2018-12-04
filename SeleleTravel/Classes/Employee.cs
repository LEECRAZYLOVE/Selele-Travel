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

        public string employeeID { get; set; }
        static int numberOfEmployees = 0;

        /// <summary>
        /// The time when the employee was hired. This is initialized in the 'hire' method of a Manager or Boss.
        /// </summary>
        public DateTime timeHired;
        /// <summary>
        /// This is a list of all the employees that are hired by the company.
        /// </summary>
        public static List<Employee> hiredEmployees = new List<Employee>();

        /// <summary>
        /// Generates an employee id.
        /// </summary>
        /// <returns></returns>
        private void makeEmployeeID()
        {
            string idEnding = numberOfEmployees.ToString();
            while(idEnding.Length < 4)
            {
                idEnding = idEnding.PadLeft(1, '0');
            }
            employeeID = timeHired.Year + surname[0] + idEnding;
        }
        /// <summary>
        /// The location where the employee is based.(Useful in the Managers 'getEmployees' method).
        /// </summary>
        public string location;    

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
            if (!(this is Boss))
                makeEmployeeID();
            else employeeID = this.names + " " + surname;
            numberOfEmployees++;
        }
    }
}

