using System;
using commandercmd.console.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace commandercmd.Tests
{
    [TestClass]
    public class setcolorTest
    {

        [TestMethod]
        public void TestInvalidColor()
        {
            // Arrange
            string setcolor = "INVALID_COLOR";
            colorCommand command = new colorCommand("color", setcolor);
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            command.Execute();

            // Assert
            Assert.AreEqual(writer.ToString().Trim(),"Invalid color");
        }
    }
}