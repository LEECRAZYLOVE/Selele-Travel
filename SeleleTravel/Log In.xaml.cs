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
    /// Interaction logic for Log_In.xaml
    /// </summary>
    public partial class Log_In : Window
    {
        public Log_In()
        {
            InitializeComponent();
            //this.WindowState = WindowState.Maximized;
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            //MainWindow.consultantWindow.Show(); //if consultant details correspond with the database
            MainWindow.managerWindow.Show(); //if manager details correspond with the database
           // MainWindow.ownerWindow.Show(); //if owner details correspond with the database
        }

        private void Log_In_Home_Closed(object sender, EventArgs e)
        {
            GeneralMethods.CloseAllWindows();
        }
    }
}
