using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TimerTask
{
    public class TimeIsOverEventArgs: EventArgs
    {
        public string Msg { get; set; } 
    }
    class Timer
    {
        private int _time;

        public int Time
        {
            get => _time;
            
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Time must be more then zero");
                }
                _time = value;
            }
        }

        public event EventHandler<TimeIsOverEventArgs> TimeIsOver = delegate
        { };
        private void OnTimeIsOver (TimeIsOverEventArgs eventArgs)
        {
            EventHandler<TimeIsOverEventArgs> temp = TimeIsOver;
            temp?.Invoke(this, eventArgs);
        }
        public void Start (string msg)
        {
            Thread.Sleep(1000 * Time);
            OnTimeIsOver(new TimeIsOverEventArgs() { Msg = msg});
        }

        
    }
}
