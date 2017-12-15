using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Accord.Statistics.Models.Regression.Linear;
using DAL;
using DTO;
using Interfaces;

namespace BL
{
    internal class Calibration : CalibrationSubject
    {
        private readonly CalibrationValuesDTO _calibrationValuesDto;
        private readonly iDataAccessLogic _iDataAccessLogic;
        private readonly double _zp;
        private List<double> CalibrationValues;

        public Calibration(double zp)
        {
            _iDataAccessLogic = new CtrlDataAccessLogic();
            _calibrationValuesDto = new CalibrationValuesDTO();
            _zp = zp;
        }

        public void CalibrateSystem()
        {
            _calibrationValuesDto.addValue(_iDataAccessLogic.getSingleReading());
            var dialogResponse = DialogResult.None;
            Debug.Write("ZP Value for Calibration: " + _zp);
            Debug.WriteLine("10 Mmhg: " + _calibrationValuesDto.getValues()[0]);
            for (var i = 0; i <= 1; i++)
            {
                if (i == 0)
                    dialogResponse = MessageBox.Show(
                        "Apply 50 mmHg preassure to the transducer. Press OK when the coloumn is connected",
                        "Important", MessageBoxButtons.OKCancel);
                if (i == 1)
                    dialogResponse = MessageBox.Show(
                        "Apply 100 mmHg preassure to the transducer. Press OK when the coloumn is connected",
                        "Important", MessageBoxButtons.OKCancel);
                if (dialogResponse == DialogResult.OK)
                    _calibrationValuesDto.addValue(_iDataAccessLogic.getSingleReading());
                if (dialogResponse == DialogResult.Cancel)
                    return;
                Debug.WriteLine("Kalibrationsværdi: " + _calibrationValuesDto.getValues()[i]);
            }

            CalibrationValues = new List<double>(_calibrationValuesDto.getValues());
            Notify();

            double[] _voltageArray =
            {
                _calibrationValuesDto.getValues()[0] - _zp, _calibrationValuesDto.getValues()[1] - _zp,
                _calibrationValuesDto.getValues()[2] - _zp
            };
            double[] _mmhgArray = {10, 50, 100};

            dialogResponse =
                MessageBox.Show(
                    "Are you satisfied with the values? \n10 mmHg: " + _voltageArray[0] + " \n50 mmHg: " + _voltageArray[1]+ " \n100 mmHg: " + _voltageArray[2]+ "\nPress Yes to use these values. \nPress no to abort calibration",
                    "", MessageBoxButtons.YesNo);
            switch (dialogResponse)
            {
                case DialogResult.Yes:
                    var ols = new OrdinaryLeastSquares();
                    var _linearRegression = ols.Learn(_voltageArray, _mmhgArray);

                    var slope = _linearRegression.Slope;
                    var intercept = _linearRegression.Intercept;

                    _calibrationValuesDto.Slope = slope;
                    _calibrationValuesDto.Intercept = intercept;


                    _iDataAccessLogic.uploadCalibation(_calibrationValuesDto);
                    MessageBox.Show("Succesfully calibrated! \nPressing OK will restart the application.");
                    Application.Restart();
                    break;
                case DialogResult.No:
                    MessageBox.Show("Calibration aborted", "Notice");
                    return;
            }
        }

        public List<double> getCalibrationValues()
        {
            return CalibrationValues; 
        }
    }
}