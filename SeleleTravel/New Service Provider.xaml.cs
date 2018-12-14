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
    /// Interaction logic for New_Service_Provider.xaml
    /// </summary>
    public partial class New_Service_Provider : Window
    {
        public New_Service_Provider()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //this.WindowState = WindowState.Maximized;
        }

        private void validateValue(object sender, TextChangedEventArgs e)
        {
            GeneralMethods.checkAmountTyped(sender);
        }

        private void validateNumber(object sender, TextChangedEventArgs e)
        {
            GeneralMethods.checkPhoneNumber(sender);
        }

        private void createNewClient_Click(object sender, RoutedEventArgs e)
        {
            // Assign textbox values to variables
            string name = txbNewService_name.Text;
            string entityType = cbbNewService_entities.SelectionBoxItem.ToString();
            string address = txbNewClient_address.Text;
            string city = txbNewService_city.Text;
            int areaCode = Convert.ToInt32(txbNewService_areaCode.Text);
            string province = provinceComboBox.SelectionBoxItem.ToString();
            int cellphoneNumber = Convert.ToInt32(txbNewService_cellphone.Text);
            int faxNumber = Convert.ToInt32(txbNewService_fax.Text);
            int telephoneNumber = Convert.ToInt32(txbNewService_telephone.Text);
            string emailAddress = txbNewService_email.Text;

            // Validate email address
            if(emailAddress.IndexOf('@') <= 0)
            {
                MessageBox.Show("Please a valid email address!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                // check for errors
                List<string> stringVs = new List<string>();
                stringVs.Add(name);
                stringVs.Add(entityType);
                stringVs.Add(address);
                stringVs.Add(city);
                stringVs.Add(province);
                stringVs.Add(emailAddress);
                bool t_or_f = GeneralMethods.checkEmptytxtBox(stringVs);

                if (!t_or_f)
                {
                    // create an instance


                    // clear textboxes
                    List<TextBox> textBoxes = new List<TextBox>();
                    textBoxes.Add(txbNewService_name);
                    textBoxes.Add(txbNewClient_address);
                    textBoxes.Add(txbNewService_city);
                    textBoxes.Add(txbNewService_areaCode);
                    textBoxes.Add(txbNewService_cellphone);
                    textBoxes.Add(txbNewService_fax);
                    textBoxes.Add(txbNewService_telephone);
                    textBoxes.Add(txbNewService_email);
                    GeneralMethods.clearTextBoxes(textBoxes);

                }
            }
        }

        private void New_Service_Provider_Home_Closed(object sender, EventArgs e)
        {
            GeneralMethods.closeAllWindows();
        }

        
    }
}
