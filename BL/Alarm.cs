using System.Diagnostics;
using System.Media;

namespace BL
{
    public class Alarm
    {
        private readonly SoundPlayer alarmSound;
        private int _currentDia;
        private int _currentSys;
        private Stopwatch _stopwatch;
        private bool enabled;
        private int HighValue;
        private int LowValue;

        public Alarm(int sysHighValue, int diaLowValue) // Til Unit Test
        {
            HighValue = sysHighValue;
            LowValue = diaLowValue;
            alarmSound = new SoundPlayer(@"C:\Users\drsel\Documents\GitHub\Smart-BP-application-v2\mediumAlarm.wav");
            enabled = true;
        }

        public Alarm()
        {
            HighValue = 180;
            LowValue = 60;
            enabled = true;
            alarmSound = new SoundPlayer(@"C:\Users\drsel\Documents\GitHub\Smart-BP-application-v2\mediumAlarm.wav");
        }


        public void setHighValue(int sysHigh) //Grænseværdi 1
        {
            HighValue = sysHigh;
        }

        public void setLowValue(int diaLow) //Grænseværdi 2
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
                    alarmSound.PlayLooping();
                //Console.Beep(500, 200);
                if (_currentDia != 0 && _currentDia < LowValue)
                    alarmSound.PlayLooping();
                //Console.Beep(2000, 200);
            }
        }

        public void PauseAlarm()
        {
            if (enabled)
            {
                enabled = false;
                alarmSound.Stop();
                _stopwatch = Stopwatch.StartNew();
            }
        }

        public void checkAlarmState()
        {
            if (_stopwatch.Elapsed.Seconds >= 30 && enabled == false)
            {
                enabled = true;
                _stopwatch.Stop();
            }
        }

        public bool alarmStatus()
        {
            return enabled;
        }
    }
}