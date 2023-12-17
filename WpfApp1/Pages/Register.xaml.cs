using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ARS
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        SQL mySQL = new SQL();

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string email = EmailTextBox.Text;
            string dob = datePicker.Text;

            // Validate values
            if (!Validator.IsValidUserName(firstName) || !Validator.IsValidUserName(lastName))
            {
                Logger.logError("Name cannot contain numbers or be empty");
                MessageBox.Show("Cannot contain numbers or be empty ", "Invalid Name", MessageBoxButton.OK);
                return;
            }
            if (!Validator.IsValidEmail(email))
            {
                Logger.logError("Invalid Email");
                MessageBox.Show("Invalid Email", "Invalid Field", MessageBoxButton.OK);
                return;
            }

            // Hash and store password
            SecureString password = PasswordBox.SecurePassword;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(SecureStringToString(password));

            // Store all the values
            Dictionary<string, object> customerDetails = new Dictionary<string, object>
            {
                { "first_name", firstName },
                { "last_name", lastName },
                { "password", passwordHash},
                { "email", email },
                { "date_of_birth", dob }
            };

            // Check if the user already exists
            if (mySQL.checkValue("customer", "email", email))
            {
                Logger.logError("This user already exists!");
                MessageBox.Show("This user already exists!", "User Exists", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // Insert values to DB
                mySQL.insertValues("customer", customerDetails);

                // Insert values to temp storage
                Customer.setData(firstName + " " + lastName, email, dob);

                if (MessageBox.Show("User has been registered!", "Successful", MessageBoxButton.OK) == MessageBoxResult.OK)
                {
                    Logger.logEvent("User has been registered!");
                    NavigationService.Navigate(new LoginPage());
                }
            }
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
