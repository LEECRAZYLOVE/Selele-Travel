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
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Threading;
using Npgsql;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Manager_Home.xaml
    /// </summary>
    public partial class Manager_Home : Window
    {
        public string currentStaffID = "";
        Timer timer = new Timer(1000);
        Manager_Authorizations_Window managerAuthorizations;
        Manager_Confirmations_Window managerConfirmations;
        Manager_Payments_Window managerPayments;
        Manager_Quotes_Window managerQuotes;
        ComposeMessageWindow composeMessageWindow;
        // time to update
        DispatcherTimer theLoadingTime;

        public Manager_Home()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // time to help load the program fully
            theLoadingTime = new DispatcherTimer();
            theLoadingTime.Interval = TimeSpan.FromSeconds(5);
            theLoadingTime.IsEnabled = true;
            theLoadingTime.Tick += TheLoadingTime_Tick;
        }

        /// <summary>
        /// Read all messages from the table
        /// </summary>
        /// <param name="idOfUser"> Name of the table to read from </param>
        public void readAll(string idOfUser)
        {
            using (var conn = new NpgsqlConnection(MainWindow.ChatConnectionString))
            {
                // open the connection
                conn.Open();

                // Retrieve all rows
                using (var cmd = new NpgsqlCommand($"SELECT * FROM {idOfUser}", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TextBlock theTextBlock = new TextBlock()
                        {
                            Text = Convert.ToString(reader.GetValue(2)),
                            Tag = Convert.ToString(reader.GetValue(0)),
                            TextAlignment = TextAlignment.Center,
                            FontSize = 16,
                            Focusable = false,
                            IsEnabled = false,
                            Margin = new Thickness(2, 2, 2, 2)
                        };

                        lbManager_inboxList.Items.Add(theTextBlock);
                    }
                    lbManager_inboxList.Items.Refresh();
                }
            }
        }

        /// <summary>
        /// check for updates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TheLoadingTime_Tick(object sender, EventArgs e)
        {
            // get the latest messages 
         //   readSome(currentStaffID);
        }

        /// <summary>
        /// Read all messages from the table
        /// </summary>
        /// <param name="idOfUser"> Name of the table to read from </param>
        /// <param name="last_ID"> ID of the last item </param>
        public void readSome(string idOfUser)
        {
            using (var conn = new NpgsqlConnection(MainWindow.ChatConnectionString))
            {
                // open the connection
                conn.Open();

                // Last num in the list of the messages
                int lastNum = lbManager_inboxList.Items.Count;

                // Retrieve all rows
                using (var cmd = new NpgsqlCommand($"SELECT * FROM {idOfUser} WHERE tb_ID > {lastNum}", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TextBlock theTextBlock = new TextBlock()
                        {
                            Text = Convert.ToString(reader.GetValue(2)),
                            Tag = Convert.ToString(reader.GetValue(0)),
                            TextAlignment = TextAlignment.Center,
                            FontSize = 25,
                            Focusable = false,
                            IsEnabled = false,
                            Margin = new Thickness(2, 2, 2, 2)
                        };

                        lbManager_inboxList.Items.Insert(0, theTextBlock);
                    }
                    lbManager_inboxList.Items.Refresh();
                }

            }
        }

        /// <summary>
        /// Read message from the table
        /// </summary>
        /// <param name="idOfUser">Id of sender </param>
        public void readSelectedID(string idOfUser, int itemIndex)
        {
            using (var conn = new NpgsqlConnection(MainWindow.ChatConnectionString))
            {
                // open the connection
                conn.Open();

                // Last num in the list of the messages
                int lastNum = lbManager_inboxList.Items.Count;

                // Retrieve the specific message with the given id rows 
                using (var cmd = new NpgsqlCommand($"SELECT message FROM {idOfUser} WHERE tb_ID = {itemIndex}", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    tbkManager_inboxMessages.Text = Convert.ToString(reader.GetValue(0));
                }


            }
        }

        ///// <summary>
        ///// Read all messages from the table
        ///// </summary>
        ///// <param name="idOfUser"> Name of the table to read from </param>
        //public void getTheResults(string idOfUser)
        //{
        //    using (var conn = new NpgsqlConnection(MainWindow.ChatConnectionString))
        //    {
        //        // open the connection
        //        conn.Open();


        //        string commandToSend = $"SELECT staffid FROM staff_members WHERE staffid LIKE '{idOfUser}%'";

        //        // Retrieve all rows
        //        using (var cmd = new NpgsqlCommand(commandToSend, conn))
        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                string yestext = Convert.ToString(reader.GetValue(0));
        //                if (yestext != userId.Text.ToLower())
        //                {
        //                    TextBlock theTextBlock = new TextBlock()
        //                    {
        //                        Text = yestext,
        //                        TextAlignment = TextAlignment.Center,
        //                        FontSize = 16,
        //                        Focusable = false,
        //                        IsEnabled = false,
        //                        Margin = new Thickness(2, 2, 2, 2)
        //                    };
        //                    searchResults.Items.Add(theTextBlock);
        //                }
        //            }
        //            searchResults.Items.Refresh();
        //        }
        //    }


            #region Quote Summary tab

            #endregion

            #region Compose Message tab
            /// <summary>
            /// Returns true if the was an error
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public bool checkForError(string name)
        {
            if(name.Trim() == "")
            {
                MessageBox.Show("You cannot send an empty message!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            return false;
        }
      

        #endregion

        #region Verified Quotes tab

        #endregion

        #region Authorizations tab
        

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
            ltbManager_Search_Results.Items.Clear();
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
                ltbManager_Search_Results.Items.Add(nothingFoundMessage);                
            }
            else
            {
                ltbManager_Search_Results.ItemsSource = results;
                ltbManager_Search_Results.Items.Refresh();
            }
        }

        private void btnManager_search_Click_1(object sender, RoutedEventArgs e)
        {
            //New edit
            string filter = cbbManager_Search_entities.SelectionBoxItem.ToString();
            string search = txbManager_search.Text;
        }


        #endregion

        private void btnManager_logOut_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.logOut(this);
        }


        private void btnManager_Quotes_Click(object sender, RoutedEventArgs e)
        {
            managerQuotes = new Manager_Quotes_Window();
            //Hide();
            managerQuotes.Show();
        }

        private void cbbManager_Search_entities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnManager_authorize_Click(object sender, RoutedEventArgs e)
        {
            managerAuthorizations = new Manager_Authorizations_Window();
            //Hide();
            managerAuthorizations.Show();
        }

        private void BtnManager_Paymentss_Click(object sender, RoutedEventArgs e)
        {
            managerPayments = new Manager_Payments_Window();
            //Hide();
            managerPayments.Show();
        }

        private void BtnManager_Confirmatons_Click(object sender, RoutedEventArgs e)
        {
            managerConfirmations = new Manager_Confirmations_Window();
            //Hide();
            managerConfirmations.Show();
        }

        private void BtnManager_composeMessage_Click(object sender, RoutedEventArgs e)
        {
            composeMessageWindow = new ComposeMessageWindow();
            //Hide();
            composeMessageWindow.Show();
        }

        private void LbManager_inboxList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // get the index of the selected item
            int indexPath = lbManager_inboxList.SelectedIndex;
            if (indexPath >= 0)
            {
                // the textbox that has the details
                TextBlock id = (TextBlock)lbManager_inboxList.SelectedItem;

                // change the font
                id.FontSize = 16;

                // get the ID
                txbMessageFrom.Content += id.Text;

                // Assign the new button
                lbManager_inboxList.Items.RemoveAt(indexPath);
                lbManager_inboxList.Items.Insert(indexPath, id);

                // get the ID of the reciever 
                string idContent = currentStaffID.ToLower();

                // get the index of the entry
                int idNum = Convert.ToInt32(id.Tag);

                // read the selected entry
                readSelectedID(idContent, idNum);

                // enable
                composeMessageWindow.txbMessage_message.IsEnabled = true;
                composeMessageWindow.btnMessage_send.IsEnabled = true;
            }
        }

        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentStaffID))
            {
                for (int i = lbManager_inboxList.Items.Count - 1; i >= 0; i--)
                    lbManager_inboxList.Items.RemoveAt(i);

                readAll(currentStaffID);
            }
        }
    }
}
