using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments;

namespace DTO
{
    public class Datacontainer
    {
        public double _mv;
        public List<double> _MvList;
        private double[] rawDoubles = new double[500];

        public Datacontainer()
        {
            _MvList = new List<double>();
        }

        public double[] getRawDoubles()
        {
            return rawDoubles;
        }

        public void setMVMeasurement(double mv)
        {
            _MvList.Add(mv);
        }
        public List<double> getMVMeasaurement()
        {
            return _MvList;
        }

        public void SetRawDataSample(AnalogWaveform<double>[] data)
        {
            foreach (AnalogWaveform<double> waveform in data)
            {
                for (int i = 0; i < waveform.Samples.Count; i++)
                {
                    rawDoubles[i] = waveform.Samples[i].Value;
                }
            }
        }
    }
}
