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
        public string currentStaffID = "";
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
            
            switch(intCKB)
            {
                case 1:
                    try
                    {
                        myConnect.Open();
                        NpgsqlCommand cmdQuotes = new NpgsqlCommand("SELECT * from quote", myConnect);
                        NpgsqlDataReader drQuotes = cmdQuotes.ExecuteReader();
                        while (drQuotes.Read())
                        {
                            ltbConsultant_Search_Results.Items.Add(drQuotes);
                        }
                        myConnect.Close();
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show(h.ToString());
                    }
                    break;
            }

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
            ComposeMessageWindow composeMessageWindow = new ComposeMessageWindow();
            composeMessageWindow.Owner = this;
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
    }
}
