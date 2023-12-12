using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WpfApp1
{
    public static class Validator
    {
        public static bool IsValidEmail(string email)
        {
            // This regular expression is a basic one and may not cover all valid email formats
            // Consider using a more comprehensive email validation library or regex for production
            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }

        public static bool IsValidUserName(string userName)
        {
            // UserName validation logic goes here
            // For example, you might want to check length, allowed characters, etc.
            // This is a simple example, and you should adjust it based on your requirements
            return !string.IsNullOrWhiteSpace(userName) && userName.Length <= 20;
        }
    }
}
