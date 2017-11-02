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

        public Datacontainer(List<double> mv)
        {
            _MvList = mv;
        }

        public void setMVMeasurement(double mv)
        {
            _mv = mv;
        }
        public List<double> getMVMeasaurement()
        {
            return _MvList;
        }

    }
}
