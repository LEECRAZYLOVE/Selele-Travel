using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Consultant_Update_Window.xaml
    /// </summary>
    public partial class ConsultantUpdateWindow : Window
    {
        public ConsultantUpdateWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void createNewClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOldClient_find_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BtnCarHire_update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCab_update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnFlight_update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnFlight_addPassenger_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAccommodation_update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnConference_update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnQuote_update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSendQuotes_send_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AmountChanged_WHOLENumber(object sender, TextChangedEventArgs e)
        {

        }

        private void AmountChanged(object sender, TextChangedEventArgs e)
        {

        }
        //Implementing placeholder
        private void TxbCab_pickUpTime_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox current = (TextBox)sender;
            string placeHolderText = "hh:mm";
            if (current.Text == placeHolderText)
            {
                current.Foreground = Brushes.Black;
                current.Clear();
            }
        }

        private void TxbCab_pickUpTime_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox current = (TextBox)sender;
            string placeHolderText = "hh:mm";
            if (current.Text == "")
            {
                current.Foreground = Brushes.LightGray;
                current.Text = placeHolderText;
            }
        }
    }
}
