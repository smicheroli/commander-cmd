using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.console.Commands.prompt
{
    public class prompt : ShellCommand
    {

        


        public prompt(string command, string parameter) : base(command, parameter)
        {
  
        }

        public override void Execute()
        {
            if (Parameter.Equals("")){
                Program.shell.prompt = Program.shell.currentDirectory + ">";
                Program.shell.promptChanged = false;
            }
            else
            {
                Program.shell.prompt = Parameter;
                Program.shell.promptChanged = true;
            }
        }
    }
}
