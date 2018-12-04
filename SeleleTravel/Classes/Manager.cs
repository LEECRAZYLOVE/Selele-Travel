using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel.Classes
{
    class Manager : Employee
    {
        /// <summary>
        /// Employees under this specific manager.
        /// </summary>
        public List<Employee> employees;
        /// <summary>
        /// Each manager manages in a specific location,
        /// so this method gets all the employees of that location,
        /// and assigns this manager as their manager.
        /// </summary>
        private void getEmployees()
        {
            foreach (Employee e in Employee.AllEmployees)
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
        /// Fires an employee.
        /// </summary>
        /// <param name="employee"></param>
        public void fire(Employee employee)
        {
            if (employees.Contains(employee))
                employees.Remove(employee);
        }
        public Manager(string names, string surname, string location = "East London") : base(names, surname, location)
        {
            getEmployees();
            AllManagers.Add(this);
        }
    }
}
