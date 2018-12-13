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
    public enum LoadWindow { Consultant, Manager, Owner}
    public partial class MainWindow : Window
    {
        //instantiating all the windows as global objects
        public static Log_In logInWindow;
        public static Consultant_Home_Window consultantWindow = new Consultant_Home_Window();
        public static Manager_Home managerWindow = new Manager_Home();
        public static Owner ownerWindow = new Owner();
        public static New_Service_Provider newServiceProviderWindow = new New_Service_Provider();
        
        //Makes all windows spawn in the center of the screen

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

        private void btn_consultantSide_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            logInWindow = new Log_In(LoadWindow.Consultant);
            logInWindow.Show();

        }

        private void btn_managerSide_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            logInWindow = new Log_In(LoadWindow.Manager);
            logInWindow.Show();
        }

        private void btn_bossSide_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            logInWindow = new Log_In(LoadWindow.Owner);
            logInWindow.Show();
            
        }
        
        public string MakeQuoteSummmary () //function that will display the final information for the quote
        {

            return "";
        }
        
    }
}
