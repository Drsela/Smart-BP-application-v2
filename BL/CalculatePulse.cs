using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Accord.Diagnostics;
using Interfaces;
using System.Diagnostics;
using Accord.IO;
using MathNet.Filtering;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using System.Numerics;

namespace BL
{
    public class CalculatePulse : CalculatePulseSubject, IConsumerObserver

    {
        private List<double> _calculatePulseList;
        private AutoResetEvent _dataReadResetEvent;
        private Consumer _consumer;
        private bool _threadStatus;
        private int _pulse;
        private List<double> _analyseList;

    public CalculatePulse(AutoResetEvent dataReadyResetEvent, Consumer consumer)
    {
        _dataReadResetEvent = dataReadyResetEvent;
        _consumer = consumer;
        _consumer.Attach(this);
        _analyseList = new List<double>();
        _calculatePulseList = new List<double>();
    }

    public void calculatePulseThread()
    {
        while (!_threadStatus)
        {
            _dataReadResetEvent.WaitOne();
            List<double> rawData = _consumer.mwList();
            //_pulse = 0;
            CalculatePulseMethod(rawData);
        }
    }

        public void CalculatePulseMethod(List<double> rawDoubles)
        {
            /*
            foreach (var item in rawDoubles)
            {
                _analyseList.Add(item);
            }

            //<summary> 
            // Denne metode tager 5000 målinger (10 sekunder), og laver dem om til et komplekst array.
            // Efterfølgende laves et HanningVindue, som ganges på det komplekse array.
            // Derefter laves en fft af det nye array med Hanning.
            // Magnituden findes. Den største magnitude er lig hjerteslag pr. sekund.
            //</ summary >
            if (_analyseList.Count == 6000)
            {
                var _analyseListCopy = _analyseList.ToList();

                Complex[] complexAnalysisListWithoutWindow = new Complex[6000];
                for (int i = 0; i < _analyseListCopy.Count; i++)
                {
                    complexAnalysisListWithoutWindow[i] = new Complex(_analyseListCopy[i], 0);
                }

                Complex[] complexAnalysisListWithWindow = new Complex[6000];

                double[] hammingWindow = MathNet.Numerics.Window.Hamming(complexAnalysisListWithWindow.Length);

                for (int i = 0; i < complexAnalysisListWithoutWindow.Length; i++)
                {
                    complexAnalysisListWithWindow[i] = hammingWindow[i] * complexAnalysisListWithoutWindow[i];
                }
                Fourier.Forward(complexAnalysisListWithWindow, FourierOptions.NoScaling);       // Laver en fft uden skalering

                double[] magnitudes = new double[complexAnalysisListWithWindow.Length / 2];     // For at undgå aliasering

                for (int i = 2; i < complexAnalysisListWithWindow.Length / 2; i++)
                {
                    magnitudes[i] = complexAnalysisListWithWindow[i].Magnitude;                 // Finder magnituden af fft'en
                }

                int maxIndex = 0;

                for (int i = 0; i < magnitudes.Length; i++)
                {
                    if (magnitudes[i] == magnitudes.Max())
                        maxIndex = i;
                }                                // Finder højeste magnitude


                double frequenceForMaxMagnitude = maxIndex * 1000.0 / complexAnalysisListWithWindow.Length;     // Finder frekvensen pr. sekund (Hz)
                double bpm = 60 * frequenceForMaxMagnitude;                                                     // Finder den pr. minut.

                _pulse = Convert.ToInt32(bpm);                                                                  // Konverteres og sendes til UI
                Notify();
                _analyseList.Clear();
            }

            */
            if (_calculatePulseList.Count <= 4500)
                _calculatePulseList.AddRange(rawDoubles);

            if (_calculatePulseList.Count >= 5000)
            {
                var new1 = _calculatePulseList.ToList();
                int sys = 0;
                int dia = 0;
                _pulse = 0;
                for (int i = 0; i < new1.Count-1; i++)
                {
                    //System.Diagnostics.Debug.WriteLine("Punkt" + Math.Abs(_calculatePulseList[i]) + " Max: " + Math.Abs(_calculatePulseList.Max()) *0.85);
                    if (Math.Abs(new1[i]) >= (Math.Abs(new1.Max() - Math.Abs(new1.Max() * 0.60))) &&
                        Math.Abs(new1[i]) > Math.Abs(new1[i + 1]) &&
                        Math.Abs(new1[i + 1]) < Math.Abs(new1.Max() - new1.Max() * 0.60))
                    {
                        //sys++;
                        _pulse++;
                    }
                    if (Math.Abs(new1[i]) <= (Math.Abs(new1.Min() - (new1.Min() * 0.60))) &&
                        Math.Abs(new1[i]) < Math.Abs(new1[i + 1]) &&
                        Math.Abs(new1[i + 1]) > Math.Abs(new1.Min() - (new1.Min() * 0.60)))
                    {
                        //dia++;
                        //_pulse++;
                    }
                }
                //_pulse = sys / dia;
                _calculatePulseList.RemoveRange(0, 500);
                _pulse = _pulse * 6;
                Notify();
            }
            
        }

        public int getPulse()
        {
            return _pulse;
            /*
            try
            {
                return _pulse;
            }
            finally
            {
                _pulse = 0;
            }
            */

        }
        public void getObserverState()
        {
            _dataReadResetEvent.Set();
        }
    }
}
