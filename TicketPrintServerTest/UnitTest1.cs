using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using local.defpub.TicketPrintServer;
using System.Threading;
using System.Diagnostics;
using System.Net.Sockets;
using System.IO;

namespace local.defpub.TicketPrintServer.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public EventLog el;
        public TicketPrintServer tps;

        public Thread StartServer ()
        {
            Thread thr;
            el = new EventLog();
            tps = new TicketPrintServer("ELGIN i9 (Rede)");

            el.Source = "TicketPrintServerTest";
            tps.Header = "IMPRESSAO DE TESTE";
            tps.Footer = "IMPRESSAO DE TESTE";
            thr = new Thread(new ThreadStart(() => tps.ServerLoop(el)));
            thr.Start();
            return thr;
        }

        public void PrintTest(string msg)
        {
            TcpClient client = new TcpClient();
            StreamWriter sw;

            client.Connect("localhost", 9100);
            Assert.IsTrue(client.Connected);
            try
            {
                sw = new StreamWriter(client.GetStream());
                sw.WriteLine("teste|teste|teste");
                sw.Close();
            }
            catch (SocketException ex)
            {
                Assert.Fail();
            }
            finally
            {
                client.Close();
            }
        }

        [TestMethod]
        public void PrintOK()
        {
            Thread thr = StartServer();
            PrintTest("teste|teste|teste");
            thr.Interrupt();
        }

        [TestMethod]
        public void PrintError()
        {
            Thread thr = StartServer();
            PrintTest("istonaovaiimprimirdejeitonenhum");
            thr.Interrupt();
        }

        [TestMethod]
        public void PrintStress()
        {
            Thread thr = StartServer();
            PrintTest("teste|teste|teste");
            PrintTest("istonaovaiimprimirdejeitonenhum");
            PrintTest("teste|teste|teste");
            thr.Interrupt();
        }
    }
}
