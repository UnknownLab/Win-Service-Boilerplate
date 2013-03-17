using System.ServiceProcess;
using UnknownScheduler.Core;
using UnknownScheduler.Solutions.Example.Services;
using UnknownScheduler.Solutions.Example.Services.Settings;

namespace UnknownScheduler.Solutions.Example
{
    public class ServiceRunner : IServiceRunner
    {
        public void Run()
        {
            IMultipleServiceItem[] servicesToRun = GetServices();
            var multiService = new MultipleService(servicesToRun);
            ServiceBase.Run(multiService);
        }

        public IMultipleServiceItem[] GetServices()
        {
            var googleSettings = new GoogleSettings();
            var githubSettings = new GithubSettings();

            var servicesToRun = new IMultipleServiceItem[]
                {
                    new Github(githubSettings),
                    new Google(googleSettings)
                };

            return servicesToRun;
        }
    }
}