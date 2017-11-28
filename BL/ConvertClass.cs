using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Interfaces;

namespace BL
{
    public class ConvertClass
    {
        private iDataAccessLogic _dataAccessLogic;
        private List<double> mmHgList;
        private CalibrationValuesDTO _calibrationDTO;
        private double slope;
        private double intercept;
        private double _zeroPointValue;

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
            for (int i = 0; i < mvValues.Count; i++)
            {
                if (intercept > 0)
                {
                    mmHgList.Add(mvValues[i] * slope - intercept + _zeroPointValue);
                }

                if (intercept < 0)
                {
                    mmHgList.Add(mvValues[i] * slope + intercept + _zeroPointValue);
                }
            }
            return mmHgList;
        }

        public void setZeroPointValue(double zp)
        {
            _zeroPointValue = zp;
        }
    }
}
