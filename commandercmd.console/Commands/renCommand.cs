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
            
            Console.WriteLine("Hoi Stephhhhhhh");
            Console.WriteLine(this.Parameter);
            String startpath = this.Parameter;
            String[] endpath = startpath.Split(' ');

            File.Move(endpath[0], endpath[1]);

            //Console.WriteLine(endpath[0], endpath[1]);

            //if(this.Parameter!= null)
            //{
             //   Program.shell.Exit();
            //}
            


            
        }
    }
}
