using System.Net;

namespace UnknownScheduler.Jobs.Settings
{
    public interface IWebRequestSettings
    {
        string GetUrl();
        string GetData();

        string getMethod();
        string getContentType();


    }
}
