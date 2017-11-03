using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Datacontainer
    {
        public double _mv;
        public List<double> _MvList;

        public Datacontainer()
        {
            _MvList = new List<double>();
            //_MvList = mv;
        }

        public void setMVMeasurement(double mv)
        {
            _MvList.Add(mv);
        }
        public List<double> getMVMeasaurement()
        {
            return _MvList;
        }

    }
}
