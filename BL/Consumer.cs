using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DAL;

namespace BL
{
    public class Consumer
    {
        private readonly ConcurrentQueue<Datacontainer> _dataQueue;

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
               // UDREGNINGER
                Console.WriteLine("Udregninger");
            }
        }
    }
}
