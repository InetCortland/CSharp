using Microsoft.Practices.Unity;
using System;
using System.Windows.Forms;
using Interfaces;
using LoggingLibrary;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using CortlandsLogger_Nlog;


namespace AsyncChat_W0237252
{
    static class NetworkCode
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //********* WINDSOR ****************
            var container = new WindsorContainer();
            container.Register(Component.For<Network_Game>());

            //********* Nlog ****************
           // container.Register(Component.For<ILoggingService>().ImplementedBy<CortlandsNLog>());

            //********* Orginal Logger ****************
            container.Register(Component.For<ILoggingService>().ImplementedBy<Logger>());

            //********* Gregs Logger ****************

            //******* UNITY **************
            //UnityContainer container = new UnityContainer();
            //container.RegisterType<ILoggingService, Logger>();


            Application.Run(container.Resolve<Network_Game>());

        }
    }
}
