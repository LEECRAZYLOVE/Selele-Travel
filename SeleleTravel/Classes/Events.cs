using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel
{
    class Events
    {
        public string name;
        public string specifications;
        public double amount;

        public Events(string name, string specifications, double amount)
        {
            this.name = name;
            this.specifications = specifications;
            this.amount = amount;
        }
    }
}
