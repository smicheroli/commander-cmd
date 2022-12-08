using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.console
{
    public class Parser
    {

        public String GetCommand(String input)
        {
            String command = input.Split(' ').First();
            return command;
        }

        public String GetParameter(String input)
        {
            int commandEnd = input.IndexOf(' ');

            String parameters = input.Substring(commandEnd).Trim();

            return parameters;
        }

    }
}
