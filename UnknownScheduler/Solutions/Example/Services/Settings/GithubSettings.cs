namespace UnknownScheduler.Solutions.Example.Services.Settings
{
    class GithubSettings : TimerServiceSettings
    {
        public override int GetTimeout()
        {
            return 84600000; //24 hrs 
        }

        public override string GetServiceName()
        {
            return "GithubService";
        }

        public override string GetServiceNameForLogger()
        {
            return "Github Service ";
        }
    }
}
