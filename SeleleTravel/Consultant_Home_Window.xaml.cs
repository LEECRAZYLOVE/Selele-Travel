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

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Consultant_Quotes_Window.xaml
    /// </summary>
    public partial class Consultant_Home_Window : Window
    {
        //instantiating all the windows as global objects
        public static Consultant_Orders_Window consultantOrdersWindow = new Consultant_Orders_Window();
        public static Consultant_Quotes consultantQuotesWindow = new Consultant_Quotes();
        public static Consultant_Update_Window consultantUpdateWindow = new Consultant_Update_Window();
        public static Consultant_Vouchers_Window consultantVouchersWindow = new Consultant_Vouchers_Window();

        public Consultant_Home_Window()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void BtnConsultant_logOut_Click(object sender, RoutedEventArgs e)
        {
            GeneralMethods.logOut(this);
        }

        private void btnConsultant_Quotes_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            consultantQuotesWindow.Show();
            
        }

        private void btnConsultant_search_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
