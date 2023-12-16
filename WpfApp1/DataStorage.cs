using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS
{
    public static class DataStorage
    {
        public static string UserName { get; set; }
        public static string Email { get; set; }
        public static string DOB { get; set; }

        public static void setData(string name, string email, string dob)
        {
            UserName = name;
            Email = email;
            DOB = dob;
        }
    }

}
