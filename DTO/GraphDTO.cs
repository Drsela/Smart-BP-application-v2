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
        private List<double> list;

        public GraphDTO()
        {
            list = new List<double>();
        }

        public List<double> GetCurrentValue()
        {
            return list;
        }

        public void SetCurrentValue(List<double> values)
        {
            foreach (var item in values)
            {
                list.Add(item);
            }
        }
    }
}
