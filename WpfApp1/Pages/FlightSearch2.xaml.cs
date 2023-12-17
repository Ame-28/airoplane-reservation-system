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

        public void loadData()
        {
            // Load data into XAML elements
            FromCode.Text = Ticket.FromCode;
            FromLocation.Text = Ticket.FromLocation;
            FromTime.Text = Ticket.FromTime;

            ToCode.Text = Ticket.ToCode;
            ToLocation.Text = Ticket.ToLocation;
            ToTime.Text = Ticket.ToTime;

            Duration.Text = Ticket.Duration;

            PassengerCount.Text = Ticket.PassengerCount.ToString();

            TicketPrice.Text = $"{Ticket.TicketPrice}$"; 

            TotalAmount.Text = $"{Ticket.GrandTotal}"; //fix this
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/Pages/FlightSearch3.xaml", UriKind.Relative));
            NavigationService.Navigate(new FlightSearch3(true));
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FlightSearch3(false));
        }
    }
}
