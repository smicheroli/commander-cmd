using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.console.Commands
{
    public class setColorCommand : ShellCommand
    {
        public setColorCommand(string command, string parameter) : base(command, parameter)
        {
        }
        public override void Execute()
        {
            string setcolor = this.Parameter;
            Console.WriteLine(setcolor);
            // Check if the user provided two colors as arguments
            if (setcolor.Length == 2)
            {
                string bcolorstring = setcolor.Substring(0, 1);
                string tcolorstring = setcolor.Substring(1, 1);
                // Try to parse the first argument as a ConsoleColor for the background coloryyy
                ConsoleColor backgroundColor = ConsoleColor.Black;
                if (Enum.TryParse(bcolorstring, out ConsoleColor parsedBackgroundColor))
                {
                    backgroundColor = parsedBackgroundColor;
                }

                // Try to parse the second argument as a ConsoleColor for the text color
                ConsoleColor textColor = ConsoleColor.White;
                if (Enum.TryParse(tcolorstring, out ConsoleColor parsedTextColor))
                {
                    textColor = parsedTextColor;
                }

                // Set the background and text colors of the console
                Console.BackgroundColor = backgroundColor;
                Console.ForegroundColor = textColor;

                // Print a message to the console to confirm the colors have been set
                Console.WriteLine("The background color has been set to " + backgroundColor + " and the text color has been set to " + textColor + ".");
            }
            else
            {
                // Print an error message if the user did not provide two colors as arguments
                Console.WriteLine("Please provide two colors as arguments, for example: color fa");
            }
        }
    }
}

