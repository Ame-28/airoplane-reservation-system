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
            SQL sql = new SQL();

            // Get From and To details
            fromDetails = sql.readValues("airport", $"CITY = '{FromTextBox.Text}'");
            toDetails = sql.readValues("airport", $"CITY = '{ToTextBox.Text}'");

        }

    }
}
