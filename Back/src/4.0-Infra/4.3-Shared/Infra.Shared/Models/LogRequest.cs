using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Shared.Models.Base;

namespace Infra.Shared.Models
{
    public class LogRequest : LogBase
    {
        public string Client { get; set; }
        public object Request { get; set; }
    }
}