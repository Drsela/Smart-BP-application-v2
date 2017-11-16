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
        private List<iPatentConsumerObserver> _observers = new List<iPatentConsumerObserver>();

        public void Attach(iPatentConsumerObserver IPO)
        {
            _observers.Add(IPO);
        }

        public void Detach(iPatentConsumerObserver IPO)
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
