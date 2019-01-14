using System;

namespace SeleleTravel
{
    internal class carhire
    {
        public carhire()
        {
        }

        public string quote_no { get; set; }
        public string agencyname { get; set; }
        public string pickuplocation { get; set; }
        public string dropofflocation { get; set; }
        public DateTime dayofhire { get; set; }
        public DateTime expectedenddate { get; set; }
        public string carhirespecifications { get; set; }
        public double amount { get; set; }
    }
}