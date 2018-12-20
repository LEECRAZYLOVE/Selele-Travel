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
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void btnSignUp_done_Click(object sender, RoutedEventArgs e)
        {
            //string currentStaffID = txbSignUp_staffID.Text;
            //  using (SeleleEntities currentEmployee = new SeleleEntities())
            //{
            //   var query = (from c in currentEmployee.staffs
            //    where c.staff_id == currentStaffID 
            //    select new
            //    {
            //        c.staff_id
            //    });
            //}

            //string Password = pdbSignUp_password.Password;
            //string confirmPassword = pdbSignUp_passwordConfirm.Password;

            //if (Password != confirmPassword)
            //{
            //    MessageBox.Show("Password doest not match. Please try again.");
            //    pdbSignUp_password.Clear();
            //    pdbSignUp_passwordConfirm.Clear();
            //    btnSignUp_done_Click(sender, e);
            //}

            //var context = new SeleleEntities();
            //var currentNewEmployee = new staff()
            //{
            //    password = Password
            //};

        }
    }
}
