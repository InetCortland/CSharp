using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using LoggingLibrary;
using System.Threading;
using Interfaces;

namespace ChatLibrary
{
    public abstract class Chat
    {

        /// <summary>
        /// Chat Class Level Variables:
        ///public Byte[] bytes = new Byte[256];
        ///public String data = null;
        ///public NetworkStream stream = null;
        ///public static String ipAddress = "127.0.0.1";
        ///public static IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        ///public static Int32 port = 13000;
        ///public TcpClient client = null;
        ///public ProgressChangedHandler ProgressChanged;
        ///public bool stopExecution = false;
        ///public Log logs = new Log();
        /// </summary>


        public Byte[] bytes = new Byte[256];
        public String data = null;
        public NetworkStream stream = null;
        public static String ipAddress = "127.0.0.1";
        public static IPAddress localAddr = IPAddress.Parse("127.0.0.1");
        public static Int32 port = 13000;
        public TcpClient client = null;
        public ProgressChangedHandler ProgressChanged;
        public bool stopExecution = false;
        //public Logger logs = new Logger();
        protected  ILoggingService logger;






        /// <summary>
        /// This method has a loop inside of it that trys to check if there is
        /// data in the datastream, and if there is it returns the value of the data
        /// </summary>
        public string Listen()
        {
            while (!stopExecution)
            {

                int i;
                data = null;
                try
                {
                    if (stream.DataAvailable)
                    {
                        while (stream.DataAvailable && (i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            // Translate data bytes to a ASCII string.
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            //Console.WriteLine(data);
                            // Process the data sent by the client.
                        }



                        return data;
                    }// end datastream if
                }
                catch (Exception e)
                {

                    return e.ToString(); 
                
                }
            }


            data = "&&^^^%%#$$#%#$%#$%";
            return data;
        }// End Listen Method



        /// <summary>
        /// This method takes a input string and sends it across the TCP Connectionm
        /// </summary>
        public String Input(String input)
        {
            //client = new TcpClient(ipAddress, port);
            //NetworkStream stream = client.GetStream();


            String message = input;
           


      
                try
                {
                    Byte[] dataout = System.Text.Encoding.ASCII.GetBytes(message);
                    stream.Write(dataout, 0, dataout.Length);

                    // Created thread which writes to the log
                    Thread logThread = new Thread(() => logger.Log(message));
                    logThread.IsBackground = true;
                    logThread.Start();
                    
                    return null;
                }
                catch (Exception e)
                {

                    return e.ToString();

                }
            

         
        }// end of input method


        /// <summary>
        /// This method is a outer loop that calls the Listen function, 
        /// this allows us to be completely seperate from the UI
        ///  and use events to send datas
        /// </summary>
        public void startListen() 
        {

            while (!stopExecution) 
            
            {

               string data = Listen();

               //raising an event

               if (ProgressChanged != null)
                   ProgressChanged(new ProgressChangedEventArgs(data));


            }// end while loop

        }

        /// <summary>
        /// Closes both the stream and client, proving a disonnection;
        /// </summary>
        public void startDisconnect()
        
        {
            
            stream.Close();
            client.Close();
            stream.Dispose();
        }



    } // end Abstract class Chat
}// end Namespace
