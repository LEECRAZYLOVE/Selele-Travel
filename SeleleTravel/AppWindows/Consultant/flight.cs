using System;

namespace SeleleTravel
{
    internal class flight
    {
        public flight()
        {
        }

        public string quote_no { get; set; }
        public string airline { get; set; }
        public string fromcity { get; set; }
        public string tocity { get; set; }
        public DateTime departdate { get; set; }
        public int numberofbags { get; set; }
        public string flightspecs { get; set; }
        public double amount { get; set; }
    }
}