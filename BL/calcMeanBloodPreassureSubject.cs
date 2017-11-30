using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BL
{
    public class calcMeanBloodPreassureSubject
    {
        private List<IMeanBPObserver> _observers = new List<IMeanBPObserver>();

        public void Attach(IMeanBPObserver IPO)
        {
            _observers.Add(IPO);
        }

        public void Detach(IMeanBPObserver IPO)
        {
            _observers.Remove(IPO);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.updateMeanBP();
            }
        }
    }
}
