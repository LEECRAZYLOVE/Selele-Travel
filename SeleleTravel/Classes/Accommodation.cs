using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeleleTravel.Classes
{
    enum AccommodationType { self_catering, BnB, hotel, lodge}
    class Accommodation //: Service
    {
        /// <summary>
        /// Name of the place.
        /// </summary>
        public string name;
        /// <summary>
        /// Date of check-in.
        /// </summary>
        public DateTime checkIn;
        /// <summary>
        /// Date of check-out.
        /// </summary>
        public DateTime checkOut;
        /// <summary>
        /// The number of people that need accommodation.
        /// </summary>
        public string numberOfPeople;
        public AccommodationType accommodationType;

        public Accommodation(string name, DateTime checkIn, 
            DateTime checkOut, string numberOfPeople, 
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
