using System.Collections.Generic;
using Interfaces;

namespace BL
{
    public class CalculateBloodPreassureSubject
    {
        private readonly List<IBloodPressureObserver> _observers = new List<IBloodPressureObserver>();

        public void Attach(IBloodPressureObserver IPO)
        {
            _observers.Add(IPO);
        }

        public void Detach(IBloodPressureObserver IPO)
        {
            _observers.Remove(IPO);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
                observer.updateBloodPreassureValues();
        }
    }
}