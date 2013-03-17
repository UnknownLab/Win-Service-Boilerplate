using System;
using UnknownScheduler.Jobs;
using UnknownScheduler.Services;
using UnknownScheduler.Services.Settings;
using UnknownScheduler.Solutions.Example.Jobs.Settings;

namespace UnknownScheduler.Solutions.Example.Services
{
    internal class Google : TimerService
    {
        public Google(ITimerServiceSettings settingsObj) : base(settingsObj)
        {
        }

        public override void OnStart(string[] args)
        {
            base.OnStart(args);
            _call();
        }

        private void _call()
        {
            try
            {
                var webRequestSettings = new GithubWebRequest();

                var job = new WebRequest(EventLogger, webRequestSettings);

                StateTimer.Elapsed += job.Action;

                StateTimer.Interval = TimeOut;

                StateTimer.Enabled = true;

                //First call on start
                job.Action(null, null);
            }
            catch (Exception e)
            {
                EventLogger.WriteEntry("GoogleService error: " + " .StackTrace: " + e.StackTrace);
            }
        }

        public override void OnStop()
        {
            base.OnStop();

            StateTimer.Dispose();
        }
    }
}