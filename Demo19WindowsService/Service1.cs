using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using log4net.Repository.Hierarchy;
using log4net;

namespace Demo19WindowsService
{
    public partial class Service1: ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        EventLog evt = new EventLog();
        System.Timers.Timer timer = new System.Timers.Timer();

        protected override void OnStart(string[] args)
        {
                timer.Interval = int.Parse(ConfigurationManager.AppSettings["INTERVAL_SEGUNDO"]) * 1000;
            fswMonitor.Path = ConfigurationManager.AppSettings["RUTA"];
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
            timer.Start();
            evt.Source = "Application";
            evt.WriteEntry("La aplicación inició");
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(ConfigurationManager.AppSettings["ARCHIVO"], true) { AutoFlush = true })
            {
                sw.WriteLine(DateTime.Now.ToLongTimeString());
            };
        }

        protected override void OnStop()
        {
            evt.WriteEntry("Aplicación detenida");
            log.Info("Aplicación detenida");
        }

        private void fswMonitor_Changed(object sender, System.IO.FileSystemEventArgs e) {
            evt.WriteEntry("Cambió: " + e.Name);
            log.Info("Cambió: " + e.Name);
        }

        private void fswMonitor_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            evt.WriteEntry("Se creó: " + e.Name);
            log.Info("Se creó: " + e.Name);
        }

        private void fswMonitor_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            evt.WriteEntry("Se eliminó: " + e.Name);
            log.Info("Se eliminó: " + e.Name);
        }

        private void fswMonitor_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            evt.WriteEntry("Se cambió: " + e.OldName + ">" + e.Name);
            log.Info("Se cambió: " + e.OldName + ">" + e.Name);
        }
    }
}
