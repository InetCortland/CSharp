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
    public class Server : Chat
    {
       protected TcpListener serverListener = new TcpListener(localAddr, port);





       public Server(ILoggingService logger)
        {
            this.logger = logger;
        }
       /// <summary>
       /// This enables the server to start waiting for the client's
       /// connection, and it is only able to be called from a server object
       /// </summary>
       /// 
        public int listenforClient()
        {
            try {


            serverListener.Start();
            this.client = serverListener.AcceptTcpClient();
            stream = client.GetStream();


             }
                catch 
                {
                    return 0;
            
                }

            return 1;

        } // end Method ListenforClient


    }// end class Server
}// end namespace
