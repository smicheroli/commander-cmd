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

            {

            }

        }

        public override void Execute()

        {

            String currentDirectory = Program.shell.currentDirectory;
            Console.WriteLine("The current directory is" + currentDirectory);
            Console.ReadLine();

        }
    }
}
