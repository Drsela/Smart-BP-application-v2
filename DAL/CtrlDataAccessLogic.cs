using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using ST2Prj2LibNI_DAQ;

namespace DAL
{
    public class CtrlDataAccessLogic : iDataAccessLogic
    {
        private GetData _daq;
        public CtrlDataAccessLogic()
        {
        }
        

        public List<double> getData()
        {
            _daq = new GetData();
            return _daq.GetBpList();
        }

        public void saveSomeData(int val)
        {
        }
    }
}
