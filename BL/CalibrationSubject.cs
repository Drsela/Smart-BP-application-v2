using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BL
{
    class CalibrationSubject
    {
        private readonly List<ICalibrateValueUpdater> _observers = new List<ICalibrateValueUpdater>();

        public void Attach(ICalibrateValueUpdater IPO)
        {
            _observers.Add(IPO);
        }

        public void Detach(ICalibrateValueUpdater IPO)
        {
            _observers.Remove(IPO);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
                observer.updateCBValue();
        }
    }
}
