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
        private int DAQ_samplerate;
        private bool alarmEnabledBool;
        private iBusinessLogic _businessLogic;
        public CalculateBloodPreassure(AutoResetEvent dataReadyResetEvent, Consumer consumer, iBusinessLogic businessLogic)
        {
            _dataReadResetEvent = dataReadyResetEvent;
            _consumer = consumer;
            _systolicValue = 0;
            _consumer.Attach(this);
            sysList = new List<double>();
            DAQ_samplerate = 500;
            _businessLogic = businessLogic;
        }


        public void CalculateBPValues(List<double> dataList)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                if(sysList.Count < DAQ_samplerate)
                    sysList.Add(dataList[i]);
                if (sysList.Count == DAQ_samplerate)
                {
                    //System.Diagnostics.Debug.WriteLine("Den afrundede værdi er: " + Math.Round(sysList.Max()));
                    _systolicValue = Convert.ToInt32(Math.Round(sysList.Max()));
                    _diastolicValue = Convert.ToInt32(Math.Round(sysList.Min()));
                    sysList.RemoveAt(0);
                }
            }
            if (alarmEnabledBool = true)
            {
                /*
           Alarm _alarm = new Alarm();
           _alarm.setCurrentDia(_diastolicValue);
           _alarm.setCurrentSys(_systolicValue);
           _alarm.CheckAlarmValues();
           */
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

        public void calculateSystolicThread()
        {
            while (!_threadStatus)
            {
                _dataReadResetEvent.WaitOne();
                List<double> rawData = _consumer.mwList();
                CalculateBPValues(rawData);
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
