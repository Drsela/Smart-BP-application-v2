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
using System.Windows.Threading;
using BL;
using Interfaces;
using DTO;
using DateTime = System.DateTime;


namespace PL
{
    public partial class Main : Form, IRawToFineObserver, IBloodPressureObserver, IPulseMeanBPObserver
    {
        private iBusinessLogic _businessLogic;
        private ConcurrentQueue<Datacontainer> dataQueue;
        private AlarmDTO _alarm;
        private List<double> measureList;
        private List<double> fineList;
        private iPatientConsumerObserver observer;
        private double time;
        private double timeOne;
        private AdjustBP _adjustBpForm;
        private bool isrunning;

        private int sysAdjust;
        private int diaAdjust;
        private Thread trackbarThread;

        delegate void StringArgReturningVoidDelegate(int sys);

        private DispatcherTimer timer;
        private DateTime _nowDateTime;
        private int caseswitch = 1;

        private int antalTimer;
        private int minutter;
        private int sekunder;

        public Main(iBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
            _businessLogic.AttachToRawFineObserver(this);
            _businessLogic.AttachToSystolicObserver(this);
            timer = new DispatcherTimer();
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
                    stopButton.Hide();
                    button3.Hide();
                    button4.Hide();
                    button5.Hide();
                    button6.Hide();
                    button1.Text = "Stop";
                    caseswitch = 2;
                    timer1.Interval = 1000;
                    timer1.Start();
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
            _businessLogic.StopThreads(true);
            timer1.Stop();
            formLogin.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Maximum = 220;
            chart1.ChartAreas[0].AxisY.Minimum = -220;

            monitorRadioButton.Checked = true;
            diagnoseRadioButton.Checked = false;
            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            button1.Enabled = false;

            DialogResult zeropointDialogResult =
                MessageBox.Show(
                    "You need to zeropoint adjust before you can start a reading. \nPressing OK will perform such adjustment \nPress Cancel to close the application",
                    "Zeropoint adjust", MessageBoxButtons.OKCancel);

            if (zeropointDialogResult == DialogResult.Yes)
                button5_Click(this, e);
            if (zeropointDialogResult == DialogResult.Cancel)
                this.Close();
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
                this.Invoke((Action) delegate
                {
                    if (diagnoseRadioButton.Checked)
                    {
                        measureList = _businessLogic.mwList();
                        chart1.Series["Blodtryk"].Points.Clear();
                        for (int i = 0; i < measureList.Count; i++)
                        {
                            //chart1.Series["Blodtryk"].XValueType = ChartValueType.Time;
                            chart1.Series["Blodtryk"].Points.AddY(measureList[i]); //Ændres til ConvertedValue
                            //time = time + 0.002;
                            //time = Math.Round(time, 3);
                        }
                    }

                    if (monitorRadioButton.Checked)
                    {
                        fineList = _businessLogic.getFineValues();
                        chart1.Series["Blodtryk"].Points.Clear();
                        for (int i = 0; i < fineList.Count; i++)
                        {
                            chart1.Series["Blodtryk"].Points.AddY(fineList[i]); //Ændres til ConvertedValue
                            //timeOne = timeOne + 0.002;
                            //timeOne = Math.Round(timeOne, 3);
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
                this.Invoke(d, new object[] {sys});
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
                this.Invoke(d, new object[] {dia});
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
                    textBox2.Text = Convert.ToString(_businessLogic.getDiastolicValue());
                });
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sekunder++;

            if (sekunder >= 60)
            {
                sekunder = 0;
                minutter++;
            }
            if (minutter >= 60)
            {
                minutter = 0;
                antalTimer++;
            }

            label8.Text = "Timer: " + antalTimer + ":" + minutter + ":" + sekunder;

            //label8.Text = Convert.ToString(DateTime.Now);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _businessLogic.PerformZeroPoint();
            button1.Enabled = true;
        }

        public void updatePulseMeanBP()
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action) delegate
                {
                    
                });
            }
        }
    }
}
