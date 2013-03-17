using System;
using UnknownScheduler.Jobs;
using UnknownScheduler.Services;
using UnknownScheduler.Services.Settings;
using UnknownScheduler.Solutions.Example.Jobs.Settings;

namespace UnknownScheduler.Solutions.Example.Services
{
    public class Github : TimerService
    {
        public Github(ITimerServiceSettings settingsObj) : base(settingsObj)
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

                job.Action(null, null);
            }
            catch (Exception e)
            {
                EventLogger.WriteEntry("GithubService error: " + " .StackTrace: " + e.StackTrace);
            }
        }

        public override void OnStop()
        {
            base.OnStop();

            StateTimer.Dispose();
        }
    }
}