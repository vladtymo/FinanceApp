using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTypes
{
    class HelloCommand : ICommand
    {
        public object Content { get; set; }

        public ICommandResult Execute()
        {
            return new HelloCommandResult("Hello from server!");
        }
    }
}
