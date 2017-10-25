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
        private NI_DAQVoltage _daq;
        public CtrlDataAccessLogic()
        {
        }
        
        public int getSomeData()
        {
            _daq = new NI_DAQVoltage();
            return 5;       // FJERN DETTE
            
        }
        
        public void saveSomeData(int val)
        {
        }
    }
}
