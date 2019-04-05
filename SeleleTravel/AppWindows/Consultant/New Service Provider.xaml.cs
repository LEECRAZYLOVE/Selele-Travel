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
            GeneralMethods.checkAmountTyped((TextBox)sender);
        }

        private void validateNumber(object sender, TextChangedEventArgs e)
        {
            GeneralMethods.checkPhoneNumber((TextBox)sender);
        }

        private void createNewClient_Click(object sender, RoutedEventArgs e)
        {
            //new edit
            string name = txbNewService_name.Text;
            string address = txbNewService_address.Text;
            string telephone = txbNewService_telephone.Text;
            string emailadress = txbNewService_email.Text;
            string fax = txbNewService_fax.Text;
            string cellphone = txbNewService_cellphone.Text;
            string service = cbbNewService_entities.SelectionBoxItem.ToString() ;

    
        }

        private void New_Service_Provider_Home_Closed(object sender, EventArgs e)
        {
            //GeneralMethods.closeAllWindows();
            Owner.Show();
        }

        private void txbNewService_name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnUpdateClient_Click(object sender, RoutedEventArgs e)
        {//For insertion Done
            string name = txbNewService_name.Text;
            string address = txbNewService_address.Text;
            string telephone = txbNewService_telephone.Text;
            string emailadress = txbNewService_email.Text;
            string fax = txbNewService_fax.Text;
            string cellphone = txbNewService_cellphone.Text;
            string service = cbbNewService_entities.SelectionBoxItem.ToString();
            string agency_ID = GeneralMethods.makeAgency_ID(name, service);
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {//Extracting data from the database DONE!


        }

        

        private void BtnNewService_add_Click(object sender, RoutedEventArgs e)
        {
            //For insertion Done
            string name = txbNewService_name.Text;
            string address = txbNewService_address.Text;
            string telephone = txbNewService_telephone.Text;
            string emailadress = txbNewService_email.Text;
            string fax = txbNewService_fax.Text;
            string cellphone = txbNewService_cellphone.Text;
            string service = cbbNewService_entities.SelectionBoxItem.ToString();
            string postalcode = txbNewService_areaCode.Text;
            string agency_ID = GeneralMethods.makeAgency_ID(name, postalcode);
            
            //Query for inserting the service provider
            try
            {
                NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);
                myConnect.Open();
                using (var cmd = new NpgsqlCommand($"INSERT INTO agencydetails (agency_id,nameofagency,address,telephone,emailaddress,fax,cellphone,service) VALUES (@agency_id,@nameofagency,@address,@telephone,@emailaddress,@fax,@cellphone,@service)", myConnect))
                {
                    cmd.Parameters.AddWithValue("agency_id", agency_ID);
                    cmd.Parameters.AddWithValue("nameofagency",name );
                    cmd.Parameters.AddWithValue("address", address);
                    cmd.Parameters.AddWithValue("telephone", telephone);
                    cmd.Parameters.AddWithValue("emailaddress",emailadress );
                    cmd.Parameters.AddWithValue("fax",fax );
                    cmd.Parameters.AddWithValue("cellphone",cellphone );
                    cmd.Parameters.AddWithValue("service",service );
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show($"Successfully added into database. Agency_Id is: {agency_ID}");
            }
            catch (Exception h)
            {
                MessageBox.Show(h.ToString());
            }
        }

        private void btnUpdateClient_Click_1(object sender, RoutedEventArgs e)
        {

        }

        

        private void cbbNewService_entities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
