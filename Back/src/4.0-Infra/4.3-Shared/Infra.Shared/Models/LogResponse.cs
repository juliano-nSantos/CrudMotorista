using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Shared.Models.Base;

namespace Infra.Shared.Models
{
    public class LogResponse : LogBase
    {
        public object Response { get; set; }
    }
}