using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTypes
{
    public class CommandResult 
    {
        public object Result { get; set; }

        public Type CommandType { get; set; }

        public CommandResult(object result, Type command)
        {
            Result = result;

            CommandType = command;
        }
    }
}
