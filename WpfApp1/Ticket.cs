using System;

namespace ARS
{
    public static class Ticket
    {
        // Departure details
        public static string FromCode { get; set; }
        public static string FromLocation { get; set; }
        public static string FromTime { get; set; }

        // Arrival details
        public static string ToCode { get; set; }
        public static string ToLocation { get; set; }
        public static string ToTime { get; set; }

        public static string Duration { get; set; }

        // Passenger details
        public static int PassengerCount { get; set; }

        public static string TicketID { get; set; }
        public static int TicketPrice { get; set; }

        // Grand Total Attributes
        public static string GrandTotal { get; set; }

    }
}
