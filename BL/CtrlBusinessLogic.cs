using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DAL;
using Interfaces;

namespace BL
{
    public class CtrlBusinessLogic : iBusinessLogic
    {
        private iDataAccessLogic currentDal;
        private Producer _producer;
        private Consumer _consumer;

        public CtrlBusinessLogic(iDataAccessLogic mydal)
        {
            this.currentDal = mydal;
        }
        public void doAnAlogrithm()
        {
            
        }

        public void startThreads(ConcurrentQueue<Datacontainer> dataQueue)
        {
            _consumer = new Consumer(dataQueue); 
            _producer = new Producer(dataQueue);

            Thread startProucerThread = new Thread(_producer.RunProducer);
            Thread startConsumerThread = new Thread(_consumer.RunConsumer);

            startProucerThread.Start();
            startConsumerThread.Start();
         
        }
    }
}
