using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel.Classes
{
    class Boss : Manager
    {
        
        public override List<Employee> employees { get => Employee.hiredEmployees; }
        
        /// <summary>
        /// Makes a given employee a manager.
        /// </summary>
        /// <param name="employee"></param>
        public void promote(Employee employee)
        {
            fire(employee);
            Manager manager = new Manager(employee.names, employee.surname, employee.location);
            manager.employeeID = employee.employeeID;
            manager.timeHired = employee.timeHired;
        }
        
        public Boss(string names = "Pumla Patricia", string surname ="Nyangiwe", string location = "East London")
            :base(names, surname, location)
        {
            this.names = names;
            this.surname = surname;
            this.location = location;
        }
    }
}
