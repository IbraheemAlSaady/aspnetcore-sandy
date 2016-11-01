using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandy.Models
{
    internal class RequestInfo
    {
        public RequestInfo()
        {
            Headers = new Dictionary<string, string>();
        }
        public string Method { get; set; }
        public string Url { get; set; }
        public string RemoteAddress { get; set; }
        public string RemotePort { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string Body { get; set; }
    }
}
