using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;

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
            for (int i = 0; i < dateTimeValues.Count; i++)
            {
                if (dateTimeValues[i] == null || dateTimeValues[i].ToString() == "")
                {
                    MessageBox.Show("Please select a date", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return true;
                }
            }
            return false;
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
        /// Checks for the first day of service from  list of given dates
        /// </summary>
        /// <param name="dateTimes"></param>
        /// <returns></returns>
        public static DateTime checkFirstDay(List<DateTime> dateTimes)
        {
            DateTime v = dateTimes[1];
            return v;
        }

        /// <summary>
        /// Checks the last day from a list of given dates.
        /// </summary>
        /// <param name="dateTimes"></param>
        /// <returns></returns>
        public static DateTime checkLastDay(List<DateTime> dateTimes)
        {
            DateTime v = dateTimes[1];
            return v;
        }

        /// <summary>
        /// Gets the first and last day of service rendered from the services that are currently being created. 
        /// It stores the dates in a csv file.
        /// format: Order Number, Start date, End date
        /// </summary>
        /// <returns></returns>
        public static void checkEndOfservices()
        {
            // 1. Get the order number
            // 2. Get the dates
            // 3. store the info in a csv file

            // 1.
            
        }

        /// <summary>
        /// Extract the data from the csv file and then sends it to manager
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string,Dictionary<string,string>> getLastDayOfService()
        {
            // 1. extract data
            // 2. compare todays date with the last day
            // 3. If today is the last day then send it to the manager 
            // 4. and then delete it from the csv file

            // 1.

            Dictionary<string, Dictionary<string, string>> keyValuePairs = new Dictionary<string, Dictionary<string, string>>();
            return keyValuePairs;
        }
    }
}
