//using Devart.Data.MySql;
using Npgsql;
using System;
using System.Windows;

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
        public static ConsultantHomeWindow consultantWindow = new ConsultantHomeWindow();
        public static Manager_Home managerWindow = new Manager_Home();
        public static OwnerHomeWindow ownerWindow = new OwnerHomeWindow();
        string staffID = "";
        string staffName = "";
        public LogInWindow()
        {
            InitializeComponent();
        }

        public LogInWindow(LoadWindow windowToLoad) : this()
        {
            this.windowToLoad = windowToLoad;
        }

        #region Helper Methods

        private bool loginViaDatabase(string staffID, string password)
        {
            NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);
            try
            {
                myConnect.Open();
                NpgsqlCommand myCommand = new NpgsqlCommand($"SELECT password, staff_id, stafffirstnames FROM staff WHERE staff_id = '{staffID}'", myConnect);
                NpgsqlDataReader dr = myCommand.ExecuteReader();

                while (dr.Read())
                {
                    bool checkedAll = false;
                    for (int j = 0; j < dr.FieldCount; j++)
                    {
                        if (password == dr[0].ToString() && staffID == dr[1].ToString())
                        {
                            MessageBox.Show($"Welcome {dr[2]}");
                            staffID = dr[1].ToString();
                            staffName = dr[2].ToString();
                            Hide();
                            break;
                        }
                        checkedAll = j + 1 == dr.FieldCount;
                    }
                    if (checkedAll)
                    {
                        MessageBox.Show("Password and Staff ID do not match, or do not exist. Please try again.");
                    }
                }
                myConnect.Close();
            }
            catch (Exception h)
            {
                MessageBox.Show(h.ToString());
                return false;
            }
            return true;
        }

        #endregion

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            string staffID = txbLogIn_staffID.Text;
            string password = pdbLogIn_password.Password;

            switch (windowToLoad)
            {
                case LoadWindow.Consultant:
                    ConsultantHomeWindow consultantWindow = new ConsultantHomeWindow();
                    consultantWindow.Owner = Owner;
                    //If we connect properly to the database
                    if (loginViaDatabase(staffID, password))
                    {
                        consultantWindow.currentStaffID = staffID;
                        consultantWindow.lblConsultantName.Content = staffName;
                        consultantWindow.lblConsultantID.Content = staffID;
                        consultantWindow.Show();
                    }
                    break;

                case LoadWindow.Manager:
                    Manager_Home managerWindow = new Manager_Home();
                    managerWindow.Owner = Owner;
                    //If we connect properly to the database
                    if (loginViaDatabase(staffID, password))
                    {
                        managerWindow.currentStaffID = staffID;
                        managerWindow.lblManagerName.Content = staffName;
                        managerWindow.lblManagerID.Content = staffID;
                        managerWindow.Show();
                    }
                    break;

                case LoadWindow.Owner:
                    OwnerHomeWindow ownerWindow = new OwnerHomeWindow();
                    ownerWindow.Owner = Owner;
                    //If we connect properly to the database
                    if (loginViaDatabase(staffID, password))
                    {
                        ownerWindow.currentStaffID = staffID;
                        ownerWindow.lblOwnerID.Content = staffID;
                        ownerWindow.lblOwnerName.Content = staffName;
                        ownerWindow.Show();
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
