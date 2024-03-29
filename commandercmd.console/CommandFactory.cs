﻿using commandercmd.console.Commands;
using commandercmd.console.Commands.prompt;
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
                    command = new clsCommand(commandName, parameter);

                    break;
                case "color":
                    command = new colorCommand(commandName, parameter);

                    break;
                case "ren":
                    command = new renCommand(commandName, parameter);

                    break;
                case "ver":
                    command = new versionCommand(commandName, parameter);

                    break;
                case "prompt":
                    command = new prompt(commandName, parameter);

                    break;
                case "cd":
                    command = new cdCommand(commandName, parameter);

                    break;
                case "cd..":
                    command = new cdCommand(commandName, "..");

                    break;
                case "del":
                    command = new delCommand(commandName, parameter);

                    break;
            }


            return command;
        }
    }
}
