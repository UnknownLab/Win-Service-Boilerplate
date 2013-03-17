namespace UnknownScheduler.Services.Settings
{
    public interface ITimerServiceSettings : IMainServiceSettings
    {
        int GetTimeout();
    }
}
