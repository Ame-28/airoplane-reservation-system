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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Pages;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

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

        SQL sql = new SQL();

        private void swap(object sender, RoutedEventArgs e)
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
            List<FlightDetailsTag> allFlights = new List<FlightDetailsTag>();
            Airport fromAirport = new Airport();
            Airport toAirport = new Airport();
            List<Dictionary<string, object>> flights = getAirportDetails(fromAirport, toAirport);
            Random random = new Random();

            /*
             * Validate fields
             * Go to FlightSearch1.xaml
             * Populate the tag with details
             * Randomly generate from and to time
             * Randomly generate price 
             */


            foreach (var i in flights)
            {
                FlightDetailsTag flightDetailsTag = new FlightDetailsTag();
                Random radnom = new Random();

                // Populate flight tag
                flightDetailsTag.FromCode.Text = fromAirport.IATACode;
                flightDetailsTag.ToCode.Text = toAirport.IATACode;
                flightDetailsTag.FromLocation.Text = fromAirport.AirportCity;
                flightDetailsTag.ToLocation.Text = toAirport.AirportCity;
                flightDetailsTag.DepartureTime.Text = generateRandomTime(random);
                flightDetailsTag.ArrivalTime.Text = generateRandomTime(random);
                flightDetailsTag.Duration.Text = $"{calculateDuration(flightDetailsTag.DepartureTime.Text, flightDetailsTag.ArrivalTime.Text)} hrs";
                flightDetailsTag.Price.Text = $"{Convert.ToInt32(PassengersTextBox.Text) * random.Next(100, 500)}$";
                flightDetailsTag.PassengerCount.Text = PassengersTextBox.Text;
                
                // Add flight tag to list
                allFlights.Add(flightDetailsTag);
            }

            NavigationService.Navigate(new FlightSearch1(allFlights));

        }

        public List<Dictionary<string, object>> getAirportDetails(Airport from, Airport to)
        {
            Dictionary<string, object> route = new Dictionary<string, object>();

            // Get Primary keys
            from.AirportID = Convert.ToInt32(sql.readValues("airport", $"CITY = '{FromTextBox.Text}'")["AIRPORT_ID"]);
            to.AirportID = Convert.ToInt32(sql.readValues("airport", $"CITY = '{ToTextBox.Text}'")["AIRPORT_ID"]);
            Route.RouteID = Convert.ToInt32(sql.readValues("route", $"DEPARTURE_LOCATION_ID = {from.AirportID} AND ARRIVAL_LOCATION_ID = {to.AirportID}")["ROUTE_ID"]);

            // Get Departure Airport details
            from.AirportCity = FromTextBox.Text;
            from.IATACode = sql.customQuery("SELECT DISTINCT iata_code FROM airport a " +
                "LEFT JOIN route r ON a.airport_id = r.ARRIVAL_LOCATION_ID " +
                "LEFT JOIN flight f ON r.route_id = f.route_id WHERE r.route_id = 1;")
                [0]["iata_code"].ToString();
            Flight.DepartureTime = Convert.ToDateTime(sql.readValues("flight", $"ROUTE_ID = {Route.RouteID}")["DEPARTURE_TIME"]);
            
            // Get Arrival Airport details
            to.AirportCity = ToTextBox.Text;
            to.IATACode = sql.customQuery("SELECT DISTINCT iata_code FROM airport a " +
                "LEFT JOIN route r ON a.airport_id = r.DEPARTURE_LOCATION_ID " +
                "LEFT JOIN flight f ON r.route_id = f.route_id WHERE r.route_id = 1;")
                [0]["iata_code"].ToString();
            Flight.ArrivalTime = Convert.ToDateTime(sql.readValues("flight", $"ROUTE_ID = {Route.RouteID}")["ARRIVAL_TIME"]);

            // Get Duration
            Route.Duration = sql.readValues("route", $"ROUTE_ID = {Route.RouteID}")["DURATION"].ToString();
            return sql.readValues("flight", $"ROUTE_ID = {Route.RouteID}", false);
        }

        public string generateRandomTime(Random random)
        {
            // Generate a random hour between 0 and 23
            int randomHour = random.Next(0, 24);

            // Generate a random minute between 0 and 59
            int randomMinute = random.Next(0, 60);

            // Format the time as HH:mm
            string formattedTime = $"{randomHour:D2}:{randomMinute:D2}";

            return formattedTime;
        }

        public static TimeSpan calculateDuration(string departureTime, string arrivalTime)
        {
            // Parse departure and arrival times
            TimeSpan departure = TimeSpan.Parse(departureTime);
            TimeSpan arrival = TimeSpan.Parse(arrivalTime);

            // Calculate the duration
            TimeSpan duration = arrival - departure;

            // Handle cases where the arrival time is earlier than the departure time (e.g., overnight flights)
            if (duration.TotalMinutes < 0)
            {
                duration = TimeSpan.FromHours(24) + duration;
            }

            return duration;
        }
    }
}
