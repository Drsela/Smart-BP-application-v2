using System.Collections.Generic;
using NationalInstruments;

namespace DTO
{
    public class Datacontainer
    {
        private readonly double[] rawDoubles = new double[1000];
        public double _mv;
        public List<double> _MvList;

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
            foreach (var waveform in data)
                for (var i = 0; i < waveform.Samples.Count; i++)
                    rawDoubles[i] = waveform.Samples[i].Value;
        }
    }
}