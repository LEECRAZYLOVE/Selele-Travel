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
            bool boolValue = GeneralMethods.checkEmptytxtBox(txbNewEmployee_surname.Text, 
                txbNewEmployee_name.Text, txbNewEmployee_address.Text, txbNewEmployee_city.Text, txbNewEmployee_areaCode.Text, 
                txbEmployee_cellphone.Text, txbNewEmployee_telephone.Text, txbNewEmployee_fax.Text, txbNewEmployee_email.Text, 
                cmbNewEmployee_position.Text, txbNewEmployee_salary.Text );

            NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);

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
                string Position = cmbNewEmployee_position.Text;
                double Salary = Convert.ToDouble(txbNewEmployee_salary.Text);

                try
                {
                    myConnect.Open();
                    NpgsqlCommand myCommand = new NpgsqlCommand($"INSERT INTO staff (staff_id, stafffirstnames,stafflastname,address,cellphone,telephone,fax,staffposition,salary,dateofhire) " +
                        $"VALUES ('{GeneralMethods.makeStaffID(Surname, Cellphone)}', '{Name}', '{Surname}', '{FullAddress}', '{Cellphone}', '{Telephone}', '{Fax}', '{Position}', '{Salary}', '{DateTime.Today.ToString().Substring(0, 10)}') ", myConnect);
                    myCommand.ExecuteNonQuery();
                    MessageBox.Show($"Succesfully added into the database. New Employee ID is: {GeneralMethods.makeStaffID(Surname, Cellphone)}");
                    GeneralMethods.clearTextBoxes(txbNewEmployee_surname, txbNewEmployee_name, txbNewEmployee_address,
                        txbNewEmployee_city, txbNewEmployee_areaCode, txbEmployee_cellphone, txbNewEmployee_telephone,
                        txbNewEmployee_fax, txbNewEmployee_email, txbNewEmployee_salary);
                }
                catch (Exception h)
                {
                    MessageBox.Show(h.ToString());
                }

                // Creates a table in the database            
                using (var conn = new NpgsqlConnection(MainWindow.ChatConnectionString))
                {
                    // open the connection
                    conn.Open();

                    // create a table
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = string.Format("CREATE TABLE {0} ("
                                                      + "tb_ID         serial          NOT NULL,"
                                                      + "DateSent      varchar(30)     NOT NULL,"
                                                      + "sender        varchar(30)     NOT NULL,"
                                                      + "reciever      varchar(30)     NOT NULL,"
                                                      + "message       varchar(500)    NOT NULL,"
                                                      + "PRIMARY KEY(tb_ID)"
                                                      + ")", GeneralMethods.makeStaffID(Surname, Cellphone));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Table created", "Attention");
                    }

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
       
        }
    }
}
