using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Consultant.xaml
    /// </summary>
    public partial class Consultant : Window
    {
        public Consultant()
        {
            InitializeComponent();
        }
        private void selectionChanged(object sender, RoutedEventArgs e)
        {
            //Making sure that only one checkbox is selected at a time
            CheckBox reference = (CheckBox)sender;
            if (reference == ckbBusiness)
            {
                ckbIndividual.IsChecked = !ckbBusiness.IsChecked;
            }
            else ckbBusiness.IsChecked = !ckbIndividual.IsChecked;
        }
        //Status : Incomplete
        private void createNewClient_Click(object sender, RoutedEventArgs e)
        {
            string names = txbNewClient_name.Text + " " + txbNewClient_surname;
            //Retrieving clientType
            ClientType clientType = (bool)(ckbBusiness.IsChecked) ? ClientType.Business : ClientType.Individual;

            //Get contact details
            string cellphone = txbNewClient_cellphone.Text;
            string fax = txbNewClient_fax.Text;
            string email = txbNewClient_email.Text;
            string telephone = txbNewClient_telephone.Text;
            ContactDetails contactDetails = new ContactDetails(cellphone, email, telephone, fax);

            //Get location details
            string address = txbNewClient_address.Text;
            string city = txbNewClient_city.Text;
            string areaCode = txbNewClient_areaCode.Text;
            string province = txbNewClient_province.Text;
            //use this in initialisation of client
            string _location = address + '\n' + city + '\n' + areaCode + '\n' + province;
            //Initialize Client instance
            Client client = new Client(names, clientType, contactDetails)
            {
                location = _location
            };


            //Add client to database

        }

        private void nameAndSurnameTextChanged(object sender, TextChangedEventArgs e)
        {
            string acceptedCharacters = " qwertyuioplkjhgfdsazxcvbnm";
            TextBox reference = (TextBox)sender;
            if (reference.Text.Length <= 0) return;

            string letterEntered = reference.Text.Last().ToString().ToLower();
            if (!acceptedCharacters.Contains(letterEntered))
            {
                reference.Text = reference.Text.TrimEnd(letterEntered.ToCharArray());
                reference.SelectionStart = reference.Text.Length;
                MessageBox.Show("'" + letterEntered + "' is not an accepted character for a name or a surname!", "Invalid Character!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #region Already a Client Display

        #endregion

        #region Event tab
        private void _done(object sender, RoutedEventArgs e)
        {
            // create variables and assign to textbox values
            string nameOfEvent = txbEvents_name.Text;
            string eventSpecs = txbEvents_specifications.Text;
            string eventAmount = txbEvents_total.Text;

            // creates an instance of an event
            Events event_selele = new Events(nameOfEvent, eventSpecs, eventAmount);

            // Verifying input from user
            if(nameOfEvent == "")
            {
                MessageBox.Show("Please enter the name of the event.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(eventSpecs == "")
            {
                MessageBox.Show("Please enter the specifications of the event.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(eventAmount == "")
            {
                MessageBox.Show("Please enter the total amount of the event.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // Todo sql insertion
            // ...
        }
        #endregion

        #region Conference tab
        private void BtnConference_done_Click(object sender, RoutedEventArgs e)
        {
            string conferenceName = txbConference_name.Text;
            string conferenceVenue = txbConference_venue.Text;
            DateTime dateOfConference = dpConference_date.DisplayDate;
            string conferenceTime = txbConference_time.Text;
            string specsOfConference = txbConference_specifications.Text;
            string amountOfconf = txbConference_total.Text;
            Conference selele_Conference = new Conference(conferenceVenue, conferenceName, dateOfConference, conferenceTime, amountOfconf, specsOfConference);
            
            // Todo sql insertion
            // ...
        }
        
        #endregion

        #region Taxi cab
        private void BtnCab_done_Click(object sender, RoutedEventArgs e)
        {
            string _agencyName = txbCab_agency.Text;
            string _driverName = txbCab_driver.Text;
            string _pickUpLocation = txbCab_pickUp.Text;
            string _dropOffLocation = txbCab_dropOff.Text;
            string _timeOfPickUp = txbCab_pickUpTime.Text;
            DateTime _dateOfPickup = dpCab_pickUpDate.DisplayDate;
            string _numberOfPassengers = txbCab_numCabs.Text;
            string _taxicabSpecs = txbCab_specifications.Text;
            string _totalAmount = txbCab_total.Text;

            Cab taxiCab = new Cab(_agencyName,_driverName,_pickUpLocation,_dropOffLocation,_timeOfPickUp,_dateOfPickup,_numberOfPassengers,_taxicabSpecs,_totalAmount);
            
            // Todo sql insertion
            // ...
        }

        #endregion

        #region Flight tab
        public List<string> _passangers;
        private void BtnFlight_done_Click(object sender, RoutedEventArgs e)
        {
            string airlineName = txbFlight_airline.Text;
            string fromLoc = txbFlight_from.Text;
            string toLoc = txbFlight_to.Text;
            DateTime departureDate = dpFlight_departure.DisplayDate;
            DateTime arrivalDate = dpFlight_arrival.DisplayDate;
            int numberOfBags = Convert.ToInt32(txbFlight_numBags.Text);
            string preferedTime = txbFlight_time.Text;
            string flightSpecs = txbFlight_specifications.Text;


            Flight flight = new Flight(airlineName, fromLoc, toLoc, departureDate,numberOfBags,_passangers);
        }

        private void BtnFlight_addPassenger_Click(object sender, RoutedEventArgs e)
        {
            string passangerName = txbFlight_passengers.Text;
            ltbFlight_passengersOutput.Items.Add(passangerName);
            ltbFlight_passengersOutput.Items.Refresh();
            ltbFlight_passengersOutput.Items.CopyTo(_passangers.ToArray(), 0);
        }

        #endregion

        #region Accomodation Tab
        private void BtnAccommodation_done_Click(object sender, RoutedEventArgs e)
        {
            string nameOfAgency = txbAccommodation_name.Text;
            string accomodationSpecs = txbAccommodation_specifications.Text;
            string numberOfGuests = txbAccommodation_numGuests.Text;
            string numberOfRooms = txbAccommodation_numRooms.Text;
            string amountOfAccomodation = txbAccommodation_total.Text;

            DateTime checkInTime = dpAccommodation_checkIn.DisplayDate;
            DateTime checkOutTime = dpAccommodation_checkOut.DisplayDate;
            
            Accommodation accommodation = new Accommodation(nameOfAgency, checkInTime, checkOutTime, numberOfGuests,numberOfRooms, accomodationSpecs,amountOfAccomodation);

            // Todo sql insertion
            // ...
        }


        #endregion

        #region CarHire
        private void BtnCarHire_Done_Click(object sender, RoutedEventArgs e)
        {
            string agencyName = txbCarHire_agency.Text;
            string pickUpLoc = txbCarHire_pickUp.Text;
            string dropUpLoc = txbCarHire_dropOff.Text;
            DateTime pickUpDate = dpCarHire_startDay.DisplayDate;
            DateTime dropOffDate = dpCarHire_endDay.DisplayDate;
            int numberOfCars = Convert.ToInt32(txbCarHire_numCars.Text);
            string carhireSpecs = txbCarHire_specifications.Text;
            string totalAmount = txbCarHire_total.Text;



        }
        #endregion region 
    }
}
