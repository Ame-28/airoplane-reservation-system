using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARS
{
    /*
    Class        : Logger
    Description  : Handles logging events and errors to a file.
    */
    public static class Logger
    {
        public static string FileName { get; set; }

        /*
        Method name  : initLog()
        Description  : Initializes the log file with server start information.
        Parameters   : string[] args - Array of command line arguments
        Return value : void
        */
        public static void initLog()
        {
            using (StreamWriter sw = File.CreateText(AppDomain.CurrentDomain.BaseDirectory + FileName))
            {
                sw.WriteLine($"{DateTime.Now} [INTIALIZED]: Log file created");
            }
        }

        /*
        Method name  : logEvent()
        Description  : Logs a general event message to the log file.
        Parameters   : Logger logMessage - The message to be logged.
        Return value : void
        */
        public static void logEvent(string logMessage)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + FileName))
                {
                    sw.WriteLine($"{DateTime.Now} [MESSAGE]: {logMessage}");
                }
            }
            catch (Exception e)
            {
                logError(e.Message);
            }
        }

        /*
        Method name  : logError
        Description  : Logs an error message to the log file.
        Parameters   : logMessage - The error message to be logged.
        Return value : void
        */
        public static void logError(string logMessage)
        {
            using (StreamWriter sw = File.AppendText(FileName))
            {
                sw.WriteLine($"{DateTime.Now} [ERROR]: {logMessage}");
            }
        }

        public static void logNavigation(string logMessage)
        {
            using (StreamWriter sw = File.AppendText(FileName))
            {
                sw.WriteLine($"{DateTime.Now} [NAVIGATION]: {logMessage}");
            }
        }
    }
}

