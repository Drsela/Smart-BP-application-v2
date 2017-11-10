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
        private double _slope;
        public double Slope {
            get => _slope;
            set => _slope = value;
        }
        
        private double _intercept;
        public double Intercept
        {
            get => _intercept;
            set => _intercept = value;
        }


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
