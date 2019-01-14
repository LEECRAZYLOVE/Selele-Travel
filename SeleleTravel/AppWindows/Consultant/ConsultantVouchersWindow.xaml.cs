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
    /// Interaction logic for Consultant_Vouchers_Window.xaml
    /// </summary>
    public partial class ConsultantVouchersWindow : Window
    {
        public ConsultantVouchersWindow()
        {
            InitializeComponent();
        }
        string voucher_no = "";
        string order_no = "";
        string client_id = "";
        string accomm_ID = "";
        string agency_ID = "";
        string staff_ID = "";
        double Voucheramount = 0;

        private void BtnConvsultant_Vouchers_viewOrder_Click(object sender, RoutedEventArgs e)
        {
            //// Exract order number and assign it to the variable used to search
            //string orderNumber = txbConsultant_Vouchers_inputOrder.Text;

            //// Output the desired information 
            //txbConsultant_Vouchers_viewOrder.Text = "";
            // extract data from the database and display it in the textbox for displaying
            // the data is the one partaining to the current quote number.
            string inputOrder = txbConsultant_Vouchers_inputOrder.Text;



        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Owner.Show();
        }

        private void btnConsultant_Vouchers_selectOrder_Click(object sender, RoutedEventArgs e)
        {
            // Link the current order number to the new voucher that will be generated
        }
    }
}
