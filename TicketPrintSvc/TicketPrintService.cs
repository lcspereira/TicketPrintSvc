using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using local.defpub.TicketPrintServer;
using IniParser;
using IniParser.Model;
using System.IO;

namespace TicketPrintSvc
{
    public partial class TicketPrintService : ServiceBase
    {
        private TicketPrintServer tps;
        private Thread srvThread;
        private IniData config;
        public TicketPrintService()
        {
            InitializeComponent();
            var parser = new FileIniDataParser();
            config = parser.ReadFile(@"C:\Program Files\DPERS\TicketPrintServer\TicketPrintServer.ini");
            tps = new TicketPrintServer(config["main"]["printerName"]);
            tps.Header = config["main"]["header"];
            tps.Footer = config["main"]["footer"];
            EventLog.Source = "TicketPrintServer";
        }

        protected override void OnStart(string[] args)
        {
            EventLog.WriteEntry("Iniciando serviço de impressão de senhas do SGA...", EventLogEntryType.Information);
            srvThread = new Thread(new ThreadStart(StartServer));
            srvThread.Start();
        }

        private void StartServer()
        {
            tps.ServerLoop(EventLog, int.Parse(config["main"]["port"]));
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("Encerrando serviço de impressão de senhas do SGA...", EventLogEntryType.Information);
            srvThread.Interrupt();
        }
    }
}
