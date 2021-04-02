using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTypes
{
    public class Command
    {
        public object Parameters { get; set; }

        public Type CommandType { get; set; }

        public Command(object parameters, Type command)
        {
            Parameters = parameters;

            CommandType = command;
        }
    }
}
