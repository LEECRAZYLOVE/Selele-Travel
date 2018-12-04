using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SeleleTravel.Classes
{
    class Manager : Employee
    {
        /// <summary>
        /// Employees under this specific manager.
        /// </summary>
        public virtual List<Employee> employees { get; protected set; }
        /// <summary>
        /// Each manager manages in a specific location,
        /// so this method gets all the employees of that location,
        /// and assigns this manager as their manager.
        /// </summary>
        private void getEmployees()
        {
            foreach (Employee e in Employee.hiredEmployees)
            {
                if (e.location == location)
                {
                    employees.Add(e);
                }
            }
        }
        /// <summary>
        /// A reference to all the managers employed by the company.
        /// </summary>
        public static List<Manager> AllManagers = new List<Manager>();
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
        public Manager(string names, string surname, string location = "East London") : base(names, surname, location)
        {
            getEmployees();
            AllManagers.Add(this);
        }
    }
}
