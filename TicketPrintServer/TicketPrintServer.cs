using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ESC_POS_USB_NET.Printer;
using local.defpub.TicketPrintServer.Exceptions;

/*
 * TicketPrintServer
 * 
 * Classe para conexão com impressora térmica e suporte a socket.
 * 
 * @author: Lucas Pereira (lucaspereira@defensoria.rs.def.br)
 * @since: 13/01/2020
 * 
 */
namespace local.defpub.TicketPrintServer
{
    public class TicketPrintServer
    {
        private TcpListener server;
        private TcpClient client;
        private Printer printer;

        public string Header { get; set; } // Cabeçalho da ficha
        public string Footer { get; set; } // Rodapé da ficha

        
        /**
         * TicketPrintServer
         * 
         * Construtor da classe. Inicializa a impressora.
         */
        public TicketPrintServer(string printerName)
        {
            printer = new Printer(printerName);
        }

        /**
         * TestPrinter
         * 
         * Imprime página de testes.
         */ 
        public void TestPrinter ()
        {
            printer.TestPrinter();
            printer.FullPaperCut();
            printer.PrintDocument(); 
        }

        /*
         * ServerLoop
         * 
         * Executa o socket servidor para receber comandos da impressora.
         * 
         * @param EventLog: Log de eventos para o serviço
         * @param int: Porta do socket servidor.
         */
        public void ServerLoop(EventLog log, int port = 9100)
        {
            NetworkStream ns = null;
            string data;
            string[] dataPrint;

            try
            {
                server = new TcpListener(IPAddress.Any, port);
                log.WriteEntry("Iniciando servidor na porta " + port + "...", EventLogEntryType.Information);
                server.Start();
                while (true)
                {
                    try
                    {
                        
                        client = server.AcceptTcpClient();
                        ns = client.GetStream();
                        log.WriteEntry("Recebendo conexão de " + ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString() + "...", EventLogEntryType.Information);

                        // Recebe mensagem pela rede no formato unidade|data|senha
                        using (StreamReader sr = new StreamReader(ns))
                        {
                            data = sr.ReadLine();
                            dataPrint = data.Split('|');
                            Print(dataPrint);
                        }
                    }
                    catch (UnknownMessageException ex)
                    {
                        log.WriteEntry(ex.Message, EventLogEntryType.Warning);
                    }
                    catch (IOException ex)
                    {
                        log.WriteEntry(ex.Message, EventLogEntryType.Warning);
                    }
                    catch (ArgumentException ex)
                    {
                        log.WriteEntry(ex.Message, EventLogEntryType.Warning);
                    }
                    catch (SocketException ex)
                    {
                        log.WriteEntry(ex.Message, EventLogEntryType.Warning);
                    }
                    catch (Exception ex)
                    {
                        log.WriteEntry(ex.ToString(), EventLogEntryType.Warning);
                    }
                    finally
                    {
                        client.Close();
                    }
                }
                
            }
            catch (SocketException ex)
            {
                log.WriteEntry("FATAL: " + ex.Message, EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                log.WriteEntry("FATAL: " + ex.ToString(), EventLogEntryType.Error);
            }
        }
        
        /*
         * Print
         * 
         * Efetua a impressão.
         * 
         * @throws UnknownMessageException: E
         * 
         */
        public void Print(string[] dataPrint)
        {
            try
            {
                printer.AlignCenter();
                printer.BoldMode(Header);
                printer.NewLine();
                printer.NormalWidth();
                printer.Append(dataPrint[0]);
                printer.Append(dataPrint[1]);
                printer.NewLine();
                printer.Separator();
                printer.DoubleWidth3();
                printer.BoldMode(dataPrint[2]);
                printer.NormalWidth();
                printer.Separator();
                printer.NewLine();
                printer.AlignLeft();
                printer.BoldMode(Footer);
                printer.FullPaperCut();
                printer.PrintDocument();
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new UnknownMessageException("Recebida mensagem desconhecida: " + string.Join("", dataPrint));
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.ToString());
            }
            finally
            {
                printer.Clear();
            }
        }
    }
}
