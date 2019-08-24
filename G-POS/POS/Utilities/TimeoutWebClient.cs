using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace G_POS.POS.Utilities
{
    public class TimeoutWebClient : WebClient
    {
        public TimeSpan Timeout { get; set; }

        public TimeoutWebClient(TimeSpan timeout)
        {
            Timeout = timeout;
        }

        protected override WebRequest GetWebRequest(Uri uri)
        {
            var request = base.GetWebRequest(uri);
            if (request == null)
            {
                return null;
            }

            var timeoutInMilliseconds = (int) Timeout.TotalMilliseconds;

            request.Timeout = timeoutInMilliseconds;
            if (request is HttpWebRequest)
            {
                //httpWebRequest.ReadWriteTimeout = timeoutInMilliseconds;
            }

            return request;
        }
    }
}
