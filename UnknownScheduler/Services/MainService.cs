using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using UnknownScheduler.Core;
using UnknownScheduler.Services.Settings;

namespace UnknownScheduler.Services
{
    public abstract class MainService : IMultipleServiceItem
    {

        protected  string LoggerLogName = "";
        protected  string LoggerSource = "";
        protected  string ServiceName = "";

        protected  string ServiceNameForLogger = "";
  
        protected EventLog EventLogger;


        protected MainService(IMainServiceSettings serviceSettingsObj)
        {
            _setMainSettings(serviceSettingsObj);

            InitializeComponent();
             
            if (! EventLog.SourceExists(LoggerSource))
                EventLog.CreateEventSource(LoggerSource, LoggerLogName);

            EventLogger.Source = LoggerSource;
            EventLogger.Log = LoggerLogName;
        }

        private void _setMainSettings(IMainServiceSettings serviceSettings)
        {
            LoggerLogName = serviceSettings.GetLoggerLogName();
            LoggerSource = serviceSettings.GetLoggerSource();
            ServiceName = serviceSettings.GetServiceName();
            ServiceNameForLogger = serviceSettings.GetServiceNameForLogger();
 
        }

        private void InitializeComponent()
        {
            EventLogger = new EventLog();
            ((ISupportInitialize) (EventLogger)).BeginInit();
             
            ((ISupportInitialize) (EventLogger)).EndInit();
        }

        public virtual void OnStart(string[] args)
        { 
            EventLogger.WriteEntry( ServiceNameForLogger + " is started at " + DateTime.UtcNow.ToString(new CultureInfo("en"))); 
        }

        public virtual void OnStop()
        {
            EventLogger.WriteEntry(ServiceNameForLogger + " is stoped at " + DateTime.UtcNow.ToString(new CultureInfo("en")));  
        }
    }
}