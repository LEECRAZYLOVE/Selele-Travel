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
using System.IO;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Consultant.xaml
    /// </summary>
    public partial class ConsultantQuotesWindow : Window
    {
        public ConsultantQuotesWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public List<DateTime> servicesDates = new List<DateTime>();

        #region Client tab

        #region New Client

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

        /// <summary>
        /// checks if the email has valid number of '@' character.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        TextBox checkEmail(TextBox email)
        {
            try
            {
                char specialChar = '@';
                int countNumSpecialChar = 0;
                foreach (char x in email.Text)
                {
                    if (x == specialChar) countNumSpecialChar++;
                }
                if (countNumSpecialChar > 1 || countNumSpecialChar == 0) throw new Exception("Make sure the email has valid characters");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return email;
        }

        //Status : Incomplete
        private void createNewClient_Click(object sender, RoutedEventArgs e)
        {
            string names = txbNewClient_name.Text + " " + txbNewClient_surname.Text;
            //Retrieving clientType
            //clienttype clientType = (bool)(ckbBusiness.IsChecked) ? clienttype.Business : clienttype.Individual;

            //Get contact details
            string Cellphone = txbNewClient_cellphone.Text;
            string Fax = txbNewClient_fax.Text;

            // email verification 
            txbNewClient_email = checkEmail(txbNewClient_email);
            string email = txbNewClient_email.Text;

            string Telephone = txbNewClient_telephone.Text;

            ContactDetails contactDetails = new ContactDetails(Cellphone, email, Telephone, Fax);

            //Get location details
            string address = txbNewClient_address.Text;
            string city = txbNewClient_city.Text;
            string areaCode = txbNewClient_areaCode.Text;
            string province = DropBxNewClient_province.SelectionBoxItem.ToString();
            //use this in initialisation of client
            string _location = address + '\n' + city + '\n' + areaCode + '\n' + province;

            //Initialize Client  and DBConnect instance
            //var context = new SeleleEntities();
            var currentClient = new client()
            {
                client_no = "J0001", //This will be automatically generated. I'm using a dummy to test queries.
                quote_no = "0001",
                clientname = names,
                cellphone = Cellphone,
                address = _location,
                emailaddress = email,
                telephone = Telephone,
                fax = Fax,
            };

            //Add client to database
            //try
            //{
            //    context.clients.Add(currentClient);
            //    context.SaveChanges();
            //    MessageBox.Show($"Succesfully added into the database. The new Accommodation ID is: {currentClient.client_no}");
            //}
            //catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            //{
            //    var errorMessage = ex.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
            //    var propertyName = ex.EntityValidationErrors.First().ValidationErrors.First().PropertyName;
            //}
            //catch (Exception ex)
            //{
            //    //other error
            //   // throw ex;
              
            //}
        }

        #endregion

        #region Already a Client Display

        private void BtnOldClient_find_Click(object sender, RoutedEventArgs e)
        {
            // Assign the value to be searched to the variable
            string findName = txbOldClient_find.Text;

            // Results from the database
            //txblOldClient_Details.Text = "";
        }
        
        private void BtnOldClient_select_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion
        
        #endregion

        #region General Methods/Events
        /// <summary>
        /// Checks if number provided is a valid amount
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AmountChanged(object sender, TextChangedEventArgs e)
        {
            bool intOrDouble = false;
        }

        /// <summary>
        /// Checks if the number provided is a valid whole nummber
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AmountChanged_WHOLENumber(object sender, TextChangedEventArgs e)
        {
            bool intOrDble = true;
        }

        /// <summary>
        /// Checks if the number provided is a valid phone/fax/telephone number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void phoneNumberCheck(object sender, TextChangedEventArgs e)
        {
            
        }

        #endregion

        #region Event tab
        
        private void _done(object sender, RoutedEventArgs e)
        {
            // assign vars to the textboxes
            string nameOfEvent = txbEvents_name.Text;
            string eventSpecs = txbEvents_specifications.Text;
            double eventAmount = Convert.ToDouble(txbEvents_total.Text);
            DateTime eventStartdate = dpEvents_startDate.DisplayDate;
            DateTime eventEnddate = dpEvents_endDate.DisplayDate;

            // Data verification:
            // make sure that the supplied data is valid
            List<string> stringVs = new List<string> { nameOfEvent, eventSpecs};
            
            // This returns a bool value,
            // if it returns true then one of the strings are empty
            // if it returns flse then there are no empty strings then the program will continue to execute the following commands.
            bool boolValue = GeneralMethods.checkEmptytxtBox(stringVs);

            // check if the dates are empty
            List<DateTime> tempDateTime = new List<DateTime> { eventStartdate, eventEnddate };
            bool dateBoolValue = GeneralMethods.checkDateTimeBox(tempDateTime);
            
            if (!boolValue && !dateBoolValue)
            {

                // Add the date to the global list of dates that will be stored
                servicesDates.Add(eventStartdate);
                servicesDates.Add(eventEnddate);

                //create an instnce of the event class and dbconnect
                //var context = new SeleleEntities();
                var currentEvent = new @event()//(nameOfEvent, eventSpecs, eventAmount);
                {
                    eventname = nameOfEvent,
                    eventspecs=  eventSpecs,
                    amount = eventAmount,
                    quote_no = "1234",
                    //order_no = "5678"
                };

                //sql insertion
                //try
                //{
                //    context.events.Add(currentEvent);
                //    context.SaveChanges();
                //}
                //catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                //{
                //    var errorMessage = ex.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
                //    var propertyName = ex.EntityValidationErrors.First().ValidationErrors.First().PropertyName;
                //}
                //catch (Exception ex)
                //{
                //    other error
                //    throw ex;
                //}

                // reset texbox values to empty
                // call the clear textbox method
                List<TextBox> textBoxes = new List<TextBox> { txbEvents_name, txbEvents_specifications, txbEvents_total };
                GeneralMethods.clearTextBoxes(textBoxes);

            }


        }

        #endregion

        #region Conference tab

        private void BtnConference_done_Click(object sender, RoutedEventArgs e)
        {
            string conferenceName = txbConference_name.Text;
            string conferenceVenue = txbConference_venue.Text;
            DateTime dateOfConference = dpConference_startDate.DisplayDate;
            DateTime endDateofConference = dpConference_endDate.DisplayDate;
            string conferenceTime = txbConference_time.Text;
            string specsOfConference = txbConference_specifications.Text;
            double amountOfconf = Convert.ToDouble(txbConference_total.Text);

            // Data Verification:
            // check if the variables are empty
            List<DateTime> dateTimes = new List<DateTime> { dateOfConference, endDateofConference};
            List<string> stringVs = new List<string> { conferenceName, conferenceVenue, conferenceTime, specsOfConference};
            
            // This returns a bool value,
            // if it returns true then one of the strings are empty
            // if it returns flse then there are no empty strings then the program will continue to execute the following commands.
            bool checkEmptyStrngBool = GeneralMethods.checkEmptytxtBox(stringVs);
            bool checkDatesBool = GeneralMethods.checkDateTimeBox(dateTimes);

            if(!checkEmptyStrngBool && !checkDatesBool)
            {
                // Add the date to the global list of dates that will be stored
                servicesDates.Add(dateOfConference);
                servicesDates.Add(endDateofConference);

                // todo...
                // conference selele_Conference = new conference(conferenceVenue, conferenceName, dateOfConference, conferenceTime, amountOfconf, specsOfConference);

                // Todo sql insertion
                // ...

                // reset texbox values to empty
                // call the clear textbox method
                List<TextBox> textBoxes = new List<TextBox> { txbConference_name, txbConference_venue, txbConference_time, txbConference_specifications, txbConference_total };
                GeneralMethods.clearTextBoxes(textBoxes);
                
            }
        }

        #endregion

        #region Taxi cab
        
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
            double _totalAmount = Convert.ToDouble(txbCab_total.Text);

            // Data verification
            List<DateTime> dateTimes = new List<DateTime>();
            List<string> stringVs = new List<string>();

            stringVs.Add(_agencyName);
            stringVs.Add(_driverName);
            stringVs.Add(_pickUpLocation);
            stringVs.Add(_dropOffLocation);
            stringVs.Add(_timeOfPickUp);
            stringVs.Add(_taxicabSpecs);

            dateTimes.Add(_dateOfPickup);

            // This returns a bool value,
            // if it returns true then one of the strings are empty
            // if it returns flse then there are no empty strings then the program will continue to execute the following commands.
            bool boolValue = GeneralMethods.checkEmptytxtBox(stringVs);
            bool valueOfBool = GeneralMethods.checkDateTimeBox(dateTimes);

            if(!boolValue && !valueOfBool)
            {
                // todo
                // create the instance after checking for errors
               // var taxiCab = new cabservice(_agencyName, _driverName, _pickUpLocation, _dropOffLocation, _timeOfPickUp, _dateOfPickup, _numberOfcabs, _taxicabSpecs, _totalAmount);

                // Todo sql insertion
                // ...

                // reset the textbox values to empty
                // call the clear textbox method
                List<TextBox> textBoxes = new List<TextBox>();
                textBoxes.Add(txbCab_agency);
                textBoxes.Add(txbCab_driver);
                textBoxes.Add(txbCab_pickUp);
                textBoxes.Add(txbCab_dropOff);
                textBoxes.Add(txbCab_pickUpTime);
                textBoxes.Add(txbCab_numCabs);
                textBoxes.Add(txbCab_specifications);
                textBoxes.Add(txbCab_total);
                GeneralMethods.clearTextBoxes(textBoxes);
            }



        }

        #endregion

        #region Flight tab

        private List<string> _passengers = new List<string>();
        private void BtnFlight_done_Click(object sender, RoutedEventArgs e)
        {
            // assign valuesfrom the texbox to the variables
            string airlineName = txbFlight_airline.Text;
            string fromLoc = txbFlight_from.Text;
            string toLoc = txbFlight_to.Text;
            DateTime departureDate = dpFlight_departure.DisplayDate;
            int numberOfBags = Convert.ToInt32(txbFlight_numBags.Text);
            string preferedTime = txbFlight_time.Text;
            string flightSpecs = txbFlight_specifications.Text;
            double totolAmount = Convert.ToDouble(txbFlight_total.Text);

            // Data validation
            // and Error checking
            List<DateTime> dateTimes = new List<DateTime>();
            List<string> stringVs = new List<string>();

            stringVs.Add(airlineName);
            stringVs.Add(fromLoc);
            stringVs.Add(toLoc);
            stringVs.Add(preferedTime);
            stringVs.Add(flightSpecs);

            dateTimes.Add(departureDate);

            // This returns a bool value,
            // if it returns true then one of the strings are empty
            // if it returns flse then there are no empty strings then the program will continue to execute the following commands.
            bool boolValue = GeneralMethods.checkEmptytxtBox(stringVs);
            bool valueOfBool = GeneralMethods.checkDateTimeBox(dateTimes);
            
            if(!boolValue && !valueOfBool)
            {
                // todo ...

                // check if the list is not empty
                if (_passengers.Count <= 0)
                {
                    MessageBox.Show("Please add the names of passenger!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    // creates an instance of the flight class
                    //var Flight = new flight(airlineName, fromLoc, toLoc, departureDate, arrivalDate, numberOfBags, _passengers.Count(), _passengers, totolAmount);
                    //{

                    //};
                }

                // reset the textbox values to empty
                // call the clear textbox method
                List<TextBox> textBoxes = new List<TextBox>();
                textBoxes.Add(txbAccommodation_name);
                textBoxes.Add(txbAccommodation_specifications);
                textBoxes.Add(txbAccommodation_numGuests);
                textBoxes.Add(txbAccommodation_numRooms);
                textBoxes.Add(txbAccommodation_total);
                GeneralMethods.clearTextBoxes(textBoxes);

                // clear the passangers
                _passengers = new List<string>();
            }

            

            
        }

        private void BtnFlight_addPassenger_Click(object sender, RoutedEventArgs e)
        {
            string passengerName = txbFlight_passangerName.Text;
            ltbFlight_passengersOutput.Items.Add(passengerName);
            ltbFlight_passengersOutput.Items.Refresh();

            for (int i = 0; i < ltbFlight_passengersOutput.Items.Count; i++)
            {
                _passengers[i] = ltbFlight_passengersOutput.Items[i].ToString();
            }
        }

        #endregion

        #region Accomodation tab

        private void BtnAccommodation_done_Click(object sender, RoutedEventArgs e)
        {
            string nameOfAgency = txbAccommodation_name.Text;
            string accommodationSpecs = txbAccommodation_specifications.Text;
            DateTime checkInDate = dpAccommodation_checkIn.DisplayDate;
            DateTime checkOutDate = dpAccommodation_checkOut.DisplayDate;
            int numberOfGuests = Convert.ToInt32(txbAccommodation_numGuests.Text);
            int numberOfRooms = Convert.ToInt32(txbAccommodation_numRooms.Text);
            double totalCost = Convert.ToDouble(txbAccommodation_total.Text);

            // Data validation
            // Error checking
            List<DateTime> dateTimes = new List<DateTime>(2) { checkInDate, checkOutDate };
            List<string> stringVs = new List<string> { nameOfAgency, accommodationSpecs};
            
            // This returns a bool value,
            // if it returns true then one of the strings are empty
            // if it returns flse then there are no empty strings then the program will continue to execute the following commands.
            bool checkEmptyStringBool = GeneralMethods.checkEmptytxtBox(stringVs);
            bool checkValidDateBool = GeneralMethods.checkDateTimeBox(dateTimes);

            if(!checkEmptyStringBool && !checkValidDateBool)
            {
                // Add the date to the global list of dates that will be stored
                servicesDates.Add(checkInDate);
                servicesDates.Add(checkOutDate);

                // ... todo

                // Instantiate the accomodation
                //var currentAccommodation = new accommodation(nameOfAgency, checkInDate, checkOutDate, numberOfGuests, numberOfRooms, accommodationSpecs, totalCost);
                //{
                //    acc
                //};

                // Reset the texboxes to empty
                // call the clear textbox method
                List<TextBox> textBoxes = new List<TextBox> { txbAccommodation_name, txbAccommodation_specifications, txbAccommodation_numGuests, txbAccommodation_numRooms, txbAccommodation_total };
                GeneralMethods.clearTextBoxes(textBoxes);
            }



        }

        #endregion

        #region CarHire

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

            // Data Validation
            // Check for errors
            List<DateTime> dateTimes = new List<DateTime> (2) { _startday, _endDay};
            List<string> stringVs = new List<string> { agencyName, pickUpLocation, dropOffLocation, carHireSpecs};
            
            // This returns a bool value,
            // if it returns true then one of the strings are empty
            // if it returns flse then there are no empty strings then the program will continue to execute the following commands.
            bool checkEmptyStringBool = GeneralMethods.checkEmptytxtBox(stringVs);
            bool checkNullorEmptyDates = GeneralMethods.checkDateTimeBox(dateTimes);

            // check if the bool statements above are false
            // if they are, continue
            // else stop the program
            if(!checkEmptyStringBool && !checkNullorEmptyDates)
            {
                // Add the date to the global list of dates that will be stored
                servicesDates.Add(_startday);
                servicesDates.Add(_endDay);

                // Create an instance of carhire
                //var _carHire = new carhire(agencyName, pickUpLocation, dropOffLocation, _startday, _endDay);
                //{

                //};

                // Reset the textboxes
                // call the clear textbox method
                List<TextBox> toBeCleared = new List<TextBox> { txbCarHire_agency, txbCarHire_pickUp, txbCarHire_dropOff, txbCarHire_numCars, txbCarHire_specifications };
                GeneralMethods.clearTextBoxes(toBeCleared);
            }
            
        }

        #endregion

        #region Search tab

        private void btnConsultant_search_Click(object sender, RoutedEventArgs e)
        {
            // Assign value to the variable
           // string searchValue = txbConsultant_search.Text;

            // Filters used

        }

        #endregion

        #region Quote Summary tab

        string quoteNum = "";

        // add the mark percentage to the total amount of the quote
        private void BtnQuote_markUp_Click(object sender, RoutedEventArgs e)
        {

        }

        // send verification to the manager
        private void BtnQuote_requestVerification_Click(object sender, RoutedEventArgs e)
        {
            // NB: SET UP LOCAL SERVER TO ALLOW COMM IN THE NETWORK
            // send verification

            // check the first and last day of the quote
            List<DateTime> firstANDlastDay =  GeneralMethods.checkFirst_lastDay(servicesDates);

            // save the quote details to the csv file
            // the format is: quote number, order Number, start date, end date
            quoteNum = GeneralMethods.makeQuote_no();
            string tempOrderNum = "To Be Added";
            GeneralMethods.saveDataToCSVfile(quoteNum, tempOrderNum, firstANDlastDay);
        }

        // 
        // Opening a word document from the program
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // check quote number if it's valid
            bool checkQ_number = GeneralMethods.checkQuoteNotEmpty(quoteNum);
            if (checkQ_number)
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
        
        #endregion
        
        private void BtnConsultant_logOut_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.logOut(this);

        }

        private void TxbNewClient_name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
    }
}

