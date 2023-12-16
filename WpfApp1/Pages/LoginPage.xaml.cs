﻿using ARS;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
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

namespace ARS.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        SQL mySQL = new SQL();
        
        public LoginPage()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            // Clear all text
            userNameError.Text = string.Empty;
            passwordError.Text = string.Empty;
            loginError.Text = string.Empty;

            // Get user name and password
            string userName = UsernameTextBox.Text;
            SecureString password = PasswordBox.SecurePassword;

            // Hash and verify password
            string passwordHash = mySQL.readValues("customer", $"first_name = '{userName}'")["PASSWORD"].ToString();
            bool reverseHash = BCrypt.Net.BCrypt.Verify(SecureStringToString(password), passwordHash);

            // Check user name field
            if (!Validator.IsValidUserName(userName))
            {
                userNameError.Text = "ERROR: The username is invalid\nDo not enter number or null characters";
                Logger.logError("The username is invalid. Do not enter number or null characters");
            }

            // Check password field
            else if (password.Length == 0)
            {
                passwordError.Text = "ERROR: The password is empty";
                Logger.logError("The password is empty");
            }
            // Check if password is correct
            else if (!reverseHash)
            {
                passwordError.Text = "Incorrect Password. Please try again.";
                Logger.logError("Incorrect Password. Please try again.");
            }
            // Check user name in DB
            else
            {
                if (!mySQL.checkValue("customer", "first_name", userName))
                {
                    loginError.Text = "User not Found. Click here to register your account";
                    Logger.logError("User not Found. Click here to register your account");
                }
                else
                {
                    Logger.logEvent($"{userName} signed in successfully");

                    storeData(userName); // Store data temporarily

                    // Go to next page
                    MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

                    // Navigate to MainMenu.xaml on the main window's frame
                    if (mainWindow != null)
                    {
                        mainWindow.MainPage_Frame.Navigate(new Uri("/Pages/MainMenu.xaml", UriKind.Relative));
                    }


                }
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Register());
        }

        public void storeData(string userName)
        {
            Dictionary<string, object> vals = mySQL.readValues("customer", $"FIRST_NAME = '{userName}'");
            Customer.setData(vals["FIRST_NAME"].ToString() + " " + vals["LAST_NAME"].ToString(),
                                vals["EMAIL"].ToString(),
                                vals["DATE_OF_BIRTH"].ToString());
        }

        private string SecureStringToString(SecureString secureString)
        {
            IntPtr valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

    }
}
