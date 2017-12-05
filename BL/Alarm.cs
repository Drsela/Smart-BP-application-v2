using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL
{
    public class Alarm
    {
        private bool enabled;
        private int HighValue;
        private int LowValue;
        private int _currentSys;
        private int _currentDia;
        private Stopwatch _stopwatch;

        public Alarm(int sysHighValue, int diaLowValue)
        {
            HighValue = sysHighValue;
            LowValue = diaLowValue;
            enabled = true;
        }
        public Alarm()
        {
            HighValue = 180;
            LowValue = 60;
            enabled = true;
        }

        public void startAlarm()
        {
            while (enabled)
            {
                if (_currentSys != 0 && _currentSys > HighValue)
                    Console.Beep(500, 200);
                if (_currentDia != 0 && _currentDia < LowValue)
                    Console.Beep(2000, 200);
            }
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
            if (enabled)
            {
                if (_currentSys != 0 && _currentSys > HighValue)
                    Console.Beep(500, 200);
                if (_currentDia != 0 && _currentDia < LowValue)
                    Console.Beep(2000, 200);
            }
        }

        public void PauseAlarm()
        {
            if (enabled)
            {
                enabled = false;
                _stopwatch = Stopwatch.StartNew();
            }

            //_stopwatch.Start();
            //Thread alarmCheck = new Thread(AlarmThreadCheck) {IsBackground = true};
            //alarmCheck.Start();
        }

        public void checkAlarmState()
        {
            if (_stopwatch.Elapsed.Seconds >= 30 && enabled == false)
            {
                enabled = true;
                _stopwatch.Stop();
            }
        }
        public void AlarmThreadCheck()
        {
            while (_stopwatch.IsRunning)
            {
                if (_stopwatch.Elapsed.Seconds >= 10)
                {
                    _stopwatch.Stop();
                    enabled = true;
                    Thread checkThread = new Thread(CheckAlarmValues) { IsBackground = true };      //WTF
                    checkThread.Start();
                }
            }
        }

        public bool alarmStatus()
        {
            return enabled;
        }
    }
}
