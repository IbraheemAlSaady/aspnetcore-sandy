using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandy.Models
{
    internal abstract class LogBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public int LevelId { get; set; }
        public DateTime Time => DateTime.UtcNow;
        public RequestInfo Req { get; set; }
        public string HostName { get; set; }
    }
}
