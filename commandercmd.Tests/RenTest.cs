using commandercmd.console.Commands;

namespace commandercmd.Tests
{
    [TestClass]
    public class RenTest
    {
        [TestMethod]
        public void GivenFileRenamed()
        {
            File.Delete(Path.GetTempPath() + @"\test2.test");
            File.WriteAllText(Path.GetTempPath() + @"\test.test", "Testdatei");
            var renCommand = new renCommand("ren", @$"{Path.GetTempPath() + @"\test.test"} {Path.GetTempPath() + @"\test2.test"}");

            renCommand.Execute();

            Assert.IsTrue(File.Exists(Path.GetTempPath() + @"\test2.test"));
        }

    }
}