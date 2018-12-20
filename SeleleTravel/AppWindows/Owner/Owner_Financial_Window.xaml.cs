﻿using System;
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
    /// Interaction logic for Owner_Financial_Window.xaml
    /// </summary>
    public partial class OwnerFinancialWindow : Window
    {
        public OwnerFinancialWindow()
        {
            InitializeComponent();

            lbFinancial_clientList.Visibility = Visibility.Visible;
            lbFinancial_servicesList.Visibility = Visibility.Hidden;
            cbxFinancial_period.Visibility = Visibility.Visible;
            txbYear.Visibility = Visibility.Hidden;
            cbxMultipleMonths_from.Visibility = Visibility.Hidden;
            cbxMMultipleMonths_to.Visibility = Visibility.Hidden;
            dpMonthly_from.Visibility = Visibility.Hidden;
            dpMonthly_to.Visibility = Visibility.Hidden;
            dpWeekly_day.Visibility = Visibility.Hidden;
            lblYear.Visibility = Visibility.Hidden;
            lblMonthly_from.Visibility = Visibility.Hidden;
            lblMonthly_to.Visibility = Visibility.Hidden;
            lblMultipleMonths_from.Visibility = Visibility.Hidden;
            lblMultipleMonths_to.Visibility = Visibility.Hidden;
            lblWeekly.Visibility = Visibility.Hidden;
        }

        private void Owner_Financial_Window_Closed(object sender, EventArgs e)
        {
            Owner?.Show();
            Close();
        }

        private void CbxitemFinancial_clients_Selected(object sender, RoutedEventArgs e)
        {
            lbFinancial_clientList.Visibility = Visibility.Visible;
            lbFinancial_servicesList.Visibility = Visibility.Hidden;
            //cbxFinancial_period.Visibility = Visibility.Visible;
            txbYear.Visibility = Visibility.Hidden;
            cbxMultipleMonths_from.Visibility = Visibility.Hidden;
            cbxMMultipleMonths_to.Visibility = Visibility.Hidden;
            dpMonthly_from.Visibility = Visibility.Hidden;
            dpMonthly_to.Visibility = Visibility.Hidden;
            dpWeekly_day.Visibility = Visibility.Hidden;

        }

        private void CbxitemFinancial_services_Selected(object sender, RoutedEventArgs e)
        {
            lbFinancial_clientList.Visibility = Visibility.Hidden;
            lbFinancial_servicesList.Visibility = Visibility.Visible;
            //cbxFinancial_period.Visibility = Visibility.Visible;
            txbYear.Visibility = Visibility.Hidden;
            cbxMultipleMonths_from.Visibility = Visibility.Hidden;
            cbxMMultipleMonths_to.Visibility = Visibility.Hidden;
            dpMonthly_from.Visibility = Visibility.Hidden;
            dpMonthly_to.Visibility = Visibility.Hidden;
            dpWeekly_day.Visibility = Visibility.Hidden;
        }

        private void CbxitemFinancial_annually_Selected(object sender, RoutedEventArgs e)
        {
            //lbFinancial_clientList.Visibility = Visibility.Visible;
            //lbFinancial_servicesList.Visibility = Visibility.Hidden;
            //cbxFinancial_period.Visibility = Visibility.Visible;
            txbYear.Visibility = Visibility.Visible;
            cbxMultipleMonths_from.Visibility = Visibility.Hidden;
            cbxMMultipleMonths_to.Visibility = Visibility.Hidden;
            dpMonthly_from.Visibility = Visibility.Hidden;
            dpMonthly_to.Visibility = Visibility.Hidden;
            dpWeekly_day.Visibility = Visibility.Hidden;
            lblYear.Visibility = Visibility.Visible;
            lblMonthly_from.Visibility = Visibility.Hidden;
            lblMonthly_to.Visibility = Visibility.Hidden;
            lblMultipleMonths_from.Visibility = Visibility.Hidden;
            lblMultipleMonths_to.Visibility = Visibility.Hidden;
            lblWeekly.Visibility = Visibility.Hidden;
        }

        private void CbxitemFinancial_multipleMonths_Selected(object sender, RoutedEventArgs e)
        {
            //lbFinancial_clientList.Visibility = Visibility.Visible;
            //lbFinancial_servicesList.Visibility = Visibility.Hidden;
            //cbxFinancial_period.Visibility = Visibility.Visible;
            txbYear.Visibility = Visibility.Hidden;
            cbxMultipleMonths_from.Visibility = Visibility.Hidden;
            cbxMMultipleMonths_to.Visibility = Visibility.Hidden;
            dpMonthly_from.Visibility = Visibility.Visible;
            dpMonthly_to.Visibility = Visibility.Visible;
            dpWeekly_day.Visibility = Visibility.Hidden;
            lblYear.Visibility = Visibility.Hidden;
            lblMonthly_from.Visibility = Visibility.Hidden;
            lblMonthly_to.Visibility = Visibility.Hidden;
            lblMultipleMonths_from.Visibility = Visibility.Visible;
            lblMultipleMonths_to.Visibility = Visibility.Visible;
            lblWeekly.Visibility = Visibility.Hidden;
        }

        private void CbxitemFinancial_monthly_Selected(object sender, RoutedEventArgs e)
        {
            //lbFinancial_clientList.Visibility = Visibility.Visible;
            //lbFinancial_servicesList.Visibility = Visibility.Hidden;
            //cbxFinancial_period.Visibility = Visibility.Visible;
            txbYear.Visibility = Visibility.Hidden;
            cbxMultipleMonths_from.Visibility = Visibility.Hidden;
            cbxMMultipleMonths_to.Visibility = Visibility.Hidden;
            dpMonthly_from.Visibility = Visibility.Visible;
            dpMonthly_to.Visibility = Visibility.Visible;
            dpWeekly_day.Visibility = Visibility.Hidden;
            lblYear.Visibility = Visibility.Hidden;
            lblMonthly_from.Visibility = Visibility.Visible;
            lblMonthly_to.Visibility = Visibility.Visible;
            lblMultipleMonths_from.Visibility = Visibility.Hidden;
            lblMultipleMonths_to.Visibility = Visibility.Hidden;
            lblWeekly.Visibility = Visibility.Hidden;
        }

        private void CbxitemFinancial_weekly_Selected(object sender, RoutedEventArgs e)
        {
            //lbFinancial_clientList.Visibility = Visibility.Visible;
            //lbFinancial_servicesList.Visibility = Visibility.Hidden;
            //cbxFinancial_period.Visibility = Visibility.Visible;
            txbYear.Visibility = Visibility.Hidden;
            cbxMultipleMonths_from.Visibility = Visibility.Hidden;
            cbxMMultipleMonths_to.Visibility = Visibility.Hidden;
            dpMonthly_from.Visibility = Visibility.Hidden;
            dpMonthly_to.Visibility = Visibility.Hidden;
            dpWeekly_day.Visibility = Visibility.Visible;
            lblYear.Visibility = Visibility.Hidden;
            lblMonthly_from.Visibility = Visibility.Hidden;
            lblMonthly_to.Visibility = Visibility.Hidden;
            lblMultipleMonths_from.Visibility = Visibility.Hidden;
            lblMultipleMonths_to.Visibility = Visibility.Hidden;
            lblWeekly.Visibility = Visibility.Visible;
        }
    }
}