using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interfaces;

namespace BL
{
    public class CalculatePulse : CalculatePulseSubject, IConsumerObserver

    {
        private List<double> _calculatePulseList;
        private AutoResetEvent _dataReadResetEvent;
        private Consumer _consumer;
        private bool _threadStatus;
        private int _pulse;

    public CalculatePulse(AutoResetEvent dataReadyResetEvent, Consumer consumer)
    {
        _dataReadResetEvent = dataReadyResetEvent;
        _consumer = consumer;
        _consumer.Attach(this);
        _calculatePulseList = new List<double>();
    }

    public void calculatePulseThread()
    {
        while (!_threadStatus)
        {
            _dataReadResetEvent.WaitOne();
            List<double> rawData = _consumer.mwList();
            //_pulse = 0;
            CalculatePulseMethod(rawData);
        }
    }

        public void CalculatePulseMethod(List<double> rawDoubles)
        {
            _calculatePulseList.AddRange(rawDoubles);
            if (_calculatePulseList.Count >= 10000)
            {
                for (int i = 0; i < _calculatePulseList.Count-1; i++)
                {
                    if (_calculatePulseList[i] >= (_calculatePulseList.Max()*0.6))
                    {
                        _pulse++;
                    }
                }
                _calculatePulseList.RemoveRange(0, 500);
                Notify();
            }
        }

        public int getPulse()
        {
            return _pulse * 6;
        }
        public void getObserverState()
        {
            _dataReadResetEvent.Set();
        }
    }
}
