using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interfaces;

namespace BL
{
    class CalcMeanBloodPreassure : calcMeanBloodPreassureSubject, IConsumerObserver
    {
        private AutoResetEvent _dataReadResetEvent;
        private Consumer _consumer;
        private List<double> _calculateMeanBloodPreassureList;
        private double meanBloodPreassure;
        private bool _threadStatus;

        public CalcMeanBloodPreassure(AutoResetEvent dataReadyResetEvent, Consumer consumer)
        {
            _dataReadResetEvent = dataReadyResetEvent;
            _consumer = consumer;
            _consumer.Attach(this);
            _calculateMeanBloodPreassureList = new List<double>();
        }

        public void calculateMeanBPThread()
        {
            while (!_threadStatus)
            {
                _dataReadResetEvent.WaitOne();
                List<double> rawData = _consumer.mwList();
                calculateMeanBloodPreassure(rawData);
                
            }
        }

        public void calculateMeanBloodPreassure(List<double> mmHgValues)
        {
            _calculateMeanBloodPreassureList.AddRange(mmHgValues);
            if (_calculateMeanBloodPreassureList.Count > 5000)
            {
                meanBloodPreassure =_calculateMeanBloodPreassureList.Average();
                _calculateMeanBloodPreassureList.RemoveRange(0,500);
                Notify();
            }
        }

        public void getObserverState()
        {
            _dataReadResetEvent.Set();
        }

        public int getMeanBloodPreassure()
        {
            return Convert.ToInt32(Math.Round(meanBloodPreassure));
        }
    }
}
