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
using System.Timers;
using System.IO;
using System.Data.SqlClient;
//using Devart.Data.MySql;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for Manager_Home.xaml
    /// </summary>
    public partial class Manager_Home : Window
    {
        Timer timer = new Timer(1000);

        public Manager_Home()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
           // timer.Elapsed += Timer_Elapsed;
        }

        #region Refresh the list

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {

        }

        #endregion

        
        #region Quote Summary tab

        #endregion

        #region Compose Message tab
        /// <summary>
        /// Returns true if the was an error
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
      public bool checkForError(string name)
        {
            if(name.Trim() == "")
            {
                MessageBox.Show("You cannot send an empty message!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return true;
            }
            return false;
        }
      

        #endregion

        #region Verified Quotes tab

        #endregion

        #region Authorizations tab
        

        #endregion

        #region Search tab
        //private List<string> stringEquivalent(List<object> list)
        //{
        //    List<string> result = new List<string>();

        //    foreach (var a in list)
        //    {
        //        if (a is quote q)
        //        {
        //            result.Add(q.ToString());
        //        }
        //        else if (a is )
                    
        //    }

        //    return result;
        //}
        private void BtnManager_search_Click(object sender, RoutedEventArgs e)
        {

            //Make sure that the search results are clear
            ltbManager_Search_Results.Items.Clear();
            string searchString = txbManager_search.Text;
            List<object> results = new List<object>();
            //for all checkboxes, if a checkbox is checked, then we would like to search in the appropriate table as well
            //And add the results to the 
            if((bool)ckbManager_Search_quotes.IsChecked)
            {
                //search in the quote table

                //if we find something, add to results
            }
            if ((bool)ckbManager_Search_orders.IsChecked)
            {
                //search in the orders table

                //if we find something, add to results
            }
            if ((bool)ckbManager_Search_vouchers.IsChecked)
            {
                //search in the vouchers table

                //if we find something, add to results
            }
            if ((bool)ckbManager_Search_invoices.IsChecked)
            {
                //search in the invoices table

                //if we find something, add to results
            }
            //if we found nothing
            if (results.Count <= 0)
            {
                string nothingFoundMessage = "No items match the search term";
                ltbManager_Search_Results.Items.Add(nothingFoundMessage);                
            }
            else
            {
                ltbManager_Search_Results.ItemsSource = results;
                ltbManager_Search_Results.Items.Refresh();
            }
        }

        #endregion

        private void Manager_Home1_Closed(object sender, EventArgs e)
        {
            GeneralMethods.closeAllWindows();
        }

        private void btnManager_logOut_Click(object sender, RoutedEventArgs e)
        {

            GeneralMethods.logOut(this);
        }

        private void btnManager_search_Click_1(object sender, RoutedEventArgs e)
        {
            //New edit
            string filter = cbbManager_Search_entities.SelectionBoxItem.ToString();
            string search = txbManager_search.Text;

            if (filter == "Staff")
            {
                using (postgresEntities12th currentSearch = new postgresEntities12th())
                {
                    var query = (from c in currentSearch.staffs

                                 where c.staff_id == search
                                 select new
                                 {
                                     c.staff_id,
                                     c.staffposition,
                                     c.stafffirstnames,
                                     c.stafflastname,
                                     c.salary,
                                     c.dateofhire,
                                     c.address,
                                     c.telephone,
                                     c.cellphone,
                                     c.password,
                                     c.fax
 
                                 }).First();

                    if (query != null)
                    {
                        string staffmember = $"{query.staff_id} ,{query.stafffirstnames}, {query.stafflastname}, {query.staffposition}, {query.dateofhire}, {query.salary}, {query.password}, {query.cellphone}, {query.telephone}";
                        ltbManager_Search_Results.Items.Add(staffmember);
                    }
                }
            }
            
        }

        private void btnManager_Quotes_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void cbbManager_Search_entities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
