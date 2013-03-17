using UnknownScheduler.Jobs.Core;
using UnknownScheduler.Jobs.Settings;

namespace UnknownScheduler.Solutions.Example.Jobs.Settings
{
    class GithubWebRequest : IWebRequestSettings 
    {
        public string GetUrl()
        {
            return "http://github.com/";
        }

        public string GetData()
        {
            return null;
        }

        public string getMethod()
        {
            return WebRequestMethods.Get;
        }

        public string getContentType()
        {
            return "application/json";
        }
    }
}
