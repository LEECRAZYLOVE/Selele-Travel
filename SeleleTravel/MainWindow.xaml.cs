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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
      
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Main_Window.Visibility = Visibility.Visible;
            Log_In_Side.Visibility = Visibility.Hidden;
            Consultant_Side.Visibility = Visibility.Hidden;
        }

        private void btn_consultantSide_Click(object sender, RoutedEventArgs e)
        {
            Main_Window.Visibility = Visibility.Hidden;
            Log_In_Side.Visibility = Visibility.Visible;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Log_In_Side.Visibility = Visibility.Hidden;
            Consultant_Side.Visibility = Visibility.Visible;
        }
    }
}
