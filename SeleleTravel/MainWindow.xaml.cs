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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
//using Devart.Data.MySql;
//using Npgsql;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum LoadWindow { Consultant, Manager, Owner}
    public partial class MainWindow : Window
    {
        //instantiating all the windows as global objects
        public static LogInWindow logInWindow;
        

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Application.Current.MainWindow = this;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this.WindowState = WindowState.Maximized;
        }
        private void loadLogInWindow(LoadWindow windowToLoad)
        {
            logInWindow = new LogInWindow(windowToLoad);
            logInWindow.Owner = this;
            logInWindow.Show();
        }

        private void btn_consultantSide_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            loadLogInWindow(LoadWindow.Consultant);

        }

        private void btn_managerSide_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            loadLogInWindow(LoadWindow.Manager);
        }

        private void btn_bossSide_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            loadLogInWindow(LoadWindow.Owner);
        }
        
        public string MakeQuoteSummmary () //function that will display the final information for the quote
        {

            return "";
        }

        private void Home_Page_Closed(object sender, EventArgs e)
        {
            GeneralMethods.closeAllWindows();
        }
    }
}
