using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Shared.WriteLogs.Interface
{
    public interface IWriteLogCollections
    {
        void WriteRequest(string json);
        void WriteResponse(string json);
        void WriteError(string json);
    }
}