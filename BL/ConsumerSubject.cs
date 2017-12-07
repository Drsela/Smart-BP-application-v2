using System.Collections.Generic;
using Interfaces;

namespace BL
{
    public class ConsumerSubject
    {
        //private List<iPatientConsumerObserver> _observers = new List<iPatientConsumerObserver>();
        private readonly List<IConsumerObserver> _observers = new List<IConsumerObserver>();

        public void Attach(IConsumerObserver IPO)
        {
            _observers.Add(IPO);
        }

        public void Detach(IConsumerObserver IPO)
        {
            _observers.Remove(IPO);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
                observer.getObserverState();
        }
    }
}