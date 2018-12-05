using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel
{/// <summary>
/// Super class for the services provided by the business.
/// </summary>
    class Service
    {
        public List<Quote> serviceQuotes;
        public List<Order> serviceOrder;
        /// <summary>
        /// double Check
        /// It checks if the service order has been approved on not
        /// </summary>
        /// <param name="_serviceOrder"></param>
        /// <returns></returns>
        private bool doubleCheck(Order _serviceOrder) => serviceQuotes.Contains(_serviceOrder.approvedQuote);
        
    }
}
