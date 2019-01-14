using System;

namespace SeleleTravel
{
    internal class quote
    {
        public quote()
        {
        }

        public string quote_no { get; set; }
        public double amount { get; set; }
        public string service { get; set; }
        public string timequoted { get; set; }
        public DateTime quotedate { get; set; }
        public string consultant_no { get; set; }
        public string client_no { get; set; }
        public string clientname { get; set; }
        public double servicefee { get; internal set; }
    }
}