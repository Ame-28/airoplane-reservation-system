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
        public FlightDetailsTag()
        {
            InitializeComponent();         
        }

        SQL mySQL = new SQL();

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {           
            // Populate Ticket
            populateTicket();

            var parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                // Access the Frame 
                var frame = ((MainWindow)parentWindow).MainPage_Frame;

                // Navigate to the page
                frame.NavigationService.Navigate(new Uri("/Pages/FlightSearch2.xaml", UriKind.Relative));
            }
        }

        public void populateTicket()
        {
            Dictionary<string, object> ticketValues = new Dictionary<string, object>
            {
                { "FromCode", FromCode.Text },
                { "FromLocation", FromLocation.Text },
                { "FromTime", DepartureTime.Text },
                { "ToCode", ToCode.Text },
                { "ToLocation", ToLocation.Text },
                { "ToTime", ArrivalTime.Text },
                { "Duration", Duration.Text },
                { "PassengerCount", Convert.ToInt32(PassengerCount.Text) },
                { "TicketPrice", 123/*Convert.ToInt32(Price.Text)*/ },
                { "GrandTotal", Price.Text },
                { "CUSTOMER_NAME",Customer.UserName }
            };

            mySQL.insertValues("ticket", ticketValues);
        }
    }
}
