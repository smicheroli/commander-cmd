﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.console.Commands
{
    public class clsCommand : ShellCommand
    {
        public clsCommand(string command, string parameter) : base(command, parameter)
        {
        }

        public override void Execute()
        {
            //delete all previous actions in the terminal - clear terminal
            Console.Clear();
        }
    }
}
