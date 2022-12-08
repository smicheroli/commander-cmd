using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.console.Commands
{
    public class cls : ShellCommand
    {
        public cls(string command, string parameter) : base(command, parameter)
        {
        }

        public override void Execute()
        {
            Console.Clear();
        }
    }
}
