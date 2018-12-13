using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SeleleTravel
{
    class Manager : staff
    {
        /// <summary>
        /// Employees under this specific manager.
        /// </summary>
        public virtual List<staff> employees { get; protected set; }
        /// <summary>
        /// Each manager manages in a specific location,
        /// so this method gets all the employees of that location,
        /// and assigns this manager as their manager.
        /// </summary>
        private void getEmployees()
        {
            foreach (staff e in hiredEmployees)
            {
                if (e.branch == branch)
                {
                    employees.Add(e);
                }
            }
        }
        /// <summary>
        /// A reference to all the managers employed by the company.
        /// </summary>
        public static List<Manager> AllManagers = new List<Manager>();
        
        public Manager(string names, string surname, string location = "East London") : base(names, surname, location)
        {
            getEmployees();
            AllManagers.Add(this);
        }
    }
}
