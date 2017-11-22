using System;
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
        private Thread proucerThread;
        private Thread consumerThread;
        private Thread RawToFineThread;
        private Thread AlarmThread;
        private Alarm _alarmWithOutParameter;
        private Calibration _calibration;
        private ConsumerSubject _consumerSubject;
        private ConcurrentQueue<Datacontainer> asynchQueue;
        private RawToFine _rawtofine;

        private AutoResetEvent _dateReadyEventRawToFine;
        private bool threadStatus;

        public CtrlBusinessLogic(iDataAccessLogic mydal, ConcurrentQueue<Datacontainer> RawDataQueue)
        {
            this._currentDal = mydal;
            asynchQueue = RawDataQueue;
            _dateReadyEventRawToFine = new AutoResetEvent(false);
            _consumer = new Consumer(asynchQueue);
            _rawtofine = new RawToFine(_dateReadyEventRawToFine,_consumer);
            _currentDal.setAsyncQueue(asynchQueue);
            _alarmWithOutParameter = new Alarm();
        }

        public void doAnAlogrithm()
        {

        }

        public void AttachToRawFineObserver(IRawToFineObserver observer)
        {
            _rawtofine.Attach(observer);
        }

        public void startThreads()
        {
            _currentDal.startAsyncDAQ();
            RawToFineThread = new Thread(_rawtofine.RunFineFilter) {IsBackground = true};
            consumerThread = new Thread(_consumer.RunConsumer) {IsBackground = true};

            consumerThread.Start();
            RawToFineThread.Start();

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
        }

        public List<double> getFineValues()
        {
            return _rawtofine.getFineData();
        }

        public void setUpperAlarm(int sys)
        {
            _alarmWithOutParameter?.setHighValue(sys);
        }

        public void setLowerAlarm(int dia)
        {
            _alarmWithOutParameter?.setLowValue(dia);
        }

        public void startAlarm()
        {
            _alarmWithOutParameter.startAlarm();
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

        public double getDiaFromConsumer()
        {
            return _consumer.getDia();
        }

        public double getSysFromConsumer()
        {
            return _consumer.getSys();
        }

        public void startDataGathering()
        {
            _currentDal.startAsyncDAQ();
        }
    }
}
