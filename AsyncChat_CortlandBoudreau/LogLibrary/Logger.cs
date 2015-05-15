using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Interfaces;



namespace LoggingLibrary
{
    public class Logger : ILoggingService
    {
        /// <summary>
        /// This method ensures that the text file exsists, and if it doesn't
        /// it creates a new text file and appends the data to it.
        /// </summary>
        public void Log(string message)
        { 
            String curFile = @"Chatlog.txt";
            String formattedLog;
            formattedLog = DateTime.Now.ToString() + " - " + message;

            if (File.Exists(curFile))
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@curFile, true))
                        {
                            file.WriteLine(formattedLog);
                        }
            }

            else
            {

                System.IO.File.Create(@curFile).Dispose();
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@curFile, true))
                {
                    file.WriteLine(formattedLog);
                }
            }
  
         }//end start log

    }
}
