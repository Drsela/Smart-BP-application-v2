using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.DAQmx;
using ST2Prj2LibNI_DAQ;

namespace DAL
{
    public class Producer
    {
        private readonly ConcurrentQueue<Datacontainer> _dataQueue;
        private NI_DAQVoltage _daq;
        private GetData _getData;
       
        public Producer(ConcurrentQueue<Datacontainer> dataQueue)
        {
            _dataQueue = dataQueue;
        }

        public void RunProducer()
        {
            while (true)
            {
                _getData = new GetData();
                Datacontainer measurementDatacontainer = new Datacontainer();
                foreach (var item in _getData.GetBpList())
                {
                    measurementDatacontainer.setMVMeasurement(item);
                }
                Debug.WriteLine("Listen bør indeholde 500. Den indeholder: " + measurementDatacontainer._MvList.Count);
                _dataQueue.Enqueue(measurementDatacontainer);
            }
        }

    }
}
