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
using WpfApp1.Pages;

namespace ARS
{
    /// <summary>
    /// Interaction logic for TravelDetails.xaml
    /// </summary>
    public partial class TravelDetails : Page
    {
        public TravelDetails()
        {
            InitializeComponent();
        }

        private void Swap(object sender, RoutedEventArgs e)
        {
            // Store 'From' and 'To' place
            string fromPlace = FromTextBox.Text;
            string toPlace = ToTextBox.Text;

            // Swap Text
            FromTextBox.Text = toPlace;
            ToTextBox.Text = fromPlace;
        }
        private void SearchFlights_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, object> fromDetails = new Dictionary<string, object>();
            Dictionary<string, object> toDetails = new Dictionary<string, object>();
            Dictionary<string, object> route = new Dictionary<string, object>();
            List<Dictionary<string, object>> flight = new List<Dictionary<string, object>>();

            SQL sql = new SQL();

            // Get From and To details
            fromDetails = sql.readValues("airport", $"CITY = '{FromTextBox.Text}'");
            toDetails = sql.readValues("airport", $"CITY = '{ToTextBox.Text}'");
            route = sql.readValues("route", $"DEPARTURE_LOCATION_ID = {fromDetails["AIRPORT_ID"]} AND ARRIVAL_LOCATION_ID = {toDetails["AIRPORT_ID"]}");
            flight = sql.readValues("flight", $"ROUTE_ID = {route["ROUTE_ID"]}",true);
            /*
             * Get the following details
             * IATA from code
             * IATA to code
             * Duration
             * Departure time
             * Arrival time
             */

            /*
             * Go to FlightSearch1.xaml
             * Populate the User Control with details
             * 
             */
            FlightSearch1 page = new FlightSearch1();
            this.Content = page;

        }

    }
}
