using Microsoft.Win32;
using System;
using System.IO;
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
using System.Configuration;

namespace ARS.Pages
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        public Account()
        {
            InitializeComponent();
            UserNameAccount.Text = Customer.UserName;
            gmailAccount.Text = Customer.Email;
            DOBAccount.Text = Customer.DOB;
        }

        private void BookingListTextBox_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void DownloadLogButton_Click(object sender, RoutedEventArgs e)
        {
            // Path to your text file
            string filePath = ConfigurationManager.AppSettings["logFileName"];

            // Create a SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = ConfigurationManager.AppSettings["logFileName"];
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            // Show the dialog and get the result
            bool? result = saveFileDialog.ShowDialog();

            // Process the result
            if (result == true)
            {
                try
                {
                    // Get the selected file path
                    string selectedFilePath = saveFileDialog.FileName;

                    // Copy the file to the selected path
                    File.Copy(filePath, selectedFilePath, true);

                    MessageBox.Show("File downloaded successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    Logger.logEvent("File downloaded successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error downloading file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Logger.logError($"Error downloading file: {ex.Message}");
                }
            }
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            // Go back to login page
            if (mainWindow != null)
            {
                mainWindow.MainPage_Frame.Navigate(new Uri("/Pages/LoginPage.xaml", UriKind.Relative));
            }
        }
    }
}
