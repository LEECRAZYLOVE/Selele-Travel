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
using System.IO;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Compose_Message_Window.xaml
    /// </summary>
    public partial class ComposeMessageWindow : Window
    {
        public ComposeMessageWindow()
        {
            InitializeComponent();
        
        }

        private void BtnMessage_send_Click(object sender, RoutedEventArgs e)
        {
            // extract the value and assign them to variables
            string nameOrStaff_id = txbMessage_name.Text;
            string subjectOFmassage = txbMessage_subject.Text;
            string message = txbMessage_message.Text;

            // CHECK FOR ERRORS 
            // 1. check if the staff id or name exist in the databse
            // 2. check empty textboxes/variables

            // 1.

            // 2.
            List<string> stringVs = new List<string>();
            stringVs.Add(subjectOFmassage);
            stringVs.Add(message);
            bool t_or_f = GeneralMethods.checkEmptytxtBox(stringVs);

            if (!t_or_f)
            {
                // .. todo


                // clear the textboxes
                List<TextBox> textBoxes = new List<TextBox>();
                textBoxes.Add(txbMessage_name);
                textBoxes.Add(txbMessage_subject);
                textBoxes.Add(txbMessage_message);
                GeneralMethods.clearTextBoxes(textBoxes);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Owner.Show();
        }
    }
}
