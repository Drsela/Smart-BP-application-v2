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
        private List<double> testList;
        private double _systole;
        private double _diastole;
        private List<double> _display;
        private bool _stopThread;
        public Consumer(ConcurrentQueue<Datacontainer> dataQueue)
        {
            _dataQueue = dataQueue;
            _stopThread = false;
            _display = new List<double>();
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

                Notify();
                /*
                testList = container.getRawDoubles().ToList();
                for (int i = 0; i < testList.Count; i = i +10)
                {
                    double average = (testList.GetRange(i, 10).Average());
                    _display.Add(average);

                    if (_display.Count > 250)
                        _display.Remove(0);
                }

                _systole = testList.Max();
                _diastole = testList.Min();

                Notify();
                */

                // UDREGNINGER
                /*
                Debug.WriteLine("______________________ Consumer START __________________");
                Debug.WriteLine("Højeste punkt: " + testList.Max());
                Debug.WriteLine("Laveste punkt: " + testList.Min());
                Debug.WriteLine("Beregninger er foretaget over " + container.getMVMeasaurement().Count + " målinger");
                Debug.WriteLine("______________________ Consumer END __________________");
                */
            }
        }

        public List<double> mwList()
        {
            //return testList;
            return _display;
        }

        public double getDia()
        {
            return _diastole;
        }

        public double getSys()
        {
            return _systole;
        }

        public void setThreadStatus(bool run)
        {
            _stopThread = run;
        }
    }
}
