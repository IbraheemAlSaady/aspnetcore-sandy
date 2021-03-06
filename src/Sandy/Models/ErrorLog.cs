﻿using Sandy.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandy.Models
{
    internal class ErrorLog : LogBase
    {
        internal ErrorLog()
        {
            Id = System.Guid.NewGuid().ToString();
            Type = LogType.Error.ToString();
            Req = new RequestInfo();
            Error = new Error();
        }
        public Error Error { get; set; }
    }
}
