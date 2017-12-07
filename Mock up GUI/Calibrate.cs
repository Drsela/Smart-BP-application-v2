using System;
using System.Drawing;
using System.Windows.Forms;
using Interfaces;

namespace PL
{
    public partial class Calibrate : Form
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
            var result =
                MessageBox.Show(
                    "Calibration Succesfull \n You need to restart the application to apply the calibration. \nPressing OK will exit the application",
                    "Attention", MessageBoxButtons.OK);

            if (result == DialogResult.OK)
                Application.Exit();
        }
    }
}