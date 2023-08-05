using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Result
{
    class OperationResult : IResult
    {
        public OperationResult(bool success, string message) : this(success)
        {
            Message = message;

        }

        public OperationResult(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
