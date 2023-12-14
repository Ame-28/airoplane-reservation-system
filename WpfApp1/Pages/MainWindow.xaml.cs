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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SQL mySQL = new SQL(ConfigurationManager.AppSettings["server"],
                            ConfigurationManager.AppSettings["database"],
                            ConfigurationManager.AppSettings["userId"],
                            ConfigurationManager.AppSettings["password"]);
        Logger myLog = new Logger("log.txt");

        public MainWindow()
        {
            InitializeComponent();
            myLog.initLog();
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

            // Check user name field
            if (!Validator.IsValidUserName(userName))
            {
                userNameError.Text = "ERROR: The username is invalid\nDo not enter number or null characters";
                myLog.logError("The username is invalid. Do not enter number or null characters");
            }

            // Check password field
            else if (password.Length == 0)
            {
                passwordError.Text = "ERROR: The password is empty";
                myLog.logError("The password is empty");
            }

            // Check user name in DB
            else
            {
                if (!mySQL.checkValue("customer", "first_name", userName))
                {
                    loginError.Text = "User not Found. Click here to register your account";
                    myLog.logError("User not Found. Click here to register your account");
                }
                else
                {
                    myLog.logEvent($"{userName} signed in successfully");
                    // Go to next page
                    Page page = new MainMenu();
                    this.Content = page;
                }
            }
        }
        
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Page register = new Register();
            this.Content = register;
        }  
    }
}
