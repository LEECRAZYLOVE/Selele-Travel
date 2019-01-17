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
using Npgsql;
//using Devart.Data.MySql;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Consultant_Orders_Window.xaml
    /// </summary>
    public partial class ConsultantOrdersWindow : Window
    {
        public ConsultantOrdersWindow()
        {
            InitializeComponent();
        }
        //Variables for the order
        string order_no = "";
        string quote_no = "";
        DateTime datereceived;

        private void BtnConsultant_Orders_addNewOrder_Click(object sender, RoutedEventArgs e)
        {
            // Extract and assign to variables
            order_no = txbConsultant_Orders_orderNumber.Text;
            string orderDate = txbConsultant_Orders_orderdate.Text;

            // check if the textboxes are empty or the strings associated with the textboxes
            bool checkEmptyStringBool = GeneralMethods.checkEmptytxtBox(order_no);

            try
            {
                NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);
                myConnect.Open();
                using (var cmd = new NpgsqlCommand($"INSERT INTO orders (quote_no,order_no,datereceived,orderdate) VALUES (@quote_no,@order_no,@datereceived,@orderdate)", myConnect))
                {

                    cmd.Parameters.AddWithValue("quote_no",quote_no);
                    cmd.Parameters.AddWithValue("order_no", order_no);
                    cmd.Parameters.AddWithValue("datereceived", DateTime.Today.ToString().Substring(0,10));
                    cmd.Parameters.AddWithValue("orderdate", orderDate);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully added into the database.");
                }
            }
            catch (Exception h)
            {
                MessageBox.Show(h.ToString());
            }


            // Display data from the database which is belongs to the current quote number
            // 1. Assign the the data to variables so that it becomes easy to store the database again when creating a new order
            // 2. Display the data in the textbox

   

            // reset the textboxes
            GeneralMethods.clearTextBoxes(txbConsultant_Orders_orderNumber, txbConsultant_Orders_inputQuote);
        }

        private void BtnConvsultant_Orders_viewQuote_Click(object sender, RoutedEventArgs e)
        {
            // extract data from the database and display it in the textbox for displaying
            // the data is the one partaining to the current quote number.
            string inputQuote = txbConsultant_Orders_inputQuote.Text;
            //Query for retrieving quote data
            try
            {
                NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);
                myConnect.Open();
                using (var cmd = new NpgsqlCommand($"SELECT * FROM quote WHERE quote_no = '{inputQuote}'", myConnect))
                {
                    NpgsqlDataReader query = cmd.ExecuteReader();

                    while (query.Read())
                    {
                        txbConsultant_Orders_viewQuote.Text = $"Quote number: {query[0]}\nTotal amount:{query[1]}\n" +
                        $"Services: {query[2].ToString().Replace('|', ' ')}\nTime Quoted: {query[3]}\nTime sent: {query[4]}\n" +
                        $"Date sent: {query[5]}\nQuote Date: {query[6]}\nConsultant number: {query[7]}\n" +
                        $"Service fee: {query[8]}\nClient ID: {query[9]}\nClient Name: {query[10]}";
                    }
                    myConnect.Close();
                }
            }
            catch (Exception h)
            {
                MessageBox.Show(h.ToString());
            }
        }
        private void BtnConsultant_Orders_selectQuote_Click(object sender, RoutedEventArgs e)
        {
            // Link the current quote number to the new order that will be generated
            quote_no = txbConsultant_Orders_inputQuote.Text;
            
        }
    
        private void Window_Closed(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
