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
using Devart.Data.MySql;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Owner_Employees_Window.xaml
    /// </summary>
    public partial class OwnerEmployeesWindow : Window
    {
        public OwnerEmployeesWindow()
        {
            InitializeComponent();
        }

        private void btnOwner_search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEmployees_update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEmplyees_find_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNewEmployee_generate_Click(object sender, RoutedEventArgs e)
        {           
           bool boolValue =  GeneralMethods.checkEmptytxtBox(new List<string>() { txbNewEmployee_surname.Text, txbNewEmployee_name.Text, txbNewEmployee_address.Text, txbNewEmployee_city.Text, txbNewEmployee_areaCode.Text, txbEmployee_cellphone.Text, txbNewEmployee_telephone.Text, txbNewEmployee_fax.Text, txbNewEmployee_email.Text, txbNewEmployee_position.Text, txbNewEmployee_salary.Text });

            if (!boolValue) //if all the text boxes are fine then this code will execute
            {
                //Extracting Informtaion
                string Surname = txbNewEmployee_surname.Text;
                string Name = txbNewEmployee_name.Text;
                string FullAddress = GeneralMethods.makeAddress(txbNewEmployee_address.Text, txbNewEmployee_city.Text, txbNewEmployee_areaCode.Text, DropBxNewEmployee_province.SelectionBoxItem.ToString());
                string Cellphone = txbEmployee_cellphone.Text;
                string Telephone = txbNewEmployee_telephone.Text;
                string Fax = txbNewEmployee_fax.Text;
                string Email = txbNewEmployee_email.Text;
                string Position = txbNewEmployee_position.Text;
                double Salary = Convert.ToDouble(txbNewEmployee_salary.Text);

                var context = new SeleleEntities();
                var currentEmployee = new staff()
                {
                    staff_id = GeneralMethods.makeStaffID(Surname, Cellphone),
                    stafffirstnames = Name,
                    stafflastname = Surname,
                    address = FullAddress,
                    cellphone = Cellphone,
                    telephone = Telephone,
                    fax = Fax,
                    email = Email,
                    staffposition = Position,
                    salary = Salary,
                    dateofhire = DateTime.Today
                };
                //Add staff to database
                try
                {
                    context.staffs.Add(currentEmployee);
                    context.SaveChanges();
                    MessageBox.Show($"Succesfully added into the database. New Employee ID is: {currentEmployee.staff_id}");
                }//catching the validation error cause it kept popping up for no reason
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
        }

        private void Owner_Employees_Window_Closed(object sender, EventArgs e)
        {
            Owner?.Show();
            Close();
        }

        private void TxbNewEmployee_salary_TextChanged(object sender, TextChangedEventArgs e)
        {
            GeneralMethods.checkAmountTyped(sender, false);
        }
    }
}
