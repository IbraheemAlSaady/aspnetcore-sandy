using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandy.Models
{
    public class JsonLoggerOptions
    {
        public string AppName { get; set; }
        public string InfoFilePath { get; set; }
        public string ErrorFilePath { get; set; }
        public string DebugFilePath { get; set; }
        public string WarningFilePath { get; set; }
        public string FatalFilePath { get; set; }
    }
}
