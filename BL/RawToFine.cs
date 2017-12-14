using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Interfaces;

namespace BL
{
    internal class RawToFine : RawToFineSubject, IConsumerObserver
    {
        private readonly Consumer _consumer;
        private readonly AutoResetEvent _dataReady;
        private readonly List<double> _displayList;
        private bool _stopThread;

        public RawToFine(AutoResetEvent dateReady, Consumer consumer)
        {
            _dataReady = dateReady;
            _consumer = consumer;
            _stopThread = false;
            _displayList = new List<double>();
            _consumer.Attach(this);
        }

        public void getObserverState()
        {
            _dataReady.Set();
        }

        public void sortRawData(List<double> rawData)
        {
            for (var i = 0; i < rawData.Count; i = i + 5)
            {
                var average = rawData.GetRange(i, 5).Average();
                _displayList.Add(average);

                if (_displayList.Count > 2000)
                    _displayList.RemoveAt(0);
            }
        }

        public List<double> getFineData()
        {
            return _displayList;
        }

        public void RunFineFilter()
        {
            while (!_stopThread)
            {
                _dataReady.WaitOne();
                var sortList = _consumer.mwList();
                sortRawData(sortList);
                Notify();
            }
        }

        public void setThreadStatus(bool result)
        {
            _stopThread = result;
        }
    }
}