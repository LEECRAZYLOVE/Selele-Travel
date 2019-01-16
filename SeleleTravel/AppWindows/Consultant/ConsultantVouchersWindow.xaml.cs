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
using Npgsql;

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
            // extract data from the database and display it in the textbox for displaying
            // the data is the one partaining to the current quote number.
            string inputOrder = txbConsultant_Vouchers_inputOrder.Text;
            
            //Query for retrieving order data
            try
            {
                NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);
                myConnect.Open();

                using (var cmd = new NpgsqlCommand($"SELECT * FROM orders WHERE order_no = '{inputOrder}'", myConnect))
                {
                    NpgsqlDataReader query = cmd.ExecuteReader();
                    while (query.Read())
                    {
                        txbConsultant_Vouchers_viewOrder.Text = $"Order_no: {query[0]}\nQuote_no:{query[1]}\n" +
                        $"Date received: {query[2]}\nOrder date: {query[3]}";
                    }
                    myConnect.Close();
                }
            }
            catch (Exception h)
            {
                MessageBox.Show(h.ToString());
            }
            //// Output the desired information 
            //txbConsultant_Vouchers_viewOrder.Text = "";
            // extract data from the database and display it in the textbox for displaying
            // the data is the one partaining to the current quote number.


        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnConsultant_Vouchers_selectOrder_Click(object sender, RoutedEventArgs e)
        {
            // Link the current order number to the new voucher that will be generated
            order_no = txbConsultant_Vouchers_inputOrder.Text;
        }

        private void btnConsultant_Voucher_addNewVoucher_Click(object sender, RoutedEventArgs e)
        {
            voucher_no = GeneralMethods.makeVoucher_no();
            txbConsultsnt_Vouchers_outputVoucherNumber.Text = voucher_no;
            try
            {
                NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);
                myConnect.Open();
               
                using (var cmd = new NpgsqlCommand($"INSERT INTO voucher (voucher_no,order_no,client_id,accomm_id,agency_id,staff_id,amount) VALUES (@voucher_no,@order_no,@client_id,@accomm_id,@agency_id,@staff_id,@amount)", myConnect))
                {

                    cmd.Parameters.AddWithValue("voucher_no",voucher_no);
                    cmd.Parameters.AddWithValue("order_no",order_no);
                    cmd.Parameters.AddWithValue("client_id",client_id);
                    cmd.Parameters.AddWithValue("accomm_id",accomm_ID);
                    cmd.Parameters.AddWithValue("agency_id",agency_ID);
                    cmd.Parameters.AddWithValue("staff_id",staff_ID);
                    cmd.Parameters.AddWithValue("amount",Voucheramount);
                   
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {

            }
        }
    }
}
