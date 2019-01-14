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
    /// Interaction logic for Log_In.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        LoadWindow windowToLoad;
        public LogInWindow()
        {
            InitializeComponent();
        }

        public LogInWindow(LoadWindow windowToLoad) :this()
        {
            this.windowToLoad = windowToLoad;
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            switch (windowToLoad)
            {
                case LoadWindow.Consultant:
                    ConsultantHomeWindow consultantWindow = new ConsultantHomeWindow();
                    consultantWindow.Owner = Owner;
                    consultantWindow.Show();
                    break;
                case LoadWindow.Manager:
                    Manager_Home managerWindow = new Manager_Home();
                    managerWindow.Owner = Owner;
                    managerWindow.Show();
                    break;
                case LoadWindow.Owner:
                    OwnerHomeWindow ownerWindow = new OwnerHomeWindow();
                    ownerWindow.Owner = Owner;
                    ownerWindow.Show();
                    break;
            }
            Close();
    }

        private void Log_In_Home_Closed(object sender, EventArgs e)
        {
            //GeneralMethods.closeAllWindows();
            if (Application.Current.MainWindow.OwnedWindows.Count <= 0)
                Application.Current.MainWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Owner = Owner;
            signUpWindow.Show();
            Close();
        }
    }
}
