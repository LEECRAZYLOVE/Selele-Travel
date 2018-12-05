using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel
{/// <summary>
/// The flight service
/// it takes in the airline name, from(location) and to(location)
/// it takes in the departure time and also the number of bags
/// </summary>
    class Flight:Service
    {
        public string airline;
        public string from, to;
        public DateTime departure, arrival, CheckInTime;
        public string flightNumber;
        public int numberOfbags;

        /// <summary>
        /// Flight
        /// Takes in info that is required for flight booking
        /// </summary>
        /// <param name="airline"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="departure"></param>
        /// <param name="numberOfbags"></param>
        public Flight(string airline, string from, string to, DateTime departure, int numberOfbags)
        {
            this.airline = airline;
            this.from = from;
            this.to = to;
            this.departure = departure;
            this.numberOfbags = numberOfbags;
        }

        /// <summary>
        /// Depart and Arrival
        /// This method takes in the details provided by the airline and then overide those entered in the constructor
        /// </summary>
        /// <param name="airlineDeparture"></param>
        /// <param name="airlineArrival"></param>
        /// <param name="flightNumber"></param>
        public void departure_And_Arrival(DateTime airlineDeparture, DateTime airlineArrival, string flightNumber)
        {
            departure = airlineDeparture;
            arrival = airlineArrival;
            this.flightNumber = flightNumber;
        }

        public override string ToString()
        {
            string output = $"Thank you for choosing Selele Travel & Accomodation these are your flight details belows\n" +
                            $"{airline}\n" +
                            $"From {from} to {to}\n" +
                            $"Check in time: {CheckInTime}\n" +
                            $"Departure time: {departure}\n" +
                            $"Arrival time: {arrival}\n" +
                            $"Number of bags: {numberOfbags}" +
                            $"Safe travels.\n";
            return output;
        }
    }
}
