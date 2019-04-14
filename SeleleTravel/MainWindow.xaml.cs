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
using System.Data.SqlClient;
using Npgsql;
using System.Net.Mail;
using System.Text;

namespace SeleleTravel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum LoadWindow { Consultant, Manager, Owner }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region ClickEvents
        private void btn_consultantSide_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            loadLogInWindow(LoadWindow.Consultant);
        }

        private void btn_managerSide_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            loadLogInWindow(LoadWindow.Manager);
        }

        private void btn_bossSide_Click(object sender, RoutedEventArgs e)
        {
            //SmtpClient client = new SmtpClient();
            //client.Port = 25;
            //client.Host = "smtp.gmail.com";
            //client.EnableSsl = true;
            //client.Timeout = 10000;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //client.Credentials = new System.Net.NetworkCredential("crazedoutlee@gmail.com", "10Crazylee");

            //MailMessage mm = new MailMessage("g17s9264@campus.ru.ac.za", "seleletravel@live.com");
            //mm.BodyEncoding = UTF8Encoding.UTF8;
            //mm.Subject = "this is a test email 2.";
            //mm.Body = "this is my test email body";
            //mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            //client.Send(mm);


            //MailMessage mail = new MailMessage("crazedoutlee@gmail.com", "g17s9264@campus.ru.ac.za");
            //SmtpClient client = new SmtpClient();
            //client.Port = 25;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //client.UseDefaultCredentials = false;
            //client.Host = "smtp.gmail.com";
            //mail.Subject = "this is a test email 2.";
            //mail.Body = "this is my test email body";
            //client.Send(mail);

            Hide();
            loadLogInWindow(LoadWindow.Owner);
        }

        private void Home_Page_Closed(object sender, EventArgs e)
        {
            GeneralMethods.closeAllWindows();
        }

        #endregion

        #region Fields and Properties
        public static LogInWindow logInWindow;
        public static string ConnectionString = "Database=SeleleMain;Port=1998;Server=127.0.0.1;User Id=postgres;Password=Linomtha";
       //public static string ConnectionString = "Database=postgres;Port=5433;Server=127.0.0.1;User Id=postgres;Password=litha";
        public static string ChatConnectionString = "Server=127.0.0.1; Port=1998; User Id=postgres; Password=Linomtha; Database=SeleleChat;";
        #endregion

        #region Helper Methods
        private void loadLogInWindow(LoadWindow windowToLoad)
        {
            logInWindow = new LogInWindow(windowToLoad);
            logInWindow.Owner = this;
            logInWindow.Show();
            Hide();
        }
        #endregion
    }
}
