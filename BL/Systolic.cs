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
    public class Systolic : SystolicSubject, IConsumerObserver
    {
        private List<double> sysList;
        private int _systolicValue;
        private AutoResetEvent _dataReadResetEvent;
        private bool _threadStatus;
        private Consumer _consumer;
        private int DAQ_samplerate;
        public Systolic(AutoResetEvent dataReadyResetEvent, Consumer consumer)
        {
            _dataReadResetEvent = dataReadyResetEvent;
            _consumer = consumer;
            _systolicValue = 0;
            _consumer.Attach(this);
            sysList = new List<double>();
            DAQ_samplerate = 500;
        }


        public void CalculateSystolicValue(List<double> dataList)
        {
            for (int i = 0; i < dataList.Count; i++)
            {
                if(sysList.Count < DAQ_samplerate)
                    sysList.Add(dataList[i]);
                if (sysList.Count == DAQ_samplerate)
                {
                    System.Diagnostics.Debug.WriteLine("Den afrundede værdi er: " + Math.Round(sysList.Max()));
                    _systolicValue = Convert.ToInt32(Math.Round(sysList.Max()));
                    sysList.RemoveAt(0);
                }
            }
        }

        public int getSystolicValue()
        {
            return _systolicValue;
        }

        public void calculateSystolicThread()
        {
            while (!_threadStatus)
            {
                _dataReadResetEvent.WaitOne();
                List<double> rawData = _consumer.mwList();
                CalculateSystolicValue(rawData);
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
