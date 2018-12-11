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
            string clientAddress = txbNewClient_address.Text;
            string city = txbNewClient_city.Text;
            string areaCode = txbNewClient_areaCode.Text;
            //string province = txbNewClient_province.Text;
            //use this in initialisation of client
            string _location = clientAddress + '\n' + city + '\n' + areaCode;// + '\n' + province;
            //Initialize Client instance
            Client client = new Client(names, clientType, contactDetails)
            {
                location = _location
            };


            //Add client to database
            /*   var context = new ClientEntities();//from Client class created by DB first
               var post = new Post()//from Client class created  by DB first
               {
                   client_no = client.clientID;
               clientName = names;
               phoneNumber = telephone;
               Address = clientaddress;
               emailAddress = email;
               }
           */
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
            string nameOfEvent = txbEvents_name.Text;
            string eventSpecs = txbEvents_specifications.Text;
            string eventAmount = txbEvents_total.Text;
           // Events event_selele = new Events(nameOfEvent, eventSpecs, Convert.ToDouble(eventAmount));

            // Todo sql insertion

            var context = new SeleleEntities2();//from Client class created by DB first
            var currentEvent = new @event()//from Client class created  by DB first
            {
                event_id = "1234",
                eventname = "Litha's 21st Birthday",
                eventspecifications = "MSC Cruise to Hawaii.",
                eventcost = "250"
            };


            try
            {
                //context.events.Remove();
               // context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                var errorMessage = ex.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
                var propertyName = ex.EntityValidationErrors.First().ValidationErrors.First().PropertyName;
            }
            catch (Exception ex)
            {
                //other error
                throw ex;
            }

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
            Conference selele_Conference = new Conference(conferenceVenue, conferenceName, dateOfConference, conferenceTime, Convert.ToDouble(amountOfconf), specsOfConference);
            
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

            Cab taxiCab = new Cab(_agencyName,_driverName,_pickUpLocation,_dropOffLocation,_timeOfPickUp,_dateOfPickup,Convert.ToInt32(_numberOfPassengers),_taxicabSpecs,Convert.ToDouble(_totalAmount));
            
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
            double flightTotal = Convert.ToDouble(txbFlight_total.Text);
           
            Flight flight = new Flight(airlineName, fromLoc, toLoc, departureDate, Convert.ToInt32(numberOfBags), _passengers, flightTotal);
        }

        private void BtnFlight_addPassenger_Click(object sender, RoutedEventArgs e)
        {
            string passangerName = txbFlight_passengers.Text;
            ltbFlight_passengersOutput.Items.Add(passangerName);
            ltbFlight_passengersOutput.Items.Refresh();
            ltbFlight_passengersOutput.Items.CopyTo(_passengers.ToArray(), 0);
        }

        #endregion

        private void BtnAccommodation_done_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCarHire_Done_Click(object sender, RoutedEventArgs e)
        {

        }

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
