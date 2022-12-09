using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Shared.Models.Base;

namespace Infra.Shared.Models
{
    public class LogError : LogBase
    {
        public string ErrorMessage { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        
    }
}