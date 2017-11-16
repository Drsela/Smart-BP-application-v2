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
    }
    public interface iBusinessLogic
    {
        void doAnAlogrithm();
        void startThreads(ConcurrentQueue<Datacontainer> dataQueue, iPatientConsumerObserver observer);

        void stopThreads();
        void startAlarm(AlarmDTO alarm);
        void getSingleReading();

        CalibrationValuesDTO GetCalibrationValuesFromDAL();

        void AttachObserver(iPatientConsumerObserver observer);
        List<double> mwList();
        double getDiaFromConsumer();
        double getSysFromConsumer();

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
