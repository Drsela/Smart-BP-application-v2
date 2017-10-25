using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST2Prj2LibNI_DAQ;
namespace DAL
{
    public class StartMeasurement
    {
        private Bloodpressure _bp;
        private List<double> _bpList;
        private NI_DAQVoltage _daq;

        public List<double> GetBP()
        {
            _bpList = new List<double>();
            _bp = new Bloodpressure();
            _daq = _bp.Maaling();
            _daq.getVoltageSeqBlocking();

            foreach (var item in _daq.currentVoltageSeq)
            {
                _bpList.Add(item);
            }
            return _bpList;
        }
    }
}
