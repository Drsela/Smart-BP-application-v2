using System;
using System.Collections.Generic;
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
        public Calibration()
        {
            _iDataAccessLogic = new CtrlDataAccessLogic();
            _calibrationValuesDto = new CalibrationValuesDTO();
        }

        public void calibrateSystem()
        {
            _calibrationValuesDto.addValue(_iDataAccessLogic.getSingleReading());
            
            for (int i = 0; i<= 1; i++)
            {
                DialogResult dialogResponse = MessageBox.Show("Connect next coloumn as seen on the screen. Press Yes when the coloumn is connected",
                    "Important", MessageBoxButtons.YesNoCancel);
                if (dialogResponse == DialogResult.Yes)
                {
                    _calibrationValuesDto.addValue(_iDataAccessLogic.getSingleReading());
                }
            }

            double[] _voltageArray =
            {
                _calibrationValuesDto.getValues()[0], _calibrationValuesDto.getValues()[1], _calibrationValuesDto.getValues()[2]
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
