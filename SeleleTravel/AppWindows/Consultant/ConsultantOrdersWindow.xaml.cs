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
            string orderNumber = txbConsultant_Orders_orderNumber.Text;
            string orderDate = txbConsultant_Orders_orderdate.Text;

            // check if the textboxes are empty or the strings associated with the textboxes
            List<string> stringValueCheck = new List<string> { orderNumber};
            bool checkEmptyStringBool = GeneralMethods.checkEmptytxtBox(stringValueCheck);

            try
            {
                NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);
                myConnect.Open();
                //    quote_no=quote_no,
                //    order_no=order_no,
                //    orderdate=orderdate

                using (var cmd = new NpgsqlCommand($"INSERT INTO TABLE order  (quote_no,order_no,daterecieved,orderdate) VALUES (@quote_no,@order_no,@daterecieved,@orderdate)", myConnect))
                {

                    cmd.Parameters.AddWithValue("quote_no", $"{quote_no}");
                    cmd.Parameters.AddWithValue("order_no", $"{order_no}");
                    cmd.Parameters.AddWithValue("daterecieved", $"{DateTime.Today}");
                    cmd.Parameters.AddWithValue("orderdate", $"{orderDate}");
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {

            }


            // Display data from the database which is belongs to the current quote number
            // 1. Assign the the data to variables so that it becomes easy to store the database again when creating a new order
            // 2. Display the data in the textbox

   

            // reset the textboxes
            List<TextBox> textBoxes = new List<TextBox> { txbConsultant_Orders_orderNumber, txbConsultant_Orders_inputQuote };
            GeneralMethods.clearTextBoxes(textBoxes);
        }

        private void BtnConvsultant_Orders_viewQuote_Click(object sender, RoutedEventArgs e)
        {
            // extract data from the database and display it in the textbox for displaying
            // the data is the one partaining to the current quote number.
            string inputQuote = txbConsultant_Orders_inputQuote.Text;
            //using (SeleleEntities context = new SeleleEntities())
            //{
            //    var query = (from c in context.quotes

            //                 where c.quote_no == inputQuote
            //                 select new
            //                 {
            //                     c.quote_no,
            //                     c.amount,
            //                     c.service,
            //                     c.timequoted,
            //                     c.timesent,
            //                     c.datesent,
            //                     c.quotedate,
            //                     c.consultant_no,
            //                     c.servicefee,
            //                     c.client_no,
            //                     c.clientname

            //                 }).First();

            //    if (query != null)
            //    {
            //        txbConsultant_Orders_viewQuote.Text = $"Quote number: {query.quote_no}\nTotal amount:{query.amount}\n" +
            //            $"Services: {query.service.Replace('|',' ')}\nTime Quoted: {query.timequoted}\nTime sent: {query.timesent}\n" +
            //            $"Date sent: {query.datesent}\nQuote Date: {query.quotedate}\nConsultant number: {query.consultant_no}\n" +
            //            $"Service fee: {query.servicefee}\nClient ID: {query.client_no}\nClient Name: {query.clientname}";
            //    }

            //}
            //Query for retrieving quote data
            try
            {
                NpgsqlConnection myConnect = new NpgsqlConnection(MainWindow.ConnectionString);
                myConnect.Open();
                // c.quote_no,
                //                     c.amount,
                //                     c.service,
                //                     c.timequoted,
                //                     c.timesent,
                //                     c.datesent,
                //                     c.quotedate,
                //                     c.consultant_no,
                //                     c.servicefee,
                //                     c.client_no,
                //                     c.clientname

                using (var cmd = new NpgsqlCommand($"SELECT * FROM quote, order WHERE quote_no = '{inputQuote}'", myConnect))
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
            Owner.Show();
        }
    }
}
