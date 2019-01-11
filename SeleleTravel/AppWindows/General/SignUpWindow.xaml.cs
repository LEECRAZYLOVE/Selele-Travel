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
            string checktStaffID = txbSignUp_staffID.Text;
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
                string StaffID = "";
                string password = checkPassword;
                string staff_id = checktStaffID;
                try
                {
                    myConnect.Open();
                    NpgsqlCommand myCommand = new NpgsqlCommand($"UPDATE staff SET password={checkPassword} WHERE staff_id=={checktStaffID}", myConnect);
                    // Add paramaters.
                   
                     myCommand.Parameters.Add(new NpgsqlParameter("password", NpgsqlTypes.NpgsqlDbType.Varchar));

                    //Prepare command
                    myCommand.Prepare();
                    //add value to the parameter
                    myCommand.Parameters[0].Value = checkPassword;
                    //execute the command
                    int recordAffected= myCommand.ExecuteNonQuery();
  

                }
                catch (Exception h)
                {
                    MessageBox.Show(h.ToString());
                }
                //retieve the object, adding the password and saving it into the database
                //using (var context = new SeleleEntities())
                //{
                //    var retrievedEmployee = context.staffs.SingleOrDefault(c => c.staff_id == currentStaffID); //checking where it matches in the database
                //    if (retrievedEmployee != null)
                //    {
                //        retrievedEmployee.password = Password;
                //        context.SaveChanges();

                //        Position = retrievedEmployee.staffposition;
                //        staffFullName = retrievedEmployee.stafffirstnames + ' ' + retrievedEmployee.stafflastname;
                //        StaffID = retrievedEmployee.staff_id;
                //    }
                //}
                MessageBox.Show("Successfully saved into the database. You will now be redirected to your home page.");

                //After signing up the new employee will be redirected to the relevant window
                switch (Position)
                {
                    case "Consultant": this.Hide(); consultantWindow.Show(); break;
                    case "Manager": this.Hide(); managerWindow.Show(); break;
                    case "Owner": this.Hide(); ownerWindow.Show(); break;

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

