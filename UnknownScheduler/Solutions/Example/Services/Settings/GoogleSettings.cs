namespace UnknownScheduler.Solutions.Example.Services.Settings
{
    public class GoogleSettings : TimerServiceSettings
    {
        public override int GetTimeout()
        {
            return 84600000; //24 hrs 
        }

        public override  string GetServiceName()
        {
            return "GoogleService";
        }

        public override string GetServiceNameForLogger()
        {
            return "Google Service ";
        }
    }
}