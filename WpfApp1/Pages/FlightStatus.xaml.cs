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
    /// Interaction logic for FlightStatus.xaml
    /// </summary>
    public partial class FlightStatus : Page
    {
        public FlightStatus()
        {
            InitializeComponent();
        }

        private void FindFlightButton_Click(object sender, RoutedEventArgs e)
        {
            SQL mySQL = new SQL();
            if(mySQL.checkValue("flight", "flight_no", FlightNumberTextBox.Text))
            {
                Dictionary<string, object> flightDeets = mySQL.readValues("flight", $"flight_no = {FlightNumberTextBox.Text}");

                // Print the details to textbox
                foreach (var kvp in flightDeets)
                {
                    FlightStatusTextarea.AppendText($"{kvp.Key}: {kvp.Value}\n");
                }

                // Log event
                Logger.logEvent("Flight found!");
            }
            else
            {
                FlightStatusTextarea.Text = "Flight not found. Check your flight number and try again";

                // Log error
                Logger.logError("Flight not found");
            }
        }
    }
}
