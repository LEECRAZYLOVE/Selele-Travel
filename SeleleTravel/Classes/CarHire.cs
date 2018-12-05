using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleleTravel
{/// <summary>
/// The CareHire
/// It takes in the required information for a successful carhire
/// </summary>
    class CarHire:Service
    {
        public string agencyName;
        public string pickUpLocation;
        public string dropOffLocation;
        public DateTime timeOfHire;
        public DateTime hireDuration;
        public DateTime expectedEndTime;
        /// <summary>
        /// CarHire
        /// Takes info required for hiring
        /// </summary>
        /// <param name="agencyName"></param>
        /// <param name="pickUpLocation"></param>
        /// <param name="dropOffLocation"></param>
        /// <param name="timeOfHire"></param>
        /// <param name="hireDuration"></param>
        public CarHire(string agencyName, string pickUpLocation, string dropOffLocation,DateTime timeOfHire, DateTime hireDuration)
        {
            this.agencyName = agencyName;
            this.pickUpLocation = pickUpLocation;
            this.dropOffLocation = dropOffLocation;
            this.timeOfHire = timeOfHire;
            this.hireDuration = hireDuration;
            expectedEndTime = AddTime(timeOfHire, hireDuration);
        }
        /// <summary>
        /// This method adds the time of hire day to the hire duration day so as to get the end day of the hire.
        /// </summary>
        /// <param name="Time_of_hire"></param>
        /// <param name="Hire_duration"></param>
        /// <returns></returns>
        private DateTime AddTime(DateTime Time_of_hire, DateTime Hire_duration)
        {
            return DateTime.FromOADate(timeOfHire.Day + hireDuration.Day);
        }

        public override string ToString()
        {
            string output = $"Thank you for choosing Selele Travel & Accomodation these are your car hire details\n" +
                            $"Agency name: {agencyName}\n" +
                            $"Pick up location: {pickUpLocation}\n" +
                            $"Drop off location: {dropOffLocation}\n" +
                            $"Period of hire\n" +
                            $"From: {timeOfHire}\n" +
                            $"Till: {expectedEndTime}\n" +
                            $"Safe travels.\n";
            return output;
        }
    }
}
