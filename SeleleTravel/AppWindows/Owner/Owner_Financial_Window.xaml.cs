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
//using Devart.Data.MySql;
using Npgsql;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Owner_Financial_Window.xaml
    /// </summary>
    public partial class OwnerFinancialWindow : Window
    {
        public OwnerFinancialWindow()
        {
            InitializeComponent();

            lbFinancial_clientList.Visibility = Visibility.Visible;
            lbFinancial_servicesList.Visibility = Visibility.Hidden;
            cbxFinancial_period.Visibility = Visibility.Visible;
            txbYear.Visibility = Visibility.Hidden;
            cbxMultipleMonths_from.Visibility = Visibility.Hidden;
            cbxMultipleMonths_to.Visibility = Visibility.Hidden;
            dpMonthly_from.Visibility = Visibility.Hidden;
            dpMonthly_to.Visibility = Visibility.Hidden;
            dpWeekly_day.Visibility = Visibility.Hidden;
            lblYear.Visibility = Visibility.Hidden;
            lblMonthly_from.Visibility = Visibility.Hidden;
            lblMonthly_to.Visibility = Visibility.Hidden;
            lblMultipleMonths_from.Visibility = Visibility.Hidden;
            lblMultipleMonths_to.Visibility = Visibility.Hidden;
            lblWeekly.Visibility = Visibility.Hidden;
        }

        private void Owner_Financial_Window_Closed(object sender, EventArgs e)
        {
            Owner?.Show();
            Close();
        }

        private void CbxitemFinancial_clients_Selected(object sender, RoutedEventArgs e)
        {
            lbFinancial_clientList.Visibility = Visibility.Visible;
            lbFinancial_servicesList.Visibility = Visibility.Hidden;
            //cbxFinancial_period.Visibility = Visibility.Visible;
            txbYear.Visibility = Visibility.Hidden;
            cbxMultipleMonths_from.Visibility = Visibility.Hidden;
            cbxMultipleMonths_to.Visibility = Visibility.Hidden;
            dpMonthly_from.Visibility = Visibility.Hidden;
            dpMonthly_to.Visibility = Visibility.Hidden;
            dpWeekly_day.Visibility = Visibility.Hidden;

        }

        private void CbxitemFinancial_services_Selected(object sender, RoutedEventArgs e)
        {
            lbFinancial_clientList.Visibility = Visibility.Hidden;
            lbFinancial_servicesList.Visibility = Visibility.Visible;
            //cbxFinancial_period.Visibility = Visibility.Visible;
            txbYear.Visibility = Visibility.Hidden;
            cbxMultipleMonths_from.Visibility = Visibility.Hidden;
            cbxMultipleMonths_to.Visibility = Visibility.Hidden;
            dpMonthly_from.Visibility = Visibility.Hidden;
            dpMonthly_to.Visibility = Visibility.Hidden;
            dpWeekly_day.Visibility = Visibility.Hidden;
        }

        private void CbxitemFinancial_annually_Selected(object sender, RoutedEventArgs e)
        {
            //lbFinancial_clientList.Visibility = Visibility.Visible;
            //lbFinancial_servicesList.Visibility = Visibility.Hidden;
            //cbxFinancial_period.Visibility = Visibility.Visible;
            txbYear.Visibility = Visibility.Visible;
            cbxMultipleMonths_from.Visibility = Visibility.Hidden;
            cbxMultipleMonths_to.Visibility = Visibility.Hidden;
            dpMonthly_from.Visibility = Visibility.Hidden;
            dpMonthly_to.Visibility = Visibility.Hidden;
            dpWeekly_day.Visibility = Visibility.Hidden;
            lblYear.Visibility = Visibility.Visible;
            lblMonthly_from.Visibility = Visibility.Hidden;
            lblMonthly_to.Visibility = Visibility.Hidden;
            lblMultipleMonths_from.Visibility = Visibility.Hidden;
            lblMultipleMonths_to.Visibility = Visibility.Hidden;
            lblWeekly.Visibility = Visibility.Hidden;
        }

        private void CbxitemFinancial_multipleMonths_Selected(object sender, RoutedEventArgs e)
        {
            //lbFinancial_clientList.Visibility = Visibility.Visible;
            //lbFinancial_servicesList.Visibility = Visibility.Hidden;
            //cbxFinancial_period.Visibility = Visibility.Visible;
            txbYear.Visibility = Visibility.Hidden;
            cbxMultipleMonths_from.Visibility = Visibility.Visible;
            cbxMultipleMonths_to.Visibility = Visibility.Visible;
            dpMonthly_from.Visibility = Visibility.Hidden;
            dpMonthly_to.Visibility = Visibility.Hidden;
            dpWeekly_day.Visibility = Visibility.Hidden;
            lblYear.Visibility = Visibility.Hidden;
            lblMonthly_from.Visibility = Visibility.Hidden;
            lblMonthly_to.Visibility = Visibility.Hidden;
            lblMultipleMonths_from.Visibility = Visibility.Visible;
            lblMultipleMonths_to.Visibility = Visibility.Visible;
            lblWeekly.Visibility = Visibility.Hidden;
        }

        private void CbxitemFinancial_monthly_Selected(object sender, RoutedEventArgs e)
        {
            //lbFinancial_clientList.Visibility = Visibility.Visible;
            //lbFinancial_servicesList.Visibility = Visibility.Hidden;
            //cbxFinancial_period.Visibility = Visibility.Visible;
            txbYear.Visibility = Visibility.Hidden;
            cbxMultipleMonths_from.Visibility = Visibility.Hidden;
            cbxMultipleMonths_to.Visibility = Visibility.Hidden;
            dpMonthly_from.Visibility = Visibility.Visible;
            dpMonthly_to.Visibility = Visibility.Visible;
            dpWeekly_day.Visibility = Visibility.Hidden;
            lblYear.Visibility = Visibility.Hidden;
            lblMonthly_from.Visibility = Visibility.Visible;
            lblMonthly_to.Visibility = Visibility.Visible;
            lblMultipleMonths_from.Visibility = Visibility.Hidden;
            lblMultipleMonths_to.Visibility = Visibility.Hidden;
            lblWeekly.Visibility = Visibility.Hidden;
        }

        private void CbxitemFinancial_weekly_Selected(object sender, RoutedEventArgs e)
        {
            //lbFinancial_clientList.Visibility = Visibility.Visible;
            //lbFinancial_servicesList.Visibility = Visibility.Hidden;
            //cbxFinancial_period.Visibility = Visibility.Visible;
            txbYear.Visibility = Visibility.Hidden;
            cbxMultipleMonths_from.Visibility = Visibility.Hidden;
            cbxMultipleMonths_to.Visibility = Visibility.Hidden;
            dpMonthly_from.Visibility = Visibility.Hidden;
            dpMonthly_to.Visibility = Visibility.Hidden;
            dpWeekly_day.Visibility = Visibility.Visible;
            lblYear.Visibility = Visibility.Hidden;
            lblMonthly_from.Visibility = Visibility.Hidden;
            lblMonthly_to.Visibility = Visibility.Hidden;
            lblMultipleMonths_from.Visibility = Visibility.Hidden;
            lblMultipleMonths_to.Visibility = Visibility.Hidden;
            lblWeekly.Visibility = Visibility.Visible;
        }

        private void btnFinancial_view1_Click(object sender, RoutedEventArgs e)
        {
            string selected = cbxFinancial_entity.SelectedItem.ToString();
 

  }

        private void cbxFinancial_entity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnFinancial_view1_Click_1(object sender, RoutedEventArgs e)
        {
            //checking if date is between certain dates

            //Query for retrieving quote data between certain dates
           
                try
                {
                    NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);
                    myConnect.Open();
                    using (var cmd = new NpgsqlCommand($"SELECT client.clientname FROM client,quote,orders WHERE quote.quote_no=orders.quote_no AND quote.client_no=client.client_no AND quotedate BETWEEN '{txbYear.Text}-01-01' AND '{txbYear.Text}-12-31' ", myConnect))
                    {
                        NpgsqlDataReader query = cmd.ExecuteReader();

                        while (query.Read())
                        {
                            lbFinancial_results1.Items.Add($"{query[0]}");
                        }
                    }
                    myConnect.Close();
                }
                catch (Exception h)
                {
                    MessageBox.Show(h.ToString());
                }

            
        }
            //try
            //{
            //    NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);
            //    myConnect.Open();
            //    using (var cmd = new NpgsqlCommand($"SELECT * FROM quote,orders WHERE quote.quote_no=orders.quote_no AND quotedate BETWEEN '2019-01-01' AND '2019-01-20' ", myConnect))
            //    {
            //        NpgsqlDataReader query = cmd.ExecuteReader();

            //        while (query.Read())
            //        {
            //            lbFinancial_results1.Items.Add($"{query[0]}");
            //        }
                    
            //    }
            //    myConnect.Close();
            //}
            //catch (Exception h)
            //{
            //    MessageBox.Show(h.ToString());
            //}
      

        private void lbFinancial_results1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          string  clientname = lbFinancial_results1.SelectedItem.ToString();
            //Query for retrieving quote data
            try
            {
                NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);
                myConnect.Open();
                using (var cmd = new NpgsqlCommand($"SELECT * FROM client WHERE clientname = '{clientname}'", myConnect))
                {
                    NpgsqlDataReader query = cmd.ExecuteReader();

                    while (query.Read())
                    {
                        lbFinancial_results2.Items.Add($"Client number: {query[0]}");
                        lbFinancial_results2.Items.Add($"Client name: { query[1]}\n");
                        lbFinancial_results2.Items.Add($"Cellphone: {query[2].ToString().Replace('|', ' ')}");
                        lbFinancial_results2.Items.Add($"Address: {query[3]}");
                        lbFinancial_results2.Items.Add($"Emailaddress: {query[5]}");
                        lbFinancial_results2.Items.Add($"Telephone: {query[6]}");
                        lbFinancial_results2.Items.Add($"fax: {query[7]}");
                        lbFinancial_results2.Items.Add($"paid: {query[4]}");
                        lbFinancial_results2.Items.Add($"owe: {query[8]}");
                        lbFinancial_results2.Items.Add($"Brought forward: {query[9]}");
                        lbFinancial_results2.Items.Add($"Dateadded: {query[10]}");
                    }
                    myConnect.Close();
                }
            }
            catch (Exception h)
            {
                MessageBox.Show(h.ToString());
            }

        }

        private void cbxFinancial_period_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    } 
