﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST2Prj2LibNI_DAQ;
using NationalInstruments.DAQmx;

namespace DAL
{
    

    public class GetData
    {
        private NI_DAQVoltage _daq;
        private List<double> _bpList;
        private List<double> _singleList;

        public List<double> GetBpList()
        {
            _bpList = new List<double>();
            _daq = Maaling();
            _daq.getVoltageSeqBlocking();
            foreach (double item in _daq.currentVoltageSeq)
            {
                _bpList.Add(item);
            }
            return _bpList;

        }
        
        public double getSingleValue()
        {
            _singleList = new List<double>();
            _daq =  Maaling();
            _daq.getVoltageSeqBlocking();
            foreach (double item in _daq.currentVoltageSeq)
            {
                _singleList.Add(item);
            }

            return _singleList.Average();
        }

        public NI_DAQVoltage Maaling()
        {
            _daq = new NI_DAQVoltage()
            {
                deviceName = "Dev1/ai0",
                samplesPerChannel = 500,
                sampleRateInHz = 1000,
                rangeMaximumVolt = 1,
                rangeMinimumVolt = -1
            };
            return _daq; // Opretter DAQ som giver 500 målinger
        }

        public NI_DAQVoltage singleMaaling()
        {
            _daq = new NI_DAQVoltage()
            {
                deviceName = "Dev1/ai0",
                samplesPerChannel = 1,
                sampleRateInHz = 1000,
                rangeMaximumVolt = 1,
                rangeMinimumVolt = -1
            };
            return _daq; // Opretter DAQ som giver 1 måling
        }
    }
}