using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Npgsql;
//using Devart.Data.MySql;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Manager_Quotes_Window.xaml
    /// </summary>
    public partial class Manager_Quotes_Window : Window
    {
        public static ComposeMessageWindow composeMessage = new ComposeMessageWindow();

        public Manager_Quotes_Window()
        {
            InitializeComponent();
        }
        public string rejectedQuoteNo;
        private void BtnQuoteSummary_verifyReject_Click(object sender, RoutedEventArgs e)
        {
            // Refresh the list boxes for verified and incoming quotes
            ltbQuoteSummary_incomingQuotes.Items.Refresh();
            listbxVerifiedQuotes.Items.Refresh();


            //Grab the information of the client and send it to the 'compose message' name textbox
            composeMessage.txbMessage_staffnameTo.Text = txblockQuoteSummary_consultantID.Text;
            //view the 'compose message' tab
            Manager_tabControl.SelectedIndex = 1;
            //Grab the information of the quote we just rejected
            quote currentQuote = ltbQuoteSummary_incomingQuotes.SelectedItems[0] as quote;
            rejectedQuoteNo = $"Quote no. : {currentQuote.quote_no}";
            composeMessage.Show();
        }
        string quote_no = "";
        
        private void BtnQuoteSummary_verifyAccept_Click(object sender, RoutedEventArgs e)
        {
            // Refresh the list boxes for verified and incoming quotes
            ltbQuoteSummary_incomingQuotes.Items.Refresh();
            listbxVerifiedQuotes.Items.Refresh();
            
            //Query for updating the verification part
            try
            {
                NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);
                myConnect.Open();
                NpgsqlCommand myCommand = new NpgsqlCommand($"UPDATE quote SET verification='yes' WHERE quote_no = '{quote_no}'", myConnect);
                // Add paramaters.

                myCommand.Parameters.Add(new NpgsqlParameter("verification", NpgsqlTypes.NpgsqlDbType.Varchar));
                myCommand.Parameters.Add(new NpgsqlParameter("quote_no", NpgsqlTypes.NpgsqlDbType.Varchar));

                //add value to the parameter
                myCommand.Parameters[0].Value = "yes";
                myCommand.Parameters[1].Value = quote_no;

                //execute the command
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Successfully saved into the database. You will now be redirected to your home page.");
            }
            catch (Exception h)
            {
                MessageBox.Show(h.ToString());
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Refresh the list boxes for verified and incoming quotes!
            ltbQuoteSummary_incomingQuotes.Items.Refresh();
            listbxVerifiedQuotes.Items.Refresh();           
        }
    
        private void LtbQuoteSummary_incomingQuotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            quote_no = ltbQuoteSummary_incomingQuotes.SelectedItem.ToString();
            //Query for retrieving quote data
            try
            {
                NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);
                myConnect.Open();
                using (var cmd = new NpgsqlCommand($"SELECT * FROM quote WHERE quote_no = '{quote_no}'", myConnect))
                {
                    NpgsqlDataReader query = cmd.ExecuteReader();

                    while (query.Read())
                    {
                        txbQuoteSummary_preview.Text = 
                        $"Quote number: {query[0]}\n" +
                        $"Services: {query[2].ToString().Replace('|', ' ')}\nTime Quoted: {query[3]}\nQuote Date: {query[6]}\n" +
                        $"Client ID: {query[9]}\nClient Name: {query[10]}\n" + $"Service fee: R{query[8]}\n" + $"Total amount: R{query[1]}\n";
                        txblockQuoteSummary_consultantID.Text=   $"{query[7]}";
                    }
                    myConnect.Close();
                }
            }
            catch (Exception h)
            {
                MessageBox.Show(h.ToString());
            }

        }
    }
}
