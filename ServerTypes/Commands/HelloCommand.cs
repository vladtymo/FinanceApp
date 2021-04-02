using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTypes
{
    public class HelloCommand : ICommand
    {
        public CommandResult Execute(object parameters)
        {
            return new CommandResult($"Hello {parameters} from server!", typeof(HelloCommand));
        }
    }
}
