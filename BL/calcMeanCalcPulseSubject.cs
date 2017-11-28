using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BL
{
    public class calcMeanCalcPulseSubject
    {
        private List<IPulseMeanBPObserver> _observers = new List<IPulseMeanBPObserver>();

        public void Attach(IPulseMeanBPObserver IPO)
        {
            _observers.Add(IPO);
        }

        public void Detach(IPulseMeanBPObserver IPO)
        {
            _observers.Remove(IPO);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.updatePulseMeanBP();
            }
        }
    }
}
