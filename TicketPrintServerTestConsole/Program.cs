using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using local.defpub.TicketPrintServer;

namespace local.defpub.TicketPrintServer.TicketPrintServerTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            EventLog el = new EventLog();
            TicketPrintServer tps;
            
            el.Source = "TicketPrintServerTest";
            tps = new TicketPrintServer("ELGIN i9 (Rede)");
            tps.ServerLoop(el);

        }
    }
}
