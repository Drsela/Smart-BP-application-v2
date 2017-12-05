using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces;
using Mock_up_GUI;

namespace PL
{
    public partial class Calibrate : Form
    {
        public iBusinessLogic _BusinessLogic;
        private double _zeroPoint;
        public Calibrate(iBusinessLogic businessLogic,double ZeroPoint)
        {
            InitializeComponent();
            _BusinessLogic = businessLogic;
            _zeroPoint = ZeroPoint;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Calibrate_Load(object sender, EventArgs e)
        {
           verticalProgressbar1.ForeColor = Color.Blue;
        }

        private void calibrateButton_Click_1(object sender, EventArgs e)
        {
            _BusinessLogic.getSingleReading();
            DialogResult result =
                MessageBox.Show(
                    "Calibration Succesfull \n You need to restart the application to apply the calibration. \nPressing OK will exit the application",
                    "Attention", MessageBoxButtons.OK);

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
            
        }

        private void verticalProgressbar2_Click(object sender, EventArgs e)
        {

        }
    }
}
