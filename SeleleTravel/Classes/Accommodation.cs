using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeleleTravel
{
    public class Accommodation : Service
    {
        /// <summary>
        /// Name of the place.
        /// </summary>
        public string accomname;
        /// <summary>
        /// Date of check-in.
        /// </summary>
        public DateTime checkin;
        /// <summary>
        /// Date of check-out.
        /// </summary>
        public DateTime checkout;
        /// <summary>
        /// The number of people that need accommodation.
        /// </summary>
        public string numberofpeople;
        string accommodationSpecifications;
        string numberOFRooms;
        string amount;

        public Accommodation(string accomname, DateTime checkin, 
            DateTime checkout, string numberofpeople, string numberOFRooms, string accommodationSpecifications, string amount) : base()
        {
            this.accomname = accomname;
            this.checkin = checkin;
            this.checkout = checkout;
            this.numberofpeople = numberofpeople;
            this.accommodationSpecifications = accommodationSpecifications;
            this.numberOFRooms = numberOFRooms;
            this.amount = amount;

        }
    }
}
