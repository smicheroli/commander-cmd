using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace commandercmd.console.Commands
{
    public class colorCommand : ShellCommand
    {
        public colorCommand(string command, string parameter) : base(command, parameter)
        {
        }
        public override void Execute()
        {
            string setcolor = this.Parameter;
            Console.WriteLine(setcolor);

            //Split the color into 2 seperate words
            string[] splitcolors = setcolor.Split(" ");

            //Converting the Words to Uppercase
            string foregroundcolors = splitcolors[0].ToUpper();
            string backgroundcolors = splitcolors[1].ToUpper();

            switch (foregroundcolors)
            {
                case "BLAU":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "GELB":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "GRÜN":
                case "GRUEN":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "ROT":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "TÜRKIS":
                case "TUERKIS":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case "LILA":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case "HELLGRAU":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case "GRAU":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case "HELLBLAU":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "HELLGRÜN":
                case "HELLGRUEN":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "HELLTÜRKIS":
                case "HELLTUERKIS":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "HELLROT":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "HELLLILA":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "HELLGELB":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "WEISS":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "SCHWARZ":
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                default:
                    Console.WriteLine("Invalid color");
                    break;
            }

            switch (backgroundcolors)
            {
                case "BLAU":
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;
                case "GELB":
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    break;
                case "GRÜN":
                case "GRUEN":
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    break;
                case "ROT":
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                case "TÜRKIS":
                case "TUERKIS":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    break;
                case "LILA":
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    break;
                case "HELLGRAU":
                    Console.BackgroundColor = ConsoleColor.Gray;
                    break;
                case "GRAU":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case "HELLBLAU":
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case "HELLGRÜN":
                case "HELLGRUEN":
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case "HELLTÜRKIS":
                case "HELLTUERKIS":
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;
                case "HELLROT":
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case "HELLLILA":
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    break;
                case "HELLGELB":
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                case "WEISS":
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                case "SCHWARZ":
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
            }
            Console.WriteLine("The text color has been changed to " + foregroundcolors + "and the background color has been changed to" + backgroundcolors);
            Array.Clear(splitcolors);
        }
    }
}

