using ARS;
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
    /// Interaction logic for FlightDetailsTag.xaml
    /// </summary>
    public partial class FlightDetailsTag : UserControl
    {
        private MainMenu mainMenu;

        public FlightDetailsTag()
        {
            InitializeComponent();
           
        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {           
            // Populate Ticket
            populateTicket();

            // Find the parent window or page
            var parentWindow = Window.GetWindow(this); // For UserControl inside a Window

            if (parentWindow != null)
            {
                // Access the Frame in the parent window or page
                var frame = ((MainWindow)parentWindow).MainPage_Frame; // Adjust type accordingly

                // Navigate to the desired page
                frame.NavigationService.Navigate(new Uri("/Pages/FlightSearch2.xaml", UriKind.Relative));
            }
        }

        public void populateTicket()
        {
            Ticket.FromCode = FromCode.Text;
            Ticket.FromLocation = FromLocation.Text;
            Ticket.FromTime = DepartureTime.Text;

            Ticket.ToCode = ToCode.Text;
            Ticket.ToLocation = ToLocation.Text;
            Ticket.ToTime = ArrivalTime.Text;

            Ticket.Duration = Duration.Text;
            Ticket.PassengerCount = Convert.ToInt32(PassengerCount.Text);
            Ticket.GrandTotal = Price.Text;
            Ticket.TicketPrice = 123; //fix this
        }
    }
}
