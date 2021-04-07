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

            Console.WriteLine($"Hello Command: {parameters.GetType()}");

            return new CommandResult($"Hello from server!", typeof(HelloCommand));
        }
    }
}
