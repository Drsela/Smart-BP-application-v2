using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using ST2Prj2LibNI_DAQ;

namespace DAL
{
    public class CtrlDataAccessLogic : iDataAccessLogic
    {
        private NI_DAQVoltage daq;
        public CtrlDataAccessLogic()
        {
        }
        
        public int getSomeData()
        {
            NI_DAQVoltage daq = new NI_DAQVoltage();
            return 5;       // FJERN DETTE
        }
        
        public void saveSomeData(int val)
        {
            
        }
    }
}
