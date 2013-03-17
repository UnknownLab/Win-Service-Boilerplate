using System;
using System.Diagnostics;
using System.Globalization;

namespace UnknownScheduler.Jobs.Core
{
    public abstract class JobWithLogger : Job
    {
        protected EventLog Logger;

        protected JobWithLogger(EventLog logger)
        {
            Logger = logger;
        }
         
        public void WriteLog(string log , int? id)
        {
            var time = DateTime.UtcNow.ToString(new CultureInfo("en"));
            Logger.WriteEntry("(id" + id + ") at " + time + " ... " + log);
        }

        public void WriteFailLog(string log, int? id, Exception ex)
        {
            var time = DateTime.UtcNow.ToString(new CultureInfo("en"));
            var resultLog = "(id" + id + ") at " + time + " ... " + log + " .System Message - " + ex.Message + " .Stack Trace - " + ex.StackTrace;
            Logger.WriteEntry(resultLog);
        }

        public string DateToLog(DateTime date)
        {
            return date.ToString(CultureInfo.InvariantCulture);
        }

        public int _getId()
        {
            Random rnd = new Random();
            return rnd.Next(1, 1364654656);
        }
         
    }
}