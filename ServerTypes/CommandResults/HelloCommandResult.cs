using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTypes
{
    class HelloCommandResult : ICommandResult
    {
        public object Result { get; set; }
        public Type CommandType { get => typeof(HelloCommand); }

        public HelloCommandResult(object result)
        {
            Result = result;
        }
    }
}
