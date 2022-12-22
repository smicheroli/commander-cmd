using System;
using commandercmd.console.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace commandercmd.Tests
{
    [TestClass]
    public class setcolorTest
    {
        [TestMethod]
        public void TestValidBackgroundColor()
        {
            // Arrange
            ConsoleColor expectedColor = ConsoleColor.DarkRed;
            string setcolor = "Schwarz ROT";
            colorCommand command = new colorCommand("color", setcolor);

            // Act
            command.Execute();

            // Assert
            Assert.AreEqual(expectedColor, Console.BackgroundColor);
        }
        [TestMethod]
        public void TestValidForegroundColor()
        {
            // Arrange
            ConsoleColor expectedColor = ConsoleColor.DarkGreen;
            string setcolor = "GRUEN";
            colorCommand command = new colorCommand("color", setcolor);

            // Act
            command.Execute();

            // Assert
            Assert.AreEqual(expectedColor, Console.ForegroundColor);
        }

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