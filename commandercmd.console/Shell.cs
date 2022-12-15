﻿using commandercmd.FileSystem;
using System.Xml.Serialization;

namespace commandercmd.console
{
    public class Shell
    {

        private bool exited = false;

        public Invoker invoker { get; set; }

        public String currentDirectory { get { return Environment.CurrentDirectory; } }

        private PersistenceService persistence;
        public IList<Drive> Drives { get; set; }

        public Shell()
        {
            persistence = new PersistenceService(@$"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}\filesystem.json");
            Drives = persistence.Load();
            invoker = new Invoker();
        }

        public void Run()
        {
            while (!exited)
            {
                String input = ReadInput().Trim();

                if(ValidateInput(input))
                {
                    Process(input);
                }

            }
        }
        public void Exit()
        {
            exited = true;
        }
        private String ReadInput()
        {
            Console.Write(currentDirectory + ">");
            return Console.ReadLine();
        }
        private bool ValidateInput(String input)
        {
            String command = input.Split(' ').First();
            if(command != null)
            {
                switch (command)
                {
                    case "exit":

                        return true;
                    case "cls":

                        return true;
                    case "ver":

                        return true;
                    case "ren":

                        return true;
                    case "color":

                        return true;
                    case "test":

                        return true;
                    case "prompt":

                        return true;
                    case "cd":

                        return true;
                    case "cd..":

                        return true;
                }
            }
            return false;
        }

        private void Process(String input)
        {
            invoker.ExecuteCommand(input);
            persistence.Save(Drives);
        }

        public Drive GetDrive(String path)
        {
            if (path.Length >= 3)
            {
                return Drives.Where(x => x.DriveLetter == path[0]).First();
            }
            return null;
        }
    }
}
