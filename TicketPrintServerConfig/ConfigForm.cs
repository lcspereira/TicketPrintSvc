using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using IniParser;
using IniParser.Model;
using System.Threading;
using local.defpub.TicketPrintServer;

namespace TicketPrintServerConfig
{
    public partial class configForm : Form
    {
        public configForm()
        {
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            var parser = new FileIniDataParser();
            IniData config;

            // Lista as impressoras instaladas no combobox.
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                printerComboBox.Items.Add(printer);
            }
            
            // Carregamento do arquivo de configuração.
            config = parser.ReadFile(@"C:\Program Files\DPERS\TicketPrintServer\TicketPrintServer.ini");
            printerComboBox.SelectedItem = config["main"]["printerName"];
            portField.Text = config["main"]["port"];
            headerField.Text = config["main"]["header"];
            footerField.Text = config["main"]["footer"];
            serviceStatusLabel.Text = tpsController.Status.ToString();
        }

        // Salva o arquivo de configuração
        private void saveButton_Click(object sender, EventArgs e)
        {
            IniData config = new IniData();
            FileIniDataParser parser = new FileIniDataParser();

            try
            {
                config["main"]["printerName"] = printerComboBox.SelectedItem.ToString();
                config["main"]["port"] = portField.Text;
                config["main"]["header"] = headerField.Text;
                config["main"]["footer"] = footerField.Text;
                parser.WriteFile(@"C:\Program Files\DPERS\TicketPrintServer\TicketPrintServer.ini", config);  
                MessageBox.Show("Configuração salva com sucesso.\nReinicie o serviço para efetivar as configurações.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao escrever arquivo de configuração:\n" + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Teste de impressão de senhas.
        private void testPrinterButton_Click(object sender, EventArgs e)
        {
            TicketPrintServer tps = new TicketPrintServer(printerComboBox.SelectedItem.ToString());
            tps.Header = headerField.Text;
            tps.Footer = footerField.Text;
            string[] testData = { "teste", "teste", "A001" };
            tps.Print(testData);
        }

        // Iniciar o serviço
        private void svcStartButton_Click(object sender, EventArgs e)
        {
            ServiceControl(true);
        }

        // Parar o serviço.
        private void svcStopButton_Click(object sender, EventArgs e)
        {
            ServiceControl(false);
            
        }

        // Controle de inicialização do serviço.
        private void ServiceControl(bool status)
        {
            try
            {
                if (status == true)
                {
                    serviceStatusLabel.Text = "Iniciando serviço...";
                    tpsController.Start();
                }
                else
                {
                    serviceStatusLabel.Text = "Parando serviço...";
                    tpsController.Stop();
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erro geral", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void configForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Atualiza o label de status do serviço a cada 5 segundos.
            while (true)
            {
                tpsController.Refresh();
                serviceStatusLabel.Text = tpsController.Status.ToString();
                Thread.Sleep(5000);
            }
        }
    }
}
