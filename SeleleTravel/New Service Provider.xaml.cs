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

        private void createNewClient_Click(object sender, RoutedEventArgs e)
        {
            var context = new SeleleEntities();
            var currentServiceProvider = new accommodationdetail()
            {
                accomm_id = "lalala53",
                nameofagency = txbNewService_name.Text,
                address = $"{txbNewService_address.Text} /n { txbNewService_city.Text} /n { txbNewService_areaCode.Text} /n {ckbNewService_province.Items.CurrentItem}",
                phonenumber = txbNewService_telephone.Text,
                emailaddress = txbNewService_email.Text,
                faxnumber = txbNewService_fax.Text,
                cellphone = txbNewService_cellphone.Text
            };
      
            try
            {
                context.accommodationdetails.Add(currentServiceProvider);
                context.SaveChanges();
                MessageBox.Show($"Succesfully added into the database. The new Accommodation ID is: {currentServiceProvider.accomm_id}");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                var errorMessage = ex.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
                var propertyName = ex.EntityValidationErrors.First().ValidationErrors.First().PropertyName;
            }
            catch (Exception ex)
            {
                //other error
                throw ex;
            }

        }

        private void New_Service_Provider_Home_Closed(object sender, EventArgs e)
        {
            GeneralMethods.closeAllWindows();
        }

        
    }
}
