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
        private Consumer _consumer;
        private Thread proucerThread;
        private Thread consumerThread;
        private AlarmDTO _alarm;
        private Calibration _calibration;
        private ConsumerSubject _consumerSubject;

        public CtrlBusinessLogic(iDataAccessLogic mydal)
        {
            this._currentDal = mydal;
        }

        public void startAlarm()
        {
            
        }
        public void doAnAlogrithm()
        {

        }

        public void startThreads(ConcurrentQueue<Datacontainer> dataQueue, iPatientConsumerObserver observer)
        {
            _consumer = new Consumer(dataQueue); 
            _producer = new Producer(dataQueue);

            _consumer.Attach(observer);

            proucerThread = new Thread(_producer.RunProducer);
            consumerThread = new Thread(_consumer.RunConsumer);

            proucerThread.Start();
            consumerThread.Start();

        }
        public void AttachObserver(iPatientConsumerObserver observer)
        {
            _consumer.Attach(observer);
        }

        public void stopThreads()
        {
            proucerThread.Abort();
            consumerThread.Abort();
        }

        public void startAlarm(AlarmDTO alarm)
        {
            _alarm = alarm;
            _alarm.startAlarm();
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
    }
}
