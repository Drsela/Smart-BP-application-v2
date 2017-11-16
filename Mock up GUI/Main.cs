using System;
using System.CodeDom;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BL;
using Interfaces;
using DTO;


namespace PL
{
    public partial class Main : Form, iPatientConsumerObserver
    {
        private iBusinessLogic _businessLogic;
        private GraphDTO _graphDTO;
        private ConcurrentQueue<Datacontainer> dataQueue;
        private AlarmDTO _alarm;
        private Datacontainer measurements;
        private List<double> measureList;
        private iPatientConsumerObserver observer;
        private double time;
        private Thread graphThread;

        public Main(iBusinessLogic businessLogic)
        {
            InitializeComponent();
            _businessLogic = businessLogic;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            CalibrationValuesDTO latestValues = _businessLogic.GetCalibrationValuesFromDAL();
            Debug.WriteLine("Slope is :" + latestValues.Slope);
            Debug.WriteLine("Intercept is: " + latestValues.Intercept);
            */
            dataQueue = new ConcurrentQueue<Datacontainer>();
            _businessLogic.startThreads(dataQueue,this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login formLogin = new Login(_businessLogic);
            formLogin.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.Maximum = 5;
            double time = 0;
        }

        private void upperTrackBar_Scroll(object sender, EventArgs e)
        {
            UpperlimitText.Text = Convert.ToString(upperTrackBar.Value);
            _alarm.setUpperLimit(upperTrackBar.Value);
        }

        private void lowerTrackBar_Scroll(object sender, EventArgs e)
        {
            LowerlimitText.Text = Convert.ToString(lowerTrackBar.Value);
            _alarm.setUpperLimit(lowerTrackBar.Value);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _businessLogic.stopThreads();
        }

        public void Update()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action)delegate
                {
                    //chart1.Series["Blodtryk"].Points.Clear();
                    measureList = _businessLogic.mwList();


                    for (int i = 0; i < measureList.Count; i++)
                    {
                        chart1.Series["Blodtryk"].Points.AddXY(time, measureList[i]); //Ændres til ConvertedValue
                        time += 0.001;
                    }
                    textBox3.Text = Convert.ToString(_businessLogic.getSysFromConsumer());       //Systole
                    textBox2.Text = Convert.ToString(_businessLogic.getDiaFromConsumer());       //Diastole
                });
            }

            /*
            List<double> grafList = grafContainer.getMVMeasaurement();

            for (int i = 0; i < grafList.Count; i++)
            {
                chart1.Series["Blodtryk"].Points.AddXY(counter, grafList[i]);
                counter = counter + 0.001;
            }
            */
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Calibrate calibrateWindow = new Calibrate(_businessLogic);
            calibrateWindow.Show();
        }
    }
}
