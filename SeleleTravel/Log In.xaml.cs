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
        LoadWindow windowToLoad;
        public Log_In(LoadWindow windowToLoad)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.windowToLoad = windowToLoad;
            //this.WindowState = WindowState.Maximized;
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            switch (windowToLoad)
            {
                case LoadWindow.Consultant:
                    MainWindow.consultantWindow = new Consultant_Home_Window();
                    MainWindow.consultantWindow.Show();
                    break;
                case LoadWindow.Manager:
                    MainWindow.managerWindow = new Manager_Home();
                    MainWindow.managerWindow.Show();
                    break;
                case LoadWindow.Owner:
                    MainWindow.ownerWindow = new Owner();
                    MainWindow.ownerWindow.Show();
                    break;
            }
            Hide();
    }

        private void Log_In_Home_Closed(object sender, EventArgs e)
        {
            GeneralMethods.closeAllWindows();
        }
    }
}
