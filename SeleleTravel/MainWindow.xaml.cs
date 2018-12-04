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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SeleleTravel.Classes;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
        }
        private void selectionChanged(object sender, RoutedEventArgs e)
        {
            CheckBox reference = (CheckBox)sender;
            if (reference == ckbBusiness)
            {
                ckbIndividual.IsChecked = !ckbBusiness.IsChecked;
            }
            else ckbBusiness.IsChecked = !ckbIndividual.IsChecked;
        }
        private void createNewClient_Click(object sender, RoutedEventArgs e)
        {
            string names = txbNewClient_name.Text + " " + txbNewClient_surname;

            ClientType clientType = (bool)(ckbBusiness.IsChecked) ? ClientType.Business : ClientType.Individual;
            Client client = new Client(names, clientType);
            client.location = txbNewClient_address.Text + '\n' + txbNewClient_city.Text
                + '\n' + txbNewClient_province.Text;
        }
    }
}
