﻿using System;
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
        void startThreads(ConcurrentQueue<Datacontainer> dataQueue);

        void stopThreads();
        void startAlarm(AlarmDTO alarm);
        void getSingleReading();
        Datacontainer GetDatacontainer();

        List<double> returnTestList();
        CalibrationValuesDTO GetCalibrationValuesFromDAL();

    }

    public interface iPresentationLogic
    {
        void startUpGUI();
    }

}
