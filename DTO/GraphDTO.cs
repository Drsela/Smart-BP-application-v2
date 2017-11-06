using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class GraphDTO
    {
        private double _currentValue;

        public GraphDTO()
        {
            
        }

        public double GetCurrentValue()
        {
            return _currentValue;
        }

        public void SetCurrentValue(double value)
        {
            _currentValue = value;   
        }
    }
}
