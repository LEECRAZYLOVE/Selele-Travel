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
using Devart.Data.MySql;

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

        private void BtnConsultant_Orders_addNewOrder_Click(object sender, RoutedEventArgs e)
        {
            // Extract and assign to variables
            string orderNumber = txbConsultant_Orders_orderNumber.Text;
            string quoteNumber = txbConsultant_Orders_inputQuote.Text;

            // check if the textboxes are empty or the strings associated with the textboxes
            List<string> stringValueCheck = new List<string> { orderNumber, quoteNumber };
            bool checkEmptyStringBool = GeneralMethods.checkEmptytxtBox(stringValueCheck);

            if (!checkEmptyStringBool)
            {
                // Add order number to the service details saved in the csv file
                GeneralMethods.linkOrderNumberInCSVfile(quoteNumber, orderNumber);
            }
            
            // Display data from the database which is belongs to the current quote number
            // 1. Assign the the data to variables so that it becomes easy to store the database again when creating a new order
            // 2. Display the data in the textbox

            txbConsultant_Orders_viewQuote.Text = ""; // DISPLAY TEXTBOX 

            // 

            // reset the textboxes
            List<TextBox> textBoxes = new List<TextBox> { txbConsultant_Orders_orderNumber, txbConsultant_Orders_inputQuote };
            GeneralMethods.clearTextBoxes(textBoxes);
        }

        private void BtnConvsultant_Orders_viewQuote_Click(object sender, RoutedEventArgs e)
        {
            // extract data from the database and display it in the textbox for displaying
            // the data is the one partaining to the current quote number.


        }

        private void BtnConsultant_Orders_selectQuote_Click(object sender, RoutedEventArgs e)
        {
            // Link the current quote number to the new order that will be generated

        }
    }
}
