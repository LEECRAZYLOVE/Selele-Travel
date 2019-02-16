using System;

namespace SeleleTravel
{
    internal class accommodation
    {
        public accommodation()
        {
        }

        public string quote_no { get; set; }
        public string accomname { get; set; }
        public string accom_id { get; set; }
        public DateTime checkin { get; set; }
        public DateTime checkout { get; set; }
        public int numberofguests { get; set; }
        public int numberofrooms { get; set; }
        public string accomspecs { get; set; }
        public double amount { get; set; }
    }
}