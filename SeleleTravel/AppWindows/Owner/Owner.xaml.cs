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
using System.Data;
using System.Windows.Threading;
using Npgsql;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Owner.xaml
    /// </summary>
    public partial class OwnerHomeWindow : Window
    {
        public string currentStaffID = "";
        public OwnerFinancialWindow ownerFinancialWindow;
        public OwnerEmployeesWindow ownerEmployeesWindow;
        public OwnerPaymentsWindow ownerPaymentsWindow;
        // time to update
        DispatcherTimer theLoadingTime;

        public OwnerHomeWindow()
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
                int lastNum = lbOwner_inboxList.Items.Count;

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

                        lbOwner_inboxList.Items.Insert(0, theTextBlock);
                    }
                    lbOwner_inboxList.Items.Refresh();
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
                int lastNum = lbOwner_inboxList.Items.Count;

                // Retrieve the specific message with the given id rows 
                using (var cmd = new NpgsqlCommand($"SELECT message FROM {idOfUser} WHERE tb_ID = {itemIndex}", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    tbkOwner_inboxMessages.Text = Convert.ToString(reader.GetValue(0));
                }


            }
        }

        private void btnOwner_search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOwner_financialSummary_Click(object sender, RoutedEventArgs e)
        {
            ownerFinancialWindow = new OwnerFinancialWindow();
            ownerFinancialWindow.Owner = this;
            ownerFinancialWindow.Show();
            Hide();
        }

        private void BtnOwner_Employees_Click(object sender, RoutedEventArgs e)
        {
            ownerEmployeesWindow = new OwnerEmployeesWindow();
            ownerEmployeesWindow.Owner = this;
            ownerEmployeesWindow.Show();
            Hide();
        }

        private void BtnOwner_composeMessage_Click(object sender, RoutedEventArgs e)
        {
            ComposeMessageWindow composeMessageWindow = new ComposeMessageWindow();
            composeMessageWindow.Owner = this;
            composeMessageWindow.Show();
            Hide();
            composeMessageWindow.currentStaffID = currentStaffID;
        }

        private void BtnOwner_paymentProofs_Click(object sender, RoutedEventArgs e)
        {
            ownerPaymentsWindow = new OwnerPaymentsWindow();
            ownerPaymentsWindow.Owner = this;
            ownerPaymentsWindow.Show();
            Hide();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Hide();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnOwner_logOut_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.logOut(this);
        }

        private void LbOwner_inboxList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //// get the index of the selected item
            //int indexPath = lbOwner_inboxList.SelectedIndex;
            //if (indexPath >= 0)
            //{
            //    // the textbox that has the details
            //    TextBlock id = (TextBlock)lbOwner_inboxList.SelectedItem;

            //    // change the font
            //    id.FontSize = 16;

            //    // get the ID
            //    txbMessageFrom.Content = id.Text;

            //    // Assign the new button
            //    lbOwner_inboxList.Items.RemoveAt(indexPath);
            //    lbOwner_inboxList.Items.Insert(indexPath, id);

            //    // get the ID of the reciever 
            //    string idContent = userId.Text.ToLower();

            //    // get the index of the entry
            //    int idNum = Convert.ToInt32(id.Tag);

            //    // read the selected entry
            //    readSelectedID(idContent, idNum);

            //    // enable
            //    sendMessage.IsEnabled = true;
            //    sendMessageNow.IsEnabled = true;
            //}
        }

        private void TabItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (!string.IsNullOrEmpty(userId.Text))
            //{
            //    for (int i = lbOwner_inboxList.Items.Count - 1; i >= 0; i--)
            //        lbOwner_inboxList.Items.RemoveAt(i);

            //    readAll(userId.Text);
            //}
        }
    }
}
