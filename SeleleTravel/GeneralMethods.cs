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
         public static void CloseAllWindows()
        {
            //instantiating all the windows as global objects
            MainWindow.logInWindow.Close();
            MainWindow.consultantWindow.Close();
            MainWindow.managerWindow.Close();
            MainWindow.ownerWindow.Close();
            MainWindow.newServiceProviderWindow.Close();
        }
    }
}
