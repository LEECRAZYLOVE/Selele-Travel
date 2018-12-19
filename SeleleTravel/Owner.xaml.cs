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
    /// Interaction logic for Owner.xaml
    /// </summary>
    public partial class OwnerHomeWindow : Window
    {
        public OwnerHomeWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        
        private void Owner_Home_Closed(object sender, EventArgs e)
        {
            GeneralMethods.closeAllWindows();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.logOut(this);
        }

        private void btnOwner_search_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
