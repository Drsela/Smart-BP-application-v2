using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ST2Prj2LibNI_DAQ;

namespace DAL
{
    public class Bloodpressure
    {
        private NI_DAQVoltage _daq;

        public NI_DAQVoltage Maaling()
        {
            _daq = new NI_DAQVoltage()
            {
                deviceName = "Dev1/ai0",
                samplesPerChannel = 5000,
                sampleRateInHz = 1000,
                rangeMaximumVolt = 2,
                rangeMinimumVolt = -2
            };
            return _daq; // Opretter DAQ med vores specifikationer
        }
    }
}
