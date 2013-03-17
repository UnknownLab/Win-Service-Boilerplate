namespace UnknownScheduler.Services.Settings
{
    public interface IMainServiceSettings
    {
        string GetLoggerLogName();
        string GetLoggerSource();
        string GetServiceName();
        string GetServiceNameForLogger();
         
    }
}
