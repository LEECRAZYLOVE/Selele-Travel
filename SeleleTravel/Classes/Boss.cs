using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel.Classes
{
    class Boss
    {
        public string name { get; set; } = "Pumla Patricia";
        public string surname { get; set; } = "Nyangiwe";
        public string username { get; protected set; }
        public string password { get; protected set; }
        public List<Employee> employees { get => Employee.AllEmployees; }
        public void fire(Employee employee)
        {
            if (employees.Contains(employee))
                    employees.Remove(employee);
        }
        public void promote(Employee employee)
        {
            fire(employee);
            Manager manager = new Manager(employee.names, employee.surname, employee.location);
            manager.timeHired = employee.timeHired;
        }
        public void updatePassword(string newPassword)
        {
            password = newPassword;
        }

        public void updateUsername(string newUsername)
        {
            username = newUsername;
        }
        public Boss()
        {

        }
        public Boss(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }
    }
}
