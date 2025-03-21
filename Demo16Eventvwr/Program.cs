using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo16Eventvwr
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLog log = new EventLog();
            log.Source = "Maria";
            log.WriteEntry("Esto es desde mi aplicación", EventLogEntryType.Information);
            log.WriteEntry("Esto es desde mi aplicación", EventLogEntryType.Error);
            log.WriteEntry("Esto es desde mi aplicación", EventLogEntryType.Warning);
/*            Exception exception = new Exception("BOOM");
*/        }
    }
}
