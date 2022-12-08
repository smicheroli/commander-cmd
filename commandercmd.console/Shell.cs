using System.Xml.Serialization;

namespace commandercmd.console
{
    public class Shell
    {

        private bool exited = false;

        public Invoker invoker { get; set; }

        public String currentDirectory { get; set; }

        public Shell()
        {
            invoker = new Invoker();
            currentDirectory = Environment.CurrentDirectory;
        }

        public void Run()
        {
            while (!exited)
            {
                String input = ReadInput();

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
                }
            }
            return false;
        }

        private void Process(String input)
        {
            invoker.ExecuteCommand(input);
        }
    }
}
