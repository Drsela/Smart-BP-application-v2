using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Interfaces;
using DTO;
using Accord.Statistics.Models.Regression.Linear;

namespace BL
{
    class Calibration
    {
        private iDataAccessLogic _iDataAccessLogic;
        private CalibrationValuesDTO _calibrationValuesDto;
        private double _zp;
        public Calibration(double zp)
        {
            _iDataAccessLogic = new CtrlDataAccessLogic();
            _calibrationValuesDto = new CalibrationValuesDTO();
            _zp = zp;
        }

        public void calibrateSystem()
        {
            _calibrationValuesDto.addValue(_iDataAccessLogic.getSingleReading());
            DialogResult dialogResponse = DialogResult.None;
            Debug.Write("ZP Value for Calibration: " + _zp);
            Debug.WriteLine("10 Mmhg: " + _calibrationValuesDto.getValues()[0]);
            for (int i = 0; i<= 1; i++)
            {
                if (i == 0)
                {
                     dialogResponse = MessageBox.Show("Apply 50 mmHg preassure to the transducer. Press Yes when the coloumn is connected",
                        "Important", MessageBoxButtons.OKCancel);
                }
                if (i == 1)
                {
                     dialogResponse = MessageBox.Show("Apply 100 mmHg preassure to the transducer. Press Yes when the coloumn is connected",
                        "Important", MessageBoxButtons.OKCancel);
                }
                if (dialogResponse == DialogResult.OK)
                {
                    _calibrationValuesDto.addValue(_iDataAccessLogic.getSingleReading());
                    //Debug.WriteLine(_calibrationValuesDto.getValues()[i+1]);
                }
                if (dialogResponse == DialogResult.Cancel)
                {
                    return;
                }
                Debug.WriteLine("Kalibrationsværdi: " + _calibrationValuesDto.getValues()[i]);
            }

            double[] _voltageArray =
            {
                _calibrationValuesDto.getValues()[0]-_zp, _calibrationValuesDto.getValues()[1]-_zp, _calibrationValuesDto.getValues()[2]-_zp
            };
            double[] _mmhgArray = {10, 50, 100};
            
            OrdinaryLeastSquares ols = new OrdinaryLeastSquares();
            SimpleLinearRegression _linearRegression = ols.Learn(_voltageArray, _mmhgArray);

            double slope = _linearRegression.Slope;
            double intercept = _linearRegression.Intercept;

            _calibrationValuesDto.Slope = slope;
            _calibrationValuesDto.Intercept = intercept;


            _iDataAccessLogic.uploadCalibation(_calibrationValuesDto);
        }
    }


}
