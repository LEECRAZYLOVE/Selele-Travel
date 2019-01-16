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
            NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);

            string checkUserId = txbLogIn_staffID.Text;
            string checkPassword = pdbLogIn_password.Password;
            switch (windowToLoad)
            {
                case LoadWindow.Consultant:
                    ConsultantHomeWindow consultantWindow = new ConsultantHomeWindow();
                    consultantWindow.Owner = Owner;
                    try
                    {
                        myConnect.Open();
                        NpgsqlCommand myCommand = new NpgsqlCommand($"SELECT password, staff_id, stafffirstnames FROM staff", myConnect);
                        NpgsqlDataReader dr = myCommand.ExecuteReader();

                        while (dr.Read())
                        {
                            for (int j = 0; j < dr.FieldCount; j++)
                            {
                                if (checkPassword == dr[0].ToString() && checkUserId == dr[1].ToString())
                                {
                                    consultantWindow.Show();
                                    MessageBox.Show($"Welcome {dr[2]}");
                                    consultantWindow.currentStaffID = dr[1].ToString();
                                    Hide();
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show("Password and Staff ID do not match, or do not exist. Please try again.");

                                }

                            }
                        }
                        myConnect.Close();
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show(h.ToString());
                    }                                      
                    break;

                case LoadWindow.Manager:
                    Manager_Home managerWindow = new Manager_Home();
                    managerWindow.Owner = Owner;
                    try
                    {
                        myConnect.Open();
                        NpgsqlCommand myCommand = new NpgsqlCommand($"SELECT password, staff_id, stafffirstnames FROM staff WHERE staff_id = '{checkUserId}'", myConnect);
                        NpgsqlDataReader dr = myCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            for (int j = 0; j < dr.FieldCount; j++)
                            {
                                if (checkPassword == dr[0].ToString() && checkUserId == dr[1].ToString())
                                {
                                    managerWindow.Show();
                                    MessageBox.Show($"Welcome {dr[2]}");
                                    managerWindow.currentStaffID = dr[1].ToString();
                                    Hide();
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show("Password and Staff ID do not match, or do not exist. Please try again.");

                                }

                            }
                        }
                        myConnect.Close();
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show(h.ToString());
                    }                                      
                    break;

                case LoadWindow.Owner:
                    OwnerHomeWindow ownerWindow = new OwnerHomeWindow();
                    ownerWindow.Owner = Owner;
                    try
                    {
                        myConnect.Open();
                        NpgsqlCommand myCommand = new NpgsqlCommand($"SELECT password, staff_id, stafffirstnames FROM staff WHERE staff_id ='{checkUserId}'", myConnect);
                        NpgsqlDataReader dr = myCommand.ExecuteReader();
                        while (dr.Read())
                        {
                            for (int j = 0; j < dr.FieldCount; j++)
                            {
                                if (checkPassword == dr[0].ToString() && checkUserId == dr[1].ToString())
                                {
                                    ownerWindow.Show();
                                    MessageBox.Show($"Welcome {dr[2]}");
                                    ownerWindow.currentStaffID = dr[1].ToString();
                                    Hide();
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show("Password and Staff ID do not match, or do not exist. Please try again.");

                                }

                            }
                        }
                        myConnect.Close();
                    }
                    catch (Exception h)
                    {
                        MessageBox.Show(h.ToString());
                    }
                    break;
            }
            txbLogIn_staffID.Clear();
            pdbLogIn_password.Clear();

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
