using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SeleleTravel
{

    public static class GeneralMethods
    {
        public static void closeAllWindows()
        {
            foreach (Window w in Application.Current.Windows)
                w?.Close();
        }
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
        /// checks if the number typed is a valid number
        /// </summary>
        /// <param name="sender"></param>
        public static void checkAmountTyped(object sender, bool int_double)
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
    }
}
