//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeleleTravel
{
    using System;
    using System.Collections.Generic;
    
    public partial class conference
    {
        public string venue { get; set; }
        public string conferencename { get; set; }
        public string timeconference { get; set; }
        public Nullable<System.DateTime> dateofconference { get; set; }
        public string quote_no { get; set; }
        public string order_no { get; set; }
        public string conferencespecs { get; set; }
        public Nullable<double> amount { get; set; }

        public conference(string venueOfConference, string nameOfConference, DateTime dateOfConference, string timeOfConference, double amountOfConference, string conferenceSpecs)
        {
            this.venue = venueOfConference;
            this.conferencename = nameOfConference;
            dateofconference = dateOfConference;
            timeconference = timeOfConference;
            amount = amountOfConference;
            conferencespecs = conferenceSpecs;
        }

        public override string ToString()
        {
            string output = $"Thank you for choosing Selele Travel & Accomodation these are your conference details\n" +
                            $"Venue of conference: {venue}\n" +
                            $"Name of conference: {conferencename}\n" +
                            $"Time of conference: {timeconference}\n";
            return output;
        }
    }
}
