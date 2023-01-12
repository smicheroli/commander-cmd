using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.console.Commands
{
    public class delCommand : ShellCommand
    {
        public delCommand(string command, string parameter) : base(command, parameter) { 
        }

        public override void Execute()
        {
             if ( Program.shell.GetDrive(Parameter) != null)
            {
                Program.shell.GetDrive(Parameter).DeleteItem(Parameter);
                Console.WriteLine("Sie haben erfolgreich ihr File / Ordner gelöscht");
            }
            
            
        }
    }
}
