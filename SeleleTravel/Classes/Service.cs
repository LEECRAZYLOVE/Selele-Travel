using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel
{/// <summary>
/// Super class for the services provided by the business.
/// </summary>
    public class Service
    {
        public string serviceQuoteNum;
        public string serviceOrderNum;

        public Service()
        {
            this.serviceOrderNum = Order.order_no;
            this.serviceQuoteNum = Quote.quote_no;
        }
    }
}
