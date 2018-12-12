//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeleleTravel
{
    using System;
    using System.Collections.Generic;
    
    public partial class staff
    {
        public string staff_id { get; set; }
        public string stafffirstnames { get; set; }
        public string stafflastname { get; set; }
        public string staffposition { get; set; }
        public Nullable<System.DateTime> dateofhire { get; set; }
        public Nullable<double> salary { get; set; }
        public string branch { get; set; }

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
            while (idEnding.Length < 4)
            {
                idEnding = idEnding.PadLeft(1, '0');
            }
            employeeID = timeHired.Year + surname[0] + idEnding;
        }
        /// <summary>
        /// The location where the employee is based.(Useful in the Managers 'getEmployees' method).
        /// </summary>
        public string location;

        /// <summary>
        /// Changes the password of this employee. Status : Incomplete
        /// </summary>
        /// <param name="newPassword"></param>
        public void updatePassword(string newPassword)
        {
            password = newPassword;

            //Reflect the changes on the database

            //Displaying to user
            string message = "Password successfully updated!";
            MessageBox.Show(message, "Alert..", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        /// <summary>
        /// Changes the username of this employee. Status : incomplete
        /// </summary>
        /// <param name="newUsername"></param>
        public void updateUsername(string newUsername)
        {
            username = newUsername;

            //Make the necessary changes on the database

            //Displaying to user
            string message = "Password successfully updated!";
            MessageBox.Show(message, "Alert..", MessageBoxButton.OK, MessageBoxImage.Exclamation);

        }
        public override string ToString()
        {
            return names + " " + surname;
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
