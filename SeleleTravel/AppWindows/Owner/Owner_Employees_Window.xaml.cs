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
            bool boolValue = GeneralMethods.checkEmptytxtBox(new List<string>() { txbNewEmployee_surname.Text, txbNewEmployee_name.Text, txbNewEmployee_address.Text, txbNewEmployee_city.Text, txbNewEmployee_areaCode.Text, txbEmployee_cellphone.Text, txbNewEmployee_telephone.Text, txbNewEmployee_fax.Text, txbNewEmployee_email.Text, txbNewEmployee_position.Text, txbNewEmployee_salary.Text });

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

                    staffposition = Position,
                    salary = Salary,
                    dateofhire = DateTime.Today
                };
                //Add staff to database
                try
                {
                    //context.staffs.Add(currentEmployee);
                    //context.SaveChanges();
                    MessageBox.Show($"Succesfully added into the database. New Employee ID is: {currentEmployee.staff_id}");
                    GeneralMethods.clearTextBoxes(new List<TextBox>() { txbNewEmployee_surname, txbNewEmployee_name, txbNewEmployee_address, txbNewEmployee_city, txbNewEmployee_areaCode, txbEmployee_cellphone, txbNewEmployee_telephone, txbNewEmployee_fax, txbNewEmployee_email, txbNewEmployee_position, txbNewEmployee_salary });
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

        private void btnEmplyees_find_Click_1(object sender, RoutedEventArgs e)
        {
        //    string staff_ID = txbEmployees_find.Text;
        //    string staffName = txbEmployee_Name.Text;
        //    if (staff_ID != "")
        //    {
        //        using (SeleleEntities currentStaff = new SeleleEntities())
        //        {
        //            var query = (from c in currentStaff.staffs

        //                         where c.staff_id == staff_ID
        //                         select new
        //                         {
        //                             c.staff_id,
        //                             c.address,
        //                             c.cellphone,
        //                             c.dateofhire,
        //                             c.fax,
        //                             c.salary,
        //                             c.stafffirstnames,
        //                             c.stafflastname,
        //                             c.staffposition,
        //                             c.telephone,

        //                         }).First();

        //            if (query != null)
        //            {

        //                ltbEmployees_employeeDetails.Items.Add($"Staff ID: {query.staff_id}");
        //                ltbEmployees_employeeDetails.Items.Add($"staff first names:{query.stafffirstnames}");
        //                ltbEmployees_employeeDetails.Items.Add($"staff last name: {query.stafflastname}");
        //                ltbEmployees_employeeDetails.Items.Add($"staff position: {query.staffposition}");
        //                ltbEmployees_employeeDetails.Items.Add($"dateofhire: {query.dateofhire}");
        //                ltbEmployees_employeeDetails.Items.Add($"salary: {query.salary}");
        //                ltbEmployees_employeeDetails.Items.Add($"cellphone: {query.cellphone}");
        //                ltbEmployees_employeeDetails.Items.Add($"telephone: {query.telephone}");
        //            }

        //        }

        //    }
        //    else if (staffName != "")
        //    {
        //        using (SeleleEntities currentStaff = new SeleleEntities())
        //        {
        //            var query = (from c in currentStaff.staffs

        //                         where c.stafffirstnames == staffName
        //                         select new
        //                         {
        //                             c.staff_id,
        //                             c.address,
        //                             c.cellphone,
        //                             c.dateofhire,
        //                             c.fax,
        //                             c.salary,
        //                             c.stafffirstnames,
        //                             c.stafflastname,
        //                             c.staffposition,
        //                             c.telephone,

        //                         }).First();

        //            if (query != null)
        //            {

        //                ltbEmployees_employeeDetails.Items.Add($"Staff ID: {query.staff_id}");
        //                ltbEmployees_employeeDetails.Items.Add($"staff first names:{query.stafffirstnames}");
        //                ltbEmployees_employeeDetails.Items.Add($"staff last name: {query.stafflastname}");
        //                ltbEmployees_employeeDetails.Items.Add($"staff position: {query.staffposition}");
        //                ltbEmployees_employeeDetails.Items.Add($"dateofhire: {query.dateofhire}");
        //                ltbEmployees_employeeDetails.Items.Add($"salary: {query.salary}");
        //                ltbEmployees_employeeDetails.Items.Add($"cellphone: {query.cellphone}");
        //                ltbEmployees_employeeDetails.Items.Add($"telephone: {query.telephone}");
        //            }
        //        }

        //    }
        }
    }
}
