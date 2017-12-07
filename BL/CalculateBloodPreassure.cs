using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Interfaces;

namespace BL
{
    public class CalculateBloodPreassure : CalculateBloodPreassureSubject, IConsumerObserver
    {
        private readonly Alarm _alarm;
        private readonly iBusinessLogic _businessLogic;
        private readonly Consumer _consumer;
        private readonly AutoResetEvent _dataReadResetEvent;
        private readonly List<double> bpList;
        private readonly int numberOfReadings;
        private int _diastolicValue;
        private int _systolicValue;
        private bool _threadStatus;
        private bool alarmEnabledBool;
        private int DAQ_samplerate;

        public CalculateBloodPreassure()
        {
        }

        public CalculateBloodPreassure(AutoResetEvent dataReadyResetEvent, Consumer consumer,
            iBusinessLogic businessLogic, Alarm alarm)
        {
            _dataReadResetEvent = dataReadyResetEvent;
            _consumer = consumer;
            _systolicValue = 0;
            _consumer.Attach(this);
            bpList = new List<double>();
            numberOfReadings = 1000; // 500 el. 1000?
            _businessLogic = businessLogic;
            _alarm = alarm;
        }

        public void getObserverState()
        {
            _dataReadResetEvent.Set();
        }


        public void CalculateBPValues(List<double> dataList)
        {
            for (var i = 0; i < dataList.Count; i++)
            {
                if (bpList.Count < numberOfReadings)
                    bpList.Add(dataList[i]);
                if (bpList.Count == numberOfReadings)
                {
                    //System.Diagnostics.Debug.WriteLine("Den afrundede værdi er: " + Math.Round(bpList.Max()));
                    _systolicValue = Convert.ToInt32(Math.Round(bpList.Max()));
                    _alarm.setCurrentSys(_systolicValue);

                    _diastolicValue = Convert.ToInt32(Math.Round(bpList.Min()));
                    _alarm.setCurrentDia(_diastolicValue);
                    bpList.RemoveAt(0);
                }
            }
        }

        public void alarmEnabled(bool enable)
        {
            alarmEnabledBool = enable;
        }

        public int getSystolicValue()
        {
            _businessLogic.setCurrentSysValue(_systolicValue);
            return _systolicValue;
        }

        public int getDiastolicValue()
        {
            _businessLogic.setCurrentDiaValue(_diastolicValue);
            return _diastolicValue;
        }

        public void calculateBloodpreassureThread()
        {
            while (!_threadStatus)
            {
                _dataReadResetEvent.WaitOne();
                var rawData = _consumer.mwList();
                CalculateBPValues(rawData);
                if (_alarm.alarmStatus())
                    _alarm.CheckAlarmValues(); // Tjekker om værdier er overskredet
                if (!_alarm.alarmStatus())
                    _alarm.checkAlarmState(); // Checker om alarmtimeren er 30 og aktiverer den igen.

                Notify();
            }
        }

        public void setThreadStatus(bool status)
        {
            _threadStatus = status;
        }
    }
}