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

            String path = Parameter;

            if(path == "")
            {
                Console.WriteLine(Program.shell.currentDirectory + "\n");
                //Program.shell.currentDirectory;
            }
            else if (path != null)
            {
                //check if path exists (absolute) 


                try
                {
                    if (Program.shell.GetDrive(path).ExistsDirectory(path))
                    {
                        Console.WriteLine("Du hast ins folgende Verzeichnis gewechselt: " + path);
                        Program.shell.currentDirectory = path;
                        if(Program.shell.prompt == "C:\\")
                        {
                            Program.shell.prompt = path;
                        }
                        
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Das Laufwerk konnte nicht gefunden werden");
                }

                //else check if relative?


                //..




            }
        }
    }
}
