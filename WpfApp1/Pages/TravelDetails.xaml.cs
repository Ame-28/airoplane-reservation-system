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
            SQL sql = new SQL();
            Dictionary<string, object> route = new Dictionary<string, object>();
            List<Dictionary<string, object>> flight = new List<Dictionary<string, object>>();
            List<FlightDetailsTag> allFlights = new List<FlightDetailsTag>();
            string departDate = DepartDatePicker.Text;
            string returnDate = ReturnDatePicker.Text;
            Airport fromAirport = new Airport();
            Airport toAirport = new Airport();
            /*
             * Validate fields
             * Go to FlightSearch1.xaml
             * Populate the tag with details
             */

            // Get From and To details
            Route.FromCity = sql.readValues("airport", $"CITY = '{FromTextBox.Text}'")["CITY"].ToString();
            Route.ToCity = sql.readValues("airport", $"CITY = '{ToTextBox.Text}'")["CITY"].ToString();

            // Get Departure Airport Details
            //Dictionary<string, object> test = sql.readValues("airport", $"CITY = {FromTextBox.Text}");
            fromAirport.AirportID = Convert.ToInt32(sql.readValues("airport", $"CITY = '{FromTextBox.Text}'")["AIRPORT_ID"]);
            fromAirport.AirportCity = FromTextBox.Text;           
            fromAirport.IATACode = sql.customQuery("SELECT DISTINCT iata_code FROM airport a LEFT JOIN route r ON a.airport_id = r.ARRIVAL_LOCATION_ID LEFT JOIN flight f ON r.route_id = f.route_id WHERE r.route_id = 1;")[0]["iata_code"].ToString();

            // Get Arrival Airport Details
            toAirport.AirportID = Convert.ToInt32(sql.readValues("airport", $"CITY = '{ToTextBox.Text}'")["AIRPORT_ID"]);
            toAirport.AirportCity = ToTextBox.Text;
            toAirport.IATACode = sql.customQuery("SELECT DISTINCT iata_code FROM airport a LEFT JOIN route r ON a.airport_id = r.DEPARTURE_LOCATION_ID LEFT JOIN flight f ON r.route_id = f.route_id WHERE r.route_id = 1;")[0]["iata_code"].ToString();

            
            route = sql.readValues("route", $"DEPARTURE_LOCATION_ID = {fromAirport.AirportID} AND ARRIVAL_LOCATION_ID = {toAirport.AirportID}");
            flight = sql.readValues("flight", $"ROUTE_ID = {route["ROUTE_ID"]}", false);

            foreach (var i in flight)
            {
                FlightDetailsTag flightDetailsTag = new FlightDetailsTag();
                flightDetailsTag.FromCode.Text = fromAirport.IATACode;
                flightDetailsTag.ToCode.Text = toAirport.IATACode;
                flightDetailsTag.FromLocation.Text = fromAirport.AirportCity;
                flightDetailsTag.ToLocation.Text = toAirport.AirportCity;
                allFlights.Add(flightDetailsTag);
            }
            NavigationService.Navigate(new FlightSearch1(allFlights));
            //((FlightSearch1)NavigationService.Content).populateDetails(allFlights);

        }

    }
}
