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
using Npgsql;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public static ConsultantHomeWindow consultantWindow = new ConsultantHomeWindow();
        public static Manager_Home managerWindow = new Manager_Home();
        public static OwnerHomeWindow ownerWindow = new OwnerHomeWindow();
        public static MainWindow mainWindow = new MainWindow();
        public SignUpWindow()
        {
            InitializeComponent();
        }
        
        private void btnSignUp_done_Click(object sender, RoutedEventArgs e)
        {
            NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);
            string checkStaffID = txbSignUp_staffID.Text;
            string checkPassword = pdbSignUp_password.Password;
            string checkConfirmPassword = pdbSignUp_passwordConfirm.Password;

            if (checkPassword != checkConfirmPassword)
            {
                MessageBox.Show("Password doest not match. Please try again.");
                pdbSignUp_password.Clear();
                pdbSignUp_passwordConfirm.Clear();
                pdbSignUp_password.Clear();
                pdbSignUp_passwordConfirm.Clear();
            }
            else if (checkPassword == checkConfirmPassword)
            {
                string Position = "";
                string staffFullName = "";
                string password = checkPassword;
                string staff_id = checkStaffID;
                //Query for updating the password side
                try
                {
                    myConnect.Open();
                    NpgsqlCommand myCommand = new NpgsqlCommand($"UPDATE staff SET password='{checkPassword}' WHERE staff_id = '{checkStaffID}'", myConnect);
                    // Add paramaters.
                   
                     myCommand.Parameters.Add(new NpgsqlParameter("password", NpgsqlTypes.NpgsqlDbType.Varchar));
                     myCommand.Parameters.Add(new NpgsqlParameter("staff_id", NpgsqlTypes.NpgsqlDbType.Varchar));
                     
                    //add value to the parameter
                    myCommand.Parameters[0].Value = checkPassword;
                    myCommand.Parameters[1].Value = checkStaffID;

                    //execute the command
                    myCommand.ExecuteNonQuery();
                }
                catch (Exception h)
                {
                    MessageBox.Show(h.ToString());
                }

                try
                {
                    NpgsqlCommand myCommand = new NpgsqlCommand($"SELECT staffposition, stafffirstnames FROM staff WHERE staff_id = '{checkStaffID}'", myConnect);
                    // Add paramaters.
                    NpgsqlDataReader dr = myCommand.ExecuteReader();
                    while (dr.Read())
                    {          
                        for (int k = 0; k < dr.FieldCount; k++)
                        {
                            Position = string.Format("{0}", dr[0]);
                            staffFullName = dr[1].ToString();
                        }
                    }
                    MessageBox.Show("Successfully saved into the database. You will now be redirected to your home page.");
                    //After signing up the new employee will be redirected to the relevant window
                    switch (Position)
                    {
                        case "Consultant": this.Hide(); consultantWindow.Show(); consultantWindow.lblConsultantName.Content = staffFullName; consultantWindow.lblConsultantID.Content = staff_id; consultantWindow.currentStaffID = staff_id; break;
                        case "Manager": this.Hide(); managerWindow.Show(); managerWindow.lblManagerName.Content = staffFullName; managerWindow.lblManagerID.Content = staff_id; managerWindow.currentStaffID = staff_id; break;
                        case "Owner": this.Hide(); ownerWindow.Show(); ownerWindow.lblOwnerName.Content = staffFullName; ownerWindow.lblOwnerID.Content = staff_id; ownerWindow.currentStaffID = staff_id; break;

                    }
                }
                catch (Exception h)
                {
                    MessageBox.Show(h.ToString());
                }

               
            }
        }

        private void BtnSignUp_goBack_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            Application.Current.MainWindow.Show();
           // mainWindow.Show();
        }

        private void Sign_Up_Home_Closed(object sender, EventArgs e)
        {
            Hide();
            mainWindow.Show();
            //Application.Current.MainWindow.Show();
        }
    }
    
}

