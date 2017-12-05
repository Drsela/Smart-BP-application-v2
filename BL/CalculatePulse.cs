using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Accord.Diagnostics;
using Interfaces;
using System.Diagnostics;
using Accord.IO;

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
            if (_calculatePulseList.Count <= 9500)
                _calculatePulseList.AddRange(rawDoubles);

            if (_calculatePulseList.Count >= 10000)
            {
                var new1 = _calculatePulseList.ToList();

                for (int i = 0; i < new1.Count-1; i++)
                {
                    //System.Diagnostics.Debug.WriteLine("Punkt" + Math.Abs(_calculatePulseList[i]) + " Max: " + Math.Abs(_calculatePulseList.Max()) *0.85);
                    if (Math.Abs(new1[i]) >= (new1.Max() - Math.Abs(new1.Max()*0.60)) &&
                        new1[i] > new1[i+1] &&
                        new1[i+1] < (new1.Max() - new1.Max()*0.60))
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
            try
            {
                return _pulse * 6;
            }
            finally
            {
                _pulse = 0;
            }
            
            
        }
        public void getObserverState()
        {
            _dataReadResetEvent.Set();
        }
    }
}
