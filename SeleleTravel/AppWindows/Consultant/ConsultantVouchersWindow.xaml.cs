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

        private void BtnConvsultant_Vouchers_viewOrder_Click(object sender, RoutedEventArgs e)
        {
            // Exract order number and assign it to the variable used to search
            string orderNumber = txbConsultant_Vouchers_inputOrder.Text;

            // Output the desired information 
            txbConsultant_Vouchers_viewOrder.Text = "";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Owner.Show();
        }
    }
}
