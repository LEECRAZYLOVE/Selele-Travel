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
using Devart.Data.MySql;

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
        {//new edit
            string name = txbNewService_name.Text;
            string address = txbNewClient_address.Text;
            string telephone = txbNewService_telephone.Text;
            string emailadress = txbNewService_email.Text;
            string fax = txbNewService_fax.Text;
            string cellphone = txbNewService_cellphone.Text;
            string service = cbbNewService_entities.SelectionBoxItem.ToString() ;

            //var context = new SeleleEntities();
            var currentServiceProvider = new agencydetail()
            {
                agency_id = "A0001", //This will be automatically generated. I'm using a dummy to test queries.
                nameofagency = name,
               address = address,
                telephone = telephone,
                emailaddress = emailadress,
                fax = fax,
               cellphone  = cellphone,
              service=service
            };
           //Add service provider to database
            //try
            //{
            //    context.agencydetails.Add(currentServiceProvider);
            //    context.SaveChanges();
            //    //  MessageBox.Show($"Succesfully added into the database. The new Accommodation ID is: {currentServiceProvider.client_no}");
            //}
            //catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            //{
            //    var errorMessage = ex.EntityValidationErrors.First().ValidationErrors.First().ErrorMessage;
            //    var propertyName = ex.EntityValidationErrors.First().ValidationErrors.First().PropertyName;
            //}
            //catch (Exception ex)
            //{
            //    //other error
            //    throw ex;

            //}
        }

        private void New_Service_Provider_Home_Closed(object sender, EventArgs e)
        {
            GeneralMethods.closeAllWindows();
        }

        private void txbNewService_name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnUpdateClient_Click(object sender, RoutedEventArgs e)
        {//For insertion Done
            string name = txbNewService_name.Text;
            string address = txbNewClient_address.Text;
            string telephone = txbNewService_telephone.Text;
            string emailadress = txbNewService_email.Text;
            string fax = txbNewService_fax.Text;
            string cellphone = txbNewService_cellphone.Text;
            string service = cbbNewService_entities.SelectionBoxItem.ToString();

            var context = new postgresEntities12th();
            var currentServiceProvider = new agencydetail()
            {
                agency_id = "A0001", //This will be automatically generated. I'm using a dummy to test queries.
                nameofagency = name,
                address = address,
                telephone = telephone,
                emailaddress = emailadress,
                fax = fax,
                cellphone = cellphone,
                service = service
            };
            //Add service provider to database
            try
            {
                context.agencydetails.Add(currentServiceProvider);
                context.SaveChanges();
                //  MessageBox.Show($"Succesfully added into the database. The new Accommodation ID is: {currentServiceProvider.client_no}");
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {//Extracting data from the database DONE!
            using (postgresEntities12th currentServiceProvider = new postgresEntities12th())
            {
                var query =(from c in currentServiceProvider.agencydetails

                             where c.telephone=="0783861533"
                             select new
                             {
                                 c.agency_id,
                                 c.address,
                                 c.cellphone,
                                 c.emailaddress,
                                 c.fax,
                                 c.nameofagency,
                                 c.service,
                                 c.telephone,
                                
                             }).First() ;

                if (query != null)
                {
                    txbNewService_name.Text = query.nameofagency;
                    txbNewClient_address.Text = query.address ;
                    txbNewService_cellphone.Text = query.cellphone;
                    txbNewService_fax.Text = query.fax;
                    txbNewService_telephone.Text = query.telephone;
                    txbNewService_email.Text = query.emailaddress;
                }
            }

        }
    }
}
