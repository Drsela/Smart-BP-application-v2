using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BL
{
    public class CalculateBloodPreassureSubject
    {
        private List<IBloodPressureObserver> _observers = new List<IBloodPressureObserver>();

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
            {
                observer.updateSystolicValue();
            }
        }
    }
}
