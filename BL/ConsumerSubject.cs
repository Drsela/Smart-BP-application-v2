using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BL
{
    public class ConsumerSubject
    {
        private List<iPatientConsumerObserver> _observers = new List<iPatientConsumerObserver>();

        public void Attach(iPatientConsumerObserver IPO)
        {
            _observers.Add(IPO);
        }

        public void Detach(iPatientConsumerObserver IPO)
        {
            _observers.Remove(IPO);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}
