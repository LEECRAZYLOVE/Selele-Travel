using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media;

namespace SeleleTravel
{

    public static class GeneralMethods
    {

        /// <summary>
        /// closes all windows open.
        /// </summary>
        public static void closeAllWindows()
        {
            foreach (Window w in Application.Current.Windows)
                w?.Close();
        }

        /// <summary>
        /// Logs out the window
        /// </summary>
        /// <param name="windowToLogOutOff"></param>
        public static void logOut(Window windowToLogOutOff)
        {
            windowToLogOutOff.Hide();
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// Check if the texboxes are empty.
        /// </summary>
        /// <param name="stringValues"></param>
        public static bool checkEmptytxtBox(List<string> stringValues)
        {
            for (int i = 0; i < stringValues.Count; i++)
            {
                if (stringValues[i] == "")
                {
                    MessageBox.Show("Please type a valid text", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the date is null or the toString() method is an empty string.
        /// </summary>
        /// <param name="dateTimeValues"></param>
        /// <returns></returns>
        public static bool checkDateTimeBox(List<DateTime> dateTimeValues)
        {
            // check if the end date is bigger that the start date
            bool greaterORless = dateTimeValues[1] >= dateTimeValues[0];
            if (greaterORless)
            {
                for (int i = 0; i < dateTimeValues.Count; i++)
                {
                    // checks if the dates are null or empty strings.
                    if (dateTimeValues[i] == null || dateTimeValues[i].ToString() == "")
                    {
                        MessageBox.Show("Please select a date", "Error, selected dates are invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                        return true;
                    }
                }
                return false;
            }
            else
            {
                MessageBox.Show("Please select a date that is valid", "Error, Selected dates are invalid", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
        }

        /// <summary>
        /// checks if the number typed is a valid number.
        /// If the value to be checked is not a whole number then assign the bool to false. 
        /// </summary>
        /// <param name="sender"></param>
        /// /// <param name="int_double"></param>
        public static void checkAmountTyped(object sender, bool int_double=true)
        {
            string acceptedCharacters = "";

            if (int_double)
            {
                acceptedCharacters = "0123456789";
            }
            else
            {
                acceptedCharacters = "0123456789." +
                    "";
            }

            TextBox reference = (TextBox)sender;
            if (reference.Text.Length <= 0) return;

            string letterEntered = reference.Text.Last().ToString().ToLower();
            if (!acceptedCharacters.Contains(letterEntered))
            {
                reference.Text = reference.Text.TrimEnd(letterEntered.ToCharArray());
                reference.SelectionStart = reference.Text.Length;
                MessageBox.Show("'" + letterEntered + "' is not an accepted character for an amount!", "Invalid Character!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// checks if the phone/telephone/fax number typed is valid
        /// </summary>
        /// <param name="sender"></param>
        public static void checkPhoneNumber(object sender)
        {
            string acceptedCharacters = "+0123456789 ";
            TextBox reference = (TextBox)sender;
            if (reference.Text.Length <= 0) return;

            string letterEntered = reference.Text.Last().ToString().ToLower();
            if (!acceptedCharacters.Contains(letterEntered))
            {
                reference.Text = reference.Text.TrimEnd(letterEntered.ToCharArray());
                reference.SelectionStart = reference.Text.Length;
                MessageBox.Show("'" + letterEntered + "' is not an accepted character for a phone/telephone number!", "Invalid Character!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// clears the texboxes in the list.
        /// </summary>
        /// <param name="textBoxes"></param>
        public static void clearTextBoxes(List<TextBox> textBoxes)
        {
            foreach(TextBox x in textBoxes)
            {
                x.Text = "";
            }
        }

        /// <summary>
        /// Checks for the first and last day of service from  list of given dates.
        /// MAKE SURE THE LIST HAS ALL THE DATES PARTAINING TO THE CURRENT ORDER!
        /// </summary>
        /// <param name="dateTimes"></param>
        /// <returns></returns>
        public static List<DateTime> checkFirst_lastDay(List<DateTime> dateTimes)
        {
            // 0. create a temp list
            // 1. sort the list
            // 2. Assign the first day to the first index
            // 3. Assign the last day to the last index
            // 4. Add the dates(first and last day dates) to the temp list
            // 5. return the temp list

            // 0. 
            List<DateTime> dates = new List<DateTime>();

            // 1. 
            dateTimes.Sort();

            // 2.
            DateTime firstDay = dateTimes[0];

            // 3.
            DateTime lastDay = dateTimes[dateTimes.Count - 1];

            // 4. 
            dates.Add(firstDay);
            dates.Add(lastDay);

            // 5. 
            return dates;
        }

        /// <summary>
        /// Gets the first and last day of service rendered from the services that are currently being created. 
        /// It stores the dates in a csv file.
        /// </summary>
        /// <param name="orderNumber"> Order number of the service that will be rendered </param>
        /// <param name="firstDayOFservice"> Date of the first day of service </param>
        /// <param name="lastDayOfService"> Date of the last day of service </param>
        /// <returns></returns>
        public static void saveDataToCSVfile(string quoteNumber,string orderNumber, List<DateTime> dates)
        {
            // format for storing: quote number, order Number, start date, end date

            // for first time launch: create a directory relative to the .exe file.
            // hide the folder once created.

            // 1. Get the order number
            // 2. Get the dates
            // 3. store the info in a csv file

            // create variables and assign then to the
            // make sure that the dates are correctly sorted
            // MAKE SURE THAT THE LIST HAS A LENGTH OF 2!
            dates.Sort();
            if(dates.Count > 2)
            {
                throw new Exception("list is bigger than 2. By default it should have two elements.");
            }

            // create a string that follows the format stated above
            // create a textwriter variables
            string orderDetails = $"{quoteNumber},{orderNumber},{dates[0]},{dates[1]}";
            TextWriter writer;

            // first time launch
            string DirectoryPath = "DatesOfServices";
            string Filepath = $"{DirectoryPath}/serviceDates.csv";
            string metaData = "Quote Number, Order Number, Start date, End Date";
            
            if (!Directory.Exists(DirectoryPath))
            {
                // create directory
                Directory.CreateDirectory(DirectoryPath);

                // set access control
                // Directory.SetAccessControl(DirectoryPath,)

                // create file
                writer = File.CreateText(Filepath);

                // Write metadata first
                writer.WriteLine(metaData);

                // write data to the file
                writer.WriteLine(orderDetails);
                writer.Close();
            }
            else
            {
                if (!File.Exists(Filepath))
                {
                    // create file
                    writer = File.CreateText(Filepath);

                    // Write metadata first
                    writer.WriteLine(metaData);

                    // write data to the file
                    writer.WriteLine(orderDetails);
                    writer.Close();
                }
                else
                {
                    // create file
                    writer = File.AppendText(Filepath);

                    // write data to the file
                    writer.WriteLine(orderDetails);
                    writer.Close();
                }
            }
        }

        /// <summary>
        /// It links the order number to the quote number and then saves the info to the csv file.
        /// </summary>
        /// <param name="quote_Number"></param>
        /// <param name="order_Number"></param>
        public static void linkOrderNumberInCSVfile(string quote_Number, string order_Number)
        {
            // format for storing: quote number, order Number, start date, end date

            // Extract the detail from the csv file
            List<string[]> serviceDetails_ = getServiceDates();

            // Link the order number to the quote number
            for(int i =0; i < serviceDetails_.Count; i++)
            {
                // temp storage for the current index array
                string[] temp = serviceDetails_[i];

                // check if the quote number is the same as the one on the array
                // if so update the order number from "To Be Added" to the new quote number
                if (temp[0] == quote_Number && temp[1] == "To Be Added")
                {
                    temp[1] = order_Number;
                    serviceDetails_[i] = temp;
                    break;
                }
            }

            // save details to the file
            // create a new file with the updated details

            // first time launch
            string Filepath = "DatesOfServices/serviceDates.csv";
            string metaData = "Quote Number, Order Number, Start date, End Date";

            // create file
            TextWriter writer = File.CreateText(Filepath);

            // Write metadata first
            writer.WriteLine(metaData);

            // write data to the file
            for(int i=0;i< serviceDetails_.Count; i++)
            {
                // Extrct data from the list
                // store using the format: quote number, order Number, start date, end date
                string[] temp = serviceDetails_[i];
                string line = $"{temp[0]},{temp[1]},{temp[2]},{temp[3]}";
                writer.WriteLine(line);
            }

            writer.Close();
            
        }

        /// <summary>
        /// Extract the data from the csv file and then sends it to manager
        /// </summary>
        /// <returns></returns>
        public static List<string[]> getServiceDates()
        {
            // 0. create a list of a list
            // 1. extract data
            // 2. compare todays date with the last day
            // 3. If today is the last day then send it to the manager 
            // 4. and then delete it from the csv file

            // 0. 
            List<string[]> serviceDetails = new List<string[]>();

            // 1.
            string DirectoryPath = "DatesOfServices";
            string Filepath = $"{DirectoryPath}/serviceDates.csv";

            // check if the directory and the filr exist
            if(Directory.Exists(DirectoryPath) && File.Exists(Filepath))
            {
                // Assign to reader the file line
                // read the first line which is the metadata
                TextReader reader = File.OpenText(Filepath);
                string headings = reader.ReadLine();

                // read all lines and add them to a dictionary
                string line = reader.ReadLine();
                while(line != null)
                {
                    // recycle the List for service dates.
                    // extract the data from the read
                    string[] orderDetails = line.Split(',');
                    serviceDetails.Add(orderDetails);
                }
                reader.Close();
            }
            else
            {
                throw new Exception("The folder or the file do not exist in the system!");
            }
            return serviceDetails;
        }

        /// <summary>
        /// Removes services which expire on the current date, and have been ticked by the manager.
        /// </summary>
        /// <param name="serviceDetails"></param>
        public static void removeTodaysService(List<string[]> serviceDetails, List<string> orderNumbers)
        {
            // Removes all the order numbers that are in the from the list
            for(int i = 0; i< orderNumbers.Count; i++)
            {
                for(int k = 0; k< serviceDetails.Count; k++)
                {
                    string[] temp = serviceDetails[k];
                    // compare the order number on the file with the one on the list
                    if (temp[1] == orderNumbers[i]) serviceDetails.Remove(temp);
                }
            }

            // the path to the file
            // create a variable of the for writing to the file.
            string Filepath = "DatesOfServices/serviceDates.csv";
            string metaData = "Order Number, Start date, End Date";
            TextWriter writer;

            // create file
            writer = File.CreateText(Filepath);

            // Write metadata first
            writer.WriteLine(metaData);

            // write data to the file
            for(int i = 0;i< serviceDetails.Count; i++)
            {
                string[] mytemp = serviceDetails[i];
                string line = $"{mytemp[0]},{mytemp[1]},{mytemp[2]},{mytemp[3]}";
                writer.WriteLine();
            }
            writer.Close();
        }

        /// <summary>
        /// It generates the quote number.
        /// </summary>
        /// <returns></returns>
        public static string makeQuote_no()
        {
            string numOfQuotes = Convert.ToString(getNumberOfQuotes());
            DateTime timeQuoted = DateTime.Now; // Assignes the timeQuoted to the current time
            string _totalQts = numOfQuotes; // assigns the static value to the string
            while (_totalQts.Length < 6)
            {
                // It adds a zero once to the left of the current string
                _totalQts = _totalQts.PadLeft(1, '0');
            }
            // generates the quote number using the time and string generated above
            string quote_no = $"{timeQuoted}{_totalQts}";
            
            // increment the number of quotes
            incrementNumOfQuotes();

            return quote_no;
        }

        /// <summary>
        /// gets the total number of quotes that have been generated thus far.
        /// </summary>
        /// <returns></returns>
        private static int getNumberOfQuotes()
        {
            TextReader reader = File.OpenText("quoteNum/numOfQuotes");
            int number = Convert.ToInt32(reader.ReadLine());
            reader.Close();
            return number;
        }

        /// <summary>
        ///increments the number of generated quotes by one and then stores the number.
        /// </summary>
        private static void incrementNumOfQuotes()
        {
            TextReader reader = File.OpenText("quoteNum/numOfQuotes.seleleqs");
            int number = Convert.ToInt32(reader.ReadLine());
            reader.Close();
            TextWriter writer = File.CreateText("quoteNum/numOfQuotes.seleleqs");
            writer.WriteLine(number++);
            writer.Close();
        }

        /// <summary>
        /// checks if the quote number is empty.
        /// </summary>
        /// <param name="q_number"></param>
        /// <returns></returns>
        public static bool checkQuoteNotEmpty(string q_number)
        {
            if (q_number == "")
            {
                MessageBox.Show("The quote number has not been generated, please press the \"Request Verification\" button", "Error: Quote number not generated",MessageBoxButton.OK,MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Generates a staff ID by taking the surname and the last four number in the cellphone e.g. Stuurman1533
        /// shows it in a popup
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="cellphone"></param>
        public static string makeStaffID(string surname, string cellphone)
        {
            string ID = surname + cellphone.Substring(1,4);
            MessageBox.Show("New Employee ID is: ID");
            return ID;
        }

        /// <summary>
        /// Forms the full address string with the city, area code and province
        /// </summary>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="areaCode"></param>
        /// <param name="province"></param>
        /// <returns></returns>
        public static string makeAddress(string address, string city, string areaCode, string province)
        {
            return $"{address} \n {city} \n {areaCode} \n {province}";
        }
    }
}
