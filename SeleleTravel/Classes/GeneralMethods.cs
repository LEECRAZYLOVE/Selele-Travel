using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        
    }
}
