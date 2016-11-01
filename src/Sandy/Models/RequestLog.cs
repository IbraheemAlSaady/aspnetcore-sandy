using Sandy.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandy.Models
{
    internal class RequestLog : LogBase
    {
        internal RequestLog()
        {
            Id = System.Guid.NewGuid().ToString();
            Type = LogType.Request.ToString();
            Req = new RequestInfo();
        }
    }
}
