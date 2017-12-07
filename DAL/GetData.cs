using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ST2Prj2LibNI_DAQ;

namespace DAL
{
    public class GetData
    {
        private List<double> _bpList;
        private NI_DAQVoltage _daq;
        private List<double> _singleList;

        public List<double> GetBpList()
        {
            _bpList = new List<double>();
            _daq = Maaling();
            _daq.getVoltageSeqBlocking();
            foreach (var item in _daq.currentVoltageSeq)
                _bpList.Add(item);
            return _bpList;
        }

        public double getSingleValue()
        {
            _singleList = new List<double>();
            _daq = Maaling();
            _daq.getVoltageSeqBlocking();
            foreach (var item in _daq.currentVoltageSeq)
                _singleList.Add(item);
            //Debug.WriteLine(item);
            Debug.WriteLine("Gennemsnit (zeropoint) = " + _singleList.Average());
            return _singleList.Average();
        }

        public NI_DAQVoltage Maaling()
        {
            _daq = new NI_DAQVoltage
            {
                deviceName = "Dev1/ai0",
                samplesPerChannel = 500,
                sampleRateInHz = 1000,
                rangeMaximumVolt = 5,
                rangeMinimumVolt = 0
            };
            return _daq; // Opretter DAQ som giver 500 målinger
        }
    }
}