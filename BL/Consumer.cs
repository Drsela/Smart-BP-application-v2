using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL;
using DTO;
using Interfaces;

namespace BL
{
    public class Consumer : ConsumerSubject
    {
        private readonly ConcurrentQueue<Datacontainer> _dataQueue;
        private Datacontainer _measurementDatacontainer;
        private List<double> allReadings;
        private double _systole;
        private double _diastole;
        private List<double> _display;
        private bool _stopThread;
        public Consumer(ConcurrentQueue<Datacontainer> dataQueue)
        {
            _dataQueue = dataQueue;
            _stopThread = false;
            _display = new List<double>();
            allReadings = new List<double>();
        }

        public void RunConsumer()
        {
            while (!_stopThread)
            {
                Datacontainer container = null;
                while (!_dataQueue.TryDequeue(out container))
                {
                    Thread.Sleep(0);
                }
                _display = container.getRawDoubles().ToList();
                allReadings.AddRange(_display);
                Notify();


            }
        }

        public List<double> mwList()
        {
            return _display;
        }

        public List<double> getAllReadings()
        {
            return allReadings;
        }
        public void setThreadStatus(bool run)
        {
            _stopThread = run;
        }
    }
}
