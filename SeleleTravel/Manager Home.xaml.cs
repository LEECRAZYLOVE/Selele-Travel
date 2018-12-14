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

            timer.Elapsed += Timer_Elapsed;
        }

        #region Refresh the list

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Refresh the list boxes for verified and incoming quotes!
            ltbQuoteSummary_incomingQuotes.Items.Refresh();
            listbxVerifiedQuotes.Items.Refresh();
            ltbAuthorizations_incomingAuthorizations.Items.Refresh();
        }

        #endregion

        #region Quote Summary tab

        #endregion

        #region Compose Message tab

        void errorMessage(string name)
        {
            if(name == "")
            {
                MessageBox.Show("You cannot send an empty message!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnMessage_send_Click(object sender, RoutedEventArgs e)
        {
            // Type out the consultant id
            // Assign the id to the variable

            // search for the consultant id from the database
            string consultantId = txbMessage_name.Text;

            // Type out the message to be sent to the client
            // Assign the message typed to the variable
            string message = txbMessage_message.Text;

            // check if the message is empty and throw an error if it's empty
            errorMessage(message);

            // update the message list for the consultant id
            //
            
        }

        #endregion

        #region Verified Quotes tab

        #endregion

        #region Authorizations tab

        private void BtnQuoteSummary_send_Click(object sender, RoutedEventArgs e)
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

        #endregion

    }
}
