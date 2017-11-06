using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlarmDTO
    {
        private bool enabled;
        private int _upperLimit;
        private int _lowerLimit;
        public AlarmDTO()
        {
            enabled = false;
        }

        public void startAlarm()
        {
            enabled = true;
        }

        public void stopAlarm()
        {
            enabled = false;
        }

        public void setUpperLimit(int upperLimit)
        {
            _upperLimit = upperLimit;
        }
        public void setLowerLimit(int lowerLimit)
        {
            _lowerLimit = lowerLimit;
        }
    }
}
