using commandercmd.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.console
{
    public class Invoker
    {

        public List<Drive> Drives { get; set; }
        public Parser parser { get; set; }
        private CommandFactory commandFactory = new CommandFactory();

        public Invoker()
        {
            this.parser =  new Parser();
        }

        public void ExecuteCommand(string input)
        {
            String command = parser.GetCommand(input);
            String parameter = parser.GetParameter(input);

            ShellCommand executableCommand = commandFactory.GetCommand(command,parameter);

            executableCommand.Execute();
        }
    }
}
