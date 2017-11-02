using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Producer
    {
        ConcurrentQueue<Datacontainer> _dataQueue;
        private MVMeasurements _measurements;
       
        public Producer(ConcurrentQueue<Datacontainer> dataQueue)
        {
            _dataQueue = dataQueue;
        }

        public void RunProducer()
        {
            while (true)
            {
                
                _measurements = new MVMeasurements();
                List<double> MVCollection = new List<double>();
                foreach (var item in _measurements.GetMeasurement())
                {
                    MVCollection.Add(item);
                }
                Datacontainer measurementDatacontainer = new Datacontainer(MVCollection);
                _dataQueue.Enqueue(measurementDatacontainer);
            }
        }

    }
}
