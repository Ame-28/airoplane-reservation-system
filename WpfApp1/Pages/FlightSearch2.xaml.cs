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

namespace ARS
{
    /// <summary>
    /// Interaction logic for FlightSearch2.xaml
    /// </summary>
    public partial class FlightSearch2 : Page
    {
        public FlightSearch2()
        {
            InitializeComponent();
            loadData();
        }

        SQL mySQL = new SQL();

        public void loadData()
        {
            // Load data into XAML elements
            FromCode.Text = mySQL.readValues("ticket", $"CUSTOMER_NAME = '{Customer.UserName}'")["FromCode"].ToString();
            FromLocation.Text = mySQL.readValues("ticket", $"CUSTOMER_NAME = '{Customer.UserName}'")["FromLocation"].ToString();
            FromTime.Text = mySQL.readValues("ticket", $"CUSTOMER_NAME = '{Customer.UserName}'")["FromTime"].ToString();

            ToCode.Text = mySQL.readValues("ticket", $"CUSTOMER_NAME = '{Customer.UserName}'")["ToCode"].ToString();
            ToLocation.Text = mySQL.readValues("ticket", $"CUSTOMER_NAME = '{Customer.UserName}'")["ToLocation"].ToString();
            ToTime.Text = mySQL.readValues("ticket", $"CUSTOMER_NAME = '{Customer.UserName}'")["ToTime"].ToString();

            Duration.Text = mySQL.readValues("ticket", $"CUSTOMER_NAME = '{Customer.UserName}'")["Duration"].ToString();

            PassengerCount.Text = mySQL.readValues("ticket", $"CUSTOMER_NAME = '{Customer.UserName}'")["PassengerCount"].ToString();

            //TicketPrice.Text = $"{mySQL.readValues("ticket", $"CUSTOMER_NAME = '{Customer.UserName}'")["TicketPrice"]}$"; 

            TotalAmount.Text = $"{mySQL.readValues("ticket", $"CUSTOMER_NAME = '{Customer.UserName}'")["GrandTotal"]}"; //fix this
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/Pages/FlightSearch3.xaml", UriKind.Relative));
            NavigationService.Navigate(new FlightSearch3(true));
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
