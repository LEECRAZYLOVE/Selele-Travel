﻿using System;
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
            var context = new SeleleEntities();
            var currentServiceProvider = new agencydetail()
            {
                agency_id =agency_ID, //This will be automatically generated. I'm using a dummy to test queries.
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
                //context.agencydetails.Add(currentServiceProvider);
                //context.SaveChanges();
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
            //using (SeleleEntities currentServiceProvider = new SeleleEntities())
            //{
            //    var query =(from c in currentServiceProvider.agencydetails

            //                 where c.telephone=="0783861533"
            //                 select new
            //                 {
            //                     c.agency_id,
            //                     c.address,
            //                     c.cellphone,
            //                     c.emailaddress,
            //                     c.fax,
            //                     c.nameofagency,
            //                     c.service,
            //                     c.telephone,
                                
            //                 }).First() ;

            //    if (query != null)
            //    {
            //        txbNewService_name.Text = query.nameofagency;
            //        txbNewService_address.Text = query.address ;
            //        txbNewService_cellphone.Text = query.cellphone;
            //        txbNewService_fax.Text = query.fax;
            //        txbNewService_telephone.Text = query.telephone;
            //        txbNewService_email.Text = query.emailaddress;
            //    }
            //}

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
            
            //var context = new SeleleEntities();
            //var currentServiceProvider = new agencydetail()
            //{
            //    agency_id = agency_ID, //This will be automatically generated. I'm using a dummy to test queries.
            //    nameofagency = name,
            //    address = address,
            //    telephone = telephone,
            //    emailaddress = emailadress,
            //    fax = fax,
            //    cellphone = cellphone,
            //    service = service
            //};
            ////Add service provider to database
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

            //Query for inserting the service provider
            try
            {
                NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);
                myConnect.Open();
                using (var cmd = new NpgsqlCommand($"INSERT INTO serviceproviders (agency_id,nameofagency,address,telephone,emailaddress,fax,cellphone,service) VALUES (@agency_id,@nameofagency,@address,@telephone,@emailaddress,@fax,@cellphone,@service)", myConnect))
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
