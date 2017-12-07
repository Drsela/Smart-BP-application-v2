using System.Collections.Generic;
using Interfaces;

namespace BL
{
    internal class RawToFineSubject

    {
        private readonly List<IRawToFineObserver> _observers = new List<IRawToFineObserver>();

        public void Attach(IRawToFineObserver IPO)
        {
            _observers.Add(IPO);
        }

        public void Detach(IRawToFineObserver IPO)
        {
            _observers.Remove(IPO);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
                observer.updateGraph();
        }
    }
}