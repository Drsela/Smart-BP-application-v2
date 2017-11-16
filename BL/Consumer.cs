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

        public Consumer(ConcurrentQueue<Datacontainer> dataQueue)
        {
            _dataQueue = dataQueue;
        }

        public void RunConsumer()
        {
            while (true)
            {
                List<double> dataList = new List<double>();
                Datacontainer container;
                while (!_dataQueue.TryDequeue(out container))
                {
                    Thread.Sleep(0);
                }
                testList = container.getMVMeasaurement();
                _systole = testList.Max();
                _diastole = testList.Min();

                Notify();
               // UDREGNINGER
               Debug.WriteLine("______________________ Consumer START __________________");
               Debug.WriteLine("Højeste punkt: " + container.getMVMeasaurement().Max());
               Debug.WriteLine("Laveste punkt: " + container.getMVMeasaurement().Min());
               Debug.WriteLine("Beregninger er foretaget over " + container.getMVMeasaurement().Count + " målinger");
               Debug.WriteLine("______________________ Consumer END __________________");
            }
        }

        public List<double> mwList()
        {
            return testList;
        }

        public double getDia()
        {
            return _diastole;
        }

        public double getSys()
        {
            return _systole;
        }
    }
}
