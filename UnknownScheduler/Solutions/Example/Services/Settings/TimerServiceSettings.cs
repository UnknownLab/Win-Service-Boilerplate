using UnknownScheduler.Services.Settings;

namespace UnknownScheduler.Solutions.Example.Services.Settings
{
    public abstract class TimerServiceSettings : ITimerServiceSettings 
    {
        public string GetLoggerLogName()
        {
            return "ExampleServiceLog";
        }

        public string GetLoggerSource()
        {
            return "ExampleServiceLogSourse";
        }

        public abstract string GetServiceName();
        public abstract string GetServiceNameForLogger();


        public abstract int GetTimeout();

    }
}
