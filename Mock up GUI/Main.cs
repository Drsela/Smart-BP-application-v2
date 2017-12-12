using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Interfaces;

namespace PL
{
    public partial class Main : Form, IRawToFineObserver, IBloodPressureObserver, IMeanBPObserver, IPulseObserver
    {
        private readonly iBusinessLogic _businessLogic;
        private AdjustBP _adjustBpForm;
        private int _antalTimer;
        private int _caseswitch = 1;
        private int _diaAdjust;
        private List<double> _fineList;
        private bool _isrunning;
        private int _maxYValue;
        private List<double> _measureList;
        private int _minutter;
        private int _minYValue;
        private int _sekunder;
        private Stopwatch _stopwatch;
        private int _sysAdjust;
        private double _zeroPointValue;

        private Thread trackbarThread;

        public Main(iBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
            _businessLogic.AttachToRawFineObserver(this);
            _businessLogic.AttachToSystolicObserver(this);
            _businessLogic.AttachToMeanBPObserver(this);
            _businessLogic.AttachToPulseObserver(this);
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
        }

        public void updateBloodPreassureValues()
        {
            if (InvokeRequired)
                Invoke((Action) delegate
                {
                    textBox3.Text = Convert.ToString(_businessLogic.getSystolicValue());
                    textBox2.Text = Convert.ToString(_businessLogic.getDiastolicValue());
                });
        }

        public void updateMeanBP()
        {
            if (InvokeRequired)
                Invoke((Action) delegate { textBox4.Text = Convert.ToString(_businessLogic.getMeanBloodPreassure()); });
        }

        public void updatePulse()
        {
            if (InvokeRequired)
                Invoke((Action) delegate { textBox1.Text = Convert.ToString(_businessLogic.getPulse()); });
        }

        public void updateGraph()
        {
            if (InvokeRequired)
                Invoke((Action) delegate
                {
                    if (diagnoseRadioButton.Checked)
                    {
                        _measureList = _businessLogic.mwList();
                        if (_measureList.Max() > chart1.ChartAreas[0].AxisY.Maximum)
                            chart1.ChartAreas[0].AxisY.Maximum = Convert.ToInt32(_measureList.Max());
                        if (_measureList.Min() < chart1.ChartAreas[0].AxisY.Minimum)
                            chart1.ChartAreas[0].AxisY.Minimum = Convert.ToInt32(_measureList.Min());
                        if (_maxYValue > _measureList.Max() && _minYValue < _measureList.Min())
                        {
                            chart1.ChartAreas[0].AxisY.Maximum = _maxYValue;
                            chart1.ChartAreas[0].AxisY.Minimum = _minYValue;
                        }

                        chart1.Series["Blodtryk"].Points.Clear();
                        foreach (var t in _measureList)
                            chart1.Series["Blodtryk"].Points.AddY(t); //Ændres til ConvertedValue
                    }

                    if (monitorRadioButton.Checked)
                    {
                        _fineList = _businessLogic.getFineValues();
                        if (_fineList.Max() > chart1.ChartAreas[0].AxisY.Maximum)
                            chart1.ChartAreas[0].AxisY.Maximum = Convert.ToInt32(_fineList.Max());
                        if (_fineList.Min() < chart1.ChartAreas[0].AxisY.Minimum)
                            chart1.ChartAreas[0].AxisY.Minimum = Convert.ToInt32(_fineList.Min());
                        if (_maxYValue > _fineList.Max() && _minYValue < _fineList.Min())
                        {
                            chart1.ChartAreas[0].AxisY.Maximum = _maxYValue;
                            chart1.ChartAreas[0].AxisY.Minimum = _minYValue;
                        }


                        chart1.Series["Blodtryk"].Points.Clear();
                        foreach (var t in _fineList)
                            chart1.Series["Blodtryk"].Points.AddY(t);
                    }
                });
        }

