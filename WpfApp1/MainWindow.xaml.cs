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
using Dapper;

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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            string userName = UsernameTextBox.Text;
            SecureString password = PasswordBox.SecurePassword;

            if (!validateUserName(userName))
            {
                userNameError.Text = "ERROR: The Username is invalid";
            }
            else
            {
                // Store the username and password in database
                Page page = new Page1();
                this.Content = page;
            }

        }

        public bool validateUserName(string userName)
        {
            if(userName == string.Empty)
            {
                return false;
            }
            else if(userName.Any(char.IsDigit))
            {
                return false;
            }
            else { return true; }
        }
    }
}
