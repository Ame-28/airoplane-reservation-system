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
        Logger myLog = new Logger("log.txt");

        public MainWindow()
        {
            InitializeComponent();
            myLog.initLog();

            Pages.LoginPage loginPage = new Pages.LoginPage();
            MainPage_Frame.Content = loginPage;
        }       
    }
}
