using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatLibrary;
using System.Threading;
using Interfaces;
using LoggingLibrary;

namespace AsyncChat_W0237252
{
    public partial class Network_Game : Form
    {
        /// <summary>
        /// Form Level Variables:
        /// 
        /// Client myClient;
        /// Server myServer;
        /// String send;
        /// Boolean type;
        /// Thread listenThread;
        /// Thread sendThread;
        /// </summary>


        Client myClient;
        Server myServer;
        String send;
        Boolean type;
        Thread listenThread;
        Thread sendThread;
        private readonly  ILoggingService Currentlogger;

        public Network_Game(ILoggingService Passedlogger)
        {
            InitializeComponent();
            this.Currentlogger = Passedlogger;
        }

        
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        /// <summary>
        /// On Click event for send button
        /// This starts a send thread using the data from the text box.s
        /// </summary>
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            string error=null;

                if (txtSendbox.Text.Length > 0)
                {

                    if (type) 
                    {
                        send = "Client: " + txtSendbox.Text;
                    
                    }
                    else
                    {
                        send = "Server: " + txtSendbox.Text;

                    }


                    if (type)
                    {
                        
                        txtConvo.Text = txtConvo.Text + "\r\n" + ">> " + send;
                        txtSendbox.Text = "";

                        sendThread = new Thread(() => error = myClient.Input(send));
                        sendThread.Name = "Client Send Thread";
                        sendThread.IsBackground = true;
                        sendThread.Start();


                        if (error != null)
                        {
                            txtConvo.Text = txtConvo.Text + "\r\n" + "System Message: " + error;

                        }
                    }

                    else if (!type)
                    {

                        txtConvo.Text = txtConvo.Text + "\r\n" + ">> " + send;
                        txtSendbox.Text = "";

                        sendThread = new Thread(() => error = myServer.Input(send));
                        sendThread.Name = "Server Send Thread";
                        sendThread.IsBackground = true;
                        sendThread.Start();

                        if (error != null) 
                        {
                            txtConvo.Text = txtConvo.Text + "\r\n" + "System Message: " + error;
                        
                        }

                    }

                }
                


        }

        /// <summary>
        /// On form load we turn off some GUI Objects as well as make
        /// the large text box read-only
        /// </summary>
        private void Network_Game_Load(object sender, EventArgs e)
        {
            txtConvo.ReadOnly = true;
            btnSendMessage.Enabled = false;
            disconnectmenuNetworkGame.Enabled = false;
        }

        /// <summary>
        /// This function attempts a connection to a server, if that fails
        /// this app then hosts as the server allowing you to connect to it
        /// using another client
        /// </summary>
        private void connectmenuNetworkGame_Click(object sender, EventArgs e)
        {

            // After looking at for simple servers and clients are... I wanted to make a much more diverse system...
            // My program should try and connect to a server, and if it fails, it will host a server until a client connects.
           
            //We pass in the Current Logger
            myClient = new Client(Currentlogger);
            myServer = new Server(Currentlogger);
            myClient.ProgressChanged += new ProgressChangedHandler(Chat_DataIncomingevent);
            myServer.ProgressChanged += new ProgressChangedHandler(Chat_DataIncomingevent);


            if (myClient.connectToServer())
            {
                this.Text += " (Client Enviroment)";
                this.Update();
                type = true;
                connectmenuNetworkGame.Enabled = false;
                btnSendMessage.Enabled = true;
                disconnectmenuNetworkGame.Enabled = true;
                myServer = null;         
                listenThread = new Thread(new ThreadStart(myClient.startListen));
                listenThread.Name = "Client Listen Thread";
                listenThread.IsBackground = true;
                listenThread.Start();
                txtConvo.Text = "System Message: Connected to Server...";
            }

            else
            {
                MessageBox.Show("No Servers are active.... Hosting server now... You will be unable to play while waiting for a client");
                myServer.listenforClient();
                myClient = null;
                this.Text += " (Server Enviroment)";
                this.Update();
                type = false;
                connectmenuNetworkGame.Enabled = false;
                btnSendMessage.Enabled = true;
                disconnectmenuNetworkGame.Enabled = true;

                listenThread = new Thread(new ThreadStart(myServer.startListen));
                listenThread.Name = "Server Listen Thread";
                listenThread.IsBackground = true;
                listenThread.Start();
                txtConvo.Text = "System Message: Client is connected...";
                
            }
        }

        /// <summary>
        /// Disconnect menu item, just calls disconnect method below
        /// </summary>
        private void disconnectmenuNetworkGame_Click(object sender, EventArgs e)
        {
            disconnectUI();
        }

        /// <summary>
        /// This event causes the disconnect method to fire
        /// </summary>
        private void exitmenuNetworkGame_Click(object sender, EventArgs e)
        {
            disconnectUI();
            Thread.Sleep(500);
        }

        /// <summary>
        /// This is an event for incoming data that is coming from the listen thread
        /// This event also handles some of the basic aspects of disconnects
        /// </summary>
        private void Chat_DataIncomingevent(ChatLibrary.ProgressChangedEventArgs mre)
        {

            if (txtConvo.InvokeRequired)
            {
                MethodInvoker myMethod =
                    new MethodInvoker(delegate
                    {
                        if (mre.Data == "**!@#$%^**END")
                        {
                            disconnectUI();
                            if (type)
                            {
                                txtConvo.Text = txtConvo.Text + "\r\n" + "Server Disconnected";
                            }
                            else if (!type)
                            {
                                txtConvo.Text = txtConvo.Text + "\r\n" + "Client Disconnected";
                            }

                        }

                        else if (mre.Data == "&&^^^%%#$$#%#$%#$%") 
                        {
                            txtConvo.Text = txtConvo.Text + "\r\n" + "Disconnected.";
                        }

                        else
                        {
                            if (type)
                            {
                                txtConvo.Text = txtConvo.Text + "\r\n" +  mre.Data;
                            }
                            else if (!type)
                            {
                                txtConvo.Text = txtConvo.Text + "\r\n"  + mre.Data;
                            }
                        }
                       
                    });

                txtConvo.BeginInvoke(myMethod);
            }
            else
            {
                txtConvo.Text = mre.Data;
            }
        }

        /// <summary>
        /// Sends a message to the client Or server that the other has disconnected
        /// </summary>
        private void sendDisconnect(Chat prog)
        {
          sendThread = new Thread(() => prog.Input("**!@#$%^**END"));
          sendThread.IsBackground = true;
          sendThread.Start();
        }

        /// <summary>
        /// Starts the disconnect process, stopping threads and disconnecting
        /// TCP Connections
        /// </summary>
        private void disconnectUI ()
        {
            if (myClient != null)
            {
                myClient.stopExecution = true;
                sendDisconnect(myClient);
                Thread.Sleep(500);// small wait to ensure threads are stopped before we close connections
                myClient.startDisconnect();
            }

            if (myServer != null)
            {

                myServer.stopExecution = true;
                myServer.startDisconnect();
                Thread.Sleep(500); // small wait to ensure threads are stopped before we close connections
                sendDisconnect(myServer);

            }

            connectmenuNetworkGame.Enabled = true;
            disconnectmenuNetworkGame.Enabled = false;
        
        }

        /// <summary>
        /// If the user hits the X Button on the top right this
        /// ensures that all threads are shutdown properly.
        /// </summary>
        private void Network_Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            disconnectUI();
            Thread.Sleep(500);

        }

        private void networkmenuNetworkGame_Click(object sender, EventArgs e)
        {

        }
    
    }




 }

