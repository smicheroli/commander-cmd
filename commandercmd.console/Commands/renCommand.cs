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

            if (!File.Exists(endpath[0])){

                if (!File.Exists(endpath[0]) && !File.Exists(endpath[1]))
                {
                    Console.WriteLine(" Ihr Datei gibt es bereits haha");
                    Program.shell.Exit();
                }

                else
                {
                    File.Move(endpath[0], endpath[1]);
                    Console.Write("Ihre Datei wurde umbennant");

                }
            }
            else
            {
                Program.shell.Exit();
            }
        }

            

            

            

            
            


            
        
    }
}
