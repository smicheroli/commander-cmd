using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.console.Commands
{
    public class cdCommand : ShellCommand
    {
        public cdCommand(string command, string parameter) : base(command, parameter)
        {
        }

        public override void Execute()
        {
            String selectedpath = Parameter;

            if(selectedpath != null && selectedpath.Length > 0)
            {
                Environment.CurrentDirectory = Path.GetFullPath(selectedpath);
            }
        }
    }
}
