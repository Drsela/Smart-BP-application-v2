using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Accord.Diagnostics;
using System.Diagnostics;
using Interfaces;
using Debug = System.Diagnostics.Debug;

namespace BL
{
    public class CalculateBloodPreassure : CalculateBloodPreassureSubject, IConsumerObserver
    {
        private List<double> sysList;
        private int _systolicValue;
        private int _diastolicValue;
        private AutoResetEvent _dataReadResetEvent;
        private bool _threadStatus;
        private Consumer _consumer;
        private int numberOfReadings;
        private Alarm _alarm;

        private iBusinessLogic _businessLogic;

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
            sysList = new List<double>();
            numberOfReadings = 1000;                // 500 el. 1000?
            _businessLogic = businessLogic;
            _alarm = alarm;
        }


        public void CalculateBPValues(List<double> dataList)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                if(sysList.Count < numberOfReadings)
                    sysList.Add(dataList[i]);
                if (sysList.Count == numberOfReadings)
                {
                    //System.Diagnostics.Debug.WriteLine("Den afrundede værdi er: " + Math.Round(sysList.Max()));
                    _systolicValue = Convert.ToInt32(Math.Round(sysList.Max()));
                    _alarm.setCurrentSys(_systolicValue);

                    _diastolicValue = Convert.ToInt32(Math.Round(sysList.Min()));
                    _alarm.setCurrentDia(_diastolicValue);
                    sysList.RemoveAt(0);
                }
            }
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

        public void calculateSystolicThread()
        {
            while (!_threadStatus)
            {
                _dataReadResetEvent.WaitOne();
                List<double> rawData = _consumer.mwList();
                CalculateBPValues(rawData);
                if (_alarm.alarmStatus())
                {
                    _alarm.CheckAlarmValues();          // Tjekker om værdier er overskredet
                }
                if(!_alarm.alarmStatus())
                {
                    _alarm.checkAlarmState();           // Checker om alarmtimeren er 30.
                }
                Notify();
            }
        }

        public void getObserverState()
        {
            _dataReadResetEvent.Set();
        }

        public void setThreadStatus(bool status)
        {
            _threadStatus = status;
        }
    }


}
