using System.ServiceProcess;

namespace UnknownScheduler.Core
{
    public class MultipleService : ServiceBase
    {
        private readonly IMultipleServiceItem[] _servicesItem;

        public MultipleService(IMultipleServiceItem[] servicesItemToRun)
        {
            _servicesItem = servicesItemToRun;
        }
        protected override  void OnStart(string[] args)
        {
            foreach (var service in _servicesItem)
            {
                service.OnStart(args);
            }
        }

        protected override void OnStop()
        {
            foreach (var service in _servicesItem)
            {
                service.OnStop();
            }
        }
    }
}
