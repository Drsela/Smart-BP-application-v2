using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Interfaces;

namespace BL
{
    public class CalculatePulse : CalculatePulseSubject, IConsumerObserver

    {
        private readonly List<double> _calculatePulseList;
        private readonly Consumer _consumer;
        private readonly AutoResetEvent _dataReadResetEvent;
        private int _pulse;
        private bool _threadStatus;

        public CalculatePulse(AutoResetEvent dataReadyResetEvent, Consumer consumer)
        {
            _dataReadResetEvent = dataReadyResetEvent;
            _consumer = consumer;
            _consumer.Attach(this);
            _calculatePulseList = new List<double>();
        }

        public void getObserverState()
        {
            _dataReadResetEvent.Set();
        }

        public void calculatePulseThread()
        {
            while (!_threadStatus)
            {
                _dataReadResetEvent.WaitOne();
                var rawData = _consumer.mwList();
                CalculatePulseMethod(rawData);
            }
        }

        public void CalculatePulseMethod(List<double> rawDoubles)
        {
            if (_calculatePulseList.Count <= 4500)
                _calculatePulseList.AddRange(rawDoubles);

            if (_calculatePulseList.Count >= 5000)
            {
                var new1 = _calculatePulseList.ToList();
                var sys = 0;
                var dia = 0;
                _pulse = 0;
                for (var i = 0; i < new1.Count - 1; i++) // For hvert toppunkt (systole) er pulsen lig 1
                    if (Math.Abs(new1[i]) >= Math.Abs(new1.Max() - Math.Abs(new1.Max() * 0.60)) &&
                        Math.Abs(new1[i]) > Math.Abs(new1[i + 1]) &&
                        Math.Abs(new1[i + 1]) < Math.Abs(new1.Max() - new1.Max() * 0.60))
                        _pulse++;
                _calculatePulseList.RemoveRange(0, 1000);
                _pulse = _pulse * 6; // Ganges med 6 for at få BPM
                Notify();
            }
        }

        public int getPulse()
        {
            return _pulse;
        }
    }
}