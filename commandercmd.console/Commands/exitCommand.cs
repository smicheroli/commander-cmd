using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.console.Commands
{
    public class testCommand : ShellCommand
    {
        public testCommand(string command, string parameter) : base(command, parameter)
        {
        }

        public override void Execute()
        {
            Console.WriteLine(this.Parameter);
        }
    }
}
