using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alarm
    {
        private bool enabled;
        private int HighValue;
        private int LowValue;
        private int _currentSys;
        private int _currentDia;

        public Alarm(int sysHighValue, int diaLowValue)
        {
            HighValue = sysHighValue;
            LowValue = diaLowValue;
            enabled = false;
        }
        public Alarm()
        {
            HighValue = 180;
            LowValue = 60;
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

        public void setHighValue(int sysHigh)
        {
            HighValue = sysHigh;
        }

        public void setLowValue(int diaLow)
        {
            LowValue = diaLow;
        }

        public void setCurrentSys(int Sys)
        {
            _currentSys = Sys;
        }

        public void setCurrentDia(int Dia)
        {
            _currentDia = Dia;
        }
        public void CheckAlarmValues()
        {
            while (enabled)
            {
                if (_currentSys > HighValue)
                    Console.Beep(500,200);
                if (_currentDia < LowValue)
                    Console.Beep(2000,200);
            }
           
        }

    }
}
