using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DTO;

namespace BL
{
    public class Consumer : ConsumerSubject
    {
        private readonly ConvertClass _convertClass;
        private readonly ConcurrentQueue<Datacontainer> _dataQueue;
        private readonly List<double> allReadings;
        private double _diastole;
        private List<double> _display;
        private bool _stopThread;
        private double _systole;
        private List<double> mmhHgValues;

        public Consumer(ConcurrentQueue<Datacontainer> dataQueue, ConvertClass convert)
        {
            _dataQueue = dataQueue;
            _stopThread = false;
            _display = new List<double>();
            allReadings = new List<double>();
            _convertClass = convert;
            mmhHgValues = new List<double>();
        }

        public void RunConsumer()
        {
            while (!_stopThread)
            {
                Datacontainer container = null;
                while (!_dataQueue.TryDequeue(out container))
                    Thread.Sleep(0);
                _display = container.getRawDoubles().ToList();
                mmhHgValues = _convertClass.Conversation(_display);
                allReadings.AddRange(_display);
                Notify();
            }
        }

        public List<double> mwList()
        {
            return mmhHgValues;
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