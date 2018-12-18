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

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Manager_Quotes_Window.xaml
    /// </summary>
    public partial class Manager_Quotes_Window : Window
    {
        public static ComposeMessageWindow composeMessage = new ComposeMessageWindow();

        public Manager_Quotes_Window()
        {
            InitializeComponent();
        }

        private void BtnQuoteSummary_verifyReject_Click(object sender, RoutedEventArgs e)
        {
            composeMessage.Show();
        }

        private void BtnQuoteSummary_verifyAccept_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
