using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interfaces;

namespace BL
{
    class RawToFine : RawToFineSubject, IConsumerObserver
    {
        private List<double> _displayList;
        private AutoResetEvent _dataReady;
        private Consumer _consumer;
        private bool _stopThread;

        public RawToFine(AutoResetEvent dateReady, Consumer consumer)
        {
            _dataReady = dateReady;
            _consumer = consumer;
            _stopThread = false;
            _displayList  = new List<double>();
            _consumer.Attach(this);
        }

        public void sortRawData(List<double> rawData)
        {
            for (int i = 0; i < rawData.Count; i = i + 5)
            {
                double average = (rawData.GetRange(i, 5).Average());
                _displayList.Add(average);

                if (_displayList.Count > 500)
                    _displayList.RemoveAt(0);
            }
        }

        public List<double> getFineData()
        {
            return _displayList;
        }

        public void getObserverState()
        {
            _dataReady.Set();
        }

        public void RunFineFilter()
        {
            while (!_stopThread)
            {
                _dataReady.WaitOne();
                List<double> sortList = _consumer.mwList();
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
