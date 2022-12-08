using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.console.Commands
{
    public class exitCommand : ShellCommand
    {
        public exitCommand(string command, string parameter) : base(command, parameter)
        {
        }

        public override void Execute()
        {
            Program.shell.Exit(); 
        }
    }
}
