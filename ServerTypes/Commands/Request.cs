using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTypes
{
    public class Request
    {
        public object Parameters { get; set; }

        public Type CommandType { get; set; }

        public Request(object parameters, Type command)
        {
            Parameters = parameters;

            CommandType = command;
        }
    }
}
