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
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;

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
        void EventErrorMessage(string name, string specs)
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
            double eventAmount = Convert.ToDouble(txbEvents_total.Text);
            
            // Data verification:
            // make sure that the supplied data is valid
            EventErrorMessage(nameOfEvent, eventSpecs);

            // create an instnce of the event class
            Events event_selele = new Events(nameOfEvent, eventSpecs, eventAmount);

            // Reset textbox values to empty
            txbEvents_name.Text = "";
            txbEvents_specifications.Text = "";
            txbEvents_total.Text = "";

            // Todo sql insertion
            // ...
        }
        #endregion

        #region Conference tab

        /// <summary>
        /// Checks if the digits in the texbox are valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxbConference_total_TextChanged(object sender, TextChangedEventArgs e)
        {
            txbConference_total = validateAmount(txbConference_total);
        }

        /// <summary>
        /// It checks if the variables are empty
        /// </summary>
        /// <param name="name"></param>
        /// <param name="venue"></param>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="specs"></param>
        public void conferenceErrorMessage(string name, string venue, DateTime date, string time, string specs)
        {
            if (name == "" || specs == "" || time == "" || specs == "")
            {
                MessageBox.Show("Please enter valid text!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (date == null || date.ToString() == null || date.ToString() == "")
            {
                MessageBox.Show("Please select the date!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void BtnConference_done_Click(object sender, RoutedEventArgs e)
        {
            string conferenceName = txbConference_name.Text;
            string conferenceVenue = txbConference_venue.Text;
            DateTime dateOfConference = dpConference_date.DisplayDate;
            string conferenceTime = txbConference_time.Text;
            string specsOfConference = txbConference_specifications.Text;
            double amountOfconf = Convert.ToDouble(txbConference_total.Text);
           
            // Data Verification:
            // check if the variables are empty
            conferenceErrorMessage(conferenceName, conferenceVenue, dateOfConference, conferenceTime, specsOfConference);

            Conference selele_Conference = new Conference(conferenceVenue, conferenceName, dateOfConference, conferenceTime, amountOfconf, specsOfConference);

            // reset texbox values to empty
            txbConference_name.Text = "";
            txbConference_venue.Text = "";
            txbConference_time.Text = "";
            txbConference_specifications.Text = "";
            txbConference_total.Text = "";
            
            // Todo sql insertion
            // ...

        }

        #endregion

        #region Taxi cab
        /// <summary>
        /// Checks if the values entered are valid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxbCab_numCabs_TextChanged(object sender, TextChangedEventArgs e)
        {
            txbCab_numCabs = validateAmount(txbCab_numCabs);
        }

        /// <summary>
        /// Checks if the total amount has valid numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxbCab_total_TextChanged(object sender, TextChangedEventArgs e)
        {
            txbCab_total = validateAmount(txbCab_total);
        }

        /// <summary>
        /// Check if the texboxes are empty and the send an error message if they are.
        /// </summary>
        /// <param name="stringValues"></param>
        /// <param name="date"></param>
        /// <param name="numOfpass"></param>
        public void conferenceErrorMessage(List<string> stringValues, DateTime date)
        {
            for(int i =0; i <stringValues.Count; i++)
            {
                if (stringValues[i] == "")
                {
                    MessageBox.Show("Please enter valid text!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (date == null || date.ToString() == null || date.ToString() == "")
            {
                MessageBox.Show("Please select the date!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCab_done_Click(object sender, RoutedEventArgs e)
        {
            // Asign vars to texbox values
            string _agencyName = txbCab_agency.Text;
            string _driverName = txbCab_driver.Text;
            string _pickUpLocation = txbCab_pickUp.Text;
            string _dropOffLocation = txbCab_dropOff.Text;
            string _timeOfPickUp = txbCab_pickUpTime.Text;
            DateTime _dateOfPickup = dpCab_pickUpDate.DisplayDate;
            int _numberOfcabs = Convert.ToInt32(txbCab_numCabs.Text);
            string _taxicabSpecs = txbCab_specifications.Text;
            string _totalAmount = txbCab_total.Text;

            // Data verification
            List<string> conf_stringValues = new List<string>();
            conf_stringValues.Add(_agencyName);
            conf_stringValues.Add(_driverName);
            conf_stringValues.Add(_pickUpLocation);
            conf_stringValues.Add(_dropOffLocation);
            conf_stringValues.Add(_timeOfPickUp);
            conf_stringValues.Add(_taxicabSpecs);
            
            // create the instance after checking for errors
            Cab taxiCab = new Cab(_agencyName, _driverName, _pickUpLocation, _dropOffLocation, _timeOfPickUp, _dateOfPickup, _numberOfcabs, _taxicabSpecs, _totalAmount);

            // Todo sql insertion
            // ...
        }

        #endregion

        #region Flight tab

        /// <summary>
        /// Checks if the entered digits are valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxbFlight_numBags_TextChanged(object sender, TextChangedEventArgs e)
        {
            txbFlight_numBags = validateAmount(txbFlight_numBags);
        }

        /// <summary>
        /// checks if the digits provided in the total amount are valid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxbFlight_total_TextChanged(object sender, TextChangedEventArgs e)
        {
            txbFlight_total = validateAmount(txbFlight_total);
        }

        /// <summary>
        /// Checks if the data provided has valid characters
        /// </summary>
        /// <param name="stringValues"></param>
        /// <param name="departuredate"></param>
        /// <param name="arrival"></param>
        public void flightErrorMessage(List<string> stringValues, DateTime departuredate, DateTime arrival)
        {
            for (int i = 0; i < stringValues.Count; i++)
            {
                if (stringValues[i] == "")
                {
                    MessageBox.Show("Please enter valid text!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (departuredate == null || departuredate.ToString() == null || departuredate.ToString() == "")
            {
                MessageBox.Show("Please select the date!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(arrival == null || arrival.ToString() == null || arrival.ToString() == "")
            {
                MessageBox.Show("Please select the date!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        List<string> _passengers;
        private void BtnFlight_done_Click(object sender, RoutedEventArgs e)
        {
            // assign valuesfrom the texbox to the variables
            string airlineName = txbFlight_airline.Text;
            string fromLoc = txbFlight_from.Text;
            string toLoc = txbFlight_to.Text;
            DateTime departureDate = dpFlight_departure.DisplayDate;
            DateTime arrivalDate = dpFlight_arrival.DisplayDate;
            int numberOfBags = Convert.ToInt32(txbFlight_numBags.Text);
            string preferedTime = txbFlight_time.Text;
            string flightSpecs = txbFlight_specifications.Text;
            double totolAmount = Convert.ToDouble(txbFlight_total.Text);

            // Data validation
            List<string> _stringValues = new List<string>();
            _stringValues.Add(airlineName);
            _stringValues.Add(fromLoc);
            _stringValues.Add(toLoc);
            _stringValues.Add(preferedTime);
            _stringValues.Add(flightSpecs);
            flightErrorMessage(_stringValues, departureDate, arrivalDate);

            // check if the list is not empty
            if(_passengers.Count <= 0)
            {
                MessageBox.Show("Please add the names of passenger!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // creates an instance of the flight class
                Flight flight = new Flight(airlineName, fromLoc, toLoc, departureDate, numberOfBags, _passengers, totolAmount);
            }
            
            // reset the textbox values to empty
            txbFlight_airline.Text = "";
            txbFlight_from.Text = "";
            txbFlight_to.Text = "";
            txbFlight_numBags.Text = "";
            txbFlight_time.Text = "";
            txbFlight_specifications.Text = "";
        }

        private void BtnFlight_addPassenger_Click(object sender, RoutedEventArgs e)
        {
            string passangerName = txbFlight_passengers.Text;
            ltbFlight_passengersOutput.Items.Add(passangerName);
            ltbFlight_passengersOutput.Items.Refresh();

            for(int i = 0; i < ltbFlight_passengersOutput.Items.Count; i++)
            {
                _passengers[i] = ltbFlight_passengersOutput.Items[i].ToString();
            }
        }

        #endregion

        #region Accomodation tab

        /// <summary>
        /// Check if the variables are empty
        /// </summary>
        /// <param name="stringValues"></param>
        /// <param name="checkindate"></param>
        /// <param name="checkout"></param>
        public void accommodationErrorMessage(List<string> stringValues, DateTime checkindate, DateTime checkout)
        {
            for (int i = 0; i < stringValues.Count; i++)
            {
                if (stringValues[i] == "")
                {
                    MessageBox.Show("Please enter valid text!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            if (checkindate == null || checkindate.ToString() == null || checkindate.ToString() == "")
            {
                MessageBox.Show("Please select the date!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (checkout == null || checkout.ToString() == null || checkout.ToString() == "")
            {
                MessageBox.Show("Please select the date!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        /// <summary>
        /// checks if the digits entered are valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxbAccommodation_numGuests_TextChanged(object sender, TextChangedEventArgs e)
        {
            txbAccommodation_numGuests = validateAmount(txbAccommodation_numGuests);
        }

        /// <summary>
        /// checks if the digits entered are valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxbAccommodation_numRooms_TextChanged(object sender, TextChangedEventArgs e)
        {
            txbAccommodation_numRooms = validateAmount(txbAccommodation_numRooms);
        }

        /// <summary>
        /// checks if the digits entered are valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxbAccommodation_total_TextChanged(object sender, TextChangedEventArgs e)
        {
            txbAccommodation_total = validateAmount(txbAccommodation_total);
        }

        private void BtnAccommodation_done_Click(object sender, RoutedEventArgs e)
        {
            string nameOfAgency = txbAccommodation_name.Text;
            string accommodationSpecs = txbAccommodation_specifications.Text;
            DateTime checkInDate = dpAccommodation_checkIn.DisplayDate;
            DateTime checkOutDate = dpAccommodation_checkOut.DisplayDate;
            int numberOfGuests = Convert.ToInt32(txbAccommodation_numGuests.Text);
            int numberOfRooms = Convert.ToInt32(txbAccommodation_numRooms.Text);
            double totalCost = Convert.ToDouble(txbAccommodation_total.Text);

            // Validate data
            List<string> _stringValues = new List<string>();
            _stringValues.Add(nameOfAgency);
            _stringValues.Add(accommodationSpecs);
            accommodationErrorMessage(_stringValues, checkInDate, checkOutDate);

            // Instantiate the accomodation
            Accommodation accommodation = new Accommodation(nameOfAgency, checkInDate, checkOutDate, numberOfGuests, numberOfRooms, accommodationSpecs, totalCost);

            // Reset the texboxes to empty
            txbAccommodation_name.Text = "";
            txbAccommodation_specifications.Text = "";
            txbAccommodation_numGuests.Text = "";
            txbAccommodation_numRooms.Text = "";
            txbAccommodation_total.Text ="";
        }

        #endregion

        #region CarHire

        private void TxbCarHire_numCars_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnCarHire_Done_Click(object sender, RoutedEventArgs e)
        {
            // Asign variable to textbox text
            string agencyName = txbCarHire_agency.Text;
            string pickUpLocation = txbCarHire_pickUp.Text;
            string dropOffLocation = txbCarHire_dropOff.Text;
            DateTime _startday = dpCarHire_startDay.DisplayDate;
            DateTime _endDay = dpCarHire_endDay.DisplayDate;
            int numberOfCars = Convert.ToInt32(txbCarHire_numCars.Text);
            string carHireSpecs = txbCarHire_specifications.Text;

            //Data Validation
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            //Start Word and create a new document.
            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);

            //Insert a paragraph at the beginning of the document.
            Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            oPara1.Range.Text = "Heading 1";
            oPara1.Range.Font.Bold = 1;
            oPara1.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
            oPara1.Range.InsertParagraphAfter();

            //Insert a paragraph at the end of the document.
            Word.Paragraph oPara2;
            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara2.Range.Text = "Heading 2";
            oPara2.Format.SpaceAfter = 6;
            oPara2.Range.InsertParagraphAfter();

            //Insert another paragraph.
            Word.Paragraph oPara3;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara3.Range.Text = "This is a sentence of normal text. Now here is a table:";
            oPara3.Range.Font.Bold = 0;
            oPara3.Format.SpaceAfter = 24;
            oPara3.Range.InsertParagraphAfter();

            //Insert a 3 x 5 table, fill it with data, and make the first row
            //bold and italic.
            Word.Table oTable;
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, 3, 5, ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 6;
            int r, c;
            string strText;
            for (r = 1; r <= 3; r++)
                for (c = 1; c <= 5; c++)
                {
                    strText = "r" + r + "c" + c;
                    oTable.Cell(r, c).Range.Text = strText;
                }
            oTable.Rows[1].Range.Font.Bold = 1;
            oTable.Rows[1].Range.Font.Italic = 1;

            //Add some text after the table.
            Word.Paragraph oPara4;
            oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara4 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara4.Range.InsertParagraphBefore();
            oPara4.Range.Text = "And here's another table:";
            oPara4.Format.SpaceAfter = 24;
            oPara4.Range.InsertParagraphAfter();

            //Insert a 5 x 2 table, fill it with data, and change the column widths.
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oTable = oDoc.Tables.Add(wrdRng, 5, 2, ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 6;
            for (r = 1; r <= 5; r++)
                for (c = 1; c <= 2; c++)
                {
                    strText = "r" + r + "c" + c;
                    oTable.Cell(r, c).Range.Text = strText;
                }
            oTable.Columns[1].Width = oWord.InchesToPoints(2); //Change width of columns 1 & 2
            oTable.Columns[2].Width = oWord.InchesToPoints(3);

            //Keep inserting text. When you get to 7 inches from top of the
            //document, insert a hard page break.
            object oPos;
            double dPos = oWord.InchesToPoints(7);
            oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range.InsertParagraphAfter();
            do
            {
                wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                wrdRng.ParagraphFormat.SpaceAfter = 6;
                wrdRng.InsertAfter("A line of text");
                wrdRng.InsertParagraphAfter();
                oPos = wrdRng.get_Information
                                       (Word.WdInformation.wdVerticalPositionRelativeToPage);
            }
            while (dPos >= Convert.ToDouble(oPos));
            object oCollapseEnd = Word.WdCollapseDirection.wdCollapseEnd;
            object oPageBreak = Word.WdBreakType.wdPageBreak;
            wrdRng.Collapse(ref oCollapseEnd);
            wrdRng.InsertBreak(ref oPageBreak);
            wrdRng.Collapse(ref oCollapseEnd);
            wrdRng.InsertAfter("We're now on page 2. Here's my chart:");
            wrdRng.InsertParagraphAfter();

            //Insert a chart.
            Word.InlineShape oShape;
            object oClassType = "MSGraph.Chart.8";
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oShape = wrdRng.InlineShapes.AddOLEObject(ref oClassType, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing,
            ref oMissing, ref oMissing, ref oMissing);

            //Demonstrate use of late bound oChart and oChartApp objects to
            //manipulate the chart object with MSGraph.
            object oChart;
            object oChartApp;
            oChart = oShape.OLEFormat.Object;
            oChartApp = oChart.GetType().InvokeMember("Application",
            BindingFlags.GetProperty, null, oChart, null);

            //Change the chart type to Line.
            object[] Parameters = new Object[1];
            Parameters[0] = 4; //xlLine = 4
            oChart.GetType().InvokeMember("ChartType", BindingFlags.SetProperty,
            null, oChart, Parameters);

            //Update the chart image and quit MSGraph.
            oChartApp.GetType().InvokeMember("Update",
            BindingFlags.InvokeMethod, null, oChartApp, null);
            oChartApp.GetType().InvokeMember("Quit",
            BindingFlags.InvokeMethod, null, oChartApp, null);
            //... If desired, you can proceed from here using the Microsoft Graph 
            //Object model on the oChart and oChartApp objects to make additional
            //changes to the chart.

            //Set the width of the chart.
            oShape.Width = oWord.InchesToPoints(6.25f);
            oShape.Height = oWord.InchesToPoints(3.57f);

            //Add text after the chart.
            wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            wrdRng.InsertParagraphAfter();
            wrdRng.InsertAfter("THE END.");

            //Close this form.
            this.Close();
        }

       

       
    }
}

