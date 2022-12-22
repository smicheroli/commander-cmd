﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.console.Commands
{
    public class versionCommand : ShellCommand
    {
        public versionCommand(string command, string parameter) : base(command, parameter)
        {
        }

        public override void Execute()
        {
            string ver = System.Environment.OSVersion.ToString();
            Console.WriteLine("Version: " + ver);
        }
    }
}
