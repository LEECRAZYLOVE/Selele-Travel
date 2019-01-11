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
using Npgsql;

namespace SeleleTravel
{   
    /// <summary>
    /// Interaction logic for Log_In.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        LoadWindow windowToLoad;
        public static SignUpWindow signUpWindow = new SignUpWindow();
        public static MainWindow mainWindow = new MainWindow();
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
           
            try
            {
                NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);
                myConnect.Open();
                NpgsqlCommand myCommand = new NpgsqlCommand("SELECT * FROM staff", myConnect);
                NpgsqlDataReader dr = myCommand.ExecuteReader();
                string nje = "";
                int j = 0;
                while (dr.Read())
                {
                    for (int k = 0; k < dr.FieldCount; k++)
                    {
                        nje += string.Format("{0}\n", dr[k]);
                    }
                }
                MessageBox.Show(nje);
                myConnect.Close();
            }
            catch (Exception h)
            {
                MessageBox.Show(h.ToString());
            }
           
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

            Hide();
    }

        private void Log_In_Home_Closed(object sender, EventArgs e)
        {
            Hide();
            mainWindow.Show();
            //Application.Current.MainWindow.Show();
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            signUpWindow.Show();
            
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            mainWindow.Show();
        }
    }
}
