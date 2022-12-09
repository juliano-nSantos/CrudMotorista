using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Shared.Utils
{
    public static class Connections
    {
        public static string GetConnectionStringMongoDb()
        {
            return Constants.GetParameterById("ConnectionMongoDb");
        }
    }
}