using System;

namespace ARS
{
    public class Ticket
    {
        // Departure details
        public string FromCode { get; set; }
        public string FromLocation { get; set; }
        public string FromTime { get; set; }

        // Arrival details
        public string ToCode { get; set; }
        public string ToLocation { get; set; }
        public string ToTime { get; set; }

        public string Duration { get; set; }

        // Passenger details
        public int PassengerCount { get; set; }

        // Price of one ticket details
        public decimal TicketPrice { get; set; }

        // Grand Total Attributes
        public decimal GrandTotal { get; set; }

    }
}
