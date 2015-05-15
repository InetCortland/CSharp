using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Interfaces;

namespace ChatLibrary
{
    public class Client : Chat
    {


        public Client(ILoggingService logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// This allows the client to start a connection to the server
        /// this method is only able to be called by the client object
        /// </summary>
       public bool connectToServer()
        {

            try
            {
                this.client = new TcpClient(ipAddress, port);
                this.stream = client.GetStream();
            }
            catch {

                return false;
            
            }

            return true;

        
        }// end Method connecttoServer

    }//end Client class
}// end namespace
