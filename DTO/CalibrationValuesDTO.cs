using System.Collections.Generic;

namespace DTO
{
    public class CalibrationValuesDTO
    {
        private readonly List<double> _calibrationValues;


        public CalibrationValuesDTO()
        {
            _calibrationValues = new List<double>();
        }

        public double Slope { get; set; }

        public int ID { get; set; }

        public double Intercept { get; set; }


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