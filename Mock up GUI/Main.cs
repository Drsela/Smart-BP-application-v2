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
    public partial class Main : Form, IRawToFineObserver,ISystolicObserver
    {
        private iBusinessLogic _businessLogic;
        private ConcurrentQueue<Datacontainer> dataQueue;
        private AlarmDTO _alarm;
        private List<double> measureList;
        private List<double> fineList;
        private iPatientConsumerObserver observer;
        private double time;
        private AdjustBP _adjustBpForm;
        private bool isrunning;

        private int sysAdjust;
        private int diaAdjust;
        private Thread trackbarThread;
        delegate void StringArgReturningVoidDelegate(int sys);

        private int caseswitch = 1;

        public Main(iBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
            _businessLogic.AttachToRawFineObserver(this);
            _businessLogic.AttachToSystolicObserver(this);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (caseswitch)
            {
                case 1:
                {
                    _businessLogic.StopThreads(false);
                    _businessLogic.startThreads();

                    button3.Hide();
                    button4.Hide();
                    button5.Hide();
                    button6.Hide();
                    button1.Text = "Stop";
                    caseswitch = 2;
                    break;
                }
                case 2:
                {
                    _businessLogic.StopThreads(true);
                    button1.Text = "Start";
                    foreach (Control item in this.Controls)
                    {
                        item.Show();
                    }
                    caseswitch = 1;
                    break;
                }

            }

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
            monitorRadioButton.Checked = false;
            diagnoseRadioButton.Checked = false;
        }

        private void upperTrackBar_Scroll(object sender, EventArgs e)
        {
            UpperlimitText.Text = Convert.ToString(upperTrackBar.Value);
            _businessLogic.setUpperAlarm(upperTrackBar.Value);
        }

        private void lowerTrackBar_Scroll(object sender, EventArgs e)
        {
            LowerlimitText.Text = Convert.ToString(lowerTrackBar.Value);
            _businessLogic.setLowerAlarm(lowerTrackBar.Value);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
        }

        public void updateGraph()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action)delegate
                {
                    if (monitorRadioButton.Checked)
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
                    }

                    if (diagnoseRadioButton.Checked)
                    {
                        fineList = _businessLogic.getFineValues();
                        chart1.Series["Blodtryk"].Points.Clear();
                        for (int i = 0; i < fineList.Count; i++)
                        {
                            chart1.Series["Blodtryk"].Points.AddXY(i, fineList[i]); //Ændres til ConvertedValue
                            //time += 1/200;
                        }

                    }
                });
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Calibrate calibrateWindow = new Calibrate(_businessLogic);
            calibrateWindow.Show();
        }

        public void button6_Click(object sender, EventArgs e)
        {
            _adjustBpForm = new AdjustBP(this);
            _adjustBpForm.Show();
            this.trackbarThread = new Thread(this.updateTrackbar);

            this.trackbarThread.Start();
            isrunning = true;

        }

        public void updateTrackbar()
        {
            while (isrunning == true)
            {
                if (_adjustBpForm.getSys() > 0 && _adjustBpForm.getDia() > 0)
                {
                    sysAdjust = Convert.ToInt16(_adjustBpForm.getSys());
                    diaAdjust = Convert.ToInt16(_adjustBpForm.getDia());
                    this.setTrackbarSys(sysAdjust);
                    this.setTrackbarDia(diaAdjust);
                    //upperTrackBar.Value = Convert.ToInt16(_adjustBpForm.getSys());
                    //lowerTrackBar.Value = Convert.ToInt16(_adjustBpForm.getDia());
                    isrunning = false;
                }
            }
        }

        private void setTrackbarSys(int sys)
        {
            if (this.upperTrackBar.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(setTrackbarSys);
                this.Invoke(d, new object[] { sys });
            }
            else
            {
                this.upperTrackBar.Value = sys;
                this.UpperlimitText.Text = Convert.ToString(sys);
            }
        }
        private void setTrackbarDia(int dia)
        {
            if (this.upperTrackBar.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(setTrackbarDia);
                this.Invoke(d, new object[] { dia });
            }
            else
            {
                this.lowerTrackBar.Value = dia;
                this.LowerlimitText.Text = Convert.ToString(dia);
            }
        }

        public void updateSystolicValue()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action) delegate
                {
                    textBox3.Text = Convert.ToString(_businessLogic.getSystolicValue());
                });
            }
        }
    }
}
