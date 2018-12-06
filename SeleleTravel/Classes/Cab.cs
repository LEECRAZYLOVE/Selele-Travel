using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel
{
    /// <summary>
    /// 
    /// </summary>
    class Cab : Service
    {
        string agencyName;
        string driverName;
        string pickUpLocation;
        string dropOffLocation;
        string timeOfPickUp;
        DateTime dateOfPickup;
        string numberOfPassengers;
        string taxicabSpecs;
        string totalAmount;

        /// <summary>
        /// Cab: It takes in info required to book a cab.
        /// </summary>
        /// <param name="agencyName"></param>
        /// <param name="driverName"></param>
        /// <param name="pickUpLocation"></param>
        /// <param name="dropOffLocation"></param>
        /// <param name="timeOfPickUp"></param>
        /// <param name="dateOfPickup"></param>
        /// <param name="numberOfPassengers"></param>
        /// <param name="taxicabSpecs"></param>
        /// <param name="totalAmount"></param>
        public Cab(string agencyName, string driverName, string pickUpLocation, string dropOffLocation, string timeOfPickUp, DateTime dateOfPickup, string numberOfPassengers, string taxicabSpecs, string totalAmount)
        {
            this.agencyName = agencyName;
            this.driverName = driverName;
            this.pickUpLocation = pickUpLocation;
            this.dropOffLocation = dropOffLocation;
            this.timeOfPickUp = timeOfPickUp;
            this.dateOfPickup = dateOfPickup;
            this.numberOfPassengers = numberOfPassengers;
            this.taxicabSpecs = taxicabSpecs;
            this.totalAmount = totalAmount;
        }

        public override string ToString()
        {

            return base.ToString();
        }
    }
}
