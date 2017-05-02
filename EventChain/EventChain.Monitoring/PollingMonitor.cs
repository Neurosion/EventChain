using System;
using System.Timers;
using System.Threading.Tasks;
using EventChain.Core;
using EventChain.Core.Extensions;

namespace EventChain.Monitoring
{
    public abstract class PollingMonitor : IMonitor
    {
        private readonly Timer _timer;
        private double _interval;

        public event Action<IEvent> NewEvent;

        public double Interval
        {
            get { return _interval; }
            set
            {
                if (_interval.Equals(value))
                    return;

                _interval = value;
                
                var isEnabled = _timer.Enabled;

                if (isEnabled)
                    Stop();

                _timer.Interval = _interval;

                if (isEnabled)
                    Start();
            }
        }

        public string Name { get; set; }

        public string Description { get; set; }

        protected abstract IEvent Update();

        protected PollingMonitor(string name)
        {
            Name = name.ThrowIfNullOrWhiteSpace(nameof(name));

            Interval = Constants.DefaultPollingInterval;

            _timer = new Timer(Interval);
            _timer.Elapsed += (s, e) => HandleTimerElapsed();
        }

        public void Start()
        {
            if (_timer.Enabled)
                return;

            _timer.Enabled = true;
            Task.Run(() => HandleTimerElapsed());
        }

        public void Stop()
        {
            _timer.Enabled = false;
        }

        private void HandleTimerElapsed()
        {
            if (NewEvent == null)
                return;

            try
            {
                var result = Update();
                NewEvent(result);
            }
            catch(Exception ex)
            {
                NewEvent(new MonitorFailureEvent(this, ex));
            }
        }
    }
}