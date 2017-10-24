/******************************************************************************
*
* Eksempel Program:
*   AcqVoltageSamples_IntClk 
*
* Kategori:
*   Simplel Windos Form som bruger en ST2Prj2LibNI-DAQ komponent
*
* Beskrivelse:
*   Dette eksempel viser hvorledes en dataopsamling eksternt på NI-DAQ enheden udføres
*   og hvorledes de opsamlede data indlæses i en WinForm.
*
*Instruktioner for brug af ST2Prj2LibNI-DAQ komponent:
*   Følg de 9 punkter i metoden "startButton_Click"
*
******************************************************************************/

using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
//Husk at sætte denne using reference for at få adgang til ST2Prj2LibNI-DAQ komponenten!!
using ST2Prj2LibNI_DAQ;

namespace NationalInstruments.Examples.AcqVoltageSamples_IntClk
{
    /// <summary>
    /// Summary description for MainForm.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {

        private DataColumn[] dataColumn = null;
        private DataTable dataTable = null;

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.GroupBox channelParametersGroupBox;
        private System.Windows.Forms.Label physicalChannelLabel;
        private System.Windows.Forms.Label rateLabel;
        private System.Windows.Forms.Label samplesLabel;
        private System.Windows.Forms.GroupBox timingParametersGroupBox;
        private System.Windows.Forms.GroupBox acquisitionResultGroupBox;
        private System.Windows.Forms.NumericUpDown samplesPerChannelNumeric;
        private System.Windows.Forms.DataGrid acquisitionDataGrid;
        private System.Windows.Forms.NumericUpDown rateNumeric;
        private System.Windows.Forms.ComboBox physicalChannelComboBox;
        private Label label1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            dataTable = new DataTable();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.channelParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.physicalChannelComboBox = new System.Windows.Forms.ComboBox();
            this.physicalChannelLabel = new System.Windows.Forms.Label();
            this.timingParametersGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rateLabel = new System.Windows.Forms.Label();
            this.samplesLabel = new System.Windows.Forms.Label();
            this.samplesPerChannelNumeric = new System.Windows.Forms.NumericUpDown();
            this.rateNumeric = new System.Windows.Forms.NumericUpDown();
            this.startButton = new System.Windows.Forms.Button();
            this.acquisitionResultGroupBox = new System.Windows.Forms.GroupBox();
            this.acquisitionDataGrid = new System.Windows.Forms.DataGrid();
            this.channelParametersGroupBox.SuspendLayout();
            this.timingParametersGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.samplesPerChannelNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateNumeric)).BeginInit();
            this.acquisitionResultGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acquisitionDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // channelParametersGroupBox
            // 
            this.channelParametersGroupBox.Controls.Add(this.physicalChannelComboBox);
            this.channelParametersGroupBox.Controls.Add(this.physicalChannelLabel);
            this.channelParametersGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.channelParametersGroupBox.Location = new System.Drawing.Point(8, 12);
            this.channelParametersGroupBox.Name = "channelParametersGroupBox";
            this.channelParametersGroupBox.Size = new System.Drawing.Size(232, 124);
            this.channelParametersGroupBox.TabIndex = 0;
            this.channelParametersGroupBox.TabStop = false;
            this.channelParametersGroupBox.Text = "Channel Parameters";
            // 
            // physicalChannelComboBox
            // 
            this.physicalChannelComboBox.Location = new System.Drawing.Point(120, 24);
            this.physicalChannelComboBox.Name = "physicalChannelComboBox";
            this.physicalChannelComboBox.Size = new System.Drawing.Size(96, 21);
            this.physicalChannelComboBox.TabIndex = 1;
            this.physicalChannelComboBox.Text = "Dev1/ai0";
            this.physicalChannelComboBox.SelectedIndexChanged += new System.EventHandler(this.physicalChannelComboBox_SelectedIndexChanged);
            // 
            // physicalChannelLabel
            // 
            this.physicalChannelLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.physicalChannelLabel.Location = new System.Drawing.Point(16, 24);
            this.physicalChannelLabel.Name = "physicalChannelLabel";
            this.physicalChannelLabel.Size = new System.Drawing.Size(96, 32);
            this.physicalChannelLabel.TabIndex = 0;
            this.physicalChannelLabel.Text = "Physical Channel:  Altid Dev1";
            // 
            // timingParametersGroupBox
            // 
            this.timingParametersGroupBox.Controls.Add(this.label1);
            this.timingParametersGroupBox.Controls.Add(this.rateLabel);
            this.timingParametersGroupBox.Controls.Add(this.samplesLabel);
            this.timingParametersGroupBox.Controls.Add(this.samplesPerChannelNumeric);
            this.timingParametersGroupBox.Controls.Add(this.rateNumeric);
            this.timingParametersGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.timingParametersGroupBox.Location = new System.Drawing.Point(8, 144);
            this.timingParametersGroupBox.Name = "timingParametersGroupBox";
            this.timingParametersGroupBox.Size = new System.Drawing.Size(232, 106);
            this.timingParametersGroupBox.TabIndex = 1;
            this.timingParametersGroupBox.TabStop = false;
            this.timingParametersGroupBox.Text = "Timing Parameters Bruges ikke";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Altid 10 samples 250Hz";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // rateLabel
            // 
            this.rateLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rateLabel.Location = new System.Drawing.Point(16, 56);
            this.rateLabel.Name = "rateLabel";
            this.rateLabel.Size = new System.Drawing.Size(64, 16);
            this.rateLabel.TabIndex = 2;
            this.rateLabel.Text = "Rate (Hz):";
            // 
            // samplesLabel
            // 
            this.samplesLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.samplesLabel.Location = new System.Drawing.Point(16, 24);
            this.samplesLabel.Name = "samplesLabel";
            this.samplesLabel.Size = new System.Drawing.Size(104, 16);
            this.samplesLabel.TabIndex = 0;
            this.samplesLabel.Text = "Samples / Channel:";
            // 
            // samplesPerChannelNumeric
            // 
            this.samplesPerChannelNumeric.Location = new System.Drawing.Point(120, 24);
            this.samplesPerChannelNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.samplesPerChannelNumeric.Name = "samplesPerChannelNumeric";
            this.samplesPerChannelNumeric.Size = new System.Drawing.Size(96, 20);
            this.samplesPerChannelNumeric.TabIndex = 1;
            this.samplesPerChannelNumeric.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // rateNumeric
            // 
            this.rateNumeric.DecimalPlaces = 2;
            this.rateNumeric.Location = new System.Drawing.Point(120, 56);
            this.rateNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.rateNumeric.Name = "rateNumeric";
            this.rateNumeric.Size = new System.Drawing.Size(96, 20);
            this.rateNumeric.TabIndex = 3;
            this.rateNumeric.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // startButton
            // 
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.startButton.Location = new System.Drawing.Point(80, 256);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(80, 24);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // acquisitionResultGroupBox
            // 
            this.acquisitionResultGroupBox.Controls.Add(this.acquisitionDataGrid);
            this.acquisitionResultGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.acquisitionResultGroupBox.Location = new System.Drawing.Point(248, 12);
            this.acquisitionResultGroupBox.Name = "acquisitionResultGroupBox";
            this.acquisitionResultGroupBox.Size = new System.Drawing.Size(272, 276);
            this.acquisitionResultGroupBox.TabIndex = 3;
            this.acquisitionResultGroupBox.TabStop = false;
            this.acquisitionResultGroupBox.Text = "Acquisition Results";
            // 
            // acquisitionDataGrid
            // 
            this.acquisitionDataGrid.AllowSorting = false;
            this.acquisitionDataGrid.DataMember = "";
            this.acquisitionDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.acquisitionDataGrid.Location = new System.Drawing.Point(8, 24);
            this.acquisitionDataGrid.Name = "acquisitionDataGrid";
            this.acquisitionDataGrid.ParentRowsVisible = false;
            this.acquisitionDataGrid.ReadOnly = true;
            this.acquisitionDataGrid.Size = new System.Drawing.Size(256, 248);
            this.acquisitionDataGrid.TabIndex = 1;
            this.acquisitionDataGrid.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(522, 296);
            this.Controls.Add(this.acquisitionResultGroupBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.timingParametersGroupBox);
            this.Controls.Add(this.channelParametersGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(584, 336);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acquire Voltage Samples - Internal Clock";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.channelParametersGroupBox.ResumeLayout(false);
            this.timingParametersGroupBox.ResumeLayout(false);
            this.timingParametersGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.samplesPerChannelNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rateNumeric)).EndInit();
            this.acquisitionResultGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acquisitionDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.DoEvents();
            Application.Run(new MainForm());
        }

        private void startButton_Click(object sender, System.EventArgs e)
        {
            //Her er de 9 trin der skal udføres for at bruge ST2Prj2LibNI-DAQ komponenten

            //1 Opret en ST2Prj2LibNI-DAQ komponent
            NI_DAQVoltage datacollector = new NI_DAQVoltage();

            //2 Opret en  datastruktur dataTabel med kun en kanal (Kolonne)
            initializeDataTable(1, ref dataTable);

            //3 Stop for start af endnu en dataopsamling
            startButton.Enabled = false;

            //4 Kun 10 målinger i dette eksempel. Propety på datacollector
            datacollector.samplesPerChannel = 10;

            //5 Valg af Dev1 enhed og ai0 input kanal. Propety på datacollector
            datacollector.deviceName = "Dev1/ai0";

            //6 Begynd dataopsamlign med ST2Prj2LibNI-DAQ komponent 
            //og returnere først når alle målinger er udført
            datacollector.getVoltageSeqBlocking();

            //7 Hent de opsamlede målinger fra ST2Prj2LibNI-DAQ komponenten 
            listToDataTable(datacollector.currentVoltageSeq, ref dataTable);

            //8 Vis data i WinForm eller brug data til hvad de nu skal bruges til
            acquisitionDataGrid.DataSource = dataTable;
            startButton.Enabled = true; //Tillad næste dataopsamling

            //9 Og "Farewell"
            return;
        }

        private void listToDataTable(List<double> voltageseq, ref DataTable dataTable)
        {
           
            int currentLineIndex = 0;
            foreach (double value in voltageseq)
            {
                dataTable.Rows[currentLineIndex][0] = value;
                currentLineIndex++;
                if (currentLineIndex == 10) // Fast bestemt i dette Hello World Eksempel
                    break;
            }
        }


        public void initializeDataTable(int numOfChannels, ref DataTable data)
        {
            //Initialisering af Winform datastruktur
            data.Rows.Clear();
            data.Columns.Clear();
            dataColumn = new DataColumn[numOfChannels];
            int numOfRows = 10; //Fast bestemt i dette Hello World Eksempel

            for (int currentChannelIndex = 0; currentChannelIndex < numOfChannels; currentChannelIndex++)
            {
                dataColumn[currentChannelIndex] = new DataColumn();
                dataColumn[currentChannelIndex].DataType = typeof(double);
                dataColumn[currentChannelIndex].ColumnName = "Dev1/ai0";
            }

            data.Columns.AddRange(dataColumn);

            for (int currentDataIndex = 0; currentDataIndex < numOfRows; currentDataIndex++)
            {
                object[] rowArr = new object[numOfChannels];
                data.Rows.Add(rowArr);
            }
        }

        private void physicalChannelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Ledig WinForm control
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
