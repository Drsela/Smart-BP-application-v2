using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ST2Prj2LibNI_DAQ;
using NationalInstruments.DAQmx;

namespace DAL
{
    public class MVMeasurements
    {
        private List<double> _dataList;
        private NI_DAQVoltage _daq;
        private GetData _getData;

        public List<double> GetMeasurement()
        {
            _dataList = new List<double>();
            _daq = _getData.Maaling();
            _daq.getVoltageSeqBlocking();
            foreach (var item in _daq.currentVoltageSeq)
            {
                _dataList.Add(item);
            }
            return _dataList;
        }
    }
}
