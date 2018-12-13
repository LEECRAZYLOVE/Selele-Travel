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
            //this.WindowState = WindowState.Maximized;
        }

        private void createNewClient_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void New_Service_Provider_Home_Closed(object sender, EventArgs e)
        {
            GeneralMethods.CloseAllWindows();
        }
    }
}
