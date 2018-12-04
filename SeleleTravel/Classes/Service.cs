using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel.Classes
{/// <summary>
/// 
/// </summary>
    class Service
    {
        public List<Quote> serviceQuotes;
        public List<Order> serviceOrder;
        private bool doubleCheck(Order _serviceOrder) => serviceQuotes.Contains(_serviceOrder.approvedQuote);
        
    }
}
