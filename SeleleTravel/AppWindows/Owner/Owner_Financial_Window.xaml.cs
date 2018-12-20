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
using System.Data.SqlClient;
//using Devart.Data.MySql;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Owner_Financial_Window.xaml
    /// </summary>
    public partial class OwnerFinancialWindow : Window
    {
        public OwnerFinancialWindow()
        {
            InitializeComponent();
        }

        private void Owner_Financial_Window_Closed(object sender, EventArgs e)
        {
            Owner?.Show();
            Close();
        }
    }
}
