using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interfaces;

namespace BL
{
    class CalcMeanCalcPulse : calcMeanCalcPulseSubject, IConsumerObserver
    {
        private AutoResetEvent _dataReadResetEvent;
        private Consumer _consumer;
        private List<double> _calculatePusleList;
        private List<double> _calculateMeanBloodPreassureList;
        private double meanBloodPreassure;
        private int _pulse;

        public CalcMeanCalcPulse(AutoResetEvent dataReadyResetEvent, Consumer consumer)
        {
            _dataReadResetEvent = dataReadyResetEvent;
            _consumer = consumer;
            _consumer.Attach(this);
            _calculatePusleList = new List<double>();
            _calculateMeanBloodPreassureList = new List<double>();
        }

        public void calculateBoth(List<double> mmHgValues)
        {
            calculatePulse(mmHgValues);
            calculateMeanBloodPreassure(mmHgValues);
            Notify();
        }

        public void calculatePulse(List<double> mmHgValues)
        {
            _calculatePusleList.AddRange(mmHgValues);
            if (_calculatePusleList.Count > 5000)
            {
                // UDREGNING TIL PULSE
                //
                //
                // SLUT
                for (int i = 0; i < 500; i++)
                {
                    _calculatePusleList.RemoveAt(i);
                }
            }
        }

        public void calculateMeanBloodPreassure(List<double> mmHgValues)
        {
            _calculateMeanBloodPreassureList.AddRange(mmHgValues);
            if (_calculateMeanBloodPreassureList.Count >5000)
            {
                meanBloodPreassure =_calculateMeanBloodPreassureList.Average();
                for (int i = 0; i < 500; i++)
                {
                    _calculateMeanBloodPreassureList.RemoveAt(i);
                }
            }
        }

        public void getObserverState()
        {
            _dataReadResetEvent.Set();
        }

        public int getMeanBloodPreassure()
        {
            return Convert.ToInt32(Math.Round(meanBloodPreassure));
        }
    }
}
