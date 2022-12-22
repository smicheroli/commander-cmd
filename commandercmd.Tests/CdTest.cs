using commandercmd.console.Commands;

namespace commandercmd.Tests
{
    [TestClass]
    public class CdTest
    {
        [TestMethod]
        public void GivenRelativePathTwoPoints_ExecutingCd_PathShouldbeShorter()
        {
            String startDirectory = Environment.CurrentDirectory;
            cdCommand cdCommand = new cdCommand("cd","..");
            String expectedDirectory = Path.GetFullPath("..");

            cdCommand.Execute();

            Assert.AreEqual(expectedDirectory,Environment.CurrentDirectory);
        }

        [TestMethod]
        public void GivenFullPath_ExecutingCd_PathShouldbeEqual()
        {
            String wantedDirectory = @"C:\Windows";
            cdCommand cdCommand = new cdCommand("cd", wantedDirectory);

            cdCommand.Execute();

            Assert.AreEqual(wantedDirectory, Environment.CurrentDirectory);
        }
    }
}