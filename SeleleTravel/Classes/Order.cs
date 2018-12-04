using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel.Classes
{
    struct Order
    {
        public Quote approvedQuote;
        public string orderNumber;
        public DateTime timeOrdered;
        public Order(Quote _approvedQuote, string _orderNumber)
        {
            approvedQuote = _approvedQuote;
            orderNumber = _orderNumber;
            timeOrdered = DateTime.Now;
        }
    }
}
