using commandercmd.console.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.console
{
    public class CommandFactory
    {
        public ShellCommand GetCommand(string commandName, String parameter)
        {
            ShellCommand command = null;
            switch(commandName)
            {
                case "exit":
                    command = new exitCommand(commandName, parameter);

                    break;

                case "cls":
                    command = new cls(commandName, parameter);

                    break;
                case "color":
                    command = new setColorCommand(commandName, parameter);

                    break;
                case "ren":
                    command = new renCommand(commandName, parameter);

                    break;
                case "ver":
                    command = new CommandVersion(commandName, parameter);

                    break;
            }


            return command;
        }
    }
}
