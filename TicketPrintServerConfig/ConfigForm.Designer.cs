namespace TicketPrintServerConfig
{
    partial class configForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.printerNameLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.printerComboBox = new System.Windows.Forms.ComboBox();
            this.portField = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.headerField = new System.Windows.Forms.TextBox();
            this.footerLabel = new System.Windows.Forms.Label();
            this.footerField = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.tpsController = new System.ServiceProcess.ServiceController();
            this.testPrinterButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.serviceStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.svcControlGroupBox = new System.Windows.Forms.GroupBox();
            this.svcStopButton = new System.Windows.Forms.Button();
            this.svcStartButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.svcControlGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // printerNameLabel
            // 
            this.printerNameLabel.AutoSize = true;
            this.printerNameLabel.Location = new System.Drawing.Point(12, 22);
            this.printerNameLabel.Name = "printerNameLabel";
            this.printerNameLabel.Size = new System.Drawing.Size(61, 13);
            this.printerNameLabel.TabIndex = 0;
            this.printerNameLabel.Text = "Impressora:";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(38, 52);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(35, 13);
            this.portLabel.TabIndex = 1;
            this.portLabel.Text = "Porta:";
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Location = new System.Drawing.Point(12, 76);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(61, 13);
            this.headerLabel.TabIndex = 2;
            this.headerLabel.Text = "Cabeçalho:";
            // 
            // printerComboBox
            // 
            this.printerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.printerComboBox.FormattingEnabled = true;
            this.printerComboBox.Location = new System.Drawing.Point(80, 22);
            this.printerComboBox.Name = "printerComboBox";
            this.printerComboBox.Size = new System.Drawing.Size(313, 21);
            this.printerComboBox.TabIndex = 3;
            // 
            // portField
            // 
            this.portField.Location = new System.Drawing.Point(80, 49);
            this.portField.Name = "portField";
            this.portField.Size = new System.Drawing.Size(100, 20);
            this.portField.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // headerField
            // 
            this.headerField.Location = new System.Drawing.Point(80, 76);
            this.headerField.MaxLength = 500;
            this.headerField.Multiline = true;
            this.headerField.Name = "headerField";
            this.headerField.Size = new System.Drawing.Size(397, 84);
            this.headerField.TabIndex = 5;
            // 
            // footerLabel
            // 
            this.footerLabel.AutoSize = true;
            this.footerLabel.Location = new System.Drawing.Point(25, 169);
            this.footerLabel.Name = "footerLabel";
            this.footerLabel.Size = new System.Drawing.Size(48, 13);
            this.footerLabel.TabIndex = 6;
            this.footerLabel.Text = "Rodapé:";
            // 
            // footerField
            // 
            this.footerField.Location = new System.Drawing.Point(80, 169);
            this.footerField.MaxLength = 500;
            this.footerField.Multiline = true;
            this.footerField.Name = "footerField";
            this.footerField.Size = new System.Drawing.Size(397, 90);
            this.footerField.TabIndex = 7;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(401, 283);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Salvar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // tpsController
            // 
            this.tpsController.ServiceName = "TicketPrintServer";
            // 
            // testPrinterButton
            // 
            this.testPrinterButton.Location = new System.Drawing.Point(399, 22);
            this.testPrinterButton.Name = "testPrinterButton";
            this.testPrinterButton.Size = new System.Drawing.Size(77, 23);
            this.testPrinterButton.TabIndex = 9;
            this.testPrinterButton.Text = "Testar";
            this.testPrinterButton.UseVisualStyleBackColor = true;
            this.testPrinterButton.Click += new System.EventHandler(this.testPrinterButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serviceStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 323);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(488, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // serviceStatusLabel
            // 
            this.serviceStatusLabel.Name = "serviceStatusLabel";
            this.serviceStatusLabel.Size = new System.Drawing.Size(29, 17);
            this.serviceStatusLabel.Text = "N/A";
            // 
            // svcControlGroupBox
            // 
            this.svcControlGroupBox.Controls.Add(this.svcStopButton);
            this.svcControlGroupBox.Controls.Add(this.svcStartButton);
            this.svcControlGroupBox.Location = new System.Drawing.Point(80, 264);
            this.svcControlGroupBox.Name = "svcControlGroupBox";
            this.svcControlGroupBox.Size = new System.Drawing.Size(169, 49);
            this.svcControlGroupBox.TabIndex = 11;
            this.svcControlGroupBox.TabStop = false;
            this.svcControlGroupBox.Text = "Controle de serviço";
            // 
            // svcStopButton
            // 
            this.svcStopButton.Location = new System.Drawing.Point(87, 19);
            this.svcStopButton.Name = "svcStopButton";
            this.svcStopButton.Size = new System.Drawing.Size(75, 23);
            this.svcStopButton.TabIndex = 1;
            this.svcStopButton.Text = "Parar";
            this.svcStopButton.UseVisualStyleBackColor = true;
            this.svcStopButton.Click += new System.EventHandler(this.svcStopButton_Click);
            // 
            // svcStartButton
            // 
            this.svcStartButton.Location = new System.Drawing.Point(6, 19);
            this.svcStartButton.Name = "svcStartButton";
            this.svcStartButton.Size = new System.Drawing.Size(75, 23);
            this.svcStartButton.TabIndex = 0;
            this.svcStartButton.Text = "Iniciar";
            this.svcStartButton.UseVisualStyleBackColor = true;
            this.svcStartButton.Click += new System.EventHandler(this.svcStartButton_Click);
            // 
            // configForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 345);
            this.Controls.Add(this.svcControlGroupBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.testPrinterButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.footerField);
            this.Controls.Add(this.footerLabel);
            this.Controls.Add(this.headerField);
            this.Controls.Add(this.portField);
            this.Controls.Add(this.printerComboBox);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.printerNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "configForm";
            this.Text = "Configuração do serviço de impressão de senhas do SGA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.configForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.svcControlGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label printerNameLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.ComboBox printerComboBox;
        private System.Windows.Forms.TextBox portField;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox headerField;
        private System.Windows.Forms.Label footerLabel;
        private System.Windows.Forms.TextBox footerField;
        private System.Windows.Forms.Button saveButton;
        private System.ServiceProcess.ServiceController tpsController;
        private System.Windows.Forms.Button testPrinterButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel serviceStatusLabel;
        private System.Windows.Forms.GroupBox svcControlGroupBox;
        private System.Windows.Forms.Button svcStopButton;
        private System.Windows.Forms.Button svcStartButton;
    }
}

