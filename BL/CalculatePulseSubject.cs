using System.Collections.Generic;
using Interfaces;

namespace BL
{
    public class CalculatePulseSubject
    {
        private readonly List<IPulseObserver> _observers = new List<IPulseObserver>();

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
                observer.updatePulse();
        }
    }
}