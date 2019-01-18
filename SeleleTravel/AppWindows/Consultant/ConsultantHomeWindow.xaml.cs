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
            //Hide();
            //MessageBox.Show($"New quote number: {quote_no}");
        }

        private void btnConsultant_search_Click(object sender, RoutedEventArgs e)
        {

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
                            TxtBoxFrom.Content = id.Text;

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
       }
}
