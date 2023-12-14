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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ManageBooking_click(object sender, RoutedEventArgs e)
        {
            //flightstatus TravelDetails = new T();
            //Main_frame.Content = TravelDetails;
        }
        
    }
}
