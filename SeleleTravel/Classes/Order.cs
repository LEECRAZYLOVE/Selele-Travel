using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel
{/// <summary>
/// The Order classs
/// This class takes info that is required for the order to be placed
/// </summary>
    struct Order
    {
        public Quote approvedQuote;
        public string orderNumber;
        public DateTime timeOrdered;
        /// <summary>
        /// Order
        /// </summary>
        /// <param name="_approvedQuote"></param>
        /// <param name="_orderNumber"></param>
        public Order(Quote _approvedQuote, string _orderNumber)
        {
            approvedQuote = _approvedQuote;
            orderNumber = _orderNumber;
            timeOrdered = DateTime.Now;
        }
    }
}
