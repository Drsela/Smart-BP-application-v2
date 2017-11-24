using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BL
{
    public class SystolicSubject
    {
        private List<ISystolicObserver> _observers = new List<ISystolicObserver>();

        public void Attach(ISystolicObserver IPO)
        {
            _observers.Add(IPO);
        }

        public void Detach(ISystolicObserver IPO)
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
