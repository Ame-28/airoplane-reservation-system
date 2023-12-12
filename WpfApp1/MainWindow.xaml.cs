using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        SQL mySQL = new SQL("localhost", "airlineDB", "root", "revival2017");

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            // Get user name and password
            string userName = UsernameTextBox.Text;
            SecureString password = PasswordBox.SecurePassword;

            // Check user name in DB
            if(mySQL.checkValue("customer", "first_name", userName))
            {
                loginError.Text = "User not Found. Click here to register your account";
            }
            else
            {
                // Check user name field
                validateUserName(userName);

                // Check password field
                if (password.Length == 0)
                {
                    passwordError.Text = "ERROR: The password is empty";
                }
                else
                {
                    // Go to next page
                    Page page = new Page1();
                    this.Content = page;
                }
            }
        }

        public void validateUserName(string userName)
        {
            if(userName == string.Empty)
            {
                userNameError.Text = "ERROR: The username does not allow numbers";
            }
            if(userName.Any(char.IsDigit))
            {
                userNameError.Text = "ERROR: The username cannot be empty";
            }
        }
    }
}
