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

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Consultant.xaml
    /// </summary>
    public partial class Consultant : Window
    {
        public Consultant()
        {
            InitializeComponent();
        }
        private void selectionChanged(object sender, RoutedEventArgs e)
        {
            //Making sure that only one checkbox is selected at a time
            CheckBox reference = (CheckBox)sender;
            if (reference == ckbBusiness)
            {
                ckbIndividual.IsChecked = !ckbBusiness.IsChecked;
            }
            else ckbBusiness.IsChecked = !ckbIndividual.IsChecked;
        }
        //Status : Incomplete
        private void createNewClient_Click(object sender, RoutedEventArgs e)
        {
            string names = txbNewClient_name.Text + " " + txbNewClient_surname;
            //Retrieving clientType
            ClientType clientType = (bool)(ckbBusiness.IsChecked) ? ClientType.Business : ClientType.Individual;

            //Get contact details
            string cellphone = txbNewClient_cellphone.Text;
            string fax = txbNewClient_fax.Text;
            string email = txbNewClient_email.Text;
            string telephone = txbNewClient_telephone.Text;
            ContactDetails contactDetails = new ContactDetails(cellphone, email, telephone, fax);

            //Get location details
            string address = txbNewClient_address.Text;
            string city = txbNewClient_city.Text;
            string areaCode = txbNewClient_areaCode.Text;
            string province = txbNewClient_province.Text;
            //use this in initialisation of client
            string _location = address + '\n' + city + '\n' + areaCode + '\n' + province;
            //Initialize Client instance
            Client client = new Client(names, clientType, contactDetails)
            {
                location = _location
            };


            //Add client to database

        }
        private void nameAndSurnameTextChanged(object sender, TextChangedEventArgs e)
        {

            string acceptedCharacters = " qwertyuioplkjhgfdsazxcvbnm";
            TextBox reference = (TextBox)sender;
            if (reference.Text.Length <= 0) return;

            string letterEntered = reference.Text.Last().ToString().ToLower();
            if (!acceptedCharacters.Contains(letterEntered))
            {
                reference.Text = reference.Text.TrimEnd(letterEntered.ToCharArray());
                reference.SelectionStart = reference.Text.Length;
                MessageBox.Show("'" + letterEntered + "' is not an accepted character for a name or a surname!", "Invalid Character!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
#endregion

        #region Already a Client Display

        #endregion

    }
}
