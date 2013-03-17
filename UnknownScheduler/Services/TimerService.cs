using System.Timers;
using UnknownScheduler.Services.Settings;

namespace UnknownScheduler.Services
{
    public abstract class TimerService : MainService
    {
        protected Timer StateTimer = new Timer();
         
        protected int TimeOut = 84600000;//24 hrs

        protected TimerService(ITimerServiceSettings settingsObj)
            : base(settingsObj)
        {
            _setTimerSettings(settingsObj); 
        }

        private void _setTimerSettings(ITimerServiceSettings serviceSettings)
        {
            TimeOut = serviceSettings.GetTimeout();
        }
         

    }


}