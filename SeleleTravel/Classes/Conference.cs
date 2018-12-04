using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel.Classes
{/// <summary>
/// This the Conference service.
/// It takes in the venueOfConference, nameOfConference, and timeOfConference
/// </summary>
    class Conference :Service
    {
        public string venueOfConference;
        public string nameOfConference;
        public DateTime timeOfConference;

        /// <summary>
        /// Takes in info required for Conference booking
        /// </summary>
        /// <param name="venueOfConference"></param>
        /// <param name="nameOfConference"></param>
        /// <param name="timeOfConference"></param>
        public Conference(string venueOfConference, string nameOfConference, DateTime timeOfConference)
        {
            this.venueOfConference = venueOfConference;
            this.nameOfConference = nameOfConference;
            this.timeOfConference = timeOfConference;
        }

        public override string ToString()
        {
            string output = $"Thank you for choosing Selele Travel & Accomodation these are your conference details\n" +
                            $"Venue of conference: {venueOfConference}\n" +
                            $"Name of conference: {nameOfConference}\n" +
                            $"Time of conference: {timeOfConference}\n";
            return output;
        }
    }
}
