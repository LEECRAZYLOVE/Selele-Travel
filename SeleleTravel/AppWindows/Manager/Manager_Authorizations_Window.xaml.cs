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
    /// Interaction logic for Manager_Authorizations_Window.xaml
    /// </summary>
    public partial class Manager_Authorizations_Window : Window
    {
        public Manager_Authorizations_Window()
        {
            InitializeComponent();
        }

        private void BtnAuthorizations_Authorize_Click(object sender, RoutedEventArgs e)
        {
            // hash the password and the sign in to the database
            string newFreshNew = pdbAuthorizations_password.Password;
        }
    }
}
