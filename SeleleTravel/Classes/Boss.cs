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


        public override List<Employee> employees { get => Employee.hiredEmployees; }

        /// <summary>
        /// Fires an employee. Status : incomplete
        /// </summary>
        /// <param name="employee"></param>
        public void fire(Employee employee)
        {
            if (employees.Contains(employee))
                employees.Remove(employee);

            //Remove employee from database

            //This is for displaying to the user
            string message = employee.names + " has been successfully fired.";
            MessageBox.Show(message, "Alert..", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// Adds an new employee to the database.
        /// Status : incomplete
        /// </summary>
        /// <param name="employee"></param>
        public void hire(Employee employee)
        {
            employee.timeHired = DateTime.Now;
            Employee.hiredEmployees.Add(employee);

            //Append changes to database

            //This part here is for alerting the user
            string message = employee.names + " has been successfully hired.";
            MessageBox.Show(message, "Alert..", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// Makes a given employee a manager. Status : incomplete
        /// </summary>
        /// <param name="employee"></param>
        public void promote(Employee employee)
        {
            fire(employee);
            Manager manager = new Manager(employee.names, employee.surname, employee.location);
            manager.employeeID = employee.employeeID;
            manager.timeHired = employee.timeHired;

            //Reflect changes on database

            //Displaying to user
            string message = "Password successfully updated!";
            MessageBox.Show(message, "Alert..", MessageBoxButton.OK, MessageBoxImage.Exclamation);

        }
        
        public Boss(string names = "Mrs Pumla Patricia", string surname ="Nyangiwe", string location = "East London")
            :base(names, surname, location)
        {
            this.names = names;
            this.surname = surname;
            this.location = location;
        }
    }
}
