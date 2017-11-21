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
    public partial class Main : Form, IRawToFineObserver
    {
        private iBusinessLogic _businessLogic;
        private ConcurrentQueue<Datacontainer> dataQueue;
        private AlarmDTO _alarm;
        private List<double> measureList;
        private iPatientConsumerObserver observer;
        private double time;

        public Main(iBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
            _businessLogic.AttachToRawFineObserver(this);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataQueue = new ConcurrentQueue<Datacontainer>();
            //_businessLogic.startDataGathering();

            _businessLogic.StopThreads(false);
            _businessLogic.startThreads();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login formLogin = new Login(_businessLogic);
            formLogin.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //chart1.ChartAreas[0].AxisX.Interval = 2.5;
            chart1.ChartAreas[0].AxisY.Maximum= 1;
            chart1.ChartAreas[0].AxisY.Minimum = -1;
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
            _businessLogic.StopThreads(true);
        }

        public void updateGraph()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action)delegate
                {
                    
                    measureList = _businessLogic.mwList();

                    chart1.Series["Blodtryk"].Points.Clear();
                    for (int i = 0; i < measureList.Count; i++)
                    {
                        chart1.Series["Blodtryk"].Points.AddXY(i, measureList[i]); //Ændres til ConvertedValue
                        //time += 1/200;
                    }
                    //textBox3.Text = Convert.ToString(_businessLogic.getSysFromConsumer());       //Systole
                    //textBox2.Text = Convert.ToString(_businessLogic.getDiaFromConsumer());       //Diastole
                    
                });
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Calibrate calibrateWindow = new Calibrate(_businessLogic);
            calibrateWindow.Show();
        }
    }
}
