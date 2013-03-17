using System.Timers;

namespace UnknownScheduler.Jobs.Core
{
    public abstract class Job
    {
        public abstract void Action(object state, ElapsedEventArgs elapsedEventArgs);
    }
}
