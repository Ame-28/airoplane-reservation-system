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
    /// Interaction logic for FlightSearch3.xaml
    /// </summary>
    public partial class FlightSearch3 : Page
    {
        public FlightSearch3(bool isConfirmed)
        {
            InitializeComponent();

            if(isConfirmed)
            {
                confirmed();
            }
            else
            {
                cancelled();
            }
        }

        public void confirmed()
        {
            BookingTime.Text = $"Your booking has been confirmed at {DateTime.Now}";
            BookingID.Text = $"Your Booking ID is 1";
            Logger.logEvent($"Your booking has been confirmed");
        }

        public void cancelled()
        {
            confirmImage.Visibility = Visibility.Collapsed; // Hide confirm image
            cancelImage.Visibility = Visibility.Visible;    // Show cancel image

            BookingTime.Text = string.Empty;

            confirmText.Text = "YOUR BOOKING HAS BEEN CANCELLED!";
            Logger.logEvent($"Your booking has been cancelled");
        }

        private void ManageBooking_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/ManageBooking.xaml", UriKind.Relative));
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
