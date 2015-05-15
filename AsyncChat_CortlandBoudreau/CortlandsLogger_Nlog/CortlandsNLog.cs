using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using NLog;
using NLog.Targets;
using NLog.Layouts;
using NLog.Config;

namespace CortlandsLogger_Nlog
{

    /// <summary>
    /// This Uses the Nlog Library to create a log file. Though It has to use a configuration file
    /// Accept string and then log using the config file
    /// </summary>
    public class CortlandsNLog : ILoggingService
    {

        //Nlogger class
        Logger Nlogger = LogManager.GetLogger("CortlandsNLog");


        
        // private static Logger nlogger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Log Method for all Ilogging Interfaces
        /// </summary>
      public void Log(string message)
      {
         String formattedLog;
         formattedLog = DateTime.Now.ToString() + " - " + message;
         Nlogger.Log(LogLevel.Info, formattedLog);
             
      }
    }
}
