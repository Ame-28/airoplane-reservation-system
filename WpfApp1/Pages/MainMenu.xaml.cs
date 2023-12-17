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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            TravelDetails TravelDetails = new TravelDetails();
            Main_frame.Content = TravelDetails;
        }  

        private void ManageBooking_click(object sender, RoutedEventArgs e)
        {
            ManageBooking ManageBooking = new ManageBooking();
            Main_frame.Content = ManageBooking;
        }
        private void AccountButton_clicked(object sender, RoutedEventArgs e)
        {
            Account AccountPage = new Account();
            Main_frame.Content = AccountPage;
        }
        private void SearchFlights_clicked(object sender, RoutedEventArgs e)
        {
            FlightSearch1 tag = new FlightSearch1();
            Main_frame.Content = tag;
        }
        private void FlightStatus_clicked(object sender, RoutedEventArgs e)
        {
            FlightStatus flightStatus = new FlightStatus();
            Main_frame.Content = flightStatus;           
        }
        
        private void CheckIn_clicked(object sender, RoutedEventArgs e)
        {
            CheckIn CheckIn = new CheckIn();
            Main_frame.Content = CheckIn;
        }


    }
}
