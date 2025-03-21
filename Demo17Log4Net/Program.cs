using log4net.Config;
using log4net;
using System.Reflection;
using System.IO;

namespace Demo17Log4Net
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            log.Info("Esto es un mensaje de información");
            log.Debug("Mensaje de debug");
            log.Warn("Mensaje de advertencia");
            log.Error("Logear un error");
            log.Fatal("Logear un error crítico");
            log.Error("Ocurrio un error", new System.Exception("Boom"));
        }
    }
}
