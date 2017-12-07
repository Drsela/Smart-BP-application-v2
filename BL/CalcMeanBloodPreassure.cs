using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Interfaces;

namespace BL
{
    public class CalcMeanBloodPreassure : calcMeanBloodPreassureSubject, IConsumerObserver
    {
        private readonly List<double> _calculateMeanBloodPreassureList;
        private readonly Consumer _consumer;
        private readonly AutoResetEvent _dataReadResetEvent;
        private bool _threadStatus;
        private double meanBloodPreassure;

        public CalcMeanBloodPreassure(AutoResetEvent dataReadyResetEvent, Consumer consumer)
        {
            _dataReadResetEvent = dataReadyResetEvent;
            _consumer = consumer;
            _consumer.Attach(this);
            _calculateMeanBloodPreassureList = new List<double>();
        }

        public void getObserverState()
        {
            _dataReadResetEvent.Set();
        }

        public void calculateMeanBPThread()
        {
            while (!_threadStatus)
            {
                _dataReadResetEvent.WaitOne();
                var rawData = _consumer.mwList();
                calculateMeanBloodPreassure(rawData);
            }
        }

        public void calculateMeanBloodPreassure(List<double> mmHgValues)
        {
            _calculateMeanBloodPreassureList.AddRange(mmHgValues);
            if (_calculateMeanBloodPreassureList.Count > 5000)
            {
                meanBloodPreassure = _calculateMeanBloodPreassureList.Average();
                _calculateMeanBloodPreassureList.RemoveRange(0, 500);
                Notify();
            }
        }

        public int getMeanBloodPreassure()
        {
            return Convert.ToInt32(Math.Round(meanBloodPreassure));
        }
    }
}