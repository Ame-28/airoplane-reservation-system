using System;
using System.Collections;
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
    /// Interaction logic for ManageBooking.xaml
    /// </summary>
    public partial class ManageBooking : Page
    {
        public ManageBooking()
        {
            InitializeComponent();
        }

        SQL mySQL = new SQL();

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Logger.logNavigation("Navigated to back");
            NavigationService.GoBack();
        }

        private void FindBookedFlightsButton_Click(object sender, RoutedEventArgs e)
        {
            if(mySQL.checkValue("Ticket", "TicketID", BookingIDTextBox.Text))
            {
                Dictionary<string,object> bookingDeets = mySQL.readValues("ticket", $"TicketID = {BookingIDTextBox.Text}");
                Logger.logEvent("Booking found!");

                // Print the details to textbox
                foreach (var kvp in bookingDeets)
                {
                    BookText.AppendText($"{kvp.Key}: {kvp.Value}\n"); 
                }
            }
            else
            {
                BookText.Text = "Booking not found!";
                Logger.logError("Booking not found!");
            }
        }
    }
}
