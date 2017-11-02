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
        private Datacontainer datacontainer;
        private readonly ConcurrentQueue<Datacontainer> _dataQueue;

        public CtrlBusinessLogic(iDataAccessLogic mydal)
        {
            this.currentDal = mydal;
        }
        public void doAnAlogrithm()
        {
            
        }

        public void startThreads()
        {
            _consumer = new Consumer(_dataQueue); 
            _producer = new Producer(_dataQueue);

            Thread startProucerThread = new Thread(_producer.RunProducer);
            Thread startConsumerThread = new Thread(_consumer.RunConsumer);

            startProucerThread.Start();
            startConsumerThread.Start();
         
        }
    }
}
