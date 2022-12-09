using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Shared.Models.Base
{
    public abstract class LogBase
    {
        public Guid Id { get; set; }
        public DateTime LogDate { get; set; }
        public string Method { get; set; }
        public string SearchKey { get; set; }
    }
}