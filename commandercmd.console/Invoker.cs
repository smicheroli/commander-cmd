using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.console
{
    public class Invoker
    {
        public Parser parser { get; set; }

        public Invoker()
        {
            this.parser =  new Parser();
        }

        public void ExecuteCommand(string input)
        {
            String command = parser.GetCommand(input);
        }
    }
}