        private void button1_Click(object sender, EventArgs e) //Startknappen
        {
            switch (_caseswitch)
            {
                case 1:
                {
                    _businessLogic.StopThreads(false);
                    _businessLogic.startThreads();
                    stopButton.Hide();
                    button3.Hide();
                    button6.Hide();
                    tabControl1.Hide();
                    button1.Text = "Stop";
                    timer1.Interval = 500;
                    timer1.Start();
                    _stopwatch = Stopwatch.StartNew();
                    button1.BackColor = Color.Yellow;
                    _caseswitch = 2;
                    break;
                }
                case 2:
                {
                    _businessLogic.StopThreads(true);
                    _businessLogic.muteAlarm();
                    button1.Text = "Start";
                    foreach (Control item in Controls)
                        item.Show();
                    _caseswitch = 1;
                        timer1.Stop();
                    MessageBox.Show(
                        "Measurement stopped. \nPress Save button to save the measurement \nRestart the application to perform a new measurement",
                        "Reminder", MessageBoxButtons.OK);
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e) // Save Button
        {
            var formLogin = new Login(_businessLogic);
            timer1.Stop();
            formLogin.Show();
        }

        private void Main_Load(object sender, EventArgs e) // Når formen loades
        {
            chart1.ChartAreas[0].AxisY.Maximum = _maxYValue;
            chart1.ChartAreas[0].AxisY.Minimum = _minYValue;
            monitorRadioButton.Checked = true;
            diagnoseRadioButton.Checked = false;
            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            var zeropointDialogResult =
                MessageBox.Show(
                    "You need to zeropoint adjust before you can start a reading. \nPress OK to enter the application and perform a ZeroPoint adjustment in the lower right corner \nPressing Cancel will close the application",
                    "Reminder", MessageBoxButtons.OKCancel);
            if (zeropointDialogResult == DialogResult.Cancel)
                Close();

            _maxYValue = 200;
            _minYValue = 50;
            button1.Enabled = false;
            UpperlimitText.Text = Convert.ToString(upperTrackBar.Value);
            LowerlimitText.Text = Convert.ToString(lowerTrackBar.Value);
        }

        private void upperTrackBar_Scroll(object sender, EventArgs e) // Opdaterer systol-alarm-værdien
        {
            UpperlimitText.Text = Convert.ToString(upperTrackBar.Value);
            _businessLogic.setUpperAlarm(upperTrackBar.Value);
        }

        private void lowerTrackBar_Scroll(object sender, EventArgs e) // Opdaterer diastol-alarm-værdien
        {
            LowerlimitText.Text = Convert.ToString(lowerTrackBar.Value);
            _businessLogic.setLowerAlarm(lowerTrackBar.Value);
        }

        private void stopButton_Click(object sender, EventArgs e) // Lukker applikationen
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e) // Åbner calibration-vinduet
        {
            var calibrateWindow = new Calibrate(_businessLogic);
            calibrateWindow.Show();
        }

        public void button6_Click(object sender, EventArgs e) // Åbner vinduet med mulighed for BP-adjustment
        {
            _adjustBpForm = new AdjustBP(this);
            _adjustBpForm.Show();
            trackbarThread = new Thread(updateTrackbar);

            trackbarThread.Start();
            _isrunning = true;
        }

        public void updateTrackbar() // Opdaterer trackbar på baggrund af BP-Adjustment vinduet
        {
            while (_isrunning)
                if (_adjustBpForm.getSys() > 0 && _adjustBpForm.getDia() > 0)
                {
                    _sysAdjust = Convert.ToInt16(_adjustBpForm.getSys());
                    _diaAdjust = Convert.ToInt16(_adjustBpForm.getDia());
                    setTrackbarSys(_sysAdjust);
                    setTrackbarDia(_diaAdjust);
                    //upperTrackBar.Value = Convert.ToInt16(_adjustBpForm.getSys());
                    //lowerTrackBar.Value = Convert.ToInt16(_adjustBpForm.getDia());
                    _isrunning = false;
                }
        }

        private void setTrackbarSys(int sys) // Opdaterer trackbar på baggrund af BP-Adjustment vinduet
        {
            if (upperTrackBar.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = setTrackbarSys;
                Invoke(d, sys);
            }
            else
            {
                upperTrackBar.Value = sys;
                UpperlimitText.Text = Convert.ToString(sys);
                _businessLogic.setUpperAlarm(sys);
            }
        }

        private void setTrackbarDia(int dia)
        {
            if (upperTrackBar.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = setTrackbarDia;
                Invoke(d, dia);
            }
            else
            {
                lowerTrackBar.Value = dia;
                LowerlimitText.Text = Convert.ToString(dia);
                _businessLogic.setLowerAlarm(dia);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e) // Timer til operationstid
        {
            _sekunder++;

            if (_sekunder >= 60)
            {
                _sekunder = 0;
                _minutter++;
            }
            if (_minutter >= 60)
            {
                _minutter = 0;
                _antalTimer++;
            }
            label8.Text = "Timer: " + _stopwatch.Elapsed.Hours + ":" + _stopwatch.Elapsed.Minutes + ":" +
                          _stopwatch.Elapsed.Seconds;
        }

        private void button5_Click(object sender, EventArgs e) // Zeropoint calibration
        {
            _businessLogic.PerformZeroPoint();
            _zeroPointValue = _businessLogic.getZeroPointValue();
            MessageBox.Show("The current ZeroPoint value is: " + _zeroPointValue + ". \nPress OK to use this value.");
            button1.Enabled = true;
        }

        private void muteButton_Click(object sender, EventArgs e) // Muter alarmen 30 sekunder.
        {
            _businessLogic.muteAlarm();
        }

        private delegate void StringArgReturningVoidDelegate(int sys); // Bruges til trackbars opdateringen.
    }
}