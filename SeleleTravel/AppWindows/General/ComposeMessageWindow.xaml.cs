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

                     // don't these now because they need the user to select the id of the user
                     txbMessage_message.IsEnabled = false;
                     btnMessage_send.IsEnabled = false;
              }

        /// <summary>
        /// Send message
        /// </summary>
        /// <param name="receiver_ID"> The id of the reciever </param>
        /// <param name="sender_ID"> The id of the sender </param>
        /// <param name="messageToSend"> The message to send </param>
        public void insertMessage(string receiver_ID, string sender_ID, string messageToSend)
        {
            try
            {
                using (var conn = new NpgsqlConnection(MainWindow.ChatConnectionString))
                {
                    conn.Open();

                    // "INSERT INTO data (some_field) VALUES (@p)"
                    //cmd.Parameters.AddWithValue("p", "Hello world");
                    //cmd.Parameters.AddWithValue("p", "Hello world");

                    // intsert into a table
                    using (var cmd = new NpgsqlCommand($"INSERT INTO {receiver_ID} (datesent, sender, reciever, message) VALUES(@theDate,@sender_ID,@receiver_ID,@messageTosend)", conn))
                    {
                        // the date now
                        string theDate = DateTime.Now.ToShortDateString();

                        // INSERT INTO Staff_id (datesent, sender, message) VALUES('1 jan 2018','meloo','Hello');
                        cmd.Parameters.AddWithValue("theDate", theDate);
                        cmd.Parameters.AddWithValue("sender_ID", sender_ID);
                        cmd.Parameters.AddWithValue("receiver_ID", receiver_ID);
                        cmd.Parameters.AddWithValue("messageToSend", messageToSend);


                        // execute the query
                        cmd.ExecuteNonQuery();
                    }

                    // intsert into a table
                    using (var cmd2 = new NpgsqlCommand("INSERT INTO messages_tb (datesent, sender, reciever, message) VALUES(@theDate,@sender_ID,@receiver_ID,@messageTosend)", conn))
                    {
                        // The date now
                        string theDate = DateTime.Now.ToShortDateString();

                        // INSERT INTO messages_tb (datesent, sender, reciever, message) VALUES('1 jan 2018','meloo','ok','Hello');
                        cmd2.Parameters.AddWithValue("theDate", theDate);
                        cmd2.Parameters.AddWithValue("sender_ID", sender_ID);
                        cmd2.Parameters.AddWithValue("receiver_ID", receiver_ID);
                        cmd2.Parameters.AddWithValue("messageToSend", messageToSend);

                        // execute the query
                        cmd2.ExecuteNonQuery();
                    }

                    MessageBox.Show("Message sent!", "Attention");
                }
            }
            catch (Exception h)
            {
                MessageBox.Show(h.ToString());
            }
        }

              /// <summary>
              /// Get all staff members from the table
              /// </summary>
              /// <param name="idOfCurrentUser"> Name of the table to read from </param>
              public void GetTheResults(string IDofCurrentUser)
              {
                     // make the connection to the database
                     using (NpgsqlConnection conn = new NpgsqlConnection(MainWindow.ChatConnectionString))
                     {
                            // open the connection
                            conn.Open();

                            // do the query
                            string commandToSend = $"SELECT staffid FROM staff_members";

                            // Retrieve all rows
                            using (NpgsqlCommand cmd = new NpgsqlCommand(commandToSend, conn))
                            using (NpgsqlDataReader reader = cmd.ExecuteReader())
                            {
                                   // while we can read 
                                   while (reader.Read())
                                   {
                                          /// get the string value which is the StaffId
                                          /// and add it to the combo box
                                          string yestext = Convert.ToString(reader.GetValue(0));
                                          if (yestext != IDofCurrentUser.ToLower())
                                                 SearchResultComboBox.Items.Add(yestext);
                                   }

                                   /// refresh the combo box
                                   SearchResultComboBox.Items.Refresh();
                            }
                     }
              }
              
              private void Window_Closed(object sender, EventArgs e)
              {
                      Owner.Show();
              }

              /// <summary>
              /// Send a message.
              /// </summary>
              /// <param name="sender"></param>
              /// <param name="e"></param>
              private void BtnMessage_send_Click(object sender, RoutedEventArgs e)
              {
                     // extract the value and assign them to variables
                     if (SearchResultComboBox.SelectedIndex < 0)
                            return;

                     string staffTo = SearchResultComboBox.SelectedItem.ToString();
                     string subjectOFmassage = txbMessage_subject.Text;
                     string message = txbMessage_message.Text;

                     // CHECK FOR ERRORS 
                     // 1. check if the staff id or name exist in the databse
                     // 2. check empty textboxes/variables

                     // 1.

                     // 2.
                     string[] stringVs = new string[] {
                            subjectOFmassage,
                            message
                     };

                     bool t_or_f = GeneralMethods.checkEmptytxtBox(stringVs);

                     if (!t_or_f)
                     {
                            // .. todo

                            insertMessage(currentStaffID, staffTo, message);
                            txbMessage_message.Text = "";

                            // clear the textboxes
                            GeneralMethods.clearTextBoxes(txbMessage_subject, txbMessage_message);
                     }
              }

              /// <summary>
              /// Get all the staffIds and the Name of the staff member from the database.
              /// </summary>
              /// <param name="sender"></param>
              /// <param name="e"></param>
              private void Window_Loaded(object sender, RoutedEventArgs e)
              {
                     /// Get the staff ids from the table
                     GetTheResults(currentStaffID);
              }

              /// <summary>
              /// Show the send button
              /// </summary>
              /// <param name="sender"></param>
              /// <param name="e"></param>
              private void TxbMessage_message_TextChanged(object sender, TextChangedEventArgs e)
              {
                     if (!string.IsNullOrEmpty(txbMessage_message.Text))
                            btnMessage_send.IsEnabled = true;
              }

              /// <summary>
              /// Show the send button
              /// </summary>
              /// <param name="sender"></param>
              /// <param name="e"></param>
              private void SearchResultComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
              {
                     txbMessage_message.IsEnabled = true;
                     btnMessage_send.IsEnabled = true;
              }
       }
}
