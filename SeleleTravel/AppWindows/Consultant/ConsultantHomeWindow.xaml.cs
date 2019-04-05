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
using System.Data.SqlClient;
using System.Windows.Threading;
using Npgsql;
//using Devart.Data.MySql;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Consultant_Quotes_Window.xaml
    /// </summary>
    public partial class ConsultantHomeWindow : Window
    {
        ConsultantQuotesWindow consultantQuotesWindow = new ConsultantQuotesWindow();
        ComposeMessageWindow composeMessageWindow;

        public string currentStaffID;
        DispatcherTimer theLoadingTime;

        public ConsultantHomeWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void BtnConsultant_logOut_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.logOut(this);
        }

        private void btnConsultant_Quotes_Click(object sender, RoutedEventArgs e)
        {
            consultantQuotesWindow.Owner = this;
            consultantQuotesWindow.Show();
            consultantQuotesWindow.consultant_no = currentStaffID;
            //Hide();
            //MessageBox.Show($"New quote number: {quote_no}");
        }

        public string cbxStatus = ""; //This will tell which entity is selected in the combobox for the search results
        private void btnConsultant_search_Click(object sender, RoutedEventArgs e)
        {
            SearchResults searchResultsWindow = new SearchResults();
            string NameorID = txbConsultant_search.Text;//.ToLower();

            //Checkbox Searching Section
            int intCKB = 0;
            NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);
            if (ckbConsultant_Search_quotes.IsChecked == true)
                intCKB = 1;
            if (ckbConsultant_Search_orders.IsChecked == true)
                intCKB = 2;
            if (ckbConsultant_Search_vouchers.IsChecked == true)
                intCKB = 3;
            if (ckbConsultant_Search_invoices.IsChecked == true)
                intCKB = 4;
            if (ckbConsultant_Search_all.IsChecked == true)
                intCKB = 5;

            switch (intCKB)
            {
                case 1:
                    try
                    {
                        ltbConsultant_Search_Results.Items.Clear();
                        myConnect.Open();
                        NpgsqlCommand cmdQuotes = new NpgsqlCommand("SELECT quote_no from quote", myConnect);
                        NpgsqlDataReader drQuotes = cmdQuotes.ExecuteReader();
                        while (drQuotes.Read())
                        {
                            ltbConsultant_Search_Results.Items.Add(drQuotes[0].ToString());
                        }
                        myConnect.Close();
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show(h.ToString());
                    }
                    break;

                case 2:
                    try
                    {
                        ltbConsultant_Search_Results.Items.Clear();
                        myConnect.Open();
                        NpgsqlCommand cmdOrders = new NpgsqlCommand("SELECT order_no from orders", myConnect);
                        NpgsqlDataReader drOrders = cmdOrders.ExecuteReader();
                        while (drOrders.Read())
                        {
                            ltbConsultant_Search_Results.Items.Add(drOrders[0].ToString());
                        }
                        myConnect.Close();
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show(h.ToString());
                    }
                    break;

                case 3:
                    try
                    {
                        ltbConsultant_Search_Results.Items.Clear();
                        myConnect.Open();
                        NpgsqlCommand cmdVouchers = new NpgsqlCommand("SELECT voucher_no from voucher", myConnect);
                        NpgsqlDataReader drVouchers = cmdVouchers.ExecuteReader();
                        while (drVouchers.Read())
                        {
                            ltbConsultant_Search_Results.Items.Add(drVouchers[0].ToString());
                        }
                        myConnect.Close();
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show(h.ToString());
                    }
                    break;

                case 4:
                    try
                    {
                        ltbConsultant_Search_Results.Items.Clear();
                        myConnect.Open();
                        NpgsqlCommand cmdInvoices = new NpgsqlCommand("SELECT invoice_no from invoice", myConnect);
                        NpgsqlDataReader drInvoices = cmdInvoices.ExecuteReader();
                        while (drInvoices.Read())
                        {
                            ltbConsultant_Search_Results.Items.Add(drInvoices[0].ToString());
                        }
                        myConnect.Close();
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show(h.ToString());
                    }
                    break;

                case 5:
                    ltbConsultant_Search_Results.Items.Clear();
                    try
                    {
                        myConnect.Open();
                        NpgsqlCommand cmdQuotes = new NpgsqlCommand("SELECT quote_no from quote", myConnect);
                        NpgsqlDataReader drQuotes = cmdQuotes.ExecuteReader();
                        while (drQuotes.Read())
                        {
                            ltbConsultant_Search_Results.Items.Add(drQuotes[0].ToString());
                        }
                        myConnect.Close();
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show(h.ToString());
                    }
                    try
                    {
                        myConnect.Open();
                        NpgsqlCommand cmdOrders = new NpgsqlCommand("SELECT order_no from orders", myConnect);
                        NpgsqlDataReader drOrders = cmdOrders.ExecuteReader();
                        while (drOrders.Read())
                        {
                            ltbConsultant_Search_Results.Items.Add(drOrders[0].ToString());
                        }
                        myConnect.Close();
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show(h.ToString());
                    }
                    try
                    {
                        myConnect.Open();
                        NpgsqlCommand cmdVouchers = new NpgsqlCommand("SELECT voucher_no from voucher", myConnect);
                        NpgsqlDataReader drVouchers = cmdVouchers.ExecuteReader();
                        while (drVouchers.Read())
                        {
                            ltbConsultant_Search_Results.Items.Add(drVouchers[0].ToString());
                        }
                        myConnect.Close();
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show(h.ToString());
                    }
                    //try
                    //{
                    //    myConnect.Open();
                    //    NpgsqlCommand cmdInvoices = new NpgsqlCommand("SELECT invoice_no from invoice", myConnect);
                    //    NpgsqlDataReader drInvoices = cmdInvoices.ExecuteReader();
                    //    while (drInvoices.Read())
                    //    {
                    //        ltbConsultant_Search_Results.Items.Add(drInvoices[0].ToString());
                    //    }
                    //    myConnect.Close();
                    //}
                    //catch (Exception h)
                    //{
                    //    MessageBox.Show(h.ToString());
                    //}
                    break;
            }
            //End of Checkbox Searching Section

            //Combobox Searching Section
            switch (cbxConsultant_Search_entities.Text)
            {
                case "Staff":
                    cbxStatus = "Staff";
                    try
                    {
                        ltbConsultant_Search_Results.Items.Clear();
                        myConnect.Open();
                        NpgsqlCommand cmdStaff = new NpgsqlCommand($"SELECT staff_id, stafffirstnames, stafflastname FROM staff WHERE staff_id = '{NameorID}' OR stafffirstnames = '{NameorID}' OR stafflastname = '{NameorID}'", myConnect);
                        NpgsqlDataReader drStaff = cmdStaff.ExecuteReader();
                        while (drStaff.Read())
                        {
                            ltbConsultant_Search_Results.Items.Add($"{drStaff[1]} {drStaff[2]}, {drStaff[0]}");
                        }
                        myConnect.Close();
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show(h.ToString());
                    }
                    break;

                case "Clients":
                    try
                    {
                        ltbConsultant_Search_Results.Items.Clear();
                        myConnect.Open();
                        NpgsqlCommand cmdClients = new NpgsqlCommand($"SELECT client_no, clientname FROM client WHERE client_no = '{NameorID}' OR clientname = '{NameorID}'", myConnect);
                        NpgsqlDataReader drClients = cmdClients.ExecuteReader();
                        while (drClients.Read())
                        {
                            ltbConsultant_Search_Results.Items.Add($"{drClients[1]}, {drClients[0]}");
                        }
                        myConnect.Close();
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show(h.ToString());
                    }
                    cbxStatus = "Clients";
                    break;

                case "Service Providers":
                    try
                    {
                        ltbConsultant_Search_Results.Items.Clear();
                        myConnect.Open();
                        NpgsqlCommand cmdServiceP = new NpgsqlCommand($"SELECT agency_id, agencyname, address FROM serviceproviders WHERE agency_id = '{NameorID}' OR agencyname = '{NameorID}'", myConnect);
                        NpgsqlDataReader drServiceP = cmdServiceP.ExecuteReader();
                        while (drServiceP.Read())
                        {
                            ltbConsultant_Search_Results.Items.Add($"{drServiceP[1]} {drServiceP[2]}, {drServiceP[0]}");
                        }
                        myConnect.Close();
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show(h.ToString());
                    }
                    cbxStatus = "Service Providers";
                    break;
            }
            //End of Combobox Searching Section

        }

        private void btnConsultant_Orders_Click(object sender, RoutedEventArgs e)
        {
            ConsultantOrdersWindow consultantOrdersWindow = new ConsultantOrdersWindow();
            consultantOrdersWindow.Owner = this;
            consultantOrdersWindow.Show();
            //Hide();

        }

        private void btnConsultant_Vouchers_Click(object sender, RoutedEventArgs e)
        {
            ConsultantVouchersWindow consultantVouchersWindow = new ConsultantVouchersWindow();
            consultantVouchersWindow.Owner = this;
            consultantVouchersWindow.Show();
            //Hide();

        }

        private void btnConsultant_composeMessage_Click(object sender, RoutedEventArgs e)
        {
            ComposeMessageWindow composeMessageWindow = new ComposeMessageWindow
            {
                currentStaffID = currentStaffID,
                Owner = this
            };
            composeMessageWindow.Show();
            //Hide();

        }

        private void btnConsultant_Update_Click(object sender, RoutedEventArgs e)
        {
            ConsultantUpdateWindow consultantUpdateWindow = new ConsultantUpdateWindow();
            consultantUpdateWindow.Owner = this;
            consultantUpdateWindow.Show();
            //Hide();

            //ppConsultant_Update.Visibility = Visibility.Visible;
        }

        private void BtnConsultant_NewServiceProvider_Click(object sender, RoutedEventArgs e)
        {
            New_Service_Provider provider = new New_Service_Provider();
            provider.Owner = this;
            provider.Show();
            //Hide();
        }

        /// <summary>
        /// Indicates whether the tab is being pressed for the first time
        /// </summary>
        bool mIsItFirstTime = true;

        /// <summary>
        /// Go to the inbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (mIsItFirstTime)
            {
                mIsItFirstTime = false;
                // time to help load the program fully
                theLoadingTime = new DispatcherTimer();
                theLoadingTime.Interval = TimeSpan.FromSeconds(5);
                theLoadingTime.IsEnabled = true;
                theLoadingTime.Tick += TheLoadingTime_Tick;
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
            readSome(currentStaffID);
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
                int lastNum = lblConsultant_inboxList.Items.Count;

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

                        lblConsultant_inboxList.Items.Insert(0, theTextBlock);
                    }
                    lblConsultant_inboxList.Items.Refresh();
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
                int lastNum = lblConsultant_inboxList.Items.Count;

                // Retrieve the specific message with the given id rows 
                using (var cmd = new NpgsqlCommand($"SELECT message FROM {idOfUser} WHERE tb_ID = {itemIndex}", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    tbkConsultant_inboxMessages.Text = Convert.ToString(reader.GetValue(0));
                }


            }
        }

        /// <summary>
        /// Go to message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblConsultant_inboxList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // get the index of the selected item
            int indexPath = lblConsultant_inboxList.SelectedIndex;
            if (indexPath >= 0)
            {
                // the textbox that has the details
                TextBlock id = (TextBlock)lblConsultant_inboxList.SelectedItem;

                // change the font
                id.FontSize = 16;

                // get the ID
                lblConsultantID.Content = id.Text;

                // Assign the new button
                lblConsultant_inboxList.Items.RemoveAt(indexPath);
                lblConsultant_inboxList.Items.Insert(indexPath, id);

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

        /// <summary>
        /// Going to the Search results window if anything is picked from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LtbConsultant_Search_Results_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string qoviNum = ltbConsultant_Search_Results.SelectedItem.ToString(); //order/quote/invoice/voucher number that has been selected by the user
            SearchResults searchResultsWindow = new SearchResults();
            searchResultsWindow.Owner = this;
            searchResultsWindow.Show();
            searchResultsWindow.tbkSearchResults.Text = "";
            NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);

            //Display quotes
            try
            {
                myConnect.Open();
                NpgsqlCommand cmdView = new NpgsqlCommand($"SELECT service FROM quote WHERE quote_no = '{qoviNum}'", myConnect);
                NpgsqlDataReader drView = cmdView.ExecuteReader();
                while (drView.Read())
                {
                    searchResultsWindow.tbkSearchResults.Text = GeneralMethods.quoteSummary(qoviNum.Replace(" ", ""), drView[0].ToString()); //Viewing the selected quote's summary in the new window
                    searchResultsWindow.tbkSearchResults.Text += GeneralMethods.quoteSummaryAmounts(qoviNum);
                }
                myConnect.Close();
            }
            catch (Exception h)
            {
                MessageBox.Show(h.ToString());
            }
            //End display quote

            //Display order

            //End display order

            //Display voucher
            //End display voucher

            //Display invoice
            //End display invoice

            //Display staff, client or service proivder
            switch (cbxStatus)
            {
                case "Staff":
                    try
                    {

                        myConnect.Open();
                        NpgsqlCommand cmdStaff = new NpgsqlCommand($"SELECT staff_id, stafffirstnames, stafflastname, staffposition,email,cellphone,telephone,fax,address FROM staff WHERE staff_id = '{ltbConsultant_Search_Results.SelectedItem.ToString().Remove(0, ltbConsultant_Search_Results.SelectedItem.ToString().IndexOf(',') + 1).Replace(" ", "")}'", myConnect); //Removes the name of the staff because I'm seraching it with the staff_id in the databse
                        NpgsqlDataReader drStaff = cmdStaff.ExecuteReader();
                        while (drStaff.Read())
                        {
                            searchResultsWindow.tbkSearchResults.Text = $" Staff Id: {drStaff[0]} \n Name: {drStaff[1]} {drStaff[2]} \n Position: {drStaff[3]} \n Email: {drStaff[4]} \n Cellphone: {drStaff[5]} \n Telephone: {drStaff[6]} \n Fax: {drStaff[7]} \n Address: {drStaff[8]}"; //Viewing the selected staff member's summary in the new window
                        }
                        myConnect.Close();
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show(h.ToString());
                    }
                    break;

                case "Clients":
                    try
                    {
                        myConnect.Open();
                        NpgsqlCommand cmdClients = new NpgsqlCommand($"SELECT client_no,clientname,emailaddress,cellphone,telephone,fax,address FROM client WHERE client_no = '{ltbConsultant_Search_Results.SelectedItem.ToString().Remove(0, ltbConsultant_Search_Results.SelectedItem.ToString().IndexOf(',') + 1).Replace(" ", "")}'", myConnect); //Removes the name of the staff because I'm seraching it with the staff_id in the databse
                        NpgsqlDataReader drClients = cmdClients.ExecuteReader();
                        while (drClients.Read())
                        {
                            searchResultsWindow.tbkSearchResults.Text = $" Client No.: {drClients[0]} \n Name: {drClients[1]} \n Email: {drClients[2]} \n Cellphone: {drClients[3]} \n Telephone: {drClients[4]} \n Fax: {drClients[5]} \n Address: {drClients[6]}"; //Viewing the selected staff member's summary in the new window
                        }
                        myConnect.Close();
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show(h.ToString());
                    }
                    break;

                case "Service Providers":
                    try
                    {
                        myConnect.Open();
                        NpgsqlCommand cmdServiceP = new NpgsqlCommand($"SELECT agency_id, agencyname, emailaddress, cellphone, telephone, fax, address FROM serviceproviders WHERE agency_id = '{ltbConsultant_Search_Results.SelectedItem.ToString().Remove(0, ltbConsultant_Search_Results.SelectedItem.ToString().IndexOf(',') + 1).Replace(" ", "")}'", myConnect); //Removes the name of the staff because I'm seraching it with the staff_id in the databse
                        NpgsqlDataReader drServiceP = cmdServiceP.ExecuteReader();
                        while (drServiceP.Read())
                        {
                            searchResultsWindow.tbkSearchResults.Text = $" Agency ID: {drServiceP[0]} \n Name: {drServiceP[1]} \n Email: {drServiceP[2]} \n Cellphone {drServiceP[3]} \n Telephone: {drServiceP[4]} \n Fax: {drServiceP[5]} \n Address: {drServiceP[6]}";
                        }
                        myConnect.Close();
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show(h.ToString());
                    }
                    break;

            }
            //End display staff, client or service provider
        }
    }
}
