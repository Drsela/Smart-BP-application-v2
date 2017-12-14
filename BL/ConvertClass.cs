using System.Collections.Generic;
using DTO;
using Interfaces;

namespace BL
{
    public class ConvertClass
    {
        private readonly CalibrationValuesDTO _calibrationDTO;
        private readonly iDataAccessLogic _dataAccessLogic;
        private readonly double intercept;
        private readonly double slope;
        private double _zeroPointValue;
        private List<double> mmHgList;

        public ConvertClass(iDataAccessLogic dataAccessLogic)
        {
            _dataAccessLogic = dataAccessLogic;
            _calibrationDTO = _dataAccessLogic.getValues();
            slope = _calibrationDTO.Slope;
            intercept = _calibrationDTO.Intercept;
        }

        public List<double> Conversation(List<double> mvValues)
        {
            mmHgList = new List<double>();
            for (var i = 0; i < mvValues.Count; i++)
                mmHgList.Add(mvValues[i] * slope + intercept - (_zeroPointValue * slope));
            return mmHgList;
        }

        public void setZeroPointValue(double zp)
        {
            _zeroPointValue = zp;
        }

        public double GetZeroPointValue()
        {
            return _zeroPointValue;
        }
    }
}