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
using Npgsql;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Compose_Message_Window.xaml
    /// </summary>
    public partial class ComposeMessageWindow : Window
    {
        public string currentStaffID;

        public ComposeMessageWindow()
        {
            InitializeComponent();
        
        }

        /// <summary>
        /// Send message
        /// </summary>
        /// <param name="receiver_ID"> The id of the reciever </param>
        /// <param name="sender_ID"> The id of the sender </param>
        /// <param name="messageToSend"> The message to send </param>
        public void insertMessage(string receiver_ID, string sender_ID, string messageToSend)
        {
            using (var conn = new NpgsqlConnection(MainWindow.ChatConnectionString))
            {
                conn.Open();

                // "INSERT INTO data (some_field) VALUES (@p)"
                //cmd.Parameters.AddWithValue("p", "Hello world");
                //cmd.Parameters.AddWithValue("p", "Hello world");

                // intsert into a table
                using (var cmd = new NpgsqlCommand())
                {
                    // the date now
                    string theDate = DateTime.Now.ToShortDateString();

                    // The command to create the connection
                    cmd.Connection = conn;

                    // INSERT INTO Staff_id (datesent, sender, message) VALUES('1 jan 2018','meloo','Hello');
                    cmd.CommandText = string.Format("INSERT INTO {0} (datesent, sender, message) VALUES('{1}','{2}','{3}')",
                        receiver_ID, theDate, sender_ID, messageToSend);

                    // execute the query
                    cmd.ExecuteNonQuery();
                }

                // intsert into a table
                using (var cmd2 = new NpgsqlCommand())
                {
                    // The date now
                    string theDate = DateTime.Now.ToShortDateString();

                    // The command to create the connection
                    cmd2.Connection = conn;

                    // INSERT INTO messages_tb (datesent, sender, reciever, message) VALUES('1 jan 2018','meloo','ok','Hello');
                    cmd2.CommandText = string.Format("INSERT INTO messages_tb (datesent, sender, reciever, message) VALUES('{0}','{1}','{2}','{3}')",
                        theDate, sender_ID, receiver_ID, messageToSend);

                    // execute the query
                    cmd2.ExecuteNonQuery();
                }

                MessageBox.Show("Message sent!", "Attention");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Owner.Show();
        }

        private void BtnMessage_send_Click(object sender, RoutedEventArgs e)
        {
            // extract the value and assign them to variables
            string staffTo= txbMessage_staffnameTo.Text;
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

                insertMessage(currentStaffID, staffTo, message);
                txbMessage_message.Text = "";

                // clear the textboxes
                List<TextBox> textBoxes = new List<TextBox>();
                textBoxes.Add(txbMessage_staffnameTo);
                textBoxes.Add(txbMessage_subject);
                textBoxes.Add(txbMessage_message);
                GeneralMethods.clearTextBoxes(textBoxes);
            }
        }
    }
}
