using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace BL
{
    class RawToFineSubject

    {
    private List<IRawToFineObserver> _observers = new List<IRawToFineObserver>();

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
        {
            observer.updateGraph();
        }
    }
    }
}
