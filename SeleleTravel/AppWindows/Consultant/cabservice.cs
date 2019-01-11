using System;

namespace SeleleTravel
{
    internal class cabservice
    {
        public cabservice()
        {
        }

        public string nameofagency { get; set; }
        public string agency_id { get; set; }
        public string quote_no { get; set; }
        public string nameofdriver { get; set; }
        public string pickup { get; set; }
        public string dropoff { get; set; }
        public DateTime dateofcab { get; set; }
        public int numberofcabs { get; set; }
        public double amount { get; set; }
        public string timeofcab { get; set; }
        public string cabspecs { get; set; }
    }
}