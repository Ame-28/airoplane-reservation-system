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
    class Logger
    {
        public string FileName { get; set; }

        /*
        Method name  : Logger()
        Description  : Constructor for the Logger class.
        Parameters   : string name - Name of the log file.
        Return value : void
        */
        public Logger(string name)
        {
            FileName = name;
        }

        /*
        Method name  : initLog()
        Description  : Initializes the log file with server start information.
        Parameters   : string[] args - Array of command line arguments
        Return value : void
        */
        public void initLog()
        {
            using (StreamWriter sw = File.CreateText(AppDomain.CurrentDomain.BaseDirectory + FileName))
            {
                sw.WriteLine($"{DateTime.Now}: Log file created");
            }
        }

        /*
        Method name  : logEvent()
        Description  : Logs a general event message to the log file.
        Parameters   : Logger logMessage - The message to be logged.
        Return value : void
        */
        public void logEvent(string logMessage)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + FileName))
                {
                    sw.WriteLine($"{DateTime.Now}: {logMessage}");
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
        public void logError(string logMessage)
        {
            using (StreamWriter sw = File.AppendText(FileName))
            {
                sw.WriteLine($"{DateTime.Now}: ERROR: {logMessage}");
            }
        }

    }
}

