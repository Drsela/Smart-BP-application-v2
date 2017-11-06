using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Datacontainer
    {
        public double _mv;
        public List<double> _MvList;

        public Datacontainer()
        {
            _MvList = new List<double>();
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
