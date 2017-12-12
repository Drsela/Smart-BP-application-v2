using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Documents;
using System.Windows.Forms;
using Interfaces;

namespace PL
{
    public partial class Calibrate : Form, ICalibrateValueUpdater
    {
        public iBusinessLogic _BusinessLogic;

        public Calibrate(iBusinessLogic businessLogic)
        {
            InitializeComponent();
            _BusinessLogic = businessLogic;
        }

        private void Calibrate_Load(object sender, EventArgs e)
        {
            verticalProgressbar1.ForeColor = Color.Blue;
        }

        private void calibrateButton_Click_1(object sender, EventArgs e)
        {
            _BusinessLogic.getSingleReading();
        }

        public void updateCBValue()
        {
            if (InvokeRequired)
                Invoke((Action) delegate
                {
                    var values = _BusinessLogic.GetCalibrationValuesList();
                    label5.Text = values[0].ToString() + "mV";
                    label6.Text = values[1].ToString() + "mV";
                    label7.Text = values[2].ToString() + "mV";
                });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}