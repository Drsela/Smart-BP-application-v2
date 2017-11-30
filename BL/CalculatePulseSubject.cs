using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BL
{
    public class CalculatePulseSubject
    {
        private List<IPulseObserver> _observers = new List<IPulseObserver>();

        public void Attach(IPulseObserver IPO)
        {
            _observers.Add(IPO);
        }

        public void Detach(IPulseObserver IPO)
        {
            _observers.Remove(IPO);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.updatePulse();
            }
        }
    }
}
