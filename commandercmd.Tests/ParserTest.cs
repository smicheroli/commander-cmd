using commandercmd.console;

namespace commandercmd.Tests
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void GiveBasicCommand_GetCommandOnlyBackAsString()
        {
            Parser parser = new Parser();
            String input = "test 43 /D";

            String command = parser.GetCommand(input);

            Assert.AreEqual(expected: "test", command);

            

        }
    }
}