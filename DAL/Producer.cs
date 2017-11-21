﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using NationalInstruments.DAQmx;
using ST2Prj2LibNI_DAQ;
using Task = System.Threading.Tasks.Task;

namespace DAL
{
    public class Producer
    {
        private ConcurrentQueue<Datacontainer> _dataQueue;
        private GraphDTO _graphDTO;
        private NI_DAQVoltage _daq;
        private GetData _getData;
        private List<double> mvList;
        private int counter = 1;
        private double _currentValue;
        private Datacontainer _DataDTO;
        private Task _task;

        public Producer(ConcurrentQueue<Datacontainer> dataQueue)
        {
            _dataQueue = dataQueue;
            mvList = new List<double>();
            _graphDTO = new GraphDTO();
            _DataDTO = new Datacontainer();
        }

        public void RunProducer()
        {
            while (true)
            {
                
                Datacontainer measurementDatacontainer = new Datacontainer();
                foreach (var item in _getData.GetBpList())
                {
                    measurementDatacontainer.setMVMeasurement(item);
                    mvList.Add(item);       //tilføjer alle målingerne til en liste
                }
                Debug.WriteLine("______________________ Producer START __________________");
                Debug.WriteLine("Containeren bør indeholder 500. Den indeholder faktisk: " + measurementDatacontainer._MvList.Count);
                Debug.WriteLine("Den samlede liste bør indeholder " +  500*counter +". Den er faktisk " + mvList.Count+ "");
                Debug.WriteLine("______________________ Producer END __________________");
                counter++;
                _dataQueue.Enqueue(measurementDatacontainer);
            }
        }

        public double getCurrentValue()
        {
            return _currentValue;
        }

    }
}
