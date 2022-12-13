using commandercmd.console;
using commandercmd.console.Commands;

namespace commandercmd.Tests
{
    [TestClass]
    public class versionTest
    {
        [TestMethod]
        public void GiveBasicCommand_GetCommandOnlyBackAsString()
        {
            // Arrange
            var command = new versionCommand("ver", "");

            // Capture the output written to the Console
            var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            command.Execute();

            // Assert
            var ver = System.Environment.OSVersion.ToString();
            Assert.AreEqual("Version: " + ver, writer.ToString().Trim());

        }
    }
}