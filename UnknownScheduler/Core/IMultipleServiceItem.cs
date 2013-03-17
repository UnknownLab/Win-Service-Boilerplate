namespace UnknownScheduler.Core
{
    public interface IMultipleServiceItem
    {
        void OnStart(string[] args);
        void OnStop();
    }
}
