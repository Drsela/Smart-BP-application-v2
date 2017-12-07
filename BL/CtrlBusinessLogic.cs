using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using DTO;
using Interfaces;

namespace BL
{
    public class CtrlBusinessLogic : iBusinessLogic
    {
        private readonly Alarm _alarmWithOutParameter; //Opretter alarm. Parametre kan sættes vha. Get/Set
        private readonly CalculateBloodPreassure _calculateBloodPreassure; // Klasse til at beregne Sys/Dia
        private readonly CalcMeanBloodPreassure _calculateMean; // Klasse til at beregne middelblodtryk
        private readonly CalculatePulse _calculatePulse; // Klasse til at beregne pulsen
        private readonly Consumer _consumer; // Klasse til consumer/producer
        private readonly ConvertClass _convertClass; // Klasse til at konvertere mV to mmHg
        private readonly iDataAccessLogic _currentDal; // Forbindelse til datalaget
        private readonly AutoResetEvent _dataReadyEventMean; // Autoresetevent for trådsammenkobling
        private readonly AutoResetEvent _dataReadyEventPulse; // Autoresetevent for trådsammenkobling
        private readonly AutoResetEvent _dataReadyEventSystolic; // Autoresetevent for trådsammenkobling
        private readonly AutoResetEvent _dateReadyEventRawToFine; // Autoresetevent for trådsammenkobling
        private readonly RawToFine _rawtofine; // Klasse til smoothing filyrt
        private readonly SaveData _saveData; // Klasse til konvertering af måling til Byte Array
        private readonly SaveMeasurement _saveMeasurement; // Klasse til at uploade measurement til Databasen
        private readonly ConcurrentQueue<Datacontainer> asynchQueue; // Køen som bruges til Consumer/Producer
        private Calibration _calibration; // Klasse til at kalibrere systemet

        private Thread consumerThread; // Diverse tråde.
        private Thread meanBPThread; // Navnet forkarer det hele
        private Thread proucerThread;
        private Thread pulseThread;
        private Thread RawToFineThread;
        private Thread systolicThread;

        public CtrlBusinessLogic(iDataAccessLogic mydal, ConcurrentQueue<Datacontainer> RawDataQueue)
        {
            _currentDal = mydal;
            asynchQueue = RawDataQueue;
            _convertClass = new ConvertClass(mydal);
            _dateReadyEventRawToFine = new AutoResetEvent(false);
            _dataReadyEventSystolic = new AutoResetEvent(false);
            _dataReadyEventMean = new AutoResetEvent(false);
            _dataReadyEventPulse = new AutoResetEvent(false);
            _consumer = new Consumer(asynchQueue, _convertClass);
            _rawtofine = new RawToFine(_dateReadyEventRawToFine, _consumer);
            _currentDal.setAsyncQueue(asynchQueue);
            _alarmWithOutParameter = new Alarm();
            _calculateBloodPreassure =
                new CalculateBloodPreassure(_dataReadyEventSystolic, _consumer, this, _alarmWithOutParameter);
            _saveMeasurement = new SaveMeasurement();
            _calibration = new Calibration(_convertClass.GetZeroPointValue());
            _calculateMean = new CalcMeanBloodPreassure(_dataReadyEventMean, _consumer);
            _calculatePulse = new CalculatePulse(_dataReadyEventPulse, _consumer);
            _saveData = new SaveData();
        }

        public void AttachToMeanBPObserver(IMeanBPObserver observer)
        {
            _calculateMean.Attach(observer);
        }

        public void AttachToPulseObserver(IPulseObserver observer)
        {
            _calculatePulse.Attach(observer);
        }

        public double getZeroPointValue()
        {
            return _convertClass.GetZeroPointValue();
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
            systolicThread = new Thread(_calculateBloodPreassure.calculateBloodpreassureThread) {IsBackground = true};
            meanBPThread = new Thread(_calculateMean.calculateMeanBPThread) {IsBackground = true};
            pulseThread = new Thread(_calculatePulse.calculatePulseThread) {IsBackground = true};

            consumerThread.Start();
            RawToFineThread.Start();
            systolicThread.Start();
            meanBPThread.Start();
            pulseThread.Start();
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

        public void uploadEmployee(string text, int employeeId, string s, byte[] allReadings)
        {
            _saveData.uploadMeasurementData(text, employeeId, s, allReadings, GetCalibrationValuesFromDAL().ID);
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
            var zp = _convertClass.GetZeroPointValue();
            _calibration = new Calibration(zp);
            _calibration.CalibrateSystem();
        }

        public CalibrationValuesDTO GetCalibrationValuesFromDAL()
        {
            return _currentDal.getValues();
        }


        public List<double> mwList()
        {
            return _consumer.mwList();
        }
    }
}