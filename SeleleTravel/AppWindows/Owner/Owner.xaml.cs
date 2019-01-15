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
using System.Data;
using System.Windows.Threading;
using Npgsql;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Owner.xaml
    /// </summary>
    public partial class OwnerHomeWindow : Window
    {
        public OwnerFinancialWindow ownerFinancialWindow;
        public OwnerEmployeesWindow ownerEmployeesWindow;
        public OwnerPaymentsWindow ownerPaymentsWindow;
        // time to update
        DispatcherTimer theLoadingTime;
        public OwnerHomeWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
     

        }

        private void btnOwner_search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOwner_financialSummary_Click(object sender, RoutedEventArgs e)
        {
            ownerFinancialWindow = new OwnerFinancialWindow();
            ownerFinancialWindow.Owner = this;
            ownerFinancialWindow.Show();
            Hide();
        }

        private void BtnOwner_Employees_Click(object sender, RoutedEventArgs e)
        {
            ownerEmployeesWindow = new OwnerEmployeesWindow();
            ownerEmployeesWindow.Owner = this;
            ownerEmployeesWindow.Show();
            Hide();
        }

        private void BtnOwner_composeMessage_Click(object sender, RoutedEventArgs e)
        {
            ComposeMessageWindow composeMessageWindow = new ComposeMessageWindow();
            composeMessageWindow.Owner = this;
            composeMessageWindow.Show();
            Hide();
        }

        private void BtnOwner_paymentProofs_Click(object sender, RoutedEventArgs e)
        {
            ownerPaymentsWindow = new OwnerPaymentsWindow();
            ownerPaymentsWindow.Owner = this;
            ownerPaymentsWindow.Show();
            Hide();
            MainWindow mainwindow = new MainWindow();
            mainwindow.Hide();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnOwner_logOut_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.logOut(this);
        }
    }
}
