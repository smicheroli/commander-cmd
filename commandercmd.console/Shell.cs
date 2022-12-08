namespace commandercmd.console
{
    public class Shell
    {

        private bool exited = false;

        public Invoker invoker { get; set; }

        public Shell()
        {
            invoker = new Invoker();
        }

        public void Run()
        {
            while (!exited)
            {

            }
        }
        public void Exit()
        {
            exited = true;
        }
        private void ReadInput()
        {

        }
        private void ValidateInput()
        {

        }
        private void Process()
        {

        }
        private void WriteOutput()
        {

        }
    }
}
