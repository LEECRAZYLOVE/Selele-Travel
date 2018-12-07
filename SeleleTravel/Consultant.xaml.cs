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

        #region General Methods

        /// <summary>
        /// It validates the amount and removes any in valid characters
        /// </summary>
        /// <param name="totalAmount"></param>
        /// <returns></returns>
        TextBox validateAmount(TextBox totalAmount)
        {
            string myabc = "0123456789";
            char currentChar = totalAmount.Text[totalAmount.Text.Length - 1];
            if (myabc.IndexOf(currentChar) < 0) totalAmount.Text.Replace(currentChar, ' ');
            totalAmount.Text.Trim();
            return totalAmount;
        }



        #endregion
        
        #region Event tab
        // This removes invalid text from the amount textbox for event tab.
        private void TxbEvents_total_TextChanged(object sender, TextChangedEventArgs e)
        {
            txbEvents_total = validateAmount(txbEvents_total);
        }

        // displays an error message when the textboxes are empty
        void EventErrorMessage(string name, string specs, string amount)
        {
            if (name == "" || specs == "")
            {
                MessageBox.Show("Please enter valid text!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void _done(object sender, RoutedEventArgs e)
        {
            // assign vars to the textboxes
            string nameOfEvent = txbEvents_name.Text;
            string eventSpecs = txbEvents_specifications.Text;
            string eventAmount = txbEvents_total.Text;
            Events event_selele = new Events(nameOfEvent, eventSpecs, eventAmount);

            // Data verification:
            // make sure that the supplied data is valid
            EventErrorMessage(nameOfEvent, eventSpecs, eventAmount);

            // Reset textbox values to empty
            txbEvents_name.Text = "";
            txbEvents_specifications.Text = "";
            txbEvents_total.Text = "";

            // Todo sql insertion
            // ...
        }
        #endregion

        #region Conference tab

        public void ConferenceErrorMessage(string name, string venue, DateTime date, string time, string specs, string amount)
        {
            if (name == "" || specs == "")
            {
                MessageBox.Show("Please enter valid text!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnConference_done_Click(object sender, RoutedEventArgs e)
        {
            // Assign values from the textboxes to the variables
            string conferenceName = txbConference_name.Text;
            string conferenceVenue = txbConference_venue.Text;
            DateTime dateOfConference = dpConference_date.DisplayDate;
            string conferenceTime = txbConference_time.Text;
            string specsOfConference = txbConference_specifications.Text;
            string amountOfconf = txbConference_total.Text;
            Conference selele_Conference = new Conference(conferenceVenue, conferenceName, dateOfConference, conferenceTime, amountOfconf, specsOfConference);
            
            // Data Verification:
            // check if the variables are empty
            
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
        public List<string> _passengers;
        private void BtnFlight_done_Click(object sender, RoutedEventArgs e)
        {
            string airlineName = txbFlight_airline.Text;
            string fromLoc = txbFlight_from.Text;
            string toLoc = txbFlight_to.Text;
            DateTime departureDate = dpFlight_departure.DisplayDate;
            DateTime arrivalDate = dpFlight_arrival.DisplayDate;
            string numberOfBags = txbFlight_numBags.Text;
            string preferedTime = txbFlight_time.Text;
            string flightSpecs = txbFlight_specifications.Text;
           
            Flight flight = new Flight(airlineName, fromLoc, toLoc, departureDate, Convert.ToInt32(numberOfBags), _passengers);
        }

        private void BtnFlight_addPassenger_Click(object sender, RoutedEventArgs e)
        {
            string passangerName = txbFlight_passengers.Text;
            ltbFlight_passengersOutput.Items.Add(passangerName);
            ltbFlight_passengersOutput.Items.Refresh();
            ltbFlight_passengersOutput.Items.CopyTo(_passengers.ToArray(), 0);
        }


        #endregion
        
    }
}
