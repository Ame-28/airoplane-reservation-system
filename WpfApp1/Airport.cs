using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS
{
    public class Airport
    {
        public int AirportID { get; set; }
        public string AirportName { get; set; }
        public string AirportCity { get; set; }
        public string IATACode { get; set; }
        public int Terminals { get; set; }
        public int Gates { get; set; }
    }
}
