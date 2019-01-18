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
            composeMessage.SearchResultComboBox.SelectedItem = txblockQuoteSummary_consultantID.Text;
            //view the 'compose message' tab
            Manager_tabControl.SelectedIndex = 1;
            //Grab the information of the quote we just rejected
            quote currentQuote = ltbQuoteSummary_incomingQuotes.SelectedItems[0] as quote;
            rejectedQuoteNo = $"Quote no. : {currentQuote.quote_no}";
            composeMessage.Show();
        }

        private void BtnQuoteSummary_verifyAccept_Click(object sender, RoutedEventArgs e)
        {
            // Refresh the list boxes for verified and incoming quotes
            ltbQuoteSummary_incomingQuotes.Items.Refresh();
            listbxVerifiedQuotes.Items.Refresh();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Refresh the list boxes for verified and incoming quotes!
            ltbQuoteSummary_incomingQuotes.Items.Refresh();
            listbxVerifiedQuotes.Items.Refresh();           
        }

        private void LtbQuoteSummary_incomingQuotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string quote_no=ltbQuoteSummary_incomingQuotes.SelectedItem.ToString();
    
        }
    }
}
