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
    public interface IConsumerObserver
    {
        void getObserverState();
    }

    public interface IRawToFineObserver
    {
        void updateGraph();
    }

    public interface iDataAccessLogic
    {
        List<double> getData();//Signatur
        void saveSomeData(int val);

        double getSingleReading();
        void uploadCalibation(CalibrationValuesDTO calibrationValuesDto);
        CalibrationValuesDTO getValues();
        void startAsyncDAQ();

        void setAsyncQueue(ConcurrentQueue<Datacontainer> AsyncQueue);
    }
    public interface iBusinessLogic
    {
        void doAnAlogrithm();
        void startThreads();

        void startAlarm(AlarmDTO alarm);
        void getSingleReading();

        CalibrationValuesDTO GetCalibrationValuesFromDAL();

        void AttachToRawFineObserver(IRawToFineObserver observer);
        List<double> mwList();
        double getDiaFromConsumer();
        double getSysFromConsumer();

        void startDataGathering();
        void StopThreads(bool run);
    }

    public interface iPresentationLogic
    {
        void startUpGUI();
    }

    public interface iPatientConsumerObserver
    {
        void Update();
    }

}
