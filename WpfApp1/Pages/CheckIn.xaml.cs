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
    /// Interaction logic for CheckIn.xaml
    /// </summary>
    public partial class CheckIn : Page
    {
        public CheckIn()
        {
            InitializeComponent();
        }

        private void CheckIn_Click(object sender, RoutedEventArgs e)
        {
            SQL mySQL = new SQL();
            if (mySQL.checkValue("ticket", "ticketId", BookingIDTextBox.Text))
            {
                // Log event
                Logger.logEvent("Booking found!");

                // Booking found
                errorImage.Visibility = Visibility.Collapsed;
                successImage.Visibility = Visibility.Visible;
                messageText.Text = "You have been checked in succesfully";

            }
            else
            {
                // Log error
                Logger.logError("Booking not found");

                // Booking not found
                successImage.Visibility= Visibility.Collapsed;
                errorImage.Visibility = Visibility.Visible;
                messageText.Text = "Sorry your booking is not found";
            }
        }
    }
}
