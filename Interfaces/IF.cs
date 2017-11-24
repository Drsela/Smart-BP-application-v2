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

        double getSingleReading();
        void uploadCalibation(CalibrationValuesDTO calibrationValuesDto);
        CalibrationValuesDTO getValues();
        void startAsyncDAQ();

        void setAsyncQueue(ConcurrentQueue<Datacontainer> AsyncQueue);
    }
    public interface iBusinessLogic
    {
        int getSystolicValue();


        void startThreads();

        void startAlarm();
        void getSingleReading();

        CalibrationValuesDTO GetCalibrationValuesFromDAL();

        void AttachToRawFineObserver(IRawToFineObserver observer);
        void AttachToSystolicObserver(ISystolicObserver observer);

        List<double> mwList();

        void startDataGathering();
        void StopThreads(bool run);
        List<double> getFineValues();

        void setUpperAlarm(int sys);
        void setLowerAlarm(int dia);
    }

    public interface iPresentationLogic
    {
        void startUpGUI();
    }

    public interface iPatientConsumerObserver
    {
        void Update();
    }

    public interface ISystolicObserver
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

}
