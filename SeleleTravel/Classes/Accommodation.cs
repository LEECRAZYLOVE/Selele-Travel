using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeleleTravel.Classes
{
    enum AccommodationType { self_catering, BnB, hotel, lodge}
    class Accommodation : Service
    {
        /// <summary>
        /// Name of the place.
        /// </summary>
        public string name;
        /// <summary>
        /// Time of check-in.
        /// </summary>
        public string checkIn;
        /// <summary>
        /// Time of check-out.
        /// </summary>
        public string checkOut;
        /// <summary>
        /// The number of people that need accommodation.
        /// </summary>
        public string numberOfPeople;
        public AccommodationType accommodationType;

        public Accommodation(string name, string checkIn, 
            string checkOut, string numberOfPeople, 
            AccommodationType accommodationType)
        {
            this.name = name;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
            this.numberOfPeople = numberOfPeople;
            this.accommodationType = accommodationType;
        }
    }
}
