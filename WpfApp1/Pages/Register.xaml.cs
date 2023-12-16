using ARS.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
                MessageBox.Show("Cannot contain numbers or be empty ", "Invalid Name", MessageBoxButton.OK);
                return;
            }
            if (!Validator.IsValidEmail(email))
            {
                MessageBox.Show("Invalid Email", "Invalid Field", MessageBoxButton.OK);
                return;
            }

            // Hash and store password
            SecureString password = PasswordBox.SecurePassword;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password.ToString());

            // Store all the values
            Dictionary<string,object> customerDetails = new Dictionary<string, object>
            {
                { "first_name", firstName },
                { "last_name", lastName },
                { "password", passwordHash},
                { "email", email },
                { "date_of_birth", dob }
            };
            
            // Check if the user already exists
            if(mySQL.checkValue("customer","email",email))
            {
                MessageBox.Show("This user already exists!", "User Exists", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // Insert values to DB
                mySQL.insertValues("customer", customerDetails);

                // Insert values to temp storage
                Customer.setData(firstName + " " + lastName, email, dob);

                if(MessageBox.Show("User has been registered!", "Successful", MessageBoxButton.OK)== MessageBoxResult.OK)
                {                 
                    NavigationService.Navigate(new LoginPage());                   
                }
            }
            
        }
    }
}
