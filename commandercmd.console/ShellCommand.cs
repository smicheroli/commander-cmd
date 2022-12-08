using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.console
{
    public abstract class ShellCommand
    {
        public ShellCommand(string command, string parameter)
        {
            Command = command;
            Parameter = parameter;
        }

        /// <summary>
        /// Command der aufgerufen wird
        /// </summary>
        public String Command { get; set; }
        /// <summary>
        /// Parameter die eingegeben wurden
        /// </summary>
        public String Parameter { get; set; }

        public abstract void Execute();

    }
}
