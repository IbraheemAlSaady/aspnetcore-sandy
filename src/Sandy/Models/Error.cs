using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandy.Models
{
    internal class Error
    {
        public string Msg { get; set; }
        public string Stack { get; set; }
        public string Code { get; set; }
    }
}
