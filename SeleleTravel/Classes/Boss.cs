using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace SeleleTravel
{
    class Boss : Manager
    { 


        //public override List<staff> employees { get => staff.hiredEmployees; }

        /// <summary>
        /// Fires an employee. Status : incomplete
        /// </summary>
        /// <param name="employee"></param>
        public void fire(staff employee)
        {
            if (employees.Contains(employee))
                employees.Remove(employee);

            //Remove employee from database

            //This is for displaying to the user
            string message = employee.stafffirstnames + " has been successfully fired.";
            MessageBox.Show(message, "Alert..", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// Adds an new employee to the database.
        /// Status : incomplete
        /// </summary>
        /// <param name="employee"></param>
        public void hire(staff employee)
        {
            employee.dateofhire = DateTime.Now;
            //staff.hiredEmployees.Add(employee);

            //Append changes to database

            //This part here is for alerting the user
            string message = employee.stafffirstnames + " has been successfully hired.";
            MessageBox.Show(message, "Alert..", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// Makes a given employee a manager. Status : incomplete
        /// </summary>
        /// <param name="employee"></param>
        public void promote(staff employee)
        {
            fire(employee);
            Manager manager = new Manager(employee.stafffirstnames, employee.stafflastname);
            manager.staff_id = employee.staff_id;
            manager.dateofhire = employee.dateofhire;

            //Reflect changes on database

            //Displaying to user
            string message = "Password successfully updated!";
            MessageBox.Show(message, "Alert..", MessageBoxButton.OK, MessageBoxImage.Exclamation);

        }
        
        public Boss(string names = "Mrs Pumla Patricia", string surname ="Nyangiwe", string location = "East London")
            :base(names, surname, location)
        {
            stafffirstnames = names;
            stafflastname = surname;
        }
    }
}
