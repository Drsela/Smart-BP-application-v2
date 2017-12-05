using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using DTO;


namespace Interfaces
{


    public interface iDataAccessLogic
    {
        List<double> getData();//Signatur
        void saveSomeData(int val);

        void stopAsyncDAQ();
        double getSingleReading();
        void uploadCalibation(CalibrationValuesDTO calibrationValuesDto);
        CalibrationValuesDTO getValues();
        void startAsyncDAQ();

        void setAsyncQueue(ConcurrentQueue<Datacontainer> AsyncQueue);
    }
    public interface iBusinessLogic
    {
        void setCurrentSysValue(int sys);
        void setCurrentDiaValue(int dia);
        void AttachToMeanBPObserver(IMeanBPObserver observer);
        int getMeanBloodPreassure();
        int getSystolicValue();
        int getDiastolicValue();

        int getPulse();
        byte[] ConvertReadingToBytes();

        void PerformZeroPoint();
        void startThreads();

        void startAlarm();
        void getSingleReading();

        CalibrationValuesDTO GetCalibrationValuesFromDAL();

        void AttachToRawFineObserver(IRawToFineObserver observer);
        void AttachToSystolicObserver(IBloodPressureObserver observer);

        List<double> mwList();

        void startDataGathering();
        void StopThreads(bool run);
        List<double> getFineValues();

        void setUpperAlarm(int sys);
        void setLowerAlarm(int dia);
        void muteAlarm();
        void uploadEmployee(string text, int employeeId, string s, byte[] allReadings);
        void AttachToPulseObserver(IPulseObserver Observer);
        double getZeroPointValue();
    }

    public interface iPresentationLogic
    {
        void startUpGUI();
    }

    public interface iPatientConsumerObserver
    {
        void Update();
    }

    public interface IBloodPressureObserver
    {
        void updateSystolicValue();
    }
    public interface IConsumerObserver
    {
        void getObserverState();
    }

    public interface IRawToFineObserver
    {
        void updateGraph();
    }
    public interface IMeanBPObserver
    {
        void updateMeanBP();
    }

    public interface IPulseObserver
    {
        void updatePulse();
    }
}
