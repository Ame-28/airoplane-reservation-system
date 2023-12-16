using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS
{
    public static class Route
    {
        public static string FromIATA { get; set; }
        public static string FromCity { get; set; }
        public static string ToIATA { get; set; }
        public static string ToCity { get; set; }
        public static int Distance { get; set; }
        public static int Duration { get; set; }
    }
}
