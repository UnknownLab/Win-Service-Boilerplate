using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Timers;
using UnknownScheduler.Jobs.Core;
using UnknownScheduler.Jobs.Settings;

namespace UnknownScheduler.Jobs
{
    public class WebRequest : JobWithLogger
    {
        protected string ContentType = "";
        protected string Data = null;
        protected string Method = "";
        protected string Url = "";

        public WebRequest(EventLog logger, IWebRequestSettings settings) : base(logger)
        {
            _setSettings(settings);
        }

        private void _setSettings(IWebRequestSettings settings)
        {
            Url = settings.GetUrl();
            Data = settings.GetData();
            Method = settings.getMethod();
            ContentType = settings.getContentType();
        }

        public override void Action(object state, ElapsedEventArgs elapsedEventArgs)
        {
            int actionId = _getId();

            WriteLog("Started http request: " + Url, actionId);
            var request = (HttpWebRequest) System.Net.WebRequest.Create(Url);

            request.Method = Method;
            request.ContentType = ContentType;

            if (_itsWithContent())
            {
                request.ContentLength = Data.Length; 
                var requestWriter = new StreamWriter(request.GetRequestStream()); 
                requestWriter.Write(Data); 
                requestWriter.Close();
            }

            try
            {
                var webResponse = request.GetResponse();
                var webStream = webResponse.GetResponseStream();
                var responseReader = new StreamReader(webStream);
                var response = responseReader.ReadToEnd();
                responseReader.Close();
                WriteLog("Http request completed: " + Url, actionId);
                
            }
            catch (Exception ex)
            {
                WriteFailLog("Http request faild: " + Url + "", actionId, ex);
            }
        }

        private bool _itsWithContent()
        {
            return Method != "GET";
        }
    }
}