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
//using Npgsql;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //conn = new NpgsqlConnection("Server=127.0.0.1;Port=1998;Database=Selele;User Id=postgres;Password=Linnomtha;");
            //conn.Open();
        }

        #region Client Display
        #endregion
        #region newClient Display
        /// <summary>
        /// This just makes sure that only one type is chosen between business and individual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #endregion

        #region Log in Screen
        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            //Log_In_Side.Visibility = Visibility.Visible;
            //Consultant_Side.Visibility = Visibility.Visible;
        }
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Main_Window.Visibility = Visibility.Visible;
            //Consultant_Side.Visibility = Visibility.Hidden;
            //Log_In_Side.Visibility = Visibility.Hidden;
        }

        private void btn_consultantSide_Click(object sender, RoutedEventArgs e)
        {
            //Log_In.IsVisibleProperty.
            //Log_In_Side.Visibility = Visibility.Visible;
            //Main_Window.Visibility = Visibility.Hidden;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        //Npgsql.NpgsqlConnection conn;

        //private void button1_Click(object sender, RoutedEventArgs e)
        //{
        //    using (Npgsql.NpgsqlCommand cmd = new NpgsqlCommand("select * from myTable where name=" + Name))
        //    { // '' or 1=1
        //      // select * from myTable where name ='' or 1=1
        //        cmd.CommandText = "select date,name from quote where quote_no = @mynum";
        //        cmd.Parameters.Add("mynum", 7);
        //        // for ins/upd:
        //        cmd.ExecuteNonQuery();
        //        // for single value:
        //        cmd.ExecuteScalar();
        //        using (Npgsql.NpgsqlDataReader r = cmd.ExecuteReader())
        //        {
        //            while (r.Read())
        //            {
        //                var x = r.GetDate(0);
        //                string b = r.GetString(1);
        //                // do whatever
        //            }
        //        }
        //    }
        //}
    }
}
