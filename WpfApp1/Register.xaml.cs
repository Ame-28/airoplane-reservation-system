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

namespace WpfApp1
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

        SQL mySQL = new SQL("localhost", "airlineDB", "root", "revival2017");

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string email = EmailTextBox.Text;
            string dob = datePicker.Text;

            // Validate values
            if(!Validator.IsValidEmail(email))
            {
                MessageBox.Show("Invalid Email", "Invalid Field", MessageBoxButton.OK);
            }
            if (!Validator.IsValidUserName(firstName)||!Validator.IsValidUserName(lastName))
            {
                MessageBox.Show("Cannot contain numbers or be empty ", "Invalid Name", MessageBoxButton.OK);
            }

            // Store all the values
            Dictionary<string,object> customerDetails = new Dictionary<string,object>();

            customerDetails.Add("first_name", firstName);
            customerDetails.Add("last_name", lastName);
            customerDetails.Add("email", email);
            customerDetails.Add("date_of_birth", dob);
            
            // Check if the user already exists
            if(mySQL.checkValue("customer","email",email))
            {
                MessageBox.Show("This user already exists!", "User Exists", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                mySQL.insertValues("customer", customerDetails);
                MessageBox.Show("User has been registered!", "Successful", MessageBoxButton.OK);
            }
            
        }
    }
}
