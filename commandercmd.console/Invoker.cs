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

        public IList<Drive> Drives { get; set; }
        public Parser parser { get; set; }
        private CommandFactory commandFactory = new CommandFactory();
        private PersistenceService persistence = new PersistenceService("fileSystem.json");

        public Invoker()
        {
            this.parser =  new Parser();

            Drives = persistence.Load();
        }

        public void ExecuteCommand(string input)
        {
            String command = parser.GetCommand(input);
            String parameter = parser.GetParameter(input);

            ShellCommand executableCommand = commandFactory.GetCommand(command,parameter);

            executableCommand.Execute();

            persistence.Save(Drives);
        }
    }
}
