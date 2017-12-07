using System.Collections.Concurrent;
using System.Collections.Generic;
using DTO;
using Interfaces;

namespace DAL
{
    public class CtrlDataAccessLogic : iDataAccessLogic
    {
        private AsyncDAQ _asyncDAQ;
        private GetData _daq;
        private DatabaseConnection _databaseConnection;
        private ConcurrentQueue<Datacontainer> _datacontainer;

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

        public void stopAsyncDAQ()
        {
            _asyncDAQ.StopMeasurement();
        }

        public void setAsyncQueue(ConcurrentQueue<Datacontainer> AsyncQueue)
        {
            _asyncDAQ = new AsyncDAQ(AsyncQueue);
        }
    }
}