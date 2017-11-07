using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Interfaces;
using ST2Prj2LibNI_DAQ;

namespace DAL
{
    public class CtrlDataAccessLogic : iDataAccessLogic
    {
        private GetData _daq;
        private DatabaseConnection _databseConnection;
        public CtrlDataAccessLogic()
        {
        }
        

        public List<double> getData()
        {
            _daq = new GetData();
            return _daq.GetBpList();
        }

        public void saveSomeData(int val)
        {
        }

        public double getSingleReading()
        {
            _daq = new GetData();
            return _daq.getSingleValue();
        }

        public void uploadCalibation(CalibrationValuesDTO calibrationValuesDto)
        {
            _databseConnection = new DatabaseConnection();
            _databseConnection.uploadCalibration(calibrationValuesDto);
        }


    }
}
