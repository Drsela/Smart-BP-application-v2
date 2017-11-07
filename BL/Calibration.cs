using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Interfaces;
using DTO;

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
            _iDataAccessLogic.uploadCalibation(_calibrationValuesDto);
        }
    }
}
