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
//using Npgsql;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        //instantiating all the windows as global objects
        public static Log_In logInWindow = new Log_In();
        public static Consultant consultantWindow = new Consultant();
        public static Manager_Home managerWindow = new Manager_Home();
        public static Owner ownerWindow = new Owner();
        public static New_Service_Provider newServiceProviderWindow = new New_Service_Provider();
        //Makes all windows spawn in the center of the screen
        void MakeWindowsSpawnInScreenCenter()
        {
            logInWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            consultantWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            managerWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ownerWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            newServiceProviderWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        public MainWindow()
        {
            InitializeComponent();
            MakeWindowsSpawnInScreenCenter();
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this.WindowState = WindowState.Maximized;
        }

        private void btn_consultantSide_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            logInWindow.Show();
        }

        private void btn_managerSide_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            logInWindow.Show();
        }

        private void btn_bossSide_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            logInWindow.Show();
            
        }
        
        public string MakeQuoteSummmary () //function that will display the final information for the quote
        {

            return "";
        }

    }
}
