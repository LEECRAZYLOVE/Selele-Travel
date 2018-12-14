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
using System.Timers;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Manager_Home.xaml
    /// </summary>
    public partial class Manager_Home : Window
    {
        Timer timer = new Timer(1000);

        public Manager_Home()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            timer.Elapsed += Timer_Elapsed;
        }

        #region Refresh the list

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

        }

        #endregion

        
        #region Quote Summary tab

        #endregion

        #region Compose Message tab
        /// <summary>
        /// Returns true if the was an error
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool checkForError(string name)
        {
            if(name.Trim() == "")
            {
                MessageBox.Show("You cannot send an empty message!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            return false;
        }
        /*this is the reject quote's quote no.
         *I made this global because I want to access the current quote from the 'BtnQuoteSummary_verifyReject_Click' click event,
         *and add the quote number as a suufix to it, and send that to the consultant
         */
        string rejectedQuoteNo;
        private void BtnMessage_send_Click(object sender, RoutedEventArgs e)
        {
            // Type out the consultant id
            // Assign the id to the variable

            // search for the consultant id from the database
            string consultantId = txbMessage_name.Text;

            // Type out the message to be sent to the client
            // Assign the message typed to the variable
            string message = txbMessage_message.Text;

            // check if the message is empty and throw an error if it's empty and then get out of the method
            if (checkForError(message)) return;
            //if there is a rejected quote, we would like to send the information of the quote to the consultant
            if (!string.IsNullOrEmpty(rejectedQuoteNo))
                message = $"{message}\n{rejectedQuoteNo}";

            // update the message list for the consultant id
            //


            //At the end we want to make sure to reset the rejectedQuote number to empty again
            rejectedQuoteNo = "";
        }

        #endregion

        #region Verified Quotes tab

        #endregion

        #region Authorizations tab
        
        private void BtnQuoteSummary_verifyReject_Click(object sender, RoutedEventArgs e)
        {
            // Refresh the list boxes for verified and incoming quotes
            ltbQuoteSummary_incomingQuotes.Items.Refresh();
            listbxVerifiedQuotes.Items.Refresh();

            
            //Grab the information of the client and send it to the 'compose message' name textbox
            txbMessage_name.Text = txblockQuoteSummary_consultantID.Text;
            //view the 'compose message' tab
            Manager_tabControl.SelectedIndex = 1;
            //Grab the information of the quote we just rejected
            quote currentQuote = ltbQuoteSummary_incomingQuotes.SelectedItems[0] as quote;
            rejectedQuoteNo = $"Quote no. : {currentQuote.quote_no}";

        }
        private void BtnQuoteSummary_verifyAccept_Click(object sender, RoutedEventArgs e)
        {
            // Refresh the list boxes for verified and incoming quotes
            ltbQuoteSummary_incomingQuotes.Items.Refresh();
            listbxVerifiedQuotes.Items.Refresh();


        }
        private void BtnAuthorizations_Authorize_Click(object sender, RoutedEventArgs e)
        {
            // hash the password and the sign in to the database
            string newFreshNew = pdbAuthorizations_password.Password;
            
        }

        #endregion

        #region Search tab
        //private List<string> stringEquivalent(List<object> list)
        //{
        //    List<string> result = new List<string>();

        //    foreach (var a in list)
        //    {
        //        if (a is quote q)
        //        {
        //            result.Add(q.ToString());
        //        }
        //        else if (a is )
                    
        //    }

        //    return result;
        //}
        private void BtnManager_search_Click(object sender, RoutedEventArgs e)
        {
            //Make sure that the search results are clear
            txbManager_Search_results.Items.Clear();
            string searchString = txbManager_search.Text;
            List<object> results = new List<object>();
            //for all checkboxes, if a checkbox is checked, then we would like to search in the appropriate table as well
            //And add the results to the 
            if((bool)ckbManager_Search_quotes.IsChecked)
            {
                //search in the quote table

                //if we find something, add to results
            }
            if ((bool)ckbManager_Search_orders.IsChecked)
            {
                //search in the orders table

                //if we find something, add to results
            }
            if ((bool)ckbManager_Search_vouchers.IsChecked)
            {
                //search in the vouchers table

                //if we find something, add to results
            }
            if ((bool)ckbManager_Search_invoices.IsChecked)
            {
                //search in the invoices table

                //if we find something, add to results
            }
            //if we found nothing
            if (results.Count <= 0)
            {
                string nothingFoundMessage = "No items match the search term";
                txbManager_Search_results.Items.Add(nothingFoundMessage);
            }
            else
            {
                txbManager_Search_results.ItemsSource = results;
                txbManager_Search_results.Items.Refresh();
            }
        }

        #endregion

        private void BtnManager_logOut_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.logOut(this);
        }

        private void Manager_Home1_Closed(object sender, EventArgs e)
        {
            GeneralMethods.closeAllWindows();
        }
    }
}
