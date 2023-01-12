using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.console.Commands
{
    public class renCommand : ShellCommand
    {
        public renCommand(string command, string parameter) : base(command, parameter)
        {
           
        }

        public override void Execute()
        {
            Console.WriteLine(this.Parameter);
            String startpath = this.Parameter;
            String[] endpath = startpath.Split(' ');

            if (Program.shell.GetDrive(endpath[0]).ExistsFile(endpath[0]) && !Program.shell.GetDrive(endpath[1]).ExistsFile(endpath[1]))
            {
                Program.shell.GetDrive(endpath[0]).MoveItem(endpath[0], endpath[1]);
                Console.Write("Ihre Datei wurde umbennant");
            }

            else
            {
                Console.WriteLine(" Ihre Datei gibt es bereits haha");
            }
        }
        
    }
}
