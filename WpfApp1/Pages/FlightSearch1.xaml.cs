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
    /// Interaction logic for FlightSearch1.xaml
    /// </summary>
    public partial class FlightSearch1 : Page
    {
        public FlightSearch1()
        {
            InitializeComponent();
        }

        public FlightSearch1(List<FlightDetailsTag> flights)
        {
            InitializeComponent();
            populateFlightTag(flights);
        }

        public void populateFlightTag(List<FlightDetailsTag> flights)
        {
            foreach (var i in flights)
            {
                // Add the new instance to the StackPanel
                i.Margin = new Thickness(0, 0, 0, 10);
                flightStack.Children.Add(i);
            }              
        }

        //public 
    }
}
