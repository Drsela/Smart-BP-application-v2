using System;
using System.Collections.Concurrent;
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
        private DatabaseConnection _databaseConnection;
        private AsyncDAQ _asyncDAQ;
        private ConcurrentQueue<Datacontainer> _datacontainer;

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
            _databaseConnection = new DatabaseConnection();
            _databaseConnection.uploadCalibration(calibrationValuesDto);
        }

        public CalibrationValuesDTO getValues()
        {
            _databaseConnection = new DatabaseConnection();
            return _databaseConnection.getCalibrationValues();
        }

        public void startAsyncDAQ()
        {
            _asyncDAQ.InitiateAsyncDaq();
        }

        public void setAsyncQueue(ConcurrentQueue<Datacontainer> AsyncQueue)
        {
            _asyncDAQ = new AsyncDAQ(AsyncQueue);
        }
    }
}
