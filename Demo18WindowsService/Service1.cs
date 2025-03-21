using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Demo18WindowsService
{
    public partial class Service1: ServiceBase
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }
 
        protected override void OnStop()
        {
        }

        private void fswMonitor_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void fswMonitor_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            log.Info("Esto es un mensaje de información");
        }

        private void fswMonitor_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {

        }


        private void fswMonitor_Renamed(object sender, System.IO.RenamedEventArgs e)
        {

        }
    }
}
