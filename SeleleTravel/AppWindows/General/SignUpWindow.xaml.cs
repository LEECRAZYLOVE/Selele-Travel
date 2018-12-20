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
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public static ConsultantHomeWindow consultantWindow = new ConsultantHomeWindow();
        public static Manager_Home managerWindow = new Manager_Home();
        public static OwnerHomeWindow ownerWindow = new OwnerHomeWindow();

        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void btnSignUp_done_Click(object sender, RoutedEventArgs e)
        {
            string currentStaffID = txbSignUp_staffID.Text;
            string Password = pdbSignUp_password.Password;
            string confirmPassword = pdbSignUp_passwordConfirm.Password;

            if (Password != confirmPassword)
            {
                MessageBox.Show("Password doest not match. Please try again.");
                pdbSignUp_password.Clear();
                pdbSignUp_passwordConfirm.Clear();
                btnSignUp_done_Click(sender, e);
            }

            string Position = "";
            string staffFullName = "";
            string StaffID = "";
            //retieve the object, adding the password and saving it into the database
            using (var context = new SeleleEntities())
            {
                var retrievedEmployee = context.staffs.SingleOrDefault(c => c.staff_id == currentStaffID); //checking where it matches in the database
                if (retrievedEmployee != null)
                {
                    retrievedEmployee.password = Password;
                    context.SaveChanges();

                    Position = retrievedEmployee.staffposition;
                    staffFullName = retrievedEmployee.stafffirstnames + ' ' + retrievedEmployee.stafflastname;
                    StaffID = retrievedEmployee.staff_id;
                }
            }
            MessageBox.Show("Successfully saved into the database. You will now be redirected to your home page.");
            switch (Position)
            {
                case "Consultant": consultantWindow.Show(); break;
                case "Manager": managerWindow.Show(); break;
                case "Owner" : ownerWindow.Show(); break;
                
            }
        }
    }
    
}

