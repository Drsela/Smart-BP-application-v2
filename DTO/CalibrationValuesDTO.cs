using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CalibrationValuesDTO
    {
        private List<double> _calibrationValues;

        public CalibrationValuesDTO()
        {
            _calibrationValues = new List<double>();
        }

        public void addValue(double value)
        {
            _calibrationValues.Add(value);
        }

        public List<double> getValues()
        {
            return _calibrationValues;
        }

        public double getSingleValue(int value)
        {
            return _calibrationValues[value];
        }
    }
}
