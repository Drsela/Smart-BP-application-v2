﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using DAL;
using DTO;
using Interfaces;


namespace BL
{
    public class CtrlBusinessLogic : iBusinessLogic
    {
        private iDataAccessLogic _currentDal;
        private Producer _producer;
        private AsyncDAQ _producerAsyncDaq;
        private Consumer _consumer;
        private CalculateBloodPreassure _calculateBloodPreassure;
        private Thread proucerThread;
        private Thread consumerThread;
        private Thread RawToFineThread;
        private Thread AlarmThread;
        private Thread systolicThread;
        private Thread pulseThread;
        private Alarm _alarmWithOutParameter;
        private Calibration _calibration;
        private ConsumerSubject _consumerSubject;
        private ConcurrentQueue<Datacontainer> asynchQueue;
        private RawToFine _rawtofine;
        private CalcMeanBloodPreassure _calculateMean;

        private AutoResetEvent _dateReadyEventRawToFine;
        private AutoResetEvent _dataReadyEventSystolic;
        private AutoResetEvent _dataReadyEventMean;
        private AutoResetEvent _dataReadyEventPulse;
        private bool threadStatus;
        private SaveMeasurement _saveMeasurement;
        private ConvertClass _convertClass;
        private CalculatePulse _calculatePulse;

        private Thread meanBPThread;
        public CtrlBusinessLogic(iDataAccessLogic mydal, ConcurrentQueue<Datacontainer> RawDataQueue)
        {
            this._currentDal = mydal;
            asynchQueue = RawDataQueue;
            _convertClass = new ConvertClass(mydal);
            _dateReadyEventRawToFine = new AutoResetEvent(false);
            _dataReadyEventSystolic = new AutoResetEvent(false);
            _dataReadyEventMean = new AutoResetEvent(false);
            _dataReadyEventPulse = new AutoResetEvent(false);
            _consumer = new Consumer(asynchQueue,_convertClass);
            _rawtofine = new RawToFine(_dateReadyEventRawToFine,_consumer);
            _currentDal.setAsyncQueue(asynchQueue);
            _alarmWithOutParameter = new Alarm();
            _calculateBloodPreassure = new CalculateBloodPreassure(_dataReadyEventSystolic, _consumer, this, _alarmWithOutParameter); 
            _saveMeasurement = new SaveMeasurement();
            _calibration = new Calibration();
            _calculateMean = new CalcMeanBloodPreassure(_dataReadyEventMean, _consumer);
            _calculatePulse = new CalculatePulse(_dataReadyEventPulse, _consumer);

        }

        public void AttachToMeanBPObserver(IMeanBPObserver observer)
        {
            _calculateMean.Attach(observer);
        }

        public void AttachToPulseObserver(IPulseObserver observer)
        {
            _calculatePulse.Attach(observer);
        }

        public int getMeanBloodPreassure()
        {
            return _calculateMean.getMeanBloodPreassure();
        }

        public void AttachToRawFineObserver(IRawToFineObserver observer)
        {
            _rawtofine.Attach(observer);
        }

        public void AttachToSystolicObserver(IBloodPressureObserver observer)
        {
            _calculateBloodPreassure.Attach(observer);
        }

        public int getPulse()
        {
            return _calculatePulse.getPulse();
        }

        public byte[] ConvertReadingToBytes()
        {
            var allReadings = _saveMeasurement.ConvertToBinary(_consumer.getAllReadings());
            return allReadings;
        }

        public void PerformZeroPoint()
        {
            _convertClass.setZeroPointValue(_currentDal.getSingleReading());
        }

        public void startThreads()
        {
            _currentDal.startAsyncDAQ();
            RawToFineThread = new Thread(_rawtofine.RunFineFilter) {IsBackground = true};
            consumerThread = new Thread(_consumer.RunConsumer) {IsBackground = true};
            systolicThread = new Thread(_calculateBloodPreassure.calculateSystolicThread) {IsBackground = true}; 
            meanBPThread = new Thread(_calculateMean.calculateMeanBPThread) {IsBackground = true};
            pulseThread = new Thread(_calculatePulse.calculatePulseThread) {IsBackground = true};
            AlarmThread = new Thread(_alarmWithOutParameter.startAlarm) {IsBackground = true};

            consumerThread.Start();
            RawToFineThread.Start();
            systolicThread.Start();
            meanBPThread.Start();
            pulseThread.Start();
            AlarmThread.Start();

            
            if (_alarmWithOutParameter != null)
            {
                AlarmThread = new Thread(_alarmWithOutParameter.CheckAlarmValues) { IsBackground = true };
                AlarmThread.Start();
            }

        }

        public void StopThreads(bool run)
        {
            _rawtofine.setThreadStatus(run);
            _consumer.setThreadStatus(run);
            _calculateBloodPreassure.setThreadStatus(run);
            _currentDal.stopAsyncDAQ();
        }

        public List<double> getFineValues()
        {
            return _rawtofine.getFineData();
        }

        public int getSystolicValue()
        {
            return _calculateBloodPreassure.getSystolicValue();
        }

        public int getDiastolicValue()
        {
            return _calculateBloodPreassure.getDiastolicValue();
        }

        public void setUpperAlarm(int sys)
        {
            _alarmWithOutParameter?.setHighValue(sys);
        }

        public void setLowerAlarm(int dia)
        {
            _alarmWithOutParameter?.setLowValue(dia);
        }

        public void muteAlarm()
        {
            _alarmWithOutParameter.PauseAlarm();
        }

        public void startAlarm()
        {
            _alarmWithOutParameter.startAlarm();
        }

        public void setCurrentSysValue(int sys)
        {
            _alarmWithOutParameter.setCurrentSys(sys);
        }

        public void setCurrentDiaValue(int dia)
        {
            _alarmWithOutParameter.setCurrentDia(dia);
        }

        public void getSingleReading()
        {
            _calibration = new Calibration();
            _calibration.calibrateSystem();
            
        }

        public CalibrationValuesDTO GetCalibrationValuesFromDAL()
        {
            return _currentDal.getValues();
        }



        public List<double> mwList()
        {
            return _consumer.mwList();
        }

        public void startDataGathering()
        {
            _currentDal.startAsyncDAQ();
        }
    }
}
